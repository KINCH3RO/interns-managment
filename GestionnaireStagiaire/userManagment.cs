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
    public partial class userManagment : UserControl
    {
        public userManagment()
        {
            InitializeComponent();
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
                gunaDataGridView1.BackgroundColor = MainMenu.dark2;
                gunaDataGridView1.DefaultCellStyle.BackColor = MainMenu.dark2;
                gunaDataGridView1.DefaultCellStyle.ForeColor = MainMenu.whitecolor;
                gunaDataGridView1.DefaultCellStyle.SelectionBackColor = MainMenu.hoverdark;
                gunaDataGridView1.DefaultCellStyle.SelectionForeColor = MainMenu.whitecolor;

                gunaDataGridView1.AlternatingRowsDefaultCellStyle.BackColor = MainMenu.dark2;
                gunaDataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = MainMenu.whitecolor;
                gunaDataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor = MainMenu.hoverdark;
                gunaDataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor = MainMenu.whitecolor;

            }

        }
        public void color(Color Maincolor)
        {
            gunaSeparator1.LineColor = Maincolor;

            gunaSeparator2.LineColor = Maincolor;
            gunaSeparator3.LineColor = Maincolor;
            gunaSeparator4.LineColor = Maincolor;


            gunaRadioButton1.CheckedOnColor = Maincolor;
            gunaRadioButton2.CheckedOnColor = Maincolor;
            gunaRadioButton3.CheckedOnColor = Maincolor;
            gunaAdvenceButton1.BorderColor = Maincolor;
            gunaAdvenceButton1.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton1.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton2.BorderColor = Maincolor;
            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton3.BorderColor = Maincolor;
            gunaAdvenceButton3.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton3.OnHoverBorderColor = Maincolor;
            gunaDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Maincolor;




        }



        private void userManagment_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            filldg();

            gunaRadioButton1.Checked = true;
        }
        void filldg()
        {

            SqlCommand cmd = new SqlCommand("select * from userE where nom not like @name", Program.con);
            cmd.Parameters.Add("@name", SqlDbType.Char).Value = LOGIN2.name;

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            gunaDataGridView1.DataSource = dt;


        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FullnameTB.Text = gunaDataGridView1.CurrentRow.Cells[3].Value.ToString();
            UsernameTB.Text = gunaDataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {


        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            string sql = "insert into userE values(@username,@mdp,@nom,@adm)";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@username", SqlDbType.Char).Value = UsernameTB.Text;
            cmd.Parameters.Add("@nom", SqlDbType.Char).Value = FullnameTB.Text;
            cmd.Parameters.Add("@mdp", SqlDbType.Char).Value = mdp2.Text;
            if (gunaRadioButton1.Checked)
            {
                cmd.Parameters.Add("@adm", SqlDbType.Char).Value = gunaRadioButton1.Text;
            }
            else if (gunaRadioButton2.Checked)
            {
                cmd.Parameters.Add("@adm", SqlDbType.Char).Value = gunaRadioButton2.Text;

            }
            else if (gunaRadioButton3.Checked)
            {
                cmd.Parameters.Add("@adm", SqlDbType.Char).Value = gunaRadioButton3.Text;

            }

            if (checkifusernameexist(UsernameTB.Text) == 0)
            {
                if (mdp2.Text == cmdp1.Text)
                {
                    cmd.ExecuteNonQuery();
                    label1.Visible = false;
                }
                else
                {
                    label1.Text = "mot de passe error";
                    label1.Visible = true;
                }
            }
            else
            {
                label1.Text = "Username exist";
                label1.Visible = true;
            }


            filldg();
            Confirmationbox.Show("Ajout bien fait");
        }
        public static int checkifusernameexist(string y)
        {

            string sql = "select count(*)  from userE where username=@username ";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@username", SqlDbType.Char).Value = y;
            int x = (int)cmd.ExecuteScalar();
            return x;


        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton3_Click_1(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            string sql = "delete from userE where id like @id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);

            cmd.Parameters.Add("@id", SqlDbType.Char).Value = gunaDataGridView1.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("vous vouler vraiment supprimer ce compte", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                cmd.ExecuteNonQuery();
            }

            filldg();
            Confirmationbox.Show("Ajout bien fait");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel3);
            Program.centercontrolV(panel3);
        }

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            string sql = "update userE set username=@username,mdp=@mdp,nom=@nom,admintype=@adm where id = @id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@username", SqlDbType.Char).Value = UsernameTB.Text;
            cmd.Parameters.Add("@nom", SqlDbType.Char).Value = FullnameTB.Text;
            cmd.Parameters.Add("@mdp", SqlDbType.Char).Value = mdp2.Text;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = gunaDataGridView1.CurrentRow.Cells[0].Value;
            if (gunaRadioButton1.Checked)
            {
                cmd.Parameters.Add("@adm", SqlDbType.Char).Value = gunaRadioButton1.Text;
            }
            else if (gunaRadioButton2.Checked)
            {
                cmd.Parameters.Add("@adm", SqlDbType.Char).Value = gunaRadioButton2.Text;

            }
            else if (gunaRadioButton3.Checked)
            {
                cmd.Parameters.Add("@adm", SqlDbType.Char).Value = gunaRadioButton3.Text;

            }

            if (UsernameTB.Text != gunaDataGridView1.CurrentRow.Cells[1].Value.ToString())
            {
                if (checkifusernameexist(UsernameTB.Text) == 0)
                {
                    if (mdp2.Text == cmdp1.Text)
                    {
                        cmd.ExecuteNonQuery();
                        label1.Visible = false;
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
                if (mdp2.Text == cmdp1.Text)
                {
                    cmd.ExecuteNonQuery();
                    label1.Visible = false;
                }
                else
                {
                    label1.Text = "mot de passe error";
                    label1.Visible = true;
                }

            }
            Confirmationbox.Show("Modification bien fait");


            filldg();

        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MainMenu.resettimer();

            FullnameTB.Text = gunaDataGridView1.CurrentRow.Cells[3].Value.ToString();
            UsernameTB.Text = gunaDataGridView1.CurrentRow.Cells[1].Value.ToString();
            mdp2.Text = gunaDataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmdp1.Text = gunaDataGridView1.CurrentRow.Cells[2].Value.ToString();

            if (gunaRadioButton1.Text == "Admin")
            {
                gunaRadioButton1.Checked = true;


            }
            else if (gunaRadioButton2.Text == "Mini Admin")
            {
                gunaRadioButton2.Checked = true;
            }
            else if (gunaRadioButton3.Text == "Non Admin")
            {
                gunaRadioButton3.Checked = true;
            }
        }

        private void cmdp1_Enter(object sender, EventArgs e)
        {
            mdp2.PasswordChar = '\u25cf';
            cmdp1.PasswordChar = '\u25cf';


        }
    }
}
