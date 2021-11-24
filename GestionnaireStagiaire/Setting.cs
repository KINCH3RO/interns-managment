using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI.WinForms;
using System.Text.RegularExpressions;

namespace GestionnaireStagiaire
{
    public partial class Setting : UserControl
    {
        public Control backctrl;
        public Setting()
        {
            InitializeComponent();
        }


        public void dark()
        {
            this.BackColor = MainMenu.dark2;

            foreach (Control ctrl in panel2.Controls)
            {

                if (ctrl.GetType() == typeof(GunaTextBox))
                {
                    GunaTextBox guna = (GunaTextBox)ctrl;

                    guna.FocusedBaseColor = MainMenu.dark2;
                    guna.FocusedForeColor = MainMenu.whitecolor;
                    guna.BaseColor = MainMenu.dark2;
                }
                if (ctrl.GetType() == typeof(GunaAdvenceButton))
                {

                    GunaAdvenceButton guna = (GunaAdvenceButton)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;
                    guna.BaseColor = MainMenu.dark2;

                }
                if (ctrl.GetType() == typeof(GunaDateTimePicker))
                {
                    GunaDateTimePicker guna = (GunaDateTimePicker)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;
                    guna.FocusedColor = MainMenu.dark2;
                    guna.OnHoverBaseColor = MainMenu.dark2;

                    guna.BaseColor = MainMenu.dark2;

                }
                if (ctrl.GetType() == typeof(Label))
                {
                    Label lbl = (Label)ctrl;
                    lbl.ForeColor = MainMenu.whitecolor;


                }
                if (ctrl.GetType() == typeof(GunaLabel))
                {
                    GunaLabel lbl = (GunaLabel)ctrl;
                    lbl.ForeColor = MainMenu.whitecolor;


                }
                if (ctrl.GetType() == typeof(GunaComboBox))
                {
                    GunaComboBox guna = (GunaComboBox)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;
                    guna.BaseColor = MainMenu.dark2;

                }
                this.BackColor = MainMenu.dark2;



            }
            gunaLabel1.ForeColor = MainMenu.whitecolor;
            gunaLabel2.ForeColor = MainMenu.whitecolor;
            gunaLabel3.ForeColor = MainMenu.whitecolor;
            gunaLabel4.ForeColor = MainMenu.whitecolor;

            gunaLabel11.ForeColor = MainMenu.whitecolor;
            gunaLabel14.ForeColor = MainMenu.whitecolor;
            gunaLabel15.ForeColor = MainMenu.whitecolor;
            gunaRadioButton1.ForeColor = MainMenu.whitecolor;
            gunaRadioButton2.ForeColor = MainMenu.whitecolor;

            gunaTextBox2.FocusedBaseColor = MainMenu.dark2;
            gunaTextBox2.FocusedForeColor = MainMenu.whitecolor;
            gunaTextBox2.BaseColor = MainMenu.dark2;
        }


