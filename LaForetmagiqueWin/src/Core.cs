using LaForetmagiqueWin.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaForetmagiqueWin.src
{
    public static class Core
    {
        // keys for player movement
        public readonly static Keys keyUp = Keys.W;
        public readonly static Keys keyDown = Keys.S;
        public readonly static Keys keyLeft = Keys.A;
        public readonly static Keys keyRight = Keys.D;


        //determine if the player is moving
        public static bool IsUp = false;
        public static bool IsDown = false;
        public static bool IsLeft = false;
        public static bool IsRight = false;

        //Coins

        public static List<Coin> coins = new List<Coin>();

        public static int sante = 100;
        public static int berriesCollected = 0;
        public static int redPotionsCollected = 0;
        public static int bluePotionsCollected = 0;


    }
}
