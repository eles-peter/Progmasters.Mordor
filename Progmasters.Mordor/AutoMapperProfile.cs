using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.Dtos.Orc;
using Progmasters.Mordor.Dtos;
using Progmasters.Mordor.Repositories.Entities;
using Progmasters.Mordor.Dtos.Horde;

namespace Progmasters.Mordor
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Orc, OrcDetails>();
            CreateMap<OrcCreateItem, Orc>();
            CreateMap<DbOrc, Orc>();
            CreateMap<Orc, DbOrc>();

            CreateMap<WeaponType, DbWeapon>();
            CreateMap<DbWeapon, WeaponType>();
            CreateMap<string, OrcRaceType>().
                ConvertUsing(s => OrcRaceType.Parse(s));
            CreateMap<string, WeaponType>().
                ConvertUsing(s => WeaponType.Parse(s));

            CreateMap<Horde, HordeDetails>();
            CreateMap<Horde, HordeListItem>();
            CreateMap<HordeCreateItem, Horde>();
            CreateMap<Horde, DbHorde>();
            CreateMap<DbHorde, Horde>();
        }
            

    }
}
