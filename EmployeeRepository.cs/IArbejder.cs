using EmployeeRepository.cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedroLib
{
    public interface IArbejder
    {
        List<Medarbejdere> GetAllMedarbejdere();
        Medarbejdere? GetMedarbejderById(int medarbejderId);
        void CreateMedarbejder(Medarbejdere medarbejder);
        bool UpdateMedarbejder(Medarbejdere medarbejder);
        bool RemoveMedarbejder(int medarbejderId);
        bool DeleteMedarbejder(int medarbejderId);
    }
}
