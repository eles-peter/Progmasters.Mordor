using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        private readonly IMapper mapper;

        public OrcService(IOrcRepository orcRepository, IMapper mapper)
        {
            this.orcRepository = orcRepository;
            this.mapper = mapper;
        }

        public void createOrc(OrcCreateItem orcCreateItem)
        {
            throw new NotImplementedException();
        }

        public void deleteOrc(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrcDetail> GetAll()
        {
            List<Orc> orcList = orcRepository.getAll();
            return orcList.Select(orc => mapper.Map<OrcDetail>(orc));

        }

        public OrcDetail getOrc(int id)
        {
            Orc orc = orcRepository.getOrc(id);
            return mapper.Map<OrcDetail>(orc);
        }

        public void updateOrc(int id, OrcCreateItem orcCreateItem)
        {
            throw new NotImplementedException();
        }
    }
}
