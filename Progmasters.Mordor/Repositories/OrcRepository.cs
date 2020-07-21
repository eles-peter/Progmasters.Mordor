using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.Repositories.Entities;
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
                    WeaponType.Shield
                }
            }
        };
        private readonly DataContext context;
        private readonly IMapper mapper;

        public OrcRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool deleteOrc(int id)
        {
            DbOrc dbOrc = context.Orcs.FirstOrDefault(orc => orc.Id == id);
            if (dbOrc != null)
            {
                context.Remove(dbOrc);
                context.SaveChanges();
            }
            return dbOrc != null;
        }

        public List<Orc> getAll()
        {
            List<DbOrc> dbOrcs = context.Orcs.Include(o => o.Weapons).ToList();
            return dbOrcs.Select(dbOrc => mapper.Map<Orc>(dbOrc)).ToList();
        }

        public Orc getOrc(int id)
        {
            DbOrc dbOrc = context.Orcs
                .Include(o => o.Weapons)
                .FirstOrDefault(dbOrc => dbOrc.Id == id);
            return mapper.Map<Orc>(dbOrc);
        }

        public void saveOrc(Orc orc)
        {
            DbOrc dbOrc = mapper.Map<DbOrc>(orc);
            context.Orcs.Add(dbOrc);
            context.SaveChanges();
        }

        public Orc Update(int id, Orc updatedOrc)
        {
            DbOrc dbOrc = context.Orcs.Include(o => o.Weapons).FirstOrDefault(o => o.Id == id);
            if (dbOrc != null)
            {
                context.Entry(dbOrc).CurrentValues.SetValues(mapper.Map<DbOrc>(updatedOrc));
                context.SaveChanges();
            }
            return mapper.Map<Orc>(dbOrc);
        }
    }
}

