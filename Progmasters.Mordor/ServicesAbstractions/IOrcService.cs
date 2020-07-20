using Progmasters.Mordor.Dtos.Orc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.ServicesAbstractions
{
    public interface IOrcService
    {
        IEnumerable<OrcDetail> GetAll();
        OrcDetail getOrc(int id);
        void createOrc(OrcCreateItem orcCreateItem);
        void updateOrc(int id, OrcCreateItem orcCreateItem);
        bool deleteOrc(int id);
        OrcFormData getOrcFormData();
    }
}
