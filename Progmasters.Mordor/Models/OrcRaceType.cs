using System.Collections.Generic;
using System.ComponentModel;

namespace Progmasters.Mordor.Models
{
    public enum OrcRaceType
    {
        //public string Value { get; private set; }

        //private static List<OrcRaceType> orcRaceTypes = new List<OrcRaceType>;



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