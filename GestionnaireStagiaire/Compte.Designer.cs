namespace GestionnaireStagiaire
{
    partial class Compte
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compte));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.FullnameTB = new Guna.UI.WinForms.GunaTextBox();
            this.gunaSeparator2 = new Guna.UI.WinForms.GunaSeparator();
            this.UsernameTB = new Guna.UI.WinForms.GunaTextBox();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaSeparator3 = new Guna.UI.WinForms.GunaSeparator();
            this.cmdp1 = new Guna.UI.WinForms.GunaTextBox();
            this.gunaSeparator4 = new Guna.UI.WinForms.GunaSeparator();
            this.mdp2 = new Guna.UI.WinForms.GunaTextBox();
            this.gunaAdvenceButton2 = new Guna.UI.WinForms.GunaAdvenceButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 614);
            this.panel1.TabIndex = 0;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gunaAdvenceButton2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.FullnameTB);
            this.panel3.Controls.Add(this.gunaSeparator2);
            this.panel3.Controls.Add(this.UsernameTB);
            this.panel3.Controls.Add(this.gunaSeparator1);
            this.panel3.Controls.Add(this.gunaSeparator3);
            this.panel3.Controls.Add(this.cmdp1);
            this.panel3.Controls.Add(this.gunaSeparator4);
            this.panel3.Controls.Add(this.mdp2);
            this.panel3.Location = new System.Drawing.Point(40, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(942, 209);
            this.panel3.TabIndex = 70;
            this.panel3.SizeChanged += new System.EventHandler(this.panel3_SizeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(469, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "dfdd";
            this.label1.Visible = false;
            // 
            // FullnameTB
            // 
            this.FullnameTB.BaseColor = System.Drawing.Color.White;
            this.FullnameTB.BorderColor = System.Drawing.Color.Silver;
            this.FullnameTB.BorderSize = 0;
            this.FullnameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FullnameTB.FocusedBaseColor = System.Drawing.Color.White;
            this.FullnameTB.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.FullnameTB.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.FullnameTB.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullnameTB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FullnameTB.Location = new System.Drawing.Point(15, 6);
            this.FullnameTB.Name = "FullnameTB";
            this.FullnameTB.PasswordChar = '\0';
            this.FullnameTB.Size = new System.Drawing.Size(214, 30);
            this.FullnameTB.TabIndex = 1;
            this.FullnameTB.Text = "Nom Complet";
            // 
            // gunaSeparator2
            // 
            this.gunaSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaSeparator2.Location = new System.Drawing.Point(15, 42);
            this.gunaSeparator2.Name = "gunaSeparator2";
            this.gunaSeparator2.Size = new System.Drawing.Size(214, 10);
            this.gunaSeparator2.TabIndex = 54;
            this.gunaSeparator2.Thickness = 2;
            // 
            // UsernameTB
            // 
            this.UsernameTB.BaseColor = System.Drawing.Color.White;
            this.UsernameTB.BorderColor = System.Drawing.Color.Silver;
            this.UsernameTB.BorderSize = 0;
            this.UsernameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTB.FocusedBaseColor = System.Drawing.Color.White;
            this.UsernameTB.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.UsernameTB.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.UsernameTB.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.UsernameTB.Location = new System.Drawing.Point(11, 104);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.PasswordChar = '\0';
            this.UsernameTB.Size = new System.Drawing.Size(214, 30);
            this.UsernameTB.TabIndex = 2;
            this.UsernameTB.Text = "Username";
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaSeparator1.Location = new System.Drawing.Point(469, 140);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(214, 10);
            this.gunaSeparator1.TabIndex = 63;
            this.gunaSeparator1.Thickness = 2;
            // 
            // gunaSeparator3
            // 
            this.gunaSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaSeparator3.Location = new System.Drawing.Point(15, 140);
            this.gunaSeparator3.Name = "gunaSeparator3";
            this.gunaSeparator3.Size = new System.Drawing.Size(210, 10);
            this.gunaSeparator3.TabIndex = 56;
            this.gunaSeparator3.Thickness = 2;
            // 
            // cmdp1
            // 
            this.cmdp1.BaseColor = System.Drawing.Color.White;
            this.cmdp1.BorderColor = System.Drawing.Color.Silver;
            this.cmdp1.BorderSize = 0;
            this.cmdp1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmdp1.FocusedBaseColor = System.Drawing.Color.White;
            this.cmdp1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmdp1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdp1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdp1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.cmdp1.Location = new System.Drawing.Point(469, 104);
            this.cmdp1.Name = "cmdp1";
            this.cmdp1.PasswordChar = '\0';
            this.cmdp1.Size = new System.Drawing.Size(214, 30);
            this.cmdp1.TabIndex = 4;
            this.cmdp1.Text = "Nouveau mot de passe";
            // 
            // gunaSeparator4
            // 
            this.gunaSeparator4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaSeparator4.Location = new System.Drawing.Point(469, 42);
            this.gunaSeparator4.Name = "gunaSeparator4";
            this.gunaSeparator4.Size = new System.Drawing.Size(214, 10);
            this.gunaSeparator4.TabIndex = 61;
            this.gunaSeparator4.Thickness = 2;
            // 
            // mdp2
            // 
            this.mdp2.BaseColor = System.Drawing.Color.White;
            this.mdp2.BorderColor = System.Drawing.Color.Silver;
            this.mdp2.BorderSize = 0;
            this.mdp2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mdp2.FocusedBaseColor = System.Drawing.Color.White;
            this.mdp2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.mdp2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.mdp2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdp2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.mdp2.Location = new System.Drawing.Point(469, 6);
            this.mdp2.Name = "mdp2";
            this.mdp2.PasswordChar = '\0';
            this.mdp2.Size = new System.Drawing.Size(214, 30);
            this.mdp2.TabIndex = 3;
            this.mdp2.Text = "Mot de passe actual";
            // 
            // gunaAdvenceButton2
            // 
            this.gunaAdvenceButton2.Animated = true;
            this.gunaAdvenceButton2.AnimationHoverSpeed = 0.07F;
            this.gunaAdvenceButton2.AnimationSpeed = 0.03F;
            this.gunaAdvenceButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaAdvenceButton2.BaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaAdvenceButton2.BorderSize = 2;
            this.gunaAdvenceButton2.CheckedBaseColor = System.Drawing.Color.Gray;
            this.gunaAdvenceButton2.CheckedBorderColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton2.CheckedForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton2.CheckedImage = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton2.CheckedImage")));
            this.gunaAdvenceButton2.CheckedLineColor = System.Drawing.Color.DimGray;
            this.gunaAdvenceButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaAdvenceButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.gunaAdvenceButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaAdvenceButton2.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaAdvenceButton2.ForeColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton2.Image = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton2.Image")));
            this.gunaAdvenceButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaAdvenceButton2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.gunaAdvenceButton2.Location = new System.Drawing.Point(748, 78);
            this.gunaAdvenceButton2.Name = "gunaAdvenceButton2";
            this.gunaAdvenceButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaAdvenceButton2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.gunaAdvenceButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaAdvenceButton2.OnHoverImage = null;
            this.gunaAdvenceButton2.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.gunaAdvenceButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaAdvenceButton2.Radius = 20;
            this.gunaAdvenceButton2.Size = new System.Drawing.Size(159, 42);
            this.gunaAdvenceButton2.TabIndex = 68;
            this.gunaAdvenceButton2.Text = "Enregistrer";
            this.gunaAdvenceButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaAdvenceButton2.Click += new System.EventHandler(this.gunaAdvenceButton2_Click_1);
            // 
            // Compte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "Compte";
            this.Size = new System.Drawing.Size(1075, 614);
            this.Load += new System.EventHandler(this.Compte_Load);
            this.SizeChanged += new System.EventHandler(this.Compte_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox FullnameTB;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator2;
        private Guna.UI.WinForms.GunaTextBox UsernameTB;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator3;
        private Guna.UI.WinForms.GunaTextBox cmdp1;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator4;
        private Guna.UI.WinForms.GunaTextBox mdp2;
        private Guna.UI.WinForms.GunaAdvenceButton gunaAdvenceButton2;
    }
}
