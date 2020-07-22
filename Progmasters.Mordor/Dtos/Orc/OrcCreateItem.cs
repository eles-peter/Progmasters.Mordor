using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Dtos.Orc
{
    public class OrcCreateItem
    {
        public string Name { get; set; }
        public string OrcRaceType { get; set; }
        public int KillCount { get; set; }
        public List<string> Weapons { get; set; }
        public int HordeId { get; set; }
    }
}

