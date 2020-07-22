using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Repositories.Entities
{
    public class DbHorde
    {
        public int Id { get; set; }
        public string HordeName { get; set; }
        public List<DbOrc> Orcs { get; set; }
        public DateTime DateOfLastFight { get; set; }
    }
}
