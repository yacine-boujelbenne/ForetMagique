using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    public class BluePotion : Item
    {
        public int HealAmount { get; set; } = 20;

        public BluePotion()
        {
            Name = "Blue Potion";
        }

        public override void Use(Creature creature)
        {
            // Cette potion sera utilisée différemment (soigne toutes les créatures)
            // La logique sera dans le game manager
            creature.Heal(HealAmount);
            IsCollected = true;
        }
    }
}
