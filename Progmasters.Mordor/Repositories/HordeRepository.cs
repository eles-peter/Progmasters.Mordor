using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.Repositories.Entities;
using Progmasters.Mordor.RepositoriesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Repositories
{
    public class HordeRepository : IHordeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public HordeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool DeleteHorde(int id)
        {
            DbHorde dbHorde = context.Hordes.FirstOrDefault(horde => horde.Id == id);
            if (dbHorde != null)
            {
                context.Remove(dbHorde);
                context.SaveChanges();
            }
            return dbHorde != null;
        }

        public List<Horde> GetAll()
        {
            List<DbHorde> dbHordes = context.Hordes.Include(h => h.Orcs).ToList();
            return dbHordes.Select(dbHorde => mapper.Map<Horde>(dbHorde)).ToList();
        }

        public Horde GetHorde(int id)
        {
            DbHorde dbHorde = context.Hordes
                .Include(h => h.Orcs)
                .FirstOrDefault(dbHorde => dbHorde.Id == id);
            return mapper.Map<Horde>(dbHorde);
        }

        public Horde SaveHorde(Horde horde)
        {
            DbHorde dbHorde = mapper.Map<DbHorde>(horde);
            context.Hordes.Add(dbHorde);
            context.SaveChanges();
            return mapper.Map<Horde>(dbHorde);
        }

        public Horde Update(int id, Horde horde)
        {
            DbHorde dbHorde = context.Hordes
                .Include(h => h.Orcs)
                .FirstOrDefault(h => h.Id == id);
            if (dbHorde != null)
            {
                context.Entry(dbHorde).CurrentValues
                    .SetValues(mapper.Map<DbHorde>(horde));
                context.SaveChanges();
            }
            return mapper.Map<Horde>(dbHorde);
        }
    }
}
