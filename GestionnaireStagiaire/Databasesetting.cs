using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionnaireStagiaire
{
    public partial class Databasesetting : UserControl
    {
        public Databasesetting()
        {
            InitializeComponent();
            textBox3.PasswordChar = '\u25cf';

        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaRadioButton2.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;

                textBox3.Enabled = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();


            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;

                textBox3.Enabled = true;


            }
        }
        public void load()
        {
            textBox1.Text = Properties.Settings.Default.ServerName;
            textBox2.Text = Properties.Settings.Default.Usernamedb;
            textBox3.Text = Properties.Settings.Default.password;
            gunaRadioButton1.Checked = Properties.Settings.Default.SQLA;
            if (gunaRadioButton2.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;

                textBox3.Enabled = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();


            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;

                textBox3.Enabled = true;


            }
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            LOGIN2 login = (LOGIN2)this.ParentForm;
            login.show();
        }

        private void Databasesetting_Load(object sender, EventArgs e)
        {
            load();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (gunaRadioButton1.Checked)
            {
                Properties.Settings.Default.ServerName = textBox1.Text;
                Properties.Settings.Default.Usernamedb = textBox2.Text;
                Properties.Settings.Default.password = textBox3.Text;

                Properties.Settings.Default.connectionstring="Data Source=" + Properties.Settings.Default.ServerName + "; Initial Catalog=stagiaire;Persist Security Info=True;User ID= " + Properties.Settings.Default.Usernamedb + ";Password=" + Properties.Settings.Default.password;
                Properties.Settings.Default.SQLA = gunaRadioButton1.Checked;
                Properties.Settings.Default.Save();

            }else
            
            {
                Properties.Settings.Default.connectionstring = "Data Source=" + Environment.MachineName+ @"\SQLEXPRESS;Initial Catalog=stagiaire;Integrated Security=True";
                Properties.Settings.Default.SQLA = gunaRadioButton1.Checked;
                Properties.Settings.Default.Save();

            }
            Program.conS = Properties.Settings.Default.connectionstring;
            MessageBox.Show("bien enregistré");
        }
    }

}
