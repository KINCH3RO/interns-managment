using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace GestionnaireStagiaire
{
    public partial class LOGIN2 : Form
    {
        public static string isboss;
        public static string name = "";
        public static int id;
        public static string user;
        public LOGIN2()
        {
            InitializeComponent();
            //textBox1.PasswordChar = '\u25cf';
            databasesetting1.Visible = false;
            loadapp();
            Program.x = this;


        }

        private void LOGIN2_Load(object sender, EventArgs e)
        {


            textBox1.PasswordChar = '\u25cf';
            gunaAnimateWindow1.Start();
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            //Program.checknewversion();
            
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
        }
        void loadapp()
        {
            textBox2.Text = Properties.Settings.Default.Username;
            gunaCheckBox1.Checked = Properties.Settings.Default.rem;

            if (textBox2.Text == "")
            {
                textBox2.Select();
            }
            else
            {
                textBox1.Select();
            }
            textBox1.Select();

            var x = this;

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleButton3_Click(object sender, EventArgs e)
        {
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        void connect()
        {
            SqlConnection con = new SqlConnection(Program.conS);

            try
            {
                con.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Data base connection Erreur");
                return;
            }

            if (Program.con.State == ConnectionState.Open)
            {

                Program.con.Close();
                Program.con.ConnectionString = Properties.Settings.Default.connectionstring;

                Program.con.Open();

            }
            else if (Program.con.State == ConnectionState.Closed)
            {
                Program.con.ConnectionString = Properties.Settings.Default.connectionstring;

                Program.con.Open();
            }


            string SQL = "select id,nom,Admintype,username  from userE where username=@user and mdp = @pass COLLATE SQL_Latin1_General_Cp1_CS_AS";
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox1.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                name = dr.GetValue(1).ToString();
                isboss = dr.GetValue(2).ToString();
                id = int.Parse(dr.GetValue(0).ToString());
                user = dr.GetValue(3).ToString();
                if (gunaCheckBox1.Checked)
                {
                    Properties.Settings.Default.Username = textBox2.Text;
                    Properties.Settings.Default.rem = gunaCheckBox1.Checked;
                    Properties.Settings.Default.Save();

                }
                else
                {

                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.rem = false;
                    Properties.Settings.Default.Save();
                }
                Program.showmainmenu();
                Program.hidelogin();
            }
            else
            {
                MessageBox.Show("Wrong password or Username", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dr.Close();
            con.Close();
        }

        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {


            connect();




        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            databasesetting1.Visible = true;
            databasesetting1.load();

            gunaTransition1.Hide(panel2);
        }


        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void databasesetting1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '\0';
            pictureBox5.BackgroundImage = Properties.Resources.icons8_eye_26px_1;

        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '\u25cf';
            pictureBox5.BackgroundImage = Properties.Resources.icons8_invisible_26px;

        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown_2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaAdvenceButton1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {


        }


        private void gunaPanel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_Click_1(object sender, EventArgs e)
        {
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void show()
        {
            gunaTransition1.Show(panel2);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleButton4_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.cosumar.co.ma/");

        }

        private void gunaCircleButton2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Groupe-Cosumar-340435426289287/");

        }

        private void gunaCircleButton3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/hashtag/cosumar?lang=fr");

        }

        private void gunaCircleButton1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCLhpPMZ3Qc9xldJuJZVqsMQ");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaWinCircleProgressIndicator1_Load(object sender, EventArgs e)
        {
        }

        private void gunaCircleButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/company/groupe-cosumar");

        }
    }
}
