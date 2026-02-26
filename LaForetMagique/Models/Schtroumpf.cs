using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    internal class Schtroumpf : Creature
    {
        public string Role { get; set; } = "Schtroumpf Voyageur";

        public int ExperiencePoints { get; set; }

        public Schtroumpf()
        {
            Health = 100;
            MaxHealth = 100;
        }
    }
}
