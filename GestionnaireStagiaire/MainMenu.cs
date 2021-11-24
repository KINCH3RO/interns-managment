using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI.WinForms;
using System.Reflection;


namespace GestionnaireStagiaire
{
    public partial class MainMenu : Form
    {

        public DataTable tempdt;
        public string selectedyear;
        bool menuDisplayed = true;
        int x = 205;
        public int Stnumber = 0;
        public static Color dark1 = Color.FromArgb(42, 42, 42);
        public static Color dark2 = Color.FromArgb(34, 34, 34);
        public static Color hoverdark = Color.FromArgb(56, 56, 56);
        public static Color whitecolor = Color.White;

        public void minimize(bool systemtray)
        {

            notifyIcon1.Visible = systemtray;
            gunaControlBox1.CustomClick = systemtray;

        }

        public void color(Color maincolor)
        {
            gunaPanel1.BackColor = maincolor;
            gunaAdvenceButton7.BaseColor = maincolor;
            tabButton.BaseColor = maincolor;

            tabButton.BaseColor = maincolor;
            stagiareAdd1.color(maincolor);
            listStagiaire1.color(maincolor);
            manageStagiaire1.color(maincolor);
            listStagiaireAcc1.color(maincolor);
            manageAccSTG1.color(maincolor);
            summary1.color(maincolor);
            userManagment1.color(maincolor);
            setting1.color(maincolor);
            lP_AS1.color(maincolor);
            compte1.color(maincolor);
            Servicecombobox.OnHoverItemBaseColor = maincolor;
            accCombobox.OnHoverItemBaseColor = maincolor;
            Demandecombobox.OnHoverItemBaseColor = maincolor;
            Year.OnHoverItemBaseColor = maincolor;
            Year2.OnHoverItemBaseColor = maincolor;
            SpecialitéCombobox.OnHoverItemBaseColor = maincolor;

            SchoolComboBox.OnHoverItemBaseColor = maincolor;
            month.OnHoverItemBaseColor = maincolor;
            gunaDateTimePicker1.FocusedColor = maincolor;
            gunaDateTimePicker1.OnHoverBorderColor = maincolor;
            gunaDateTimePicker1.OnHoverForeColor = maincolor;


        }
        public MainMenu()
        {
            InitializeComponent();
            SettingPanel.SendToBack();
            progresspanel.Visible = false;
            gunaProgressBar1.Visible = false;
            gunaProgressBar1.Parent = MainPanel;
            color(Properties.Settings.Default.appcolor);

            dashboard1.BringToFront();


            gunaAdvenceButton1.Click += new EventHandler(displayname);
            gunaAdvenceButton2.Click += new EventHandler(displayname);
            gunaAdvenceButton3.Click += new EventHandler(displayname);
            gunaAdvenceButton4.Click += new EventHandler(displayname);
            gunaAdvenceButton5.Click += new EventHandler(displayname);
            gunaAdvenceButton11.Click += new EventHandler(displayname);
            gunaAdvenceButton8.Click += new EventHandler(displayname);
            gunaAdvenceButton9.Click += new EventHandler(displayname);
            gunaAdvenceButton1.Tag = gunaAdvenceButton1.Image;
            gunaAdvenceButton2.Tag = gunaAdvenceButton2.Image;

            gunaAdvenceButton3.Tag = gunaAdvenceButton3.Image;

            gunaAdvenceButton4.Tag = gunaAdvenceButton4.Image;
            gunaAdvenceButton5.Tag = gunaAdvenceButton5.Image;
            gunaAdvenceButton6.Tag = gunaAdvenceButton6.Image;
            gunaAdvenceButton7.Tag = gunaAdvenceButton7.Image;
            gunaAdvenceButton8.Tag = gunaAdvenceButton8.Image;
            gunaAdvenceButton9.Tag = gunaAdvenceButton9.Image;
            gunaAdvenceButton10.Tag = gunaAdvenceButton10.Image;
            gunaAdvenceButton11.Tag = gunaAdvenceButton11.Image;
            gunaAdvenceButton12.Tag = gunaAdvenceButton12.Image;
            gunaAdvenceButton13.Tag = gunaAdvenceButton13.Image;





        }
        public void darkmode(bool dark)
        {
            if (dark)
            {
                dark1 = Color.FromArgb(42, 42, 42);
                dark2 = Color.FromArgb(34, 34, 34);
                hoverdark = Color.FromArgb(56, 56, 56);
                whitecolor = Color.White;
                tabButton.CheckedImage = tabButton.Image;

            }
            else
            {
                dark1 = Color.FromArgb(235, 239, 242);
                dark2 = Color.White;
                hoverdark = Color.FromArgb(231, 229, 255);
                whitecolor = Color.Black;
                tabButton.CheckedImage = Properties.Resources.icons8_menu_26px_1;
            }



            tabButton.CheckedBaseColor = dark1;
            menupanel.BackColor = dark1;
            SettingPanel.BackColor = dark1;
            gunaSeparator1.LineColor = Color.Silver;
            gunaSeparator2.LineColor = Color.Silver;

            gunaSeparator3.LineColor = Color.Silver;
            this.BackColor = dark2;
            gunaLabel1.ForeColor = whitecolor;
            Servicecombobox.BaseColor = dark2;
            accCombobox.BaseColor = dark2;
            Demandecombobox.BaseColor = dark2;
            Year.BaseColor = dark2;
            Year2.BaseColor = dark2;
            Ryear.BaseColor = dark2;
            SchoolComboBox.BaseColor = dark2;
            month.BaseColor = dark2;

            SpecialitéCombobox.BaseColor = dark2;

            SpecialitéCombobox.ForeColor = whitecolor;
            Servicecombobox.ForeColor = whitecolor;
            accCombobox.ForeColor = whitecolor;
            Demandecombobox.ForeColor = whitecolor;
            Year.ForeColor = whitecolor;
            Year2.ForeColor = whitecolor;
            Ryear.ForeColor = whitecolor;
            label1.ForeColor = whitecolor;
            SchoolComboBox.ForeColor = whitecolor;
            month.ForeColor = whitecolor;
            gunaTextBox1.FocusedForeColor = whitecolor;
            gunaTextBox1.FocusedBaseColor = dark2;
            gunaTextBox1.BaseColor = dark2;

            gunaDateTimePicker1.ForeColor = whitecolor;
            gunaDateTimePicker1.FocusedColor = dark2;
            gunaDateTimePicker1.OnHoverBaseColor = dark2;
            gunaDateTimePicker1.BaseColor = dark2;
            stagiareAdd1.dark(dark);
            manageStagiaire1.dark(dark);
            manageAccSTG1.dark(dark);
            listStagiaire1.dark();
            listStagiaireAcc1.dark();
            summary1.dark();
            userManagment1.dark();
            about1.dark();
            setting1.dark();
            dashboard1.darkmode(dark);
            lP_AS1.dark(dark);
            compte1.dark();

            darkbuttons(gunaAdvenceButton1);
            darkbuttons(gunaAdvenceButton2);
            darkbuttons(gunaAdvenceButton3);
            darkbuttons(gunaAdvenceButton4);
            darkbuttons(gunaAdvenceButton5);
            darkbuttons(gunaAdvenceButton6);
            darkbuttons(gunaAdvenceButton8);
            darkbuttons(gunaAdvenceButton9);
            darkbuttons(gunaAdvenceButton10);
            darkbuttons(gunaAdvenceButton11);
            darkbuttons(gunaAdvenceButton12);
            darkbuttons(gunaAdvenceButton13);



            foreach (ToolStripItem item in notifymenu.Items)
            {
                item.BackColor = dark2;
                item.ForeColor = whitecolor;


            }

        }

