using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.cs
{
    public class Vagt
    {
        //instansfelter
        public int Id { get; set; }
        public int MaanedsplanId { get; set; }
        public string dato { get; set; }
        public int startTid { get; set; }
        public int endTid { get; set; }

        //konstruktør
        public Vagt (int id, int maanedsplanId, string dato, int startTid, int endTid)
        {
            Id = id;
            MaanedsplanId = maanedsplanId;
            this.dato = dato;
            this.startTid = startTid;
            this.endTid = endTid;
        }

        public Vagt()
        {
            Id = 0;
            MaanedsplanId = 0;
            dato = "";
            startTid = 0;
            endTid = 0;
        }
        public override string ToString()
        {
            return $"Id: {Id}, MaanedsplanId: {MaanedsplanId}, dato: {dato}, startTid: {startTid}, endTid: {endTid}";
        }

    }
}
