using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    internal class Bzzfly : Bug
    {
        public int FlightSpeed { get; set; }
        public Bzzfly()
        {
            Health = 30;
            MaxHealth = 30;
            AttackPower = 5;
            FlightSpeed = 20;
        }
    }
}
