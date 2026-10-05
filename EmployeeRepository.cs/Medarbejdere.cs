namespace EmployeeRepository.cs
{
    public class Medarbejdere
    {
        //instansfelter
        public int MedarbejderId { get; set; }
        public string Navn { get; set; } = "";
        public bool ErLeder { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }

        //konstruktør
        public Medarbejdere(int medarbejderId, string navn, bool erLeder, string? telefon, string? email)
        {
            MedarbejderId = medarbejderId;
            Navn = navn;
            ErLeder = erLeder;
            Telefon = telefon;
            Email = email;
        }
        public Medarbejdere()
        {
            MedarbejderId = 0;
            Navn = "";
            ErLeder = false;
            Telefon = null;
            Email = null;
        }
        public override string ToString()
        {
            return $"Id: {MedarbejderId}, Navn: {Navn}, ErLeder: {ErLeder}, Telefon: {Telefon}, Email: {Email}";
        }





    }

    





}


