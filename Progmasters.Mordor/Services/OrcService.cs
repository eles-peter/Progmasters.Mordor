using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Progmasters.Mordor.Dtos.Horde;
using Progmasters.Mordor.Dtos.Orc;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.Repositories;
using Progmasters.Mordor.RepositoriesAbstractions;
using Progmasters.Mordor.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Services
{
    public class OrcService : IOrcService
    {
        private readonly IOrcRepository orcRepository;
        private readonly IHordeRepository hordeRepository;
        private readonly IMapper mapper;

        public OrcService(IOrcRepository orcRepository, IHordeRepository hordeRepository, IMapper mapper)
        {
            this.orcRepository = orcRepository;
            this.hordeRepository = hordeRepository;
            this.mapper = mapper;
        }

        public OrcFormData GetOrcFormData()
        {
            return new OrcFormData {
                Weapons = WeaponType.WeaponTypes.Select(w => w.ToString()).Distinct().ToList(),
                OrcRaces = OrcRaceType.OrcRaceTypes.Select(o => o.ToString()).ToList(),
                Hordes = hordeRepository.GetAll()
                .Select(horde => mapper.Map<HordeListItem>(horde)).ToList()
           };
        }

        public void CreateOrc(OrcCreateItem orcCreateItem)
        {
            Orc orc = mapper.Map<Orc>(orcCreateItem);
            int hordeId = orcCreateItem.HordeId;
            orcRepository.SaveOrc(orc, hordeId);
        }

        public bool DeleteOrc(int id)
        {
           return orcRepository.DeleteOrc(id);
        }

        public IEnumerable<OrcDetails> GetAll()
        {
            List<Orc> orcList = orcRepository.GetAll();
            return orcList.Select(orc => mapper.Map<OrcDetails>(orc));

        }

        public OrcDetails GetOrc(int id)
        {
            Orc orc = orcRepository.GetOrc(id);
            return mapper.Map<OrcDetails>(orc);
        }

        public OrcDetails UpdateOrc(int id, OrcCreateItem orcCreateItem)
        {
            Orc orc = mapper.Map<Orc>(orcCreateItem);
            orc.Id = id;
            int hordeId = orcCreateItem.HordeId;

            Orc updatedOrc = orcRepository.Update(id, hordeId, orc);
            return mapper.Map<OrcDetails>(updatedOrc);
        }
    }
}
