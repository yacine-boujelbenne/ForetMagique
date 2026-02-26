using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaForetMagique.Models
{
    public abstract class Creature : Entity
    {
        [Key]
        [MaxLength(10), MinLength(5)]
        public string Name { get; set; } = string.Empty;

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public bool IsAlive => Health > 0;

        public virtual void Heal(int amount)
        {
            Health = Math.Min(Health + amount, MaxHealth);
        }

        public virtual void TakeDamage(int amount)
        {
            Health = Math.Max(Health - amount, 0);
        }
    }
}
