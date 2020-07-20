using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Dtos
{
    public enum OrcRaceTypeDto
    {
        [Description("Mountain")]
        Mountain,
        [Description("Uruk")]
        Uruk,
        [Description("Uruk-Hai")]
        UrukHai,
        [Description("Snaga")]
        Snaga
    }
}