        void darkbuttons(GunaAdvenceButton guna)
        {


            if (!Properties.Settings.Default.Dark)
            {
                guna.BaseColor = Color.FromArgb(235, 239, 242);
                guna.ForeColor = Color.FromArgb(64, 64, 64);

                guna.OnHoverForeColor = Color.FromArgb(64, 64, 64);
                guna.CheckedBaseColor = Color.Gray;
                guna.Image = (Image)guna.Tag;

            }
            else
            {
                guna.BaseColor = Color.FromArgb(42, 42, 42);
                guna.ForeColor = Color.White;

                guna.OnHoverForeColor = Color.FromArgb(56, 56, 56);
                guna.CheckedBaseColor = Color.FromArgb(56, 56, 56);

                guna.Image = guna.CheckedImage;



            }
        }

        private void displayname(object sender, EventArgs e)
        {
            GunaAdvenceButton but = ((GunaAdvenceButton)sender);
            gunaLabel1.Text = but.Text;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

            if (this.DesignMode)
            {

                return;

            }
            gunaAdvenceButton10.Dock = DockStyle.Bottom;
            gunaAdvenceButton11.Dock = DockStyle.Bottom;
            if (LOGIN2.isboss == "Admin")
            {
                gunaAdvenceButton12.Visible = true;
                gunaAdvenceButton11.Visible = true;
                gunaAdvenceButton5.Visible = true;
                gunaAdvenceButton4.Visible = true;
                gunaAdvenceButton3.Visible = true;
                gunaAdvenceButton2.Visible = true;
                gunaAdvenceButton1.Visible = true;

            }
            else if (LOGIN2.isboss == "Mini Admin")
            {
                gunaAdvenceButton12.Visible = false;
                gunaAdvenceButton11.Visible = false;
                gunaAdvenceButton5.Visible = true;
                gunaAdvenceButton4.Visible = true;
                gunaAdvenceButton3.Visible = true;
                gunaAdvenceButton2.Visible = true;
                gunaAdvenceButton1.Visible = true;
            }
            else if (LOGIN2.isboss == "Non Admin")
            {
                gunaAdvenceButton12.Visible = false;
                gunaAdvenceButton11.Visible = false;
                gunaAdvenceButton5.Visible = false;
                gunaAdvenceButton4.Visible = false;
                gunaAdvenceButton3.Visible = true;
                gunaAdvenceButton2.Visible = false;
                gunaAdvenceButton1.Visible = true;
                gunaAdvenceButton3.Location = new Point(0, 114);
            }
            dashboard1.BringToFront();
            gunaAnimateWindow1.Start();
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);

