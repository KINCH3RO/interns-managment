namespace GestionnaireStagiaire
{
    partial class frmAlert
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
            this.components = new System.ComponentModel.Container();
            this.GunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.GunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.GunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GunaLabel1
            // 
            this.GunaLabel1.AutoSize = true;
            this.GunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.GunaLabel1.ForeColor = System.Drawing.Color.White;
            this.GunaLabel1.Location = new System.Drawing.Point(46, 18);
            this.GunaLabel1.Name = "GunaLabel1";
            this.GunaLabel1.Size = new System.Drawing.Size(230, 21);
            this.GunaLabel1.TabIndex = 14;
            this.GunaLabel1.Text = "Stagiaire accepté : Hatim Rachid";
            this.GunaLabel1.Click += new System.EventHandler(this.GunaLabel1_Click);
            // 
            // GunaPanel1
            // 
            this.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.GunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.GunaPanel1.Name = "GunaPanel1";
            this.GunaPanel1.Size = new System.Drawing.Size(5, 91);
            this.GunaPanel1.TabIndex = 12;
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.White;
            this.gunaLabel2.Location = new System.Drawing.Point(46, 49);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(339, 24);
            this.gunaLabel2.TabIndex = 16;
            this.gunaLabel2.Text = "zidouh rachid";
            this.gunaLabel2.Click += new System.EventHandler(this.gunaLabel2_Click);
            // 
            // GunaPictureBox1
            // 
            this.GunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.GunaPictureBox1.Location = new System.Drawing.Point(12, 31);
            this.GunaPictureBox1.Name = "GunaPictureBox1";
            this.GunaPictureBox1.Size = new System.Drawing.Size(28, 28);
            this.GunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GunaPictureBox1.TabIndex = 13;
            this.GunaPictureBox1.TabStop = false;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.White;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(402, 31);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.Silver;
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(31, 29);
            this.gunaControlBox1.TabIndex = 17;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(445, 91);
            this.Controls.Add(this.gunaControlBox1);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.GunaLabel1);
            this.Controls.Add(this.GunaPanel1);
            this.Controls.Add(this.GunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlert";
            this.Text = "frmAlert";
            this.Load += new System.EventHandler(this.frmAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Guna.UI.WinForms.GunaLabel GunaLabel1;
        internal Guna.UI.WinForms.GunaPanel GunaPanel1;
        internal System.Windows.Forms.Timer Timer1;
        internal Guna.UI.WinForms.GunaPictureBox GunaPictureBox1;
        internal Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
    }
}