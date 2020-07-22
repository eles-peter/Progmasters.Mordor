using Progmasters.Mordor.Dtos.Orc;
using Progmasters.Mordor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.RepositoriesAbstractions
{
    public interface IOrcRepository
    {
        List<Orc> GetAll();
        Orc GetOrc(int id);
        void SaveOrc(Orc orc);
        bool DeleteOrc(int id);
        Orc Update(int id, Orc updatedOrc);
    }
}