            string[] filters = { "Nom", "Prenom", "Specialité", "Date debut", "Ecole", "Observation", "DateDepot", "Mois et Anné", "Anné" };
            string[] filters2 = { "Nom", "Prenom", "Service", "Date debut", "Ecole", "Mois et Anné", "Anné", "Specialité" };
            string[] service = { "S.Personnel", "Gestion des stocks", "Informatique", "Amont agricole", "ASSISTANTE Direction SUTA", "Atelier électrique", "Atelier mécanique", "Atelier régulation", "Conditionnement", "CONTROLE DE GESTION", "CRISTALLISATION", "Extraction", "Laboratoire", "VENTES USINE" };

            string[] mois = { "janvier", "février", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre", "octobre", "novembre", "décember" };
            for (int i = 0; i < 100; i++)
            {
                Year.Items.Add(2000 + i);
                Year2.Items.Add(2000 + i);
                Ryear.Items.Add(2000 + i);
            }
            Servicecombobox.Items.AddRange(service);
            Demandecombobox.Items.AddRange(filters);
            accCombobox.Items.AddRange(filters2);
            month.Items.AddRange(mois);
            Year.SelectedIndex = 0;
            Year2.SelectedIndex = 0;
            month.SelectedIndex = 0;
            Demandecombobox.SelectedIndex = 0;
            fillcomboboxecole();
            fillcomboboxspecialité();


            SettingPanel.Visible = false;
            checkifdashboard("fff");
            Year2.Text = DateTime.Now.Year.ToString();
            Year.Text = DateTime.Now.Year.ToString();
            Ryear.Text = DateTime.Now.Year.ToString();
            selectedyear = Year2.Text;
            listStagiaire1.loadstg();
            panel1.Visible = false;
            summary1.load(Ryear.Text);


            darkmode(Properties.Settings.Default.Dark);

            minimize(Properties.Settings.Default.minimize);
            timer2.Start();
            timer3.Start();

            resettimer();

        }

