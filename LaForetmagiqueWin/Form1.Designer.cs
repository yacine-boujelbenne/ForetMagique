namespace LaForetmagiqueWin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            player1 = new LaForetmagiqueWin.GameObject.Player();
            Events = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            collusion = new System.Windows.Forms.Timer(components);
            hpBar = new ProgressBar();
            buzzBug1 = new LaForetmagiqueWin.GameObject.BuzzBug();
            redStrumf1 = new LaForetmagiqueWin.GameObject.RedStrumf();
            SuspendLayout();
            // 
            // player1
            // 
            player1.BackColor = Color.Transparent;
            player1.Location = new Point(433, 276);
            player1.Name = "player1";
            player1.Size = new Size(40, 50);
            player1.TabIndex = 0;
            player1.KeyDown += OnKeyDown;
            player1.KeyUp += OnKeyUp;
            // 
            // Events
            // 
            Events.Enabled = true;
            Events.Interval = 2000;
            Events.Tick += Eventact;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Joystix Monospace", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 14);
            label1.Name = "label1";
            label1.Size = new Size(158, 23);
            label1.TabIndex = 1;
            label1.Text = "Health:100";
            // 
            // collusion
            // 
            collusion.Enabled = true;
            collusion.Interval = 10;
            collusion.Tick += Update;
            // 
            // hpBar
            // 
            hpBar.Location = new Point(11, 45);
            hpBar.Name = "hpBar";
            hpBar.Size = new Size(200, 11);
            hpBar.Style = ProgressBarStyle.Continuous;
            hpBar.TabIndex = 2;
            hpBar.Value = 100;
            // 
            // buzzBug1
            // 
            buzzBug1.BackColor = Color.Transparent;
            buzzBug1.Location = new Point(615, 62);
            buzzBug1.Name = "buzzBug1";
            buzzBug1.Size = new Size(86, 68);
            buzzBug1.TabIndex = 3;
            // 
            // redStrumf1
            // 
            redStrumf1.BackColor = Color.Transparent;
            redStrumf1.Location = new Point(11, 386);
            redStrumf1.Name = "redStrumf1";
            redStrumf1.Size = new Size(44, 61);
            redStrumf1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(redStrumf1);
            Controls.Add(buzzBug1);
            Controls.Add(hpBar);
            Controls.Add(label1);
            Controls.Add(player1);
            ForeColor = Color.Gold;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            Text = "Smurf Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GameObject.Player player1;
        private System.Windows.Forms.Timer Events;
        private Label label1;
        private System.Windows.Forms.Timer collusion;
        private ProgressBar hpBar;
        private GameObject.BuzzBug buzzBug1;
        private GameObject.RedStrumf redStrumf1;
    }
}