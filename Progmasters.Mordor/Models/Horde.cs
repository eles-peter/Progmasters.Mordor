
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Models
{
    public class Horde
    {
        public int Id { get; set; }
        public string HordeName { get; set; }
        public List<Orc> Orcs { get; set; }
        public DateTime DateOfLastFight { get; set; }

    }
}
