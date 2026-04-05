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

        public Player()
        {
            InitializeComponent();

        }


        private void Update(object sender, EventArgs e)
        {
            if (Core.IsUp)
            {
                this.Top -= speed;
                moveB();
            }
            if (Core.IsDown)
            {
                this.Top += speed;
                moveF();
            }
            if (Core.IsLeft)
            {
                this.Left -= speed;
                moveL();
            }
            if (Core.IsRight)
            {
                this.Left += speed;
                moveR();

            }
        }
        private void moveR()
        {
            if (Core.IsRight)
            {
                pictureBox1.Image = Properties.Resources.pixil_frame_1;



            }




        }
        private void moveL()
        {
            pictureBox1.Image = Properties.Resources.pixil_frame_1;

            pictureBox1.Image = Properties.Resources.pixil_frame_2;


            
        }
        private void moveF()
        {
            pictureBox1.Image = Properties.Resources.pixil_frame_2;
 
            pictureBox1.Image = Properties.Resources.pixil_frame_1;
   

        }
            private void moveB()
            {
                pictureBox1.Image = Properties.Resources.pixil_frame_2;

                pictureBox1.Image = Properties.Resources.pixil_frame_1;
 

        }


    }
}
