using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.cs
{
    public class Vagtmedarbejder
    {
        //instansfelter
        public int Id { get; set; }
        public int VagtId { get; set; }
        public int MedarbejderId { get; set; }
        //konstruktør
        public Vagtmedarbejder(int id, int vagtId, int medarbejderId)
        {
            Id = id;
            VagtId = vagtId;
            MedarbejderId = medarbejderId;
        }
        public Vagtmedarbejder()
        {
            Id = 0;
            VagtId = 0;
            MedarbejderId = 0;
        }
        public override string ToString()
        {
            return $"Id: {Id}, VagtId: {VagtId}, MedarbejderId: {MedarbejderId}";
        }
    }
}
