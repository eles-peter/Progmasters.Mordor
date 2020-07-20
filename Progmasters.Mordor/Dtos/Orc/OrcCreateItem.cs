using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Dtos.Orc
{
    public class OrcCreateItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrcRaceTypeDto OrcRaceType { get; set; }
        public int KillCount { get; set; }
        //public List<WeaponTypeDto> Weapons { get; set; }
    }
}