        void checkifdashboard(string name)
        {

            SearchPanel.Visible = (name == "gunaAdvenceButton3" || name == "gunaAdvenceButton4");

        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            resettimer();

            dashboard1.refreshdata();
            showanimation(dashboard1);
            checkifdashboard(gunaAdvenceButton1.Name);
            panel1.Visible = false;

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        public int nbfichier = 0;
        public void startprogressbar(int value)
        {

            value += 1;
            if (!Properties.Settings.Default.styleIndicator)
            { gunaProgressBar1.Value = value; }

            gunaCircleProgressBar1.Value = value;
        }
        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {


            resettimer();

            menuDisplayed = !menuDisplayed;

            if (menuDisplayed)
            {
                menupanel.Size = new Size(219, menupanel.Size.Height);
                SettingPanel.Size = new Size(219, SettingPanel.Size.Height);
            }
            else
            {
                menupanel.Size = new Size(41, menupanel.Size.Height);
                SettingPanel.Size = new Size(41, SettingPanel.Size.Height);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            gunaLabel1.Top = (gunaLabel1.Parent.Height / 2) - (gunaLabel1.Height / 2);
        }

        private void listStagiaire1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {
            gunaCircleButton1.Top = (gunaCircleButton1.Parent.Height / 2) - (gunaCircleButton1.Height / 2);
            panel5.Top = (panel5.Parent.Height / 2) - (panel5.Height / 2);
            panel4.Top = (panel4.Parent.Height / 2) - (panel4.Height / 2);



        }



        void showanimation(Control ctrl)
        {
            if (Properties.Settings.Default.animations)
            {
                foreach (Control c in MainPanel.Controls)
                {
                    c.Hide();
                }
                ctrl.BringToFront();
                gunaTransition1.Show(ctrl);
                setting1.backctrl = ctrl;

            }
            else
            {
                foreach (Control c in MainPanel.Controls)
                {
                    c.Show();
                }
                gunaTransition1.ClearQueue();
                ctrl.BringToFront();
                setting1.backctrl = ctrl;
            }
        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            resettimer();

            showanimation(stagiareAdd1);
            checkifdashboard(gunaAdvenceButton1.Name);
            panel1.Visible = false;

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            performed = false;
            resettimer();
            showanimation(listStagiaire1);
            listStagiaire1.loadstg();

            Demandecombobox.BringToFront();
            Demandecombobox.SelectedIndex = 0;
            gunaTextBox1.BringToFront();

            checkifdashboard(gunaAdvenceButton3.Name);
            panel1.Visible = false;

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            performed = false;
            resettimer();
            showanimation(listStagiaireAcc1);
            accCombobox.BringToFront();
            accCombobox.SelectedIndex = 0;

            gunaTextBox1.BringToFront();
            listStagiaireAcc1.load();
            listStagiaireAcc1.BringToFront();
            checkifdashboard(gunaAdvenceButton4.Name);
            panel1.Visible = false;


        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            resettimer();



            SettingPanel.BringToFront();

            SettingPanel.Visible = true;
            SearchPanel.Visible = false;
            panel1.Visible = false;
            showanimation(setting1);

        }
        public void checksearchpanel()
        {
            if (gunaAdvenceButton3.Checked || gunaAdvenceButton4.Checked)
            {
                SearchPanel.Visible = true;
            }
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            resettimer();


            SettingPanel.Visible = false;
            menupanel.Visible = true;
            setting1.SendToBack();
            compte1.SendToBack();
            about1.SendToBack();
            checksearchpanel();


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (menuDisplayed)
            {
                if (x < 219)
                {
                    x += 24;
                }
                if (x > 219)
                {
                    x = 219;


                }
            }
            else
            {
                if (x > 41)
                {
                    x -= 24;

                }
                if (x < 41)
                {
                    x = 41;


                }

            }
            menupanel.Size = new Size(x, menupanel.Size.Height);
            SettingPanel.Size = new Size(x, SettingPanel.Size.Height);
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            resettimer();

            if (gunaAdvenceButton3.Checked)
            {
                performed = true;
                listStagiaire1.Search(Demandecombobox.SelectedIndex, gunaTextBox1.Text, gunaDateTimePicker1.Value, Year.Text, month.SelectedIndex, Year2.Text, SchoolComboBox.Text, SpecialitéCombobox.Text);

            }

            if (gunaAdvenceButton4.Checked)
            {
                performed = true;
                listStagiaireAcc1.Search(accCombobox.SelectedIndex, gunaTextBox1.Text, gunaDateTimePicker1.Value, Year.Text, month.SelectedIndex, Year2.Text, SchoolComboBox.Text, Servicecombobox.Text, SpecialitéCombobox.Text);
            }
        }

        private void gunaCircleButton1_DoubleClick(object sender, EventArgs e)
        {
            if (gunaAdvenceButton3.Checked)
            {
                performed = false;
                listStagiaire1.loadstg();
            }
            if (gunaAdvenceButton4.Checked)
            {
                performed = false;
                listStagiaireAcc1.load();
            }

        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Demandecombobox.SelectedIndex == 2)
            {
                SpecialitéCombobox.BringToFront();
            }
            else
            if (Demandecombobox.SelectedIndex == 3 || Demandecombobox.SelectedIndex == 6)
            {
                gunaDateTimePicker1.BringToFront();
            }
            else if (Demandecombobox.SelectedIndex == 4)
            {
                SchoolComboBox.BringToFront();
            }
            else if (Demandecombobox.SelectedIndex == 7)
            {
                Year.BringToFront();
                month.BringToFront();
            }
            else if (Demandecombobox.SelectedIndex == 8)
            {
                Year2.BringToFront();
            }
            else
            {
                gunaTextBox1.BringToFront();
            }


        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPanel1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("eksde");
            if (WindowState == FormWindowState.Normal)
            {
                Screen screen = Screen.FromControl(this);
                int x = screen.WorkingArea.X - screen.Bounds.X;
                int y = screen.WorkingArea.Y - screen.Bounds.Y;
                this.MaximizedBounds = new Rectangle(x, y,
                    screen.WorkingArea.Width, screen.WorkingArea.Height);
                this.MaximumSize = screen.WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;

            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showMenu(int x)
        {
            showanimation(manageStagiaire1);
            SearchPanel.Visible = false;
            manageStagiaire1.loaddata(x);
        }
        public void showMenu2(int x)
        {
            showanimation(manageAccSTG1);
            SearchPanel.Visible = false;
            manageAccSTG1.loaddata(x);
        }
        public void showlist()
        {
            listStagiaire1.loadstg();

            showanimation(listStagiaire1);

        }
        public static void insertnotif(string msg, string notiftype)
        {
            SqlCommand cmd = new SqlCommand("insert into notif values(@msg,@sender,@senderid,@popedby,@notiftype)", Program.con);
            cmd.Parameters.Add("@msg", SqlDbType.VarChar).Value = msg;
            cmd.Parameters.Add("@sender", SqlDbType.VarChar).Value = LOGIN2.name;

            cmd.Parameters.Add("senderid", SqlDbType.Int).Value = LOGIN2.id;
            cmd.Parameters.Add("@popedby", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@notiftype", SqlDbType.VarChar).Value = notiftype;
            cmd.ExecuteNonQuery();

        }
        public void popnotif()
        {
            if (Program.con.State != ConnectionState.Open)
            {
                Confirmationbox.Show(Program.con.State.ToString());
                return;
            }
            SqlConnection con = new SqlConnection(Program.con.ConnectionString);
            SqlConnection con2 = new SqlConnection(Program.con.ConnectionString);

            try
            {
                con.Open();
            }
            catch (Exception)
            {


                frmAlert.Alert("Gestion Stagiaire", "you have beed disconected due to connection error", frmAlert.alertTypeEnum.Error);
                this.Close();
                return;
            }
            
            if (LOGIN2.isboss != "Admin")
            {
                return;
            }
            string sql = "select * from notif";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if ((int)dr.GetValue(3) != LOGIN2.id)
                {
                    string[] x = dr.GetValue(4).ToString().Split('/');

                    if (!x.Contains(LOGIN2.id.ToString()))
                    {
                        if (Properties.Settings.Default.notif)
                        {
                            switch (dr.GetValue(5).ToString())
                            {
                                case "Success": frmAlert.Alert(dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), frmAlert.alertTypeEnum.Success); break;
                                case "Warning": frmAlert.Alert(dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), frmAlert.alertTypeEnum.Warning); break;
                                case "Error": frmAlert.Alert(dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), frmAlert.alertTypeEnum.Error); break;
                                case "Info": frmAlert.Alert(dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), frmAlert.alertTypeEnum.Info); break;


                            }
                        }


                        SqlCommand cmd2 = new SqlCommand("update notif set popedby =popedby+@add where id=@id", con2);

                        con2.Open();
                        cmd2.Parameters.Add("@id", SqlDbType.Int).Value = dr.GetValue(0);
                        cmd2.Parameters.Add("@add", SqlDbType.VarChar).Value = ("/" + LOGIN2.id);

                        cmd2.ExecuteNonQuery();
                        con2.Close();



                    }

                }
            }
            dr.Close();
            con.Close();

        }

