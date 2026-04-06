using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    public abstract class Bug : Creature
    {
        public int AttackPower { get; set; }

        public bool IsHostile { get; set; } = true;

        public int? SchtroumpfId { get; set; }
        public Schtroumpf? Schtroumpf { get; set; }
    }
}
