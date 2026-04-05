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
            SuspendLayout();
            // 
            // player1
            // 
            player1.BackColor = Color.Transparent;
            player1.Location = new Point(138, 62);
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
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 14);
            label1.Name = "label1";
            label1.Size = new Size(101, 28);
            label1.TabIndex = 1;
            label1.Text = "Score : ";
            // 
            // collusion
            // 
            collusion.Enabled = true;
            collusion.Interval = 10;
            collusion.Tick += Update;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(player1);
            ForeColor = Color.Gold;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GameObject.Player player1;
        private System.Windows.Forms.Timer Events;
        private Label label1;
        private System.Windows.Forms.Timer collusion;
    }
}