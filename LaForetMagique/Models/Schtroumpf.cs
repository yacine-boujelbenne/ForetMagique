using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    public class Schtroumpf : Creature
    {
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "Schtroumpf Voyageur";

        public int ExperiencePoints { get; set; }

        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
        public ICollection<Item> Items { get; set; } = new List<Item>();

        public Schtroumpf()
        {
            Health = 100;
            MaxHealth = 100;
        }
    }
}
