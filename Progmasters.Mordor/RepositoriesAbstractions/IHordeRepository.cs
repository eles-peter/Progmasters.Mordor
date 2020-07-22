using Progmasters.Mordor.Dtos.Horde;
using Progmasters.Mordor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.RepositoriesAbstractions
{
    public interface IHordeRepository
    {
        Horde SaveHorde(Horde horde);
        bool DeleteHorde(int id);
        List<Horde> GetAll();
        Horde GetHorde(int id);
        Horde Update(int id, Horde horde);
    }
}
