using EmployeeRepository.cs;
using PedroLib;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace PedroCantina
    {
        public class Program
        {
            static void Main(string[] args)
            {
            // Forbindelsen hentes fra User Secrets ("Pcstring") inde i PedroForbindelse
            IArbejder repository = new EmployeeRepo(PedroForbindelse.HentConnectionString());  

            Console.WriteLine("Pedros Cantina");
                Console.WriteLine("==============");

                bool kører = true;
                while (kører)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Vis alle medarbejdere");
                    Console.WriteLine("2. Find medarbejder");
                    Console.WriteLine("3. Opret medarbejder");
                    Console.WriteLine("4. Opdater medarbejder");
                    Console.WriteLine("5. Slet medarbejder");
                    Console.WriteLine("0. Afslut");
                    Console.Write("Vælg: ");

                    try
                    {
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    var alle = repository.GetAllMedarbejdere();
                                    if (alle.Count == 0)
                                    {
                                        Console.WriteLine("Ingen medarbejdere fundet.");
                                    }
                                    foreach (var m in alle)
                                    {
                                        Console.WriteLine(m);
                                    }
                                    break;
                                }

                            case "2":
                                {
                                    Console.Write("Id: ");
                                    int id = int.Parse(Console.ReadLine()!);
                                    var m = repository.GetMedarbejderById(id);
                                    Console.WriteLine(m != null ? m.ToString() : "Medarbejder ikke fundet.");
                                    break;
                                }

                            case "3":
                                {
                                    var ny = new Medarbejdere();
                                    Console.Write("Navn: ");
                                    ny.Navn = Console.ReadLine()!;
                                    Console.Write("Telefon: ");
                                    ny.Telefon = Console.ReadLine()!;
                                    repository.CreateMedarbejder(ny);
                                    Console.WriteLine("Oprettet: " + ny);
                                    break;
                                }

                            case "4":
                                {
                                    Console.Write("Id på medarbejder der skal opdateres: ");
                                    int id = int.Parse(Console.ReadLine()!);
                                    var m = repository.GetMedarbejderById(id);
                                    if (m == null)
                                    {
                                        Console.WriteLine("Medarbejder ikke fundet.");
                                        break;
                                    }
                                    Console.WriteLine("Nuværende: " + m);
                                    Console.Write("Nyt navn: ");
                                    m.Navn = Console.ReadLine()!;
                                    Console.Write("Ny telefon: ");
                                    m.Telefon = Console.ReadLine()!;
                                    repository.UpdateMedarbejder(m);
                                    Console.WriteLine("Opdateret: " + m);
                                    break;
                                }

                            case "5":
                                {
                                    Console.Write("Id på medarbejder der skal slettes: ");
                                    int id = int.Parse(Console.ReadLine()!);
                                    var m = repository.GetMedarbejderById(id);
                                    if (m == null)
                                    {
                                        Console.WriteLine("Medarbejder ikke fundet.");
                                        break;
                                    }
                                    repository.DeleteMedarbejder(id);
                                    Console.WriteLine("Slettet: " + m);
                                    break;
                                }

                            case "0":
                                kører = false;
                                break;

                            default:
                                Console.WriteLine("Ugyldigt valg.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Fejl: " + ex.Message);
                    }
                }
            }
        }
    }