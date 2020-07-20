using Progmasters.Mordor.Models;
using Progmasters.Mordor.RepositoriesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Progmasters.Mordor.Repositories
{
    public class OrcRepository : IOrcRepository
    {
        private static List<Orc> orcList = new List<Orc>
        {
            new Orc{
                Id = 1,
                Name = "Ajsa",
                OrcRaceType = OrcRaceType.Mountain,
                KillCount = 5,
                Weapons = new List<WeaponType>
                {
                    WeaponType.DoubleEdgeSword,
                    WeaponType.Knife
                }
            },
            new Orc{
                Id = 2,
                Name = "Pepa",
                OrcRaceType = OrcRaceType.UrukHai,
                KillCount = 8,
                Weapons = new List<WeaponType>
                {
                    WeaponType.Bow,
                    WeaponType.Sword,
                    WeaponType.Shiled
                }
            }
        };
        public List<Orc> getAll()
        {
            return orcList;
        }

        public Orc getOrc(int id)
        {
           return orcList.FirstOrDefault(orc => orc.Id == id);
        }
    }
}
