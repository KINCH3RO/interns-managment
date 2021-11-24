using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;

namespace GestionnaireStagiaire
{
    static class Program
    {
       public static void checknewversion()
        {
            WebClient web = new WebClient();
            if (web.DownloadString("https://pastebin.com/raw/fLKV6cKn")!="1.0")
            {
                
                if (MessageBox.Show("New Version available ,do want to download it","Update",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://kinch3ro.weebly.com/apps.html");
                    
                }
                else
                {

                }
                
            }
             
        }
        public static void centercontrolH(Control ctrl)
        {
            ctrl.Left = (ctrl.Parent.Width - ctrl.Width) / 2;
        }
        public static void centercontrolV(Control ctrl)
        {
            ctrl.Top = (ctrl.Parent.Height - ctrl.Height) / 2;
        }
        public static string conS = Properties.Settings.Default.connectionstring;
        public static SqlConnection con = new SqlConnection(conS);
        public static LOGIN2 x;
        public static void showlogin()
        {
            x.Show();

        }

        public static void hidelogin()
        {
            x.Hide();

        }
        
        public static void showmainmenu()
        {
            MainMenu m = new MainMenu();
            m.Show();

        }
        public static bool checkifprocessalreadyopned(string title)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.Contains(title))
                {
                    return true;
                }
            }
            return false;
        }

        private static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main()
        {
            string app = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            bool creatednew;
            mutex = new Mutex(true, app, out creatednew);

            if (!creatednew)
            {
                MessageBox.Show("l'application est deja ouvert");
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LOGIN2());

        }
    }
}
