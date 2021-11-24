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
using System.IO;

namespace GestionnaireStagiaire
{
    public partial class LP_AS : UserControl
    {
        public LP_AS()
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
                if (ctrl.GetType() == typeof(GunaRadioButton))
                {
                    GunaRadioButton guna = (GunaRadioButton)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;

                }
                if (ctrl.GetType() == typeof(GunaComboBox))
                {
                    GunaComboBox guna = (GunaComboBox)ctrl;
                    guna.ForeColor = MainMenu.whitecolor;
                    guna.BaseColor = MainMenu.dark2;

                }



            }
        }

        public void color(Color Maincolor)
        {
            gunaSeparator1.LineColor = Maincolor;

            gunaSeparator2.LineColor = Maincolor;
            gunaSeparator3.LineColor = Maincolor;
            gunaSeparator7.LineColor = Maincolor;
            gunaSeparator8.LineColor = Maincolor;
            DateAu1.FocusedColor = Maincolor;
            DateAu1.OnHoverBorderColor = Maincolor;
            DateAu1.OnHoverForeColor = Maincolor;
            DateDu.FocusedColor = Maincolor;
            DateDu.OnHoverBorderColor = Maincolor;
            DateDu.OnHoverForeColor = Maincolor;

            gunaRadioButton1.CheckedOnColor = Maincolor;
            gunaRadioButton2.CheckedOnColor = Maincolor;
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

            gunaRadioButton1.ForeColor = MainMenu.whitecolor;
            gunaRadioButton2.ForeColor = MainMenu.whitecolor;

        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {







        }
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {


        }

        private void manageAccSTG_SizeChanged(object sender, EventArgs e)
        {
            Program.centercontrolH(panel1);
            Program.centercontrolV(panel1);

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {



        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            word w = new word();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string filename = path + @"\GSMODELS\LAISSEZPASSER.docx";

            SaveFileDialog f2 = new SaveFileDialog();
            f2.Filter = "Word file |*.Docx";

            string nom = nomTB.Text;
            string prenom = PrenomTB.Text;
            string service = ServiceComboBox.Text;
            string Du = DateDu.Value.ToShortDateString();
            string au = DateAu1.Value.ToShortDateString();
            string n = numLbl.Text;

            string date = DateTime.Now.ToShortDateString();

            string[] tofind = { "<date>", "<nom>", "<prenom>", "<du>", "<au>", "<service>", "<nu>" };
            string[] toreplace = { date, nom, prenom, Du, au, service, n };
            f2.FileName = "LaisserPasser du " + nom + prenom;

            MainMenu menu = (MainMenu)this.ParentForm;
            if (menu.nbfichier > 0)
            {
                Confirmationbox.ShowDialog("il ya deja un fichier est en cours d'exportation", true);
                return;
            }
            if (f2.ShowDialog() == DialogResult.OK)
            {
                string x = Path.GetFileNameWithoutExtension(f2.FileName);

                if (Program.checkifprocessalreadyopned(x))
                {
                    Confirmationbox.Show("Fichier deja ouvert");
                    return;
                }
                if (Confirmationbox.ShowDialog("vous voulez imprimer ce document", true) == DialogResult.OK)
                {
                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, true, 1, pr));

                    menu.nbfichier -= 1;

                }
                else
                {
                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, false, 0, pr));

                    menu.nbfichier -= 1;

                }
                Confirmationbox.ShowDialog("Operation complet", true);
                System.Diagnostics.Process.Start(f2.FileName);


            }
        }

        private async void gunaAdvenceButton3_Click_1(object sender, EventArgs e)
        {
            word w = new word();
            string filename = "";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (gunaRadioButton1.Checked)
            {
                filename = path + @"\GSMODELS\AttestationdestageM.docx";
            }
            else
            {
                filename = path + @"\GSMODELS\AttestationdestageF.docx";
            }

            SaveFileDialog f2 = new SaveFileDialog();
            f2.Filter = "Word file |*.Docx";


            string nom = nomTB.Text;
            string prenom = PrenomTB.Text;
            string service = ServiceComboBox.Text;
            string Du = DateDu.Value.ToShortDateString();
            string au = DateAu1.Value.ToShortDateString();
            string n = numLbl.Text;

            string name = nom + " " + prenom;
            string date = DateTime.Now.ToShortDateString();
            string y = DateTime.Now.ToString("yy");

            string[] tofind = { "<date>", "<name>", "<Du>", "<Au>", "<y>" };
            string[] toreplace = { date, name, Du, au, y };
            f2.FileName = "Attestation de stage du " + name;

            MainMenu menu = (MainMenu)this.ParentForm;
            if (menu.nbfichier > 0)
            {
                Confirmationbox.ShowDialog("il ya deja un fichier est en cours d'exportation", true);
                return;
            }
            if (f2.ShowDialog() == DialogResult.OK)
            {
                string x = Path.GetFileNameWithoutExtension(f2.FileName);

                if (Program.checkifprocessalreadyopned(x))
                {
                    Confirmationbox.Show("Fichier eja ouvert");
                }
                if (Confirmationbox.ShowDialog("vous voulez imprimer ce document", true) == DialogResult.OK)
                {

                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, true, 2, pr));

                    menu.nbfichier -= 1;



                }
                else
                {
                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, false, 0, pr));

                    menu.nbfichier -= 1;


                    System.Diagnostics.Process.Start(f2.FileName);
                }
                Confirmationbox.Show("Operation complet");

            }
        }
    }
}