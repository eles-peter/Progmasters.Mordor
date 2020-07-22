using AutoMapper;
using Progmasters.Mordor.Dtos.Horde;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.RepositoriesAbstractions;
using Progmasters.Mordor.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Services
{
    public class HordeService : IHordeService
    {
        private readonly IHordeRepository hordeRepository;
        private readonly IMapper mapper;

        public HordeService(IHordeRepository hordeRepository, IMapper mapper)
        {
            this.hordeRepository = hordeRepository;
            this.mapper = mapper;
        }

        public HordeDetails CreateHorde(HordeCreateItem hordeCreateItem)
        {
            Horde createdHorde = hordeRepository.SaveHorde(mapper.Map<Horde>(hordeCreateItem));
            return mapper.Map<HordeDetails>(createdHorde);
        }

        public bool DeleteHorde(int id)
        {
            return hordeRepository.DeleteHorde(id);
        }

        public IEnumerable<HordeDetails> GetAll()
        {
            List<Horde> hordeList = hordeRepository.GetAll();
            return hordeList.Select(horde => mapper.Map<HordeDetails>(horde));
        }

        public HordeDetails GetHorde(int id)
        {
            Horde horde = hordeRepository.GetHorde(id);
            return mapper.Map<HordeDetails>(horde);
        }

        public HordeDetails UpdateHorde(int id, HordeCreateItem hordeCreateItem)
        {
            Horde horde = mapper.Map<Horde>(hordeCreateItem);
            horde.Id = id;

            Horde updatedHorde = hordeRepository.Update(id, horde);
            return mapper.Map<HordeDetails>(updatedHorde);
        }
    }
}
