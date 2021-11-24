using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionnaireStagiaire.Properties;
using System.Windows.Forms;
using System.Runtime.InteropServices;
public enum alertTypeEnum
{
    Success,
    Warning,
    Error,
    Info
}
namespace GestionnaireStagiaire
{
    public partial class frmAlert : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


        public frmAlert()
        {
            InitializeComponent();
        }
        private void frmAlert_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            if (Properties.Settings.Default.notifS)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.notifsound);
                player.Play();


            }

        }
        public static  void Alert(string msg,string msg2, frmAlert.alertTypeEnum type)
        {
            frmAlert f = new frmAlert();
            f.setAlert(msg,msg2, type);
        }
        public enum alertTypeEnum
        {
            Success,
            Warning,
            Error,
            Info
        }

        private int x, y;
        public void setAlert(string msg,string msg2, frmAlert.alertTypeEnum type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                frmAlert f = (frmAlert)Application.OpenForms[fname];

                if (f == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            switch (type)
            {
                case frmAlert.alertTypeEnum.Success:
                    this.GunaPictureBox1.Image = Resources.Checkmark_28px;
                    this.BackColor = Color.FromArgb(42, 171, 160);
                    break;
                case frmAlert.alertTypeEnum.Warning:
                    this.GunaPictureBox1.Image = Resources.Warning_28px;
                    this.BackColor = Color.FromArgb(255, 179, 2);
                    break;
                case frmAlert.alertTypeEnum.Error:
                    this.GunaPictureBox1.Image = Resources.Error_28px;
                    this.BackColor = Color.FromArgb(255, 121, 70);
                    break;
                case frmAlert.alertTypeEnum.Info:
                    this.GunaPictureBox1.Image = Resources.Info_28px;
                    this.BackColor = Color.FromArgb(71, 169, 248);
                    break;
            }
            this.GunaLabel1.Text = msg;
            this.gunaLabel2.Text = msg2;

            this.TopMost = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.Show();
            this.action = actionEnum.start;
            this.Timer1.Interval = 1;
            this.Timer1.Start();


        }

        public enum actionEnum
        {
            wait,
            start,
            close
        }

        private frmAlert.actionEnum action;


        private void GunaPictureBox2_Click(object sender, EventArgs e)
        {
            this.Timer1.Interval = 1;
            this.action = frmAlert.actionEnum.close;
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case frmAlert.actionEnum.wait:
                    this.Timer1.Interval = 5000;
                    if (Properties.Settings.Default.autoclose)
                    {
                        this.action = frmAlert.actionEnum.close;

                    }
                    break;
                case frmAlert.actionEnum.start:
                    this.Timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            this.action = frmAlert.actionEnum.wait;
                        }
                    }
                    break;
                case frmAlert.actionEnum.close:
                    this.Timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }


        }

        private void GunaPictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void GunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            //this.Timer1.Interval = 1;
            this.action = frmAlert.actionEnum.close;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }

    }
}
