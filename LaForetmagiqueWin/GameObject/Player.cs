using Azure.Identity;
using LaForetmagiqueWin.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaForetmagiqueWin.GameObject
{
    public partial class Player : UserControl
    {
        private int speed = 5;
        private bool isFrame1 = true;
        private int animationDelay = 0;
        private bool facingLeft = false;

        public Player()
        {
            InitializeComponent();

        }


        private void Update(object sender, EventArgs e)
        {
            if (this.Parent == null) return;

            if (Core.IsUp && this.Top > 0)
            {
                this.Top -= speed;
                moveB();
            }
            if (Core.IsDown && this.Bottom < this.Parent.ClientSize.Height)
            {
                this.Top += speed;
                moveF();
            }
            if (Core.IsLeft && this.Left > 0)
            {
                this.Left -= speed;
                moveL();
            }
            if (Core.IsRight && this.Right < this.Parent.ClientSize.Width)
            {
                this.Left += speed;
                moveR();

            }
        }
        private void AnimateMovement()
        {
            animationDelay++;
            if (animationDelay >= 5)
            {
                isFrame1 = !isFrame1;
                animationDelay = 0;
            }

            if (facingLeft)
            {
                pictureBox1.Image = isFrame1 ? Properties.Resources.pixil_frame_1L : Properties.Resources.pixil_frame_2L;
            }
            else
            {
                pictureBox1.Image = isFrame1 ? Properties.Resources.pixil_frame_1 : Properties.Resources.pixil_frame_2;
            }
        }

        private void moveR()
        {
            facingLeft = false;
            AnimateMovement();
        }

        private void moveL()
        {
            facingLeft = true;
            AnimateMovement();
        }

        private void moveF()
        {
            AnimateMovement();
        }

        private void moveB()
        {
            AnimateMovement();
        }


    }
}
