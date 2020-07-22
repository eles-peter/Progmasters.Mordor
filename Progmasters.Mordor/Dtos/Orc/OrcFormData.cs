using Progmasters.Mordor.Dtos.Horde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Dtos.Orc
{
    public class OrcFormData
    {
        public List<string> Weapons { get; set; }
        public List<string> OrcRaces { get; set; }
        public List<HordeListItem> Hordes { get; set; }
    }
}
