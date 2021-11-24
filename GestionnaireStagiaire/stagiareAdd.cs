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
using Guna.UI.WinForms;


namespace GestionnaireStagiaire
{


    public partial class stagiareAdd : UserControl
    {
        SqlConnection con = new SqlConnection(Program.conS);
        public stagiareAdd()
        {
            InitializeComponent();
        }

        private void stagiareAdd_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            nomTB.Focus();
            DateDe.Value = DateTime.Now;
            DateDu.Value = DateTime.Now;
            DateAu1.Value = DateTime.Now;



        }
        public void dark(bool dark)
        {
            this.BackColor = MainMenu.dark2;
            gunaAdvenceButton1.ForeColor = MainMenu.whitecolor;
            gunaAdvenceButton1.BaseColor = MainMenu.dark2;
            foreach (Control ctrl in panel1.Controls)
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
                if (ctrl.GetType() == typeof(GunaRadioButton))
                {
                    GunaRadioButton guna = (GunaRadioButton)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;

                }


            }
        }
        public void color(Color Maincolor)
        {
            gunaSeparator2.LineColor = Maincolor;
            gunaSeparator3.LineColor = Maincolor;
            gunaSeparator4.LineColor = Maincolor;
            gunaSeparator5.LineColor = Maincolor;
            gunaSeparator6.LineColor = Maincolor;
            gunaSeparator7.LineColor = Maincolor;
            gunaSeparator8.LineColor = Maincolor;
            gunaSeparator9.LineColor = Maincolor;
            DateDe.FocusedColor = Maincolor;
            DateDe.OnHoverBorderColor = Maincolor;
            DateDe.OnHoverForeColor = Maincolor;
            DateAu1.FocusedColor = Maincolor;
            DateAu1.OnHoverBorderColor = Maincolor;
            DateAu1.OnHoverForeColor = Maincolor;
            DateDu.FocusedColor = Maincolor;
            DateDu.OnHoverBorderColor = Maincolor;
            DateDu.OnHoverForeColor = Maincolor;

            gunaRadioButton1.CheckedOnColor = Maincolor;
            gunaRadioButton2.CheckedOnColor = Maincolor;
            gunaAdvenceButton1.BorderColor = Maincolor;
            gunaAdvenceButton1.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton1.OnHoverBorderColor = Maincolor;





        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void nomTB_Enter(object sender, EventArgs e)
        {

        }


        private void nomTB_Leave(object sender, EventArgs e)
        {

        }

        private void PrenomTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrenomTB_Leave(object sender, EventArgs e)
        {

        }

        private void specialitetb_Leave(object sender, EventArgs e)
        {

        }

        private void ObsTB_Leave(object sender, EventArgs e)
        {

        }

        private void ecoleTB_Leave(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "")
            {
                ((GunaTextBox)sender).Text = "Ecole";
            }
        }

        private void PrenomTB_Enter(object sender, EventArgs e)
        {

        }

        private void specialitetb_Enter(object sender, EventArgs e)
        {

        }

        private void ObsTB_Enter(object sender, EventArgs e)
        {

        }

        private void ecoleTB_Enter(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "Ecole")
            {
                ((GunaTextBox)sender).ResetText();
            }
        }

        private void stagiareAdd_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel1);
            Program.centercontrolV(panel1);
        }

        int N()
        {
            string sql = "select max(id) from stagiaire";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            int x = (int)cmd.ExecuteScalar();
            return x;
        }
        bool existname()
        {
            string sql = "select count(*) from stagiaire where nom like @nom and prenom like @prenom";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = nomTB.Text.Trim();
            cmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = PrenomTB.Text.Trim();
            int x = (int)cmd.ExecuteScalar();
            return x > 0;
        }

        int getLatestId()
        {
            string sql = "select max(id) from  stagiaire";
            SqlCommand cmd = new SqlCommand(sql, Program.con);

            if (!(cmd.ExecuteScalar().Equals(DBNull.Value)))
            {
                int x = (int)cmd.ExecuteScalar() + 1;

                return x;

            }
            else
            {
                return 1;
            }
        }
        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            if (existname())
            {
                if (Confirmationbox.ShowDialog("Ce nom de stagiaire est deja existe,vous vouler vraiment continue", true) == DialogResult.Cancel)
                {
                    return;
                }
            }
            string sql = "set IDENTITY_INSERT stagiaire ON insert into stagiaire (id,nom,prenom,specialite,du,au,ecole,observation,dateD,sexe) values(@id,@nom,@prenom,@spectialte,@datedebut,@datefin,@ecole,@observation,@dated,@sexe)";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Char).Value = getLatestId();
            cmd.Parameters.Add("@nom", SqlDbType.Char).Value = nomTB.Text;
            cmd.Parameters.Add("@prenom", SqlDbType.Char).Value = PrenomTB.Text;
            cmd.Parameters.Add("@spectialte", SqlDbType.Char).Value = specialitetb.Text;
            cmd.Parameters.Add("@datedebut", SqlDbType.Date).Value = DateDu.Value;
            cmd.Parameters.Add("@datefin", SqlDbType.Date).Value = DateAu1.Value;
            cmd.Parameters.Add("@ecole", SqlDbType.Char).Value = ecoleTB.Text;
            cmd.Parameters.Add("@observation", SqlDbType.Char).Value = ObsTB.Text;
            cmd.Parameters.Add("@dated", SqlDbType.Date).Value = DateDe.Value;
            cmd.Parameters.Add("@sexe", SqlDbType.Char).Value = (gunaRadioButton1.Checked ? "M" : "F");
            cmd.ExecuteNonQuery();
            MainMenu menu = (MainMenu)this.ParentForm;
            menu.fillcomboboxecole();
            MainMenu.insertnotif("Stagiaire Ajouter : " + PrenomTB.Text + " " + nomTB.Text + " N:" + N(), alertTypeEnum.Info.ToString());




            Confirmationbox.Show("Stagiaire bien Ajoute N:" + N());
        }

        private void nomTB_MouseEnter(object sender, EventArgs e)
        {

        }

        private void nomTB_Enter_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "Nom")
            {
                ((GunaTextBox)sender).ResetText();
            }

        }

        private void nomTB_Leave_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "")
            {
                ((GunaTextBox)sender).Text = "Nom";
            }
        }

        private void PrenomTB_Enter_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "Prenom")
            {
                ((GunaTextBox)sender).ResetText();
            }
        }

        private void PrenomTB_Leave_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "")
            {
                ((GunaTextBox)sender).Text = "Prenom";
            }
        }

        private void specialitetb_Enter_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "Specialite")
            {
                ((GunaTextBox)sender).ResetText();
            }
        }

        private void specialitetb_Leave_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "")
            {
                ((GunaTextBox)sender).Text = "Specialite";
            }
        }

        private void ObsTB_Enter_1(object sender, EventArgs e)
        {
            if (((GunaTextBox)sender).Text == "Observation")
            {
                ((GunaTextBox)sender).ResetText();
            }
        }

        private void ObsTB_Leave_1(object sender, EventArgs e)
        {

        }

        private void ecoleTB_Enter_1(object sender, EventArgs e)
        {

        }

        private void ecoleTB_Leave_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gunaAdvenceButton1.Checked = false;
        }

        private void gunaAdvenceButton1_Leave(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void gunaSeparator2_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DateDu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateDe_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateAu1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void DateAu1_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void DateDu_Validated(object sender, EventArgs e)
        {

        }

        private void DateDu_Leave(object sender, EventArgs e)
        {
            string x = DateDu.Value.Year.ToString() + "-" + DateDu.Value.Month.ToString() + "-" + DateTime.DaysInMonth(DateDu.Value.Year, DateDu.Value.Month).ToString();
            DateAu1.Value = DateTime.Parse(x);

        }
    }
}
