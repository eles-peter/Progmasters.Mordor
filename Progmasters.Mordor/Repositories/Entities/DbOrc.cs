using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Repositories.Entities
{
    public class DbOrc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrcRaceType { get; set; }
        public int KillCount { get; set; }
        public List<DbWeapon> Weapons { get; set; }
    }
}
