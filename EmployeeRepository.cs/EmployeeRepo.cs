using EmployeeRepository.cs;
using Microsoft.Data.SqlClient;
using PedroLib;
using System;
using System.Collections.Generic;

namespace PedroLib


{
    public class EmployeeRepo : IArbejder
    {
        private readonly string _connectionString;

        public EmployeeRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Medarbejdere> GetAllMedarbejdere()
        {
            var medarbejdere = new List<Medarbejdere>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                "SELECT MedarbejderId, Navn, TelefonNummer, Email FROM Medarbejdere ORDER BY MedarbejderId",
                connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medarbejdere.Add(LæsMedarbejder(reader));
                    }
                }
            }
            return medarbejdere;
        }
        public EmployeeRepo() : this(PedroForbindelse.HentConnectionString()) { }

        public Medarbejdere? GetMedarbejderById(int medarbejderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                "SELECT MedarbejderId, Navn, TelefonNummer, Email FROM Medarbejdere WHERE MedarbejderId = @Id",
                connection))
            {
                command.Parameters.AddWithValue("@Id", medarbejderId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return LæsMedarbejder(reader);
                    }
                }
            }
            return null;
        }

        public void CreateMedarbejder(Medarbejdere medarbejder)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                "INSERT INTO Medarbejdere (Navn, TelefonNummer, Email) OUTPUT INSERTED.MedarbejderId VALUES (@Navn, @Telefon, @Email)",
                connection))
            {
                command.Parameters.AddWithValue("@Navn", medarbejder.Navn);
                command.Parameters.AddWithValue("@Telefon", medarbejder.Telefon);
                command.Parameters.AddWithValue("@Email", medarbejder.Email);
                connection.Open();

                medarbejder.MedarbejderId = (int)command.ExecuteScalar();
            }
        }

        public bool UpdateMedarbejder(Medarbejdere medarbejder)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                "UPDATE Medarbejdere SET Navn = @Navn, TelefonNummer = @Telefon, Email = @Email WHERE MedarbejderId = @Id",
                connection))
            {
                command.Parameters.AddWithValue("@Navn", medarbejder.Navn);
                command.Parameters.AddWithValue("@Telefon", medarbejder.Telefon);
                command.Parameters.AddWithValue("@Email", medarbejder.Email);
                command.Parameters.AddWithValue("@Id", medarbejder.MedarbejderId);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveMedarbejder(int medarbejderId)
        {
            return DeleteMedarbejder(medarbejderId);
        }

        public bool DeleteMedarbejder(int medarbejderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("DELETE FROM Medarbejdere WHERE MedarbejderId = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", medarbejderId);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Kolonnerækkefølgen svarer til SELECT-sætningerne ovenfor
        private static Medarbejdere LæsMedarbejder(SqlDataReader reader)
        {
            return new Medarbejdere
            {
                MedarbejderId = reader.GetInt32(0),
                Navn = reader.GetString(1),
                Telefon = reader.GetString(2),
                Email = reader.GetString(3)
            };
        }
    }

    
}

