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
        List<Orc> getAll();
        Orc getOrc(int id);
        void saveOrc(Orc orc);
        bool deleteOrc(int id);
        Orc Update(int id, Orc updatedOrc);
    }
}
