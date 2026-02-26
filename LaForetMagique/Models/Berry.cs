using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    public class Berry : Item
    {
        public int HealAmount { get; set; } = 15;

        public Berry()
        {
            Name = "Berry";
        }

        public override void Use(Creature creature)
        {
            creature.Heal(HealAmount);
            IsCollected = true;
        }
    }
}