        private void panel1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {

                panel1.BackColor = colorDialog1.Color;
                MainMenu menu = (MainMenu)this.ParentForm;
                menu.color(colorDialog1.Color);
                Properties.Settings.Default.appcolor = colorDialog1.Color;
                Properties.Settings.Default.Save();


            }
        }
        public void color(Color Maincolor)
        {
            gunaSwitch1.CheckedOnColor = Maincolor;
            gunaSwitch2.CheckedOnColor = Maincolor;
            gunaSwitch3.CheckedOnColor = Maincolor;
            gunaSwitch4.CheckedOnColor = Maincolor;
            gunaSwitch5.CheckedOnColor = Maincolor;

            gunaSwitch7.CheckedOnColor = Maincolor;

            gunaSwitch8.CheckedOnColor = Maincolor;

            gunaAdvenceButton5.BorderColor = Maincolor;

            gunaAdvenceButton5.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton5.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton2.BorderColor = Maincolor;
            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton3.BorderColor = Maincolor;
            gunaAdvenceButton3.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton3.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton4.BorderColor = Maincolor;
            gunaAdvenceButton4.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton4.OnHoverBorderColor = Maincolor;
            accCombobox.OnHoverItemBaseColor = Maincolor;
            gunaRadioButton1.CheckedOnColor = Maincolor;
            gunaRadioButton2.CheckedOnColor = Maincolor;




        }
        public  void set(string x)
        {
            if (gunaTextBox1.Focused)
            {
                return;

            }
            gunaTextBox1.Text = x;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if (LOGIN2.isboss == "Admin")
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
            accCombobox.Items.Add("list d'anné actuel");
            accCombobox.Items.Add("list d'archive");
            accCombobox.SelectedIndex = 0;


            colorDialog1.Color = Properties.Settings.Default.appcolor;
            panel1.BackColor = Properties.Settings.Default.appcolor;
            gunaAdvenceButton1.BackColor = Properties.Settings.Default.appcolor;
            gunaSwitch1.CheckedOnColor = Properties.Settings.Default.appcolor;
            gunaSwitch2.CheckedOnColor = Properties.Settings.Default.appcolor;
            gunaSwitch3.CheckedOnColor = Properties.Settings.Default.appcolor;

            gunaSwitch4.CheckedOnColor = Properties.Settings.Default.appcolor;
            gunaSwitch5.CheckedOnColor = Properties.Settings.Default.appcolor;
            gunaSwitch7.CheckedOnColor = Properties.Settings.Default.appcolor;
            gunaSwitch8.CheckedOnColor = Properties.Settings.Default.appcolor;


            if (this.DesignMode)
            {
                return;
            }

            gunaSwitch1.Checked = Properties.Settings.Default.Dark;
            gunaSwitch2.Checked = Properties.Settings.Default.minimize;
            gunaSwitch3.Checked = Properties.Settings.Default.notif;
            gunaSwitch4.Checked = Properties.Settings.Default.notifS;
            gunaSwitch5.Checked = Properties.Settings.Default.innactivity;
            gunaSwitch7.Checked = Properties.Settings.Default.autoclose;
            gunaSwitch8.Checked = Properties.Settings.Default.multicolor;


            gunaTextBox1.Text = getmaxnbrstg().ToString();
            gunaTextBox2.Text = Properties.Settings.Default.innactivitytime.ToString();

            gunaRadioButton1.Checked = Properties.Settings.Default.styleIndicator;


        }




        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            MainMenu menu = (MainMenu)this.ParentForm;
            menu.color(Color.FromArgb(40, 86, 182));
            panel1.BackColor = Color.FromArgb(40, 86, 182);
            Properties.Settings.Default.appcolor = Color.FromArgb(40, 86, 182);
            Properties.Settings.Default.Save();
        }

        private void gunaSwitch1_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.Dark = gunaSwitch1.Checked;
            Properties.Settings.Default.Save();
            if (!this.DesignMode)
            {
                MainMenu menu = (MainMenu)this.ParentForm;

                menu.darkmode(gunaSwitch1.Checked);
            }

        }


        private void gunaSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.minimize = gunaSwitch2.Checked;
            Properties.Settings.Default.Save();

            if (!this.DesignMode)
            {
                MainMenu menu = (MainMenu)this.ParentForm;

                menu.minimize(gunaSwitch2.Checked);
            }

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text == "")
            {
                gunaTextBox1.Text = "0";
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accCombobox.SelectedIndex == 0)
            {
                ListStagiaire.table = "stagiaire";
                ListStagiaireAcc.table = "acc";
                summary.table = "acc";

            }
            else
            {
                ListStagiaire.table = "archive";
                ListStagiaireAcc.table = "archiveacc";
                summary.table = "archiveacc";

            }
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            string sql = "insert into archive select *,( CONVERT(varchar,stagiaire.id)+'/'+format( stagiaire.Du,'yy')) from stagiaire";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            if (Confirmationbox.ShowDialog("vous voulez vraiment archivé cette table", true) == DialogResult.OK)
            {
                int X = (int)cmd.ExecuteNonQuery();
                if (X > 0)
                {

                }
                else
                {
                    return;
                }


                sql = "insert into archiveacc select *,( CONVERT(varchar,acc.id)+'/'+format( acc.Du,'yy')) from acc";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "insert into archiveinfo select accinfo.id,accinfo.info,accinfo.etat,( CONVERT(varchar,acc.id)+'/'+format( acc.Du,'yy')) from accinfo inner join acc on accinfo.id = acc.id";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                Confirmationbox.Show("operation complet");
            }

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            string sql = "  delete from accinfo delete from acc delete from stagiaire dbcc checkident ('stagiaire',RESEED,0)";
            SqlCommand cmd = new SqlCommand(sql, Program.con);

            if (Confirmationbox.ShowDialog("Avez-vous sauvgardeé la base de données",true)==DialogResult.OK)
            {
                if (Confirmationbox.ShowDialog("Voulez vraiment supprimer cette base de donné", true) == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    Confirmationbox.Show("base donné supprimer");
                }

            }
        }
       

        

        private void gunaSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.notif = gunaSwitch3.Checked;
            Properties.Settings.Default.Save();

        }

        private void gunaSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.notifS = gunaSwitch4.Checked;
            Properties.Settings.Default.Save();

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            string sql = "delete from notif";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.ExecuteNonQuery();
            Confirmationbox.Show("opereation bien fait");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text == "")
            {
                gunaTextBox2.Text = "0";
            }
        }

        private void gunaSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.innactivity = gunaSwitch5.Checked;
            Properties.Settings.Default.Save();
        }

        private void gunaSwitch6_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.Save();
        }

        private void gunaTextBox2_MouseLeave(object sender, EventArgs e)
        {
            Regex r = new Regex("^[0-9]*$");
            if (!r.IsMatch(gunaTextBox2.Text.ToString()))
            {
                Confirmationbox.Show("wrong format");
                return;
            }

            Properties.Settings.Default.innactivitytime = int.Parse(gunaTextBox2.Text.ToString());
            Properties.Settings.Default.Save();

        }

        private void gunaTextBox1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void gunaSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoclose = gunaSwitch7.Checked;
            Properties.Settings.Default.Save();
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.styleIndicator = gunaRadioButton1.Checked;
            Properties.Settings.Default.Save();

        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {

            Regex r = new Regex("^[0-9]*$");
            if (!r.IsMatch(gunaTextBox1.Text.ToString()))
            {
                Confirmationbox.Show("wrong format");
                return;
            }
            if (gunaTextBox1.Text == "0")
            {
                gunaTextBox1.Text = getmaxnbrstg().ToString();
                return;
            }
            SqlCommand cmd = new SqlCommand("update appsettings set nbstg=@x", Program.con);
            cmd.Parameters.Add("@x", SqlDbType.Int).Value = int.Parse(gunaTextBox1.Text);
            cmd.ExecuteNonQuery();
            Confirmationbox.Show("bien enregitré");
        }
        public static int getmaxnbrstg()
        {
            
                SqlConnection con = new SqlConnection(Program.con.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(nbstg) from appsettings", con);
            int x = (int)cmd.ExecuteScalar();
            con.Close();
            return x;
           
            
           


        }

        private void gunaColorTransition1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MainMenu menu = (MainMenu)this.ParentForm;

            if (Properties.Settings.Default.multicolor)
            {
                menu.color(gunaColorTransition1.Value);
            }
            else
            {
                menu.color(Properties.Settings.Default.appcolor);
                timer1.Stop();
            }
          

        }

        private void gunaSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaSwitch8.Checked)
            {
                timer1.Start();
            }
            Properties.Settings.Default.multicolor = gunaSwitch8.Checked;
            Properties.Settings.Default.Save();
            


        }

        private void gunaLabel15_Click(object sender, EventArgs e)
        {

        }
    }
}
