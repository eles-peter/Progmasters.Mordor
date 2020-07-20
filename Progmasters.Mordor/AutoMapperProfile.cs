using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.Dtos.Orc;
using Progmasters.Mordor.Dtos;

namespace Progmasters.Mordor
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Orc, OrcDetail>();
            CreateMap<OrcCreateItem, Orc>();
            CreateMap<string, OrcRaceType>().
                ConvertUsing<StringToOrcRaceTypeConverter>();
            CreateMap<string, WeaponType>().
                ConvertUsing<StringToWeaponTypeConverter>();
        }
            

    }
}
