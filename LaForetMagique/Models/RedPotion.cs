using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    public class RedPotion : Item
    {
        public int HealAmount { get; set; } = 50;

        public RedPotion()
        {
            Name = "Red Potion";
        }

        public override void Use(Creature creature)
        {
            // Fonctionne uniquement sur les Schtroumpfs
            if (creature is Schtroumpf schtroumpf)
            {
                schtroumpf.Heal(HealAmount);
                IsCollected = true;
            }
        }
    }
}
