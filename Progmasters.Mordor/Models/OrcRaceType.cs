using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Policy;

namespace Progmasters.Mordor.Models
{
    public class OrcRaceType
    {
        public string Value { get; private set; }

        private static List<OrcRaceType> orcRaceTypes = new List<OrcRaceType>();

        public static readonly OrcRaceType Mountain = new OrcRaceType("Mountain");
        public static readonly OrcRaceType Uruk = new OrcRaceType("Uruk");
        public static readonly OrcRaceType UrukHai = new OrcRaceType("Uruk-Hai");
        public static readonly OrcRaceType Snaga = new OrcRaceType("Snaga");

        public static IEnumerable<OrcRaceType> OrcRaceTypes
        {
            get { return orcRaceTypes; }
        }

        private OrcRaceType(string value) 
        {
            Value = value;
            orcRaceTypes.Add(this);
        }

        public static OrcRaceType Parse(string value)
        {
            foreach (OrcRaceType orcRaceType in OrcRaceTypes)
            {
                if (orcRaceType.Value == value) return orcRaceType;
            }
            throw new FormatException("Could not parse string."); 
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class StringToOrcRaceTypeConverter : ITypeConverter<string, OrcRaceType>
    {
        public OrcRaceType Convert(string source, OrcRaceType destination, ResolutionContext context)
        {
            return OrcRaceType.Parse(source);
        }
    }
}