        private void gunaAdvenceButton5_Click_1(object sender, EventArgs e)
        {
            checkifdashboard("f");
            summary1.load(Ryear.Text);
            showanimation(summary1);
            panel1.Visible = true;
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }
        public void showlist2()
        {
            listStagiaireAcc1.load();
            listStagiaireAcc1.BringToFront();

        }
        private void gunaAdvenceButton10_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            Program.showlogin();
        }
        public void fillcomboboxecole()
        {

            SqlCommand cmd = new SqlCommand("select ecole from stagiaire union select ecole from acc", Program.con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            SchoolComboBox.ValueMember = "ecole";
            SchoolComboBox.DisplayMember = "ecole";
            SchoolComboBox.DataSource = dt;

        }
        public void fillcomboboxspecialité()
        {


            SqlCommand cmd = new SqlCommand("select specialite from stagiaire where specialite is not null  union select specialite from acc where specialite is not null", Program.con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            SpecialitéCombobox.ValueMember = "specialite";
            SpecialitéCombobox.DisplayMember = "specialite";
            SpecialitéCombobox.DataSource = dt;

        }
        private void accCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (accCombobox.SelectedIndex == 2)
            {
                Servicecombobox.BringToFront();
            }
            else
            if (accCombobox.SelectedIndex == 3)
            {
                gunaDateTimePicker1.BringToFront();
            }
            else if (accCombobox.SelectedIndex == 4)
            {
                SchoolComboBox.BringToFront();
            }
            else if (accCombobox.SelectedIndex == 5)
            {
                Year.BringToFront();
                month.BringToFront();
            }
            else if (accCombobox.SelectedIndex == 6)
            {
                Year2.BringToFront();
            }
            else if (accCombobox.SelectedIndex == 7)
            {
                SpecialitéCombobox.BringToFront();
            }
            else
            {
                gunaTextBox1.BringToFront();
            }
        }

        private void gunaAdvenceButton11_Click(object sender, EventArgs e)
        {
            resettimer();
            showanimation(userManagment1);
            checkifdashboard("fdsf");
            panel1.Visible = false;

        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            showanimation(about1);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard1_Load_1(object sender, EventArgs e)
        {

        }

        private void about1_Load(object sender, EventArgs e)
        {

        }

        private void gunaComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            summary1.load(Ryear.Text);
        }

        private void Year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedyear = Year2.Text;

        }

        private void gunaControlBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Screen screen = Screen.FromControl(this);
                int x = screen.WorkingArea.X - screen.Bounds.X;
                int y = screen.WorkingArea.Y - screen.Bounds.Y;
                this.MaximizedBounds = new Rectangle(x, y,
                    screen.WorkingArea.Width, screen.WorkingArea.Height);
                this.MaximumSize = screen.WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;

            }
        }
        public int scroll;
        public int selectedrow;
        bool performed = false;
        public void loadback(int scroll, int selected)
        {
            if (performed)
            {
                gunaCircleButton1.PerformClick();

            }
            listStagiaire1.check(scroll, selected);

            SearchPanel.Visible = true;


        }
        public void loadback2(int scroll, int selected)
        {
            if (performed)
            {
                gunaCircleButton1.PerformClick();

            }
            listStagiaireAcc1.check2(scroll, selected);
            SearchPanel.Visible = true;


        }

        private void gunaAdvenceButton12_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaCircleButton1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void userManagment1_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            showanimation(setting1);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
          
            if (nbfichier > 0)
            {
                if (Properties.Settings.Default.styleIndicator)
                {
                    progresspanel.Visible = true;

                }
                else
                {
                    progresspanel.Visible = false;


                }
            }
            else
            {
                gunaProgressBar1.Value = 0;
                gunaCircleProgressBar1.Value = 0;
                progresspanel.Visible = false;
                gunaProgressBar1.IdleColor = dark2;

            }
            if (LOGIN2.isboss != "Admin")
            {
                return;
            }

            try
            {
                setting1.set(Setting.getmaxnbrstg().ToString());

            }
            catch (Exception ez)
            {
                frmAlert.Alert("Gestion Stagiaire", "you have beed disconected due to connection error", frmAlert.alertTypeEnum.Error);
                this.Close();
                return;
            }
            popnotif();
        }

        private void lP_AS1_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton12_Click_1(object sender, EventArgs e)
        {
            resettimer();
            showanimation(lP_AS1);
            checkifdashboard(gunaAdvenceButton12.Name);
            panel1.Visible = false;
        }

        private void MainMenu_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void MainMenu_MouseUp(object sender, MouseEventArgs e)
        {

        }

        public static int time;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.innactivity)
            {
                return;
            }
            time += 1;
            if (time == Properties.Settings.Default.innactivitytime * 60)
            {
                frmAlert.Alert("Gestion Stagiaire", "you have beed disconected", frmAlert.alertTypeEnum.Info);
                this.Close();

            }
        }
        public static void resettimer()
        {

            time = 0;
        }

        private void MainMenu_MouseMove_1(object sender, MouseEventArgs e)
        {
            MessageBox.Show(this.Focused.ToString());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            resettimer();

            SettingPanel.BringToFront();
            setting1.BringToFront();
            gunaAdvenceButton9.PerformClick();
            SettingPanel.Visible = true;
            SearchPanel.Visible = false;
            panel1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            notifyIcon1.Visible = false;
            Program.showlogin();
        }

        private void SettingPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrgTimer_Tick(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton13_Click(object sender, EventArgs e)
        {
            resettimer();


            showanimation(compte1);
            checkifdashboard(gunaAdvenceButton13.Name);
            panel1.Visible = false;
        }

        private void compte1_Load(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Screen screen = Screen.FromControl(this);
                int x = screen.WorkingArea.X - screen.Bounds.X;
                int y = screen.WorkingArea.Y - screen.Bounds.Y;
                this.MaximizedBounds = new Rectangle(x, y,
                    screen.WorkingArea.Width, screen.WorkingArea.Height);
                this.MaximumSize = screen.WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;

            }

        }
    }
}
