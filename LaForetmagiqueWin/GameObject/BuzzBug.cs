using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaForetMagique.Models;

namespace LaForetmagiqueWin.GameObject
{
    public partial class BuzzBug : UserControl
    {
        public Bzzfly BugData { get; private set; }

        private System.Windows.Forms.Timer moveTimer;
        private int speed = 3;
        private bool movingRight = true;
        private bool frameState = true;
        private int animationCounter = 0;

        public BuzzBug()
        {
            InitializeComponent();
            BugData = new Bzzfly();
            speed = BugData.FlightSpeed / 4; // Use flight speed for UI speed with some scaling
            
            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 50;
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();
        }

        private void MoveTimer_Tick(object? sender, EventArgs e)
        {
            if (this.Parent == null) return;

            // Movement
            if (movingRight)
            {
                this.Left += speed;
                if (this.Right >= Parent.ClientSize.Width)
                {
                    movingRight = false;
                }
            }
            else
            {
                this.Left -= speed;
                if (this.Left <= 0)
                {
                    movingRight = true;
                }
            }

            // Animation
            animationCounter++;
            if (animationCounter >= 3) // Flap speed
            {
                frameState = !frameState;
                animationCounter = 0;
            }

            if (movingRight)
            {
                pictureBox1.Image = frameState ? Properties.Resources.teleR : Properties.Resources.téléchargéR;
            }
            else
            {
                pictureBox1.Image = frameState ? Properties.Resources.teleL : Properties.Resources.téléchargé;
            }
        }
    }
}
