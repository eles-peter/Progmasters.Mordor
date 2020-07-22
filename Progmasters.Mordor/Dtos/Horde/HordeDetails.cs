using Progmasters.Mordor.Dtos.Orc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Dtos.Horde
{
    public class HordeDetails
    {
        public int Id { get; set; }
        public string HordeName { get; set; }
        public List<OrcDetails> Orcs { get; set; }
        public DateTime DateOfLastFight { get; set; }
    }
}
