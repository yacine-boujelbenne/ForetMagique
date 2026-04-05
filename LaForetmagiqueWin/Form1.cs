using LaForetMagique.Models;
using LaForetMagique.Data;
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
        private DateTime lastDamageTime = DateTime.MinValue;
        private LaforetMagiqueDbContext _dbContext;
        private Schtroumpf _dbPlayer;
        private Panel _pausePanel;

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            _dbContext = new LaforetMagiqueDbContext();
            _dbPlayer = new Schtroumpf { Name = "Gamer", Health = Core.sante, MaxHealth = 100, Role = "Player" };
            _dbContext.Schtroumpfs.Add(_dbPlayer);
            _dbContext.SaveChanges();

            // Setup Pause Panel
            _pausePanel = new Panel();
            _pausePanel.Size = new Size(240, 160);
            _pausePanel.BackColor = Color.FromArgb(220, 20, 20, 20); // Dark semi-transparent
            _pausePanel.Location = new Point((this.ClientSize.Width - _pausePanel.Width) / 2, (this.ClientSize.Height - _pausePanel.Height) / 2);
            _pausePanel.Visible = false;
            _pausePanel.Anchor = AnchorStyles.None;

            Label lblPause = new Label();
            lblPause.Text = "PAUSED";
            lblPause.ForeColor = Color.White;
            lblPause.Font = new Font("Joystix Monospace", 18, FontStyle.Bold);
            lblPause.Dock = DockStyle.Top;
            lblPause.Height = 50;
            lblPause.TextAlign = ContentAlignment.MiddleCenter;

            Label btnResume = new Label();
            btnResume.Text = "Resume";
            btnResume.TextAlign = ContentAlignment.MiddleCenter;
            btnResume.Size = new Size(160, 35);
            btnResume.Location = new Point(40, 60);
            btnResume.BackColor = Color.LightGreen;
            btnResume.BorderStyle = BorderStyle.FixedSingle;
            btnResume.Cursor = Cursors.Hand;
            btnResume.Click += (s, ev) => 
            {
                _pausePanel.Visible = false;
                Events.Start();
                collusion.Start(); // Resume game timers
            };

            Label btnMainMenu = new Label();
            btnMainMenu.Text = "Main Menu";
            btnMainMenu.TextAlign = ContentAlignment.MiddleCenter;
            btnMainMenu.Size = new Size(160, 35);
            btnMainMenu.Location = new Point(40, 105);
            btnMainMenu.BackColor = Color.LightCoral;
            btnMainMenu.BorderStyle = BorderStyle.FixedSingle;
            btnMainMenu.Cursor = Cursors.Hand;
            btnMainMenu.Click += (s, ev) => 
            {
                MainMenu menu = new MainMenu(this);
                menu.Show();
                this.Hide();
            };

            _pausePanel.Controls.Add(lblPause);
            _pausePanel.Controls.Add(btnResume);
            _pausePanel.Controls.Add(btnMainMenu);
            this.Controls.Add(_pausePanel);

            // Menu shortcut button (Visible Button)
            Label menuShortcut = new Label();
            menuShortcut.Text = "☰";
            menuShortcut.TextAlign = ContentAlignment.MiddleCenter;
            menuShortcut.Font = new Font("Arial", 16, FontStyle.Bold);
            menuShortcut.Size = new Size(40, 40);
            menuShortcut.Location = new Point(this.ClientSize.Width - 50, 10);
            menuShortcut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuShortcut.BackColor = Color.White;
            menuShortcut.BorderStyle = BorderStyle.FixedSingle;
            menuShortcut.Cursor = Cursors.Hand;
            
            menuShortcut.Click += (s, ev) => 
            {
                Core.IsUp = false; Core.IsDown = false; Core.IsLeft = false; Core.IsRight = false;
                Events.Stop();
                collusion.Stop(); // Pause game timers
                _pausePanel.Location = new Point((this.ClientSize.Width - _pausePanel.Width) / 2, (this.ClientSize.Height - _pausePanel.Height) / 2);
                _pausePanel.Visible = true;
                _pausePanel.BringToFront();
            };
            this.Controls.Add(menuShortcut);
            menuShortcut.BringToFront();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_pausePanel.Visible)
                {
                    _pausePanel.Visible = false;
                    Events.Start();
                    collusion.Start();
                }
                else
                {
                    Core.IsUp = false; Core.IsDown = false; Core.IsLeft = false; Core.IsRight = false;
                    Events.Stop();
                    collusion.Stop();
                    _pausePanel.Location = new Point((this.ClientSize.Width - _pausePanel.Width) / 2, (this.ClientSize.Height - _pausePanel.Height) / 2);
                    _pausePanel.Visible = true;
                    _pausePanel.BringToFront();
                }
            }
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

            // we mean by the Coin the Berry , but we will keep the name Coin for the code simplicity
            Random rand = new Random();
            int x = rand.Next(0, Math.Max(1, this.ClientSize.Width - 50));
            int y = rand.Next(0, Math.Max(1, this.ClientSize.Height - 50));

            Coin coin = new Coin(x, y);
            this.Controls.Add(coin);
            //global list
            Core.coins.Add(coin);

            var dbBerry = new Berry { Name = "Berry", HealAmount = 10, x = x, y = y };
            _dbContext.Berries.Add(dbBerry);
            _dbContext.SaveChanges();
        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                // Check collision with buzzBug1
                if (player1.Bounds.IntersectsWith(buzzBug1.Bounds))
                {
                    if ((DateTime.Now - lastDamageTime).TotalSeconds > 1.5)
                    {
                        Core.sante = Math.Max(0, Core.sante - buzzBug1.BugData.AttackPower);
                        _dbPlayer.Health = Core.sante;
                        _dbContext.SaveChanges();
                        label1.Text = "Santé : " + Core.sante;
                        hpBar.Value = Core.sante;
                        lastDamageTime = DateTime.Now;
                        
                        // Add visual floating damage effect
                        Label dmgLabel = new Label();
                        dmgLabel.Text = $"-{buzzBug1.BugData.AttackPower} HP";
                        dmgLabel.ForeColor = Color.Red;
                        dmgLabel.BackColor = Color.Transparent;
                        dmgLabel.Font = new Font("Joystix Monospace", 16, FontStyle.Bold);
                        dmgLabel.AutoSize = true;
                        dmgLabel.Location = new Point(player1.Location.X, player1.Location.Y - 10);
                        this.Controls.Add(dmgLabel);
                        dmgLabel.BringToFront();

                        System.Windows.Forms.Timer dmgTimer = new System.Windows.Forms.Timer();
                        dmgTimer.Interval = 40;
                        int dTicks = 0;
                        dmgTimer.Tick += (s, ev) =>
                        {
                            dmgLabel.Top -= 3;
                            dTicks++;
                            if (dTicks > 15)
                            {
                                dmgTimer.Stop();
                                this.Controls.Remove(dmgLabel);
                                dmgLabel.Dispose();
                                dmgTimer.Dispose();
                            }
                        };
                        dmgTimer.Start();

                        if (Core.sante <= 0)
                        {
                            collusion.Stop();
                            Events.Stop();
                            MessageBox.Show("Game Over!");
                            Application.Exit();
                        }
                    }
                }

                // we mean by the Coin the Berry , but we will keep the name Coin for the code simplicity
                foreach (Coin coin in Core.coins)
                {
                    if (player1.Bounds.IntersectsWith(coin.Bounds))
                    {
                        this.Controls.Remove(coin);
                        Core.coins.Remove(coin);
                        Core.sante = Math.Min(Core.sante + 10, hpBar.Maximum);
                        _dbPlayer.Health = Core.sante;
                        _dbContext.SaveChanges();
                        Core.berriesCollected++;
                        label1.Text = "Santé : " + Core.sante;
                        hpBar.Value = Core.sante;
                        System.Media.SystemSounds.Beep.Play();

                        // Add visual floating +1 effect
                        Label plusOne = new Label();
                        plusOne.Text = "+10 HP";
                        plusOne.ForeColor = Color.LimeGreen;
                        plusOne.BackColor = Color.Transparent;
                        plusOne.Font = new Font("Joystix Monospace", 16, FontStyle.Bold);
                        plusOne.AutoSize = true;
                        plusOne.Location = new Point(coin.Location.X, coin.Location.Y - 10);
                        this.Controls.Add(plusOne);
                        plusOne.BringToFront();

                        System.Windows.Forms.Timer effectTimer = new System.Windows.Forms.Timer();
                        effectTimer.Interval = 40;
                        int ticks = 0;
                        effectTimer.Tick += (s, ev) =>
                        {
                            plusOne.Top -= 3; // Float upwards
                            ticks++;
                            if (ticks > 15)
                            {
                                effectTimer.Stop();
                                this.Controls.Remove(plusOne);
                                plusOne.Dispose();
                                effectTimer.Dispose();
                            }
                        };
                        effectTimer.Start();

                        break; // Prevents the collection modified exception
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
