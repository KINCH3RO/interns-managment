using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionnaireStagiaire
{
    public partial class Confirmationbox : Form
    {
        public static Color maincolor;
        public Confirmationbox(string value)
        {
            InitializeComponent();
            panel1.BackColor = Properties.Settings.Default.appcolor;
            this.BackColor = MainMenu.dark2;
            gunaLabel1.ForeColor = MainMenu.whitecolor;
            gunaControlBox1.IconColor = MainMenu.whitecolor;

            gunaLabel1.Text = value;
           

        }
        

        private void Confirmationbox_Load(object sender, EventArgs e)
        {
            gunaAdvenceButton1.Focus();
            gunaAnimateWindow1.Start();

            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
        }
        public static DialogResult ShowDialog(string value,bool boxbutton)
        {
            Confirmationbox box = new Confirmationbox(value);

            if (boxbutton)
            {
                box.gunaAdvenceButton1.Visible = false;
                box.gunaAdvenceButton2.Visible = true;
                box.gunaAdvenceButton3.Visible = true;
            }
            else
            {
                box.gunaAdvenceButton1.Visible = true;
                box.gunaAdvenceButton2.Visible = false;
                box.gunaAdvenceButton3.Visible = false;

            }
           
            
            box.ShowDialog();
            return box.DialogResult;

        }
        public static void Show(string value)
        {
            Confirmationbox box = new Confirmationbox(value);
            box.gunaAdvenceButton2.Visible = false;
            box.gunaAdvenceButton3.Visible = false;
            box.Show();

        }


        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
