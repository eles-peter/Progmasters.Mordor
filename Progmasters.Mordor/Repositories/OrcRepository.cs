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
            List<DbOrc> dbOrcs = context.Orcs.Include(o => o.Weapons).ToList();
            return dbOrcs.Select(dbOrc => mapper.Map<Orc>(dbOrc)).ToList();
        }

        public Orc GetOrc(int id)
        {
            DbOrc dbOrc = context.Orcs
                .Include(o => o.Weapons)
                .FirstOrDefault(dbOrc => dbOrc.Id == id);
            return mapper.Map<Orc>(dbOrc);
        }

        public void SaveOrc(Orc orc)
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

