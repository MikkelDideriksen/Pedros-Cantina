using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.cs
{
    public class Maanedsplan
    {
        //instansfelter
        public int Id { get; set; }
        public int Maaned { get; set; }
        public int Aar { get; set; }


        //konstruktør
        public Maanedsplan(int id, int maaned, int aar)
        {
            Id = id;
            Maaned = maaned;
            Aar = aar;
        }

        public Maanedsplan ()
        {
            Id = 0;
            Maaned = 0;
            Aar = 0;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Maaned: {Maaned}, Aar: {Aar}";
        }




    }
}
