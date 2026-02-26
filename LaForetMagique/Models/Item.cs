using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    public abstract class Item : Entity
    {
        public string Name { get; set; } = string.Empty;

        public bool IsCollected { get; set; }

        public abstract void Use(Creature creature);
    }
}
