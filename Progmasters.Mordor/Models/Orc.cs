using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Models
{
    public class Orc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrcRaceType OrcRaceType { get; set; }
        public int KillCount { get; set; }
        public List<WeaponType> Weapons { get; set; }
        public Horde Horde { get; set; }
    }


}
