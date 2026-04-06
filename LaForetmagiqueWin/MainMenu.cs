using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LaForetmagiqueWin.src;
using LaForetMagique.Data;
using LaForetMagique.Models;

namespace LaForetmagiqueWin
{
    public class MainMenu : Form
    {
        private Button btnResumeGame;
        private Button btnNewGame;
        private Button btnSave;
        private Button btnQuit;
        private Label titleLabel;

        private Form1 _existingGame;

        public MainMenu()
        {
            InitializeComponent();
            this.btnResumeGame.Visible = false;
            this.btnNewGame.Text = "Start Game";
        }

        public MainMenu(Form1 existingGame) : this()
        {
            _existingGame = existingGame;
            if (_existingGame != null)
            {
                this.btnResumeGame.Visible = true;
                this.btnNewGame.Text = "Restart Game";
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            btnResumeGame = new Button();
            btnNewGame = new Button();
            btnSave = new Button();
            btnQuit = new Button();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // btnResumeGame
            // 
            btnResumeGame.BackColor = Color.Olive;
            btnResumeGame.Font = new Font("Arial", 14F);
            btnResumeGame.Location = new Point(300, 110);
            btnResumeGame.Name = "btnResumeGame";
            btnResumeGame.Size = new Size(200, 50);
            btnResumeGame.TabIndex = 4;
            btnResumeGame.Text = "Resume Game";
            btnResumeGame.UseVisualStyleBackColor = false;
            btnResumeGame.Click += btnResumeGame_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = Color.Olive;
            btnNewGame.Font = new Font("Arial", 14F);
            btnNewGame.Location = new Point(300, 180);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(200, 50);
            btnNewGame.TabIndex = 1;
            btnNewGame.Text = "Start Game";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Olive;
            btnSave.Font = new Font("Arial", 14F);
            btnSave.Location = new Point(300, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 50);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Game";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.Olive;
            btnQuit.Font = new Font("Arial", 14F);
            btnQuit.Location = new Point(300, 320);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(200, 50);
            btnQuit.TabIndex = 3;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Arial", 24F, FontStyle.Bold);
            titleLabel.ForeColor = SystemColors.ButtonHighlight;
            titleLabel.Location = new Point(300, 50);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(183, 37);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Main Menu";
            // 
            // MainMenu
            // 
            BackgroundImage = Properties.Resources.map;
            ClientSize = new Size(800, 450);
            Controls.Add(titleLabel);
            Controls.Add(btnResumeGame);
            Controls.Add(btnQuit);
            Controls.Add(btnSave);
            Controls.Add(btnNewGame);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "La Foret Magique - Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Close the existing game before starting a new one, if it exists
            if (_existingGame != null)
            {
                _existingGame.Dispose();
            }

            // Reset state
            Core.sante = 100;
            Core.berriesCollected = 0;
            Core.redPotionsCollected = 0;
            Core.bluePotionsCollected = 0;
            
            Form1 gameForm = new Form1();
            gameForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            gameForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new LaforetMagiqueDbContext())
                {
                   // db.Database.EnsureDeleted(); // Dropping first as we changed the DB schema completely to TPT
                    db.Database.EnsureCreated();
                    
                    // Find the existing player in the database
                    var currentPlayer = db.Schtroumpfs
                                          .Include(s => s.Items)
                                          .Include(s => s.Bugs)
                                          .FirstOrDefault(s => s.Name == "Gamer");

                    if (currentPlayer == null)
                    {
                        currentPlayer = new Schtroumpf { Name = "Gamer", MaxHealth = 100 };
                        db.Schtroumpfs.Add(currentPlayer);
                    }

                    // Update player stats
                    currentPlayer.Health = Core.sante;
                    currentPlayer.ExperiencePoints = Core.berriesCollected * 10;
                    
                    // Clear existing collections to overwrite
                    currentPlayer.Items.Clear();
                    currentPlayer.Bugs.Clear();
                    
                    // Add items stats to player
                    for (int i = 0; i < Core.berriesCollected; i++)
                    {
                        currentPlayer.Items.Add(new Berry { Name = "Berry", HealAmount = 10 });
                    }

                    if (_existingGame != null)
                    {
                        foreach (Control ctrl in _existingGame.Controls)
                        {
                            if (ctrl is LaForetmagiqueWin.GameObject.BuzzBug bugControl)
                            {
                                var enemyBug = new Bzzfly 
                                { 
                                    Health = bugControl.BugData.Health,
                                    AttackPower = bugControl.BugData.AttackPower,
                                    x = bugControl.Location.X,
                                    y = bugControl.Location.Y,
                                    Name = "Bzzfly"
                                };
                                currentPlayer.Bugs.Add(enemyBug);
                            }
                        }
                    }
                    else
                    {
                        var enemyBug = new Bzzfly 
                        { 
                            Health = 30, 
                            AttackPower = 5,
                            Name = "Bzzfly"
                        };
                        currentPlayer.Bugs.Add(enemyBug);
                    }

                    db.SaveChanges(); // Persist changes properly without duplication
                    MessageBox.Show($"Game Saved!\nYour HP: {Core.sante}\nBerries Collected: {Core.berriesCollected}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResumeGame_Click(object sender, EventArgs e)
        {
            if (_existingGame != null)
            {
                _existingGame.Show();
                this.Close();
            }
        }
    }
}
