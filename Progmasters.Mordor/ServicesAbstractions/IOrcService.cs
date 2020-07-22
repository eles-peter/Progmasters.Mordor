using Progmasters.Mordor.Dtos.Orc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.ServicesAbstractions
{
    public interface IOrcService
    {
        IEnumerable<OrcDetails> GetAll();
        OrcDetails GetOrc(int id);
        void CreateOrc(OrcCreateItem orcCreateItem);
        OrcDetails UpdateOrc(int id, OrcCreateItem orcCreateItem);
        bool DeleteOrc(int id);
        OrcFormData GetOrcFormData();
    }
}
