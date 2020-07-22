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
        private readonly DataContext context;
        private readonly IMapper mapper;

        public OrcRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool DeleteOrc(int id)
        {
            DbOrc dbOrc = context.Orcs.FirstOrDefault(orc => orc.Id == id);
            if (dbOrc != null)
            {
                context.Remove(dbOrc);
                context.SaveChanges();
            }
            return dbOrc != null;
        }

        public List<Orc> GetAll()
        {
            List<DbOrc> dbOrcs = context.Orcs
                .Include(o => o.Weapons)
                .Include(o => o.Horde).ToList();
            return dbOrcs.Select(dbOrc => mapper.Map<Orc>(dbOrc)).ToList();
        }

        public Orc GetOrc(int id)
        {
            DbOrc dbOrc = context.Orcs
                .Include(o => o.Weapons)
                .Include(o => o.Horde)
                .FirstOrDefault(dbOrc => dbOrc.Id == id);
            return mapper.Map<Orc>(dbOrc);
        }

        public void SaveOrc(Orc orc, int hordeId)
        {
            DbOrc dbOrc = mapper.Map<DbOrc>(orc);

            DbHorde dbHorde = context.Hordes
                .Include(horde => horde.Orcs)                
                .FirstOrDefault(horde => horde.Id == hordeId);
            if (dbHorde != null)
            {
                dbHorde.Orcs.Add(dbOrc);
            }           

            context.SaveChanges();
        }

        public Orc Update(int id, int newHordeId, Orc updatedOrc)
        {
            DbOrc dbOrc = context.Orcs
                .Include(o => o.Weapons)
                .Include(o => o.Horde)
                .ThenInclude(h => h.Orcs)
                .FirstOrDefault(o => o.Id == id);
            if (dbOrc != null)
            {
                if (dbOrc.Horde != null)
                {
                    dbOrc.Horde.Orcs.Remove(dbOrc);
                }
                // A wewapos-t nem mappeli át!!!!!!!!!!!!!
                context.Entry(dbOrc).CurrentValues.SetValues(mapper.Map<DbOrc>(updatedOrc));

                DbHorde dbHorde = context.Hordes
                    .Include(horde => horde.Orcs)
                    .FirstOrDefault(horde => horde.Id == newHordeId);

                if (dbHorde != null)
                {
                    dbHorde.Orcs.Add(dbOrc);
                }
                context.SaveChanges();
            }
            return mapper.Map<Orc>(dbOrc);
        }
    }
}

