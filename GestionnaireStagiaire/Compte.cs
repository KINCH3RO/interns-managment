using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using System.Data.SqlClient;

namespace GestionnaireStagiaire
{
    public partial class Compte : UserControl
    {
        public Compte()
        {
            InitializeComponent();
        }

        private void Compte_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel3);
            Program.centercontrolV(panel3);
        }

        public void dark()
        {
            foreach (Control ctrl in panel3.Controls)
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
                    guna.OnHoverBaseColor = MainMenu.hoverdark;
                    guna.OnHoverForeColor = MainMenu.whitecolor;
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
                if (ctrl.GetType() == typeof(GunaRadioButton))
                {
                    GunaRadioButton guna = (GunaRadioButton)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;

                }






                this.BackColor = MainMenu.dark2;


            }



        }
        public void color(Color Maincolor)
        {
            gunaSeparator1.LineColor = Maincolor;

            gunaSeparator2.LineColor = Maincolor;
            gunaSeparator3.LineColor = Maincolor;
            gunaSeparator4.LineColor = Maincolor;



            gunaAdvenceButton2.BorderColor = Maincolor;
            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;





        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            string sql = "update userE set username=@username,mdp=@mdp,nom=@nom where id = @id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@username", SqlDbType.Char).Value = UsernameTB.Text;
            cmd.Parameters.Add("@nom", SqlDbType.Char).Value = FullnameTB.Text;
            if (cmdp1.Text== "Nouveau mot de passe")
            {
                cmd.Parameters.Add("@mdp", SqlDbType.Char).Value = mdp2.Text;


            }
            else
            {
                cmd.Parameters.Add("@mdp", SqlDbType.Char).Value = cmdp1.Text;

            }
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = LOGIN2.id;


            if (UsernameTB.Text!=LOGIN2.user)
            {
                if (userManagment.checkifusernameexist(UsernameTB.Text) == 0)
                {
                    if (mdp2.Text == tempmdp)
                    {
                        cmd.ExecuteNonQuery();
                        label1.Visible = false;
                        Confirmationbox.Show("Modification bien fait");
                    }
                    else
                    {
                        label1.Text = "mot de passe error"; label1.Visible = true;
                    }
                }
                else
                {
                    label1.Text = "Username exist";
                    label1.Visible = true;
                }

            }
            else
            {
                if (mdp2.Text == tempmdp)
                {
                    cmd.ExecuteNonQuery();
                    label1.Visible = false;
                    Confirmationbox.Show("Modification bien fait");
                }
                else
                {
                    label1.Text = "mot de passe error"; label1.Visible = true;
                }

            }


            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string tempmdp;
        private void Compte_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;

            }
            SqlCommand cmd =new SqlCommand("select * from userE where id =@id", Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = LOGIN2.id;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                FullnameTB.Text = dr.GetValue(3).ToString();
                UsernameTB.Text = dr.GetValue(1).ToString();
                tempmdp = dr.GetValue(2).ToString();
                
            }
            dr.Close();
        }
    }
}
