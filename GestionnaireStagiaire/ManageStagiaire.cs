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
    public partial class ManageStagiaire : UserControl
    {

        public ManageStagiaire()
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
        private void ManageStagiaire_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            string[] service = { "S.Personnel","Gestion des stocks","Informatique","Amont agricole","ASSISTANTE Direction SUTA","Atelier électrique","Atelier mécanique","Atelier régulation","Conditionnement","CONTROLE DE GESTION","CRISTALLISATION","Extraction","Laboratoire","VENTES USINE"};

            ServiceComboBox.Items.AddRange(service);

        }
        public void loaddata(int x)
        {
            ServiceComboBox.SelectedIndex = -1;
            SqlCommand cmd = new SqlCommand("select * from stagiaire where id = @id",Program.con);
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
               Datedepot.Value = (DateTime)dr.GetValue(8);
                if (dr.GetValue(9).ToString()=="M")
                {
                    gunaRadioButton1.Checked = true;
                   

                }
                else
                {
                    gunaRadioButton2.Checked = true;
                }
            }
            dr.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "select service from acc where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = x;
             dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ServiceComboBox.Text = dr.GetValue(0).ToString();
                dr.Close();
            }

        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            MainMenu.resettimer();
            MainMenu.insertnotif("Stagiaire modifier : " + PrenomTB.Text + " " + nomTB.Text + " N:" + numLbl.Text, alertTypeEnum.Info.ToString());

            string sql = "update stagiaire set nom=@nom,prenom=@prenom,specialite=@spectialte,Du=@datedebut,Au=@datefin,ecole=@ecole,observation=@observation,dateD=@dated,sexe=@sexe where id = @id";
            SqlCommand cmd = new SqlCommand(sql,Program.con);
            cmd.Parameters.Add("@nom", SqlDbType.Char).Value = nomTB.Text;
            cmd.Parameters.Add("@prenom", SqlDbType.Char).Value = PrenomTB.Text;
            cmd.Parameters.Add("@spectialte", SqlDbType.Char).Value = specialitetb.Text;
            cmd.Parameters.Add("@datedebut", SqlDbType.Date).Value = DateDu.Value;
            cmd.Parameters.Add("@datefin", SqlDbType.Date).Value = DateAu1.Value;
            cmd.Parameters.Add("@ecole", SqlDbType.Char).Value = ecoleTB.Text;
            cmd.Parameters.Add("@observation", SqlDbType.Char).Value = ObsTB.Text;
            cmd.Parameters.Add("@dated", SqlDbType.Date).Value = Datedepot.Value;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.Parameters.Add("@sexe", SqlDbType.Char).Value = (gunaRadioButton1.Checked ? "M" : "F");
            cmd.ExecuteNonQuery();
            
            
            string sql1 = "update acc set nom=@nom,prenom=@prenom,specialite=@spectialte,Du=@datedebut,Au=@datefin,ecole=@ecole,service=@service,observation=@observation,dateD=@dated,sexe=@sexe where id = @id";
            SqlCommand cmd1 = new SqlCommand(sql1,Program.con);
            cmd1.Parameters.Add("@nom", SqlDbType.Char).Value = nomTB.Text;
            cmd1.Parameters.Add("@prenom", SqlDbType.Char).Value = PrenomTB.Text;
            cmd1.Parameters.Add("@spectialte", SqlDbType.Char).Value = specialitetb.Text;
            cmd1.Parameters.Add("@datedebut", SqlDbType.Date).Value = DateDu.Value;
            cmd1.Parameters.Add("@datefin", SqlDbType.Date).Value = DateAu1.Value;
            cmd1.Parameters.Add("@ecole", SqlDbType.Char).Value = ecoleTB.Text;
            cmd1.Parameters.Add("@observation", SqlDbType.Char).Value = ObsTB.Text;
            cmd1.Parameters.Add("@dated", SqlDbType.Date).Value = Datedepot.Value;
            cmd1.Parameters.Add("@service", SqlDbType.Char).Value = ServiceComboBox.Text;


            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd1.Parameters.Add("@sexe", SqlDbType.Char).Value = (gunaRadioButton1.Checked ? "M" : "F");
            cmd1.ExecuteNonQuery();


            MainMenu menu = (MainMenu)this.ParentForm;
            menu.fillcomboboxecole();
            menu.fillcomboboxspecialité();
            Confirmationbox.Show("Stagiaire bien enregistré");

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {

            
            string sql = "DELETE from stagiaire where id = @id";
            SqlCommand cmd = new SqlCommand(sql,Program.con);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;

            cmd.ExecuteNonQuery();

            MainMenu menu = (MainMenu)this.ParentForm;
            menu.showlist();
            menu.fillcomboboxecole();
            menu.fillcomboboxspecialité();
            MessageBox.Show("suppresion bien fait");
        }
        bool maxstg()
        {
            string sql = "select count(*) from acc where month(du) = month(@date)";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateDu.Value;
            int x =(int)cmd.ExecuteScalar();
            if (x>=Setting.getmaxnbrstg())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            if (checkIFEXIST(int.Parse(numLbl.Text))>0)
            {
                Confirmationbox.Show("ce stagiaire est deja accepté");
                gunaAdvenceButton1.Checked = false;
                return;
            }
            if (maxstg())
            {
                Confirmationbox.Show("le nombre maximum des stagiaire par moi est " + Setting.getmaxnbrstg());

                return;
            }
            string sql = @"insert into acc (id,nom,prenom,specialite,du,Au,ecole,observation,dateD,Service,sexe)
                         select id,nom,prenom,specialite,du,Au,ecole,observation,dateD,@Service,sexe
                         from stagiaire
                        where id = @id";
            SqlCommand cmd = new SqlCommand(sql,Program.con);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.Parameters.Add("@Service", SqlDbType.Char).Value = ServiceComboBox.Text;


            cmd.ExecuteNonQuery();
            
            accInfo();
            Confirmationbox.Show("Stagiaire bien accepté");
            MainMenu menu = (MainMenu)this.ParentForm;
            menu.showlist();
            menu.loadback(menu.scroll, menu.selectedrow);
            MainMenu.insertnotif("Stagiaire Accepté : " + PrenomTB.Text + " " + nomTB.Text+"N :"+ numLbl.Text, alertTypeEnum.Success.ToString());

        }
        void accInfo()
        {
            string info = LOGIN2.name + " " + DateTime.Now.ToString(); 
            
            SqlCommand cmd = new SqlCommand("insert into accinfo values (@id,@info,@N)",Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = numLbl.Text;
            cmd.Parameters.Add("@info", SqlDbType.VarChar).Value = info;
            cmd.Parameters.Add("@N", SqlDbType.VarChar).Value = "N";
            cmd.ExecuteNonQuery();
            



        }
        int checkIFEXIST(int x)
        {
            
            string sql = "select count(*) from acc where id =@id";
            SqlCommand cmd = new SqlCommand(sql,Program.con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = x;
            int z = (int)cmd.ExecuteScalar();
            
            return z;
    

        }

        private void ManageStagiaire_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel1);
            Program.centercontrolV(panel1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            Datedepot.FocusedColor = Maincolor;
            Datedepot.OnHoverBorderColor = Maincolor;
            Datedepot.OnHoverForeColor = Maincolor;
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
            gunaAdvenceButton2.BorderColor = Maincolor;

            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;

            ServiceComboBox.OnHoverItemBaseColor = Maincolor;

        }

        private void gunaAdvenceButton3_Click_1(object sender, EventArgs e)
        {
            MainMenu menu = (MainMenu)this.ParentForm;
            menu.showlist();
            menu.loadback(menu.scroll,menu.selectedrow);
            

        }
    }
}
