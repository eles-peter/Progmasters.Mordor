using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Models
{
    public class WeaponType
    {
        public string Value { get; private set; }

        private static List<WeaponType> weaponTypes = new List<WeaponType>();

        public static readonly WeaponType Bow = new WeaponType("Bow");
        public static readonly WeaponType Sword = new WeaponType("Sword");
        public static readonly WeaponType DoubleEdgeSword = new WeaponType("Double-Edge Sword");
        public static readonly WeaponType Shield = new WeaponType("Shield");
        public static readonly WeaponType Knife = new WeaponType("Knife");

        public static IEnumerable<WeaponType> WeaponTypes
        {
            get { return weaponTypes; }
        }

        private WeaponType(string value)
        {
            Value = value;
            weaponTypes.Add(this);
        }

        public static WeaponType Parse(string value)
        {
            foreach (WeaponType weaponType in WeaponTypes)
            {
                if (weaponType.Value == value) return weaponType;
            }
            throw new FormatException("Could not parse string.");
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class StringToWeaponTypeConverter : ITypeConverter<string, WeaponType>
    {
        public WeaponType Convert(string source, WeaponType destination, ResolutionContext context)
        {
            return WeaponType.Parse(source);
        }
    }
}


