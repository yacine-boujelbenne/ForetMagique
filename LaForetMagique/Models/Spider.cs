using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetMagique.Models
{
    internal class Spider : Bug
    {
        public int WebStrength { get; set; }

        public Spider()
        {
            Health = 50;
            MaxHealth = 50;
            AttackPower = 10;
            WebStrength = 5;
        }
    }
}
