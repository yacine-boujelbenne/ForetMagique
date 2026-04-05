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
    public partial class Coin : UserControl
    {
        public Coin()
        {
            InitializeComponent();
        }
        public Coin(int x, int y)
        {
            InitializeComponent();

            Location = new System.Drawing.Point(x, y);
        }
    }
}
