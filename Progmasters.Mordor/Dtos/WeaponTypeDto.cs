using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Dtos
{
    public enum WeaponTypeDto
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
