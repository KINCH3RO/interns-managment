using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionnaireStagiaire

{

    public partial class Dashboard : UserControl
    {
        bool isopned = false;
        public Dashboard()
        {
            InitializeComponent();
        }
        public void darkmode(bool dark)
        {
            this.BackColor = MainMenu.dark2;
            chart1.ForeColor = Color.White;
            
            foreach (Control lbl in Controls) { lbl.ForeColor = MainMenu.whitecolor; }
            chart1.BorderlineColor = MainMenu.whitecolor;

            chart1.Titles["Title1"].ForeColor = MainMenu.whitecolor;

            chart1.Legends["Legend1"].ForeColor = MainMenu.whitecolor;
            chart1.Legends["Legend1"].TitleForeColor = MainMenu.whitecolor;

            chart2.BorderlineColor = MainMenu.whitecolor;
            chart2.Titles["Title1"].ForeColor = MainMenu.whitecolor;

            chart2.Legends["Legend1"].ForeColor = MainMenu.whitecolor;
            chart2.Legends["Legend1"].TitleForeColor = MainMenu.whitecolor;



        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            refreshdata();

        }
        public void refreshdata()
        {

            int a = nbrST();
            int x = nbrSTA();
            label4.Text = a.ToString();
            label5.Text = x.ToString();
            label6.Text = (a - x).ToString();
            label7.Text = SP();
            label9.Text = nbrencours().ToString();
            demandeparecole();
            demandeparmois();
            ECOLE.Text = SP2();
        }
        string SP2()
        {

             string sql = @"select TOP 1 stagiaire.ecole
                          from stagiaire where year(du)=year(getdate())

                          group by stagiaire.ecole
                          order by count(*) desc";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            string specialite = (string)cmd.ExecuteScalar();

            return specialite;
        }
        void demandeparmois()
        {


            string sql = @"select count(*),month(stagiaire.Du)
                        from stagiaire where year(du)=year(getdate())
                        group by month(stagiaire.Du)";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            SqlDataReader dr = cmd.ExecuteReader();
            chart2.Series["STG"].Points.Clear();


            while (dr.Read())
            {
                chart2.Series["STG"].Points.AddXY(dr.GetValue(1).ToString(), int.Parse(dr.GetValue(0).ToString()));


            }
            dr.Close();


        }
        void demandeparecole()
        {


            string sql = @"select count(*),(stagiaire.ecole+' '+CONVERT(varchar,COUNT(*))) as 'lol' from stagiaire where year(du)=year(getdate()) and stagiaire.ecole  not like '' group by stagiaire.ecole";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            SqlDataReader dr = cmd.ExecuteReader();
            chart1.Series["STG"].Points.Clear();

            while (dr.Read())
            {
                chart1.Series["STG"].Points.AddXY(dr.GetValue(1).ToString(), int.Parse(dr.GetValue(0).ToString()));


            }
            dr.Close();

        }


        string SP()
        {

            string sql = @" select stagiaire.specialite
                           from stagiaire where year(du)=year(getdate())
                           group by stagiaire.specialite
                           order by count(*) desc";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            string specialite = (string)cmd.ExecuteScalar();

            return specialite;
        }
        int nbrST()
        {

            SqlCommand cmd = new SqlCommand("select count(*) from stagiaire where year(du)=year(getdate())", Program.con);
            int nbrtotal = (int)cmd.ExecuteScalar();

            return nbrtotal;
        }
        int nbrencours()
        {

            SqlCommand cmd = new SqlCommand("select count(*) from acc where getdate() >= acc.Du and getdate() <= acc.Au", Program.con);
            int nbrtotal = (int)cmd.ExecuteScalar();

            return nbrtotal;
        }

        int nbren()
        {

            SqlCommand cmd = new SqlCommand(@"select  count(*),stagiaire.specialite from stagiaire where year(du)=year(getdate()) group by stagiaire.specialite", Program.con);
            int nbrtotal = (int)cmd.ExecuteScalar();

            return nbrtotal;
        }

        int nbrSTA()
        {

            SqlCommand cmd = new SqlCommand("select count(*) from acc where year(du)=year(getdate())", Program.con);
            int nbrtotal = (int)cmd.ExecuteScalar();

            return nbrtotal;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            isopned = !isopned;
            if (isopned)
            {
                chart1.Parent = this;
                chart1.Size = new Size(this.Width, this.Height);
                chart1.Location = new Point(0, 0);
                chart1.BringToFront();

            }
            else
            {
                chart1.Parent = panel1;
                chart1.Size = new Size(531, 329);
                chart1.Location = new Point(2, 226);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ECOLE_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel1);
            Program.centercontrolV(panel1);

            if (isopned)
            {
                chart1.Parent = this;
                chart1.Size = new Size(this.Width, this.Height);
                chart1.Location = new Point(0, 0);
                chart1.BringToFront();

            }
            else
            {
                chart1.Parent = panel1;
                chart1.Size = new Size(531, 329);
                chart1.Location = new Point(2, 226);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
