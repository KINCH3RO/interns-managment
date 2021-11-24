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

namespace GestionnaireStagiaire
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
        public void dark()
        {
            this.BackColor = MainMenu.dark2;
            foreach  (Control x in this.Controls)
            {
                if (x.GetType()==typeof(GunaLabel))
                {
                    x.ForeColor = MainMenu.whitecolor;

                }
            }
        }

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kinchero1.github.io/KINCH/");

        }
    }
}
