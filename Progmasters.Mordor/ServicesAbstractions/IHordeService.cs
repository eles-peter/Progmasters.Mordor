using Progmasters.Mordor.Dtos.Horde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.ServicesAbstractions
{
    public interface IHordeService
    {
        IEnumerable<HordeDetails> GetAll();
        HordeDetails GetHorde(int id);
        HordeDetails CreateHorde(HordeCreateItem hordeCreateItem);
        HordeDetails UpdateHorde(int id, HordeCreateItem hordeCreateItem);
        bool DeleteHorde(int id);
    }
}
