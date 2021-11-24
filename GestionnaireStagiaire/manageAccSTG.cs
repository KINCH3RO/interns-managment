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
    public partial class manageAccSTG : UserControl
    {
        public manageAccSTG()
        {
            InitializeComponent();
        }
        public void dark(bool dark)
        {
            this.BackColor = MainMenu.dark2;
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


            }
        }

        public void color(Color Maincolor)
        {
            gunaSeparator1.LineColor = Maincolor;

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
            gunaAdvenceButton4.BorderColor = Maincolor;
            gunaAdvenceButton4.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton4.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton2.BorderColor = Maincolor;
            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton3.BorderColor = Maincolor;
            gunaAdvenceButton3.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton3.OnHoverBorderColor = Maincolor;


            ServiceComboBox.OnHoverItemBaseColor = Maincolor;

        }


        private void manageAccSTG_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            string[] service = { "S.Personnel", "Gestion des stocks", "Informatique", "Amont agricole", "ASSISTANTE Direction SUTA", "Atelier électrique", "Atelier mécanique", "Atelier régulation", "Conditionnement", "CONTROLE DE GESTION", "CRISTALLISATION", "Extraction", "Laboratoire", "VENTES USINE" };
            ServiceComboBox.Items.AddRange(service);


        }
        public void loaddata(int x)
        {

            SqlCommand cmd = new SqlCommand("select * from acc where id = @id", Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = x;
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {
                numLbl.Text = dr.GetValue(0).ToString();
                nomTB.Text = dr.GetValue(1).ToString();

                PrenomTB.Text = dr.GetValue(2).ToString();
                specialitetb.Text = dr.GetValue(3).ToString();
                DateDu.Value = (DateTime)dr.GetValue(4);
                DateAu1.Value = (DateTime)dr.GetValue(5);
                ecoleTB.Text = dr.GetValue(6).ToString();
                ObsTB.Text = dr.GetValue(7).ToString();
                DateDe.Value = (DateTime)dr.GetValue(8);
                ServiceComboBox.Text = dr.GetValue(9).ToString();
                if (dr.GetValue(10).ToString() == "M")
                {
                    gunaRadioButton1.Checked = true;
                }
                else
                {
                    gunaRadioButton2.Checked = true;
                }
            }
            dr.Close();
            Readinfo();
        }
        void accInfo()
        {
            string info = LOGIN2.name + " " + DateTime.Now.ToString();

            SqlCommand cmd = new SqlCommand("update accinfo set info=@info where id=@id", Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.Parameters.Add("@info", SqlDbType.VarChar).Value = info;
            cmd.ExecuteNonQuery();




        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            MainMenu.insertnotif("Stagiaire modifier : " + PrenomTB.Text + " " + nomTB.Text + " N:" + numLbl.Text, alertTypeEnum.Info.ToString());

            string sql = "update acc set nom=@nom,prenom=@prenom,specialite=@spectialte,Du=@datedebut,Au=@datefin,ecole=@ecole,observation=@observation,dateD=@dated,Service=@service,sexe=@sexe where id = @id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@nom", SqlDbType.Char).Value = nomTB.Text;
            cmd.Parameters.Add("@prenom", SqlDbType.Char).Value = PrenomTB.Text;
            cmd.Parameters.Add("@spectialte", SqlDbType.Char).Value = specialitetb.Text;
            cmd.Parameters.Add("@datedebut", SqlDbType.Date).Value = DateDu.Value;
            cmd.Parameters.Add("@datefin", SqlDbType.Date).Value = DateAu1.Value;
            cmd.Parameters.Add("@ecole", SqlDbType.Char).Value = ecoleTB.Text;
            cmd.Parameters.Add("@observation", SqlDbType.Char).Value = ObsTB.Text;
            cmd.Parameters.Add("@dated", SqlDbType.Date).Value = DateDe.Value;
            cmd.Parameters.Add("@service", SqlDbType.Char).Value = ServiceComboBox.Text;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.Parameters.Add("@sexe", SqlDbType.Char).Value = (gunaRadioButton1.Checked ? "M" : "F");
            cmd.ExecuteNonQuery();






            string sql1 = "update stagiaire set nom=@nom,prenom=@prenom,specialite=@spectialte,Du=@datedebut,Au=@datefin,ecole=@ecole,observation=@observation,dateD=@dated,sexe=@sexe where id = @id";
            SqlCommand cmd1 = new SqlCommand(sql1, Program.con);
            cmd1.Parameters.Add("@nom", SqlDbType.Char).Value = nomTB.Text;
            cmd1.Parameters.Add("@prenom", SqlDbType.Char).Value = PrenomTB.Text;
            cmd1.Parameters.Add("@spectialte", SqlDbType.Char).Value = specialitetb.Text;
            cmd1.Parameters.Add("@datedebut", SqlDbType.Date).Value = DateDu.Value;
            cmd1.Parameters.Add("@datefin", SqlDbType.Date).Value = DateAu1.Value;
            cmd1.Parameters.Add("@ecole", SqlDbType.Char).Value = ecoleTB.Text;
            cmd1.Parameters.Add("@observation", SqlDbType.Char).Value = ObsTB.Text;
            cmd1.Parameters.Add("@dated", SqlDbType.Date).Value = DateDe.Value;
            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd1.Parameters.Add("@sexe", SqlDbType.Char).Value = (gunaRadioButton1.Checked ? "M" : "F");
            cmd1.ExecuteNonQuery();



            MainMenu menu = (MainMenu)this.ParentForm;
            menu.fillcomboboxecole();
            menu.fillcomboboxspecialité();
            accInfo();
            Readinfo();

            Confirmationbox.Show("Stagiaire bien enregistré");

        }
        void Readinfo()
        {

            SqlCommand cmd = new SqlCommand("select info from accinfo where id = @id", Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                gunaLabel3.Text = dr.GetValue(0).ToString();


            }
            dr.Close();




        }
        void deleteinfo()
        {

            string sql = "delete from accinfo where id = @id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.ExecuteNonQuery();

        }
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            deleteinfo();

            string sql = "delete from acc where id = @id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.ExecuteNonQuery();

            MainMenu menu = (MainMenu)this.ParentForm;

            menu.showlist2();
            menu.loadback2(menu.scroll, 0);

            menu.fillcomboboxecole();
            menu.fillcomboboxspecialité();
            gunaAdvenceButton3.Checked = false;
            Confirmationbox.Show("supression bien fait");
            MainMenu.insertnotif("Stagiaire Supprimer : " + PrenomTB.Text + " " + nomTB.Text + " N:" + numLbl.Text, alertTypeEnum.Warning.ToString());


        }

        private void manageAccSTG_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel1);
            Program.centercontrolV(panel1);
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            MainMenu menu = (MainMenu)this.ParentForm;
           
            menu.showlist2();
            menu.loadback2(menu.scroll, menu.selectedrow);


        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {

            string sql = "update accinfo set etat=@etat where id =@id ";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.Parameters.Add("@etat", SqlDbType.Char).Value = "N";
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                Confirmationbox.Show("Cleared");

            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
