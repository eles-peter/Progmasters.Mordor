using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Models
{
    public enum WeaponType
    {
        [Description("Bow")]
        Bow,
        [Description("Sword")]
        Sword,
        [Description("Double-Edge Sword")]
        DoubleEdgeSword,
        [Description("Shield")]
        Shiled,
        [Description("Knife")]
        Knife
    }
}
