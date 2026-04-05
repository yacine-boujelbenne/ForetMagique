using LaForetmagiqueWin.GameObject;
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

namespace LaForetmagiqueWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up | e.KeyCode == Core.keyUp)
            {
                Core.IsUp = true;
            }
            if (e.KeyCode == Keys.Down | e.KeyCode == Core.keyDown)
            {
                Core.IsDown = true;
            }
            if (e.KeyCode == Keys.Left | e.KeyCode == Core.keyLeft)
            {
                Core.IsLeft = true;
            }
            if (e.KeyCode == Keys.Right | e.KeyCode == Core.keyRight)
            {
                Core.IsRight = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up | e.KeyCode == Core.keyUp)
            {
                Core.IsUp = false;
            }
            if (e.KeyCode == Keys.Down | e.KeyCode == Core.keyDown)
            {
                Core.IsDown = false;
            }
            if (e.KeyCode == Keys.Left | e.KeyCode == Core.keyLeft)
            {
                Core.IsLeft = false;
            }
            if (e.KeyCode == Keys.Right | e.KeyCode == Core.keyRight)
            {
                Core.IsRight = false;
            }

        }

        private void Eventact(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x = rand.Next(0, this.ClientSize.Width - 50);
            int y = rand.Next(0, this.ClientSize.Height - 50);

            Coin coin = new Coin(x, y);
            this.Controls.Add(coin);
            //global list
            Core.coins.Add(coin);

        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                foreach (Coin coin in Core.coins)
                {
                    if (player1.Bounds.IntersectsWith(coin.Bounds))
                    {
                        this.Controls.Remove(coin);
                        Core.coins.Remove(coin);
                        Core.score++;
                        label1.Text = "Score : " + Core.score;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
