namespace GestionnaireStagiaire
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ECOLE = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gunaPictureBox3 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox6 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox4 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox5 = new Guna.UI.WinForms.GunaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Title = "Les ecoles";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(2, 226);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "STG";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(531, 329);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            title1.BackColor = System.Drawing.Color.Transparent;
            title1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Nbr demande par ecole";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Black;
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleBackColor = System.Drawing.Color.Transparent;
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(536, 226);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsXValueIndexed = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "STG";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(500, 329);
            this.chart2.TabIndex = 12;
            this.chart2.Text = "chart2";
            title2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Nbr demande par mois";
            this.chart2.Titles.Add(title2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.chart2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 588);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gunaPictureBox3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.gunaPictureBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.gunaSeparator1);
            this.panel2.Controls.Add(this.gunaPictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 203);
            this.panel2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(178, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "45";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 168);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "100";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "100";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(175, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "St,Att";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "St,Acc";
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.Silver;
            this.gunaSeparator1.Location = new System.Drawing.Point(21, 101);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(214, 10);
            this.gunaSeparator1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nbr stagiaire";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.gunaPictureBox6);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(264, 13);
            this.panel3.Margin = new System.Windows.Forms.Padding(7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(248, 203);
            this.panel3.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-1, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 50);
            this.label9.TabIndex = 7;
            this.label9.Text = "100";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(208, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "Nbr stagiaire en cours";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.gunaPictureBox4);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(526, 13);
            this.panel4.Margin = new System.Windows.Forms.Padding(7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 203);
            this.panel4.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 50);
            this.label7.TabIndex = 7;
            this.label7.Text = "Agro-Alimentaire";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Specialite plus demandé";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.ECOLE);
            this.panel5.Controls.Add(this.gunaPictureBox5);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(788, 13);
            this.panel5.Margin = new System.Windows.Forms.Padding(7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(248, 203);
            this.panel5.TabIndex = 13;
            // 
            // ECOLE
            // 
            this.ECOLE.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ECOLE.Location = new System.Drawing.Point(-1, 151);
            this.ECOLE.Name = "ECOLE";
            this.ECOLE.Size = new System.Drawing.Size(248, 50);
            this.ECOLE.TabIndex = 7;
            this.ECOLE.Text = "E";
            this.ECOLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Ecole  plus demandé";
            // 
            // gunaPictureBox3
            // 
            this.gunaPictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox3.BackgroundImage")));
            this.gunaPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gunaPictureBox3.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox3.Location = new System.Drawing.Point(178, 117);
            this.gunaPictureBox3.Name = "gunaPictureBox3";
            this.gunaPictureBox3.Size = new System.Drawing.Size(29, 31);
            this.gunaPictureBox3.TabIndex = 10;
            this.gunaPictureBox3.TabStop = false;
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.BackgroundImage")));
            this.gunaPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Location = new System.Drawing.Point(44, 121);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(27, 27);
            this.gunaPictureBox2.TabIndex = 5;
            this.gunaPictureBox2.TabStop = false;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.BackgroundImage")));
            this.gunaPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Location = new System.Drawing.Point(104, 40);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(35, 35);
            this.gunaPictureBox1.TabIndex = 1;
            this.gunaPictureBox1.TabStop = false;
            // 
            // gunaPictureBox6
            // 
            this.gunaPictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox6.BackgroundImage")));
            this.gunaPictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox6.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox6.Location = new System.Drawing.Point(105, 78);
            this.gunaPictureBox6.Name = "gunaPictureBox6";
            this.gunaPictureBox6.Size = new System.Drawing.Size(35, 35);
            this.gunaPictureBox6.TabIndex = 1;
            this.gunaPictureBox6.TabStop = false;
            // 
            // gunaPictureBox4
            // 
            this.gunaPictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox4.BackgroundImage")));
            this.gunaPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox4.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox4.Location = new System.Drawing.Point(107, 78);
            this.gunaPictureBox4.Name = "gunaPictureBox4";
            this.gunaPictureBox4.Size = new System.Drawing.Size(35, 35);
            this.gunaPictureBox4.TabIndex = 1;
            this.gunaPictureBox4.TabStop = false;
            // 
            // gunaPictureBox5
            // 
            this.gunaPictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox5.BackgroundImage")));
            this.gunaPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox5.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox5.Location = new System.Drawing.Point(107, 78);
            this.gunaPictureBox5.Name = "gunaPictureBox5";
            this.gunaPictureBox5.Size = new System.Drawing.Size(35, 35);
            this.gunaPictureBox5.TabIndex = 1;
            this.gunaPictureBox5.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1075, 614);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.SizeChanged += new System.EventHandler(this.Dashboard_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label ECOLE;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox5;
        private System.Windows.Forms.Label label11;
    }
}
