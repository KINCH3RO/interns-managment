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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;



namespace GestionnaireStagiaire
{
    public partial class ListStagiaireAcc : UserControl
    {
        public ListStagiaireAcc()
        {
            InitializeComponent();
        }
        public static string table = "acc";
        public void dark()
        {
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

            panel1.BackColor = MainMenu.hoverdark;
            panel2.BackColor = MainMenu.hoverdark;
            panel3.BackColor = MainMenu.hoverdark;
            gunaAdvenceButton1.ForeColor = MainMenu.whitecolor;
            gunaAdvenceButton1.BaseColor = MainMenu.dark2;

            gunaAdvenceButton2.ForeColor = MainMenu.whitecolor;
            gunaAdvenceButton2.BaseColor = MainMenu.dark2;

            gunaAdvenceButton3.ForeColor = MainMenu.whitecolor;
            gunaAdvenceButton3.BaseColor = MainMenu.dark2;

            gunaLabel1.ForeColor = MainMenu.whitecolor;
            gunaLabel2.ForeColor = MainMenu.whitecolor;

        }

        public void color(Color Maincolor)
        {

            gunaDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Maincolor;
            gunaAdvenceButton2.BorderColor = Maincolor;
            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton3.BorderColor = Maincolor;
            gunaAdvenceButton3.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton3.OnHoverBorderColor = Maincolor;
            gunaAdvenceButton1.BorderColor = Maincolor;
            gunaAdvenceButton1.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton1.OnHoverBorderColor = Maincolor;




        }


        private void ListStagiaireAcc_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }


        }
        public void load()
        {

            MainMenu menu = (MainMenu)this.ParentForm;

            if (table != "acc")
            {
                gunaAdvenceButton3.Visible = false;
                gunaAdvenceButton2.Visible = false;
                gunaCircleButton1.Visible = false;

            }
            else
            {
                gunaAdvenceButton3.Visible = true;
                gunaAdvenceButton2.Visible = true;

                gunaCircleButton1.Visible = true;

            }

            if (LOGIN2.isboss != "Admin")
            {
                gunaAdvenceButton3.Visible = false;
            }
            string sql = "select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where year(du) like @year ";
            if (table != "acc")
            {
                sql += " order by idd";
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = menu.selectedyear;
            dt.Load(cmd.ExecuteReader());
            gunaDataGridView1.DataSource = dt;

            checketat();

        }

        private async void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            MainMenu.resettimer();

            SaveFileDialog f2 = new SaveFileDialog();
            f2.Filter = "excel file |*.xlsx";
            f2.FileName = "list des stagiaires accepté " + " " + DateTime.Now.Year.ToString() + " " + "le " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            string from = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GSMODELS\stagiaires2020acc.xlsx";
            MainMenu menu = (MainMenu)this.ParentForm;
            if (menu.nbfichier > 0)
            {
                Confirmationbox.ShowDialog("il ya deja un fichier est en cours d'exportation", false);
                return;
            }
            if (f2.ShowDialog() == DialogResult.OK)
            {
                string to = f2.FileName;
                if (File.Exists(to))
                {
                    string x = Path.GetFileNameWithoutExtension(f2.FileName);

                    if (Program.checkifprocessalreadyopned(x))
                    {
                        Confirmationbox.Show("Fichier deja ouvert");
                        return;
                    }
                    File.Delete(to);

                }
                File.Copy(from, to);

                for (int i = 1; i <= 12; i++)
                {
                    if (checkstg(i) > Setting.getmaxnbrstg())
                    {


                        Confirmationbox.Show("le nbr max du stagiaire est achevé pour le mois" + i);
                        Confirmationbox.Show("operation blockée");

                        return;

                    }
                }

                menu.nbfichier += 1;


                Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                await Task.Run(() => export(to, f2.FileName, pr));

                menu.nbfichier -= 1;




            }


            async Task export(string to, string f22, IProgress<int> progress)
            {



                excel ex = new excel(to, 1);
                try
                {
                    ex.writecell(0, 0, "list des stagiaires accepté" + " " + DateTime.Now.Year.ToString(), 1, 1, false);


                    for (int i = 1; i <= 12; i++)
                    {

                        exportaccstagiaire(i, ex);
                        progress.Report(i * 100 / 12);

                    }

                    ex.SAVE();
                    Confirmationbox.ShowDialog("Exportation complet", false);

                    System.Diagnostics.Process.Start(f22);



                }
                catch (Exception)
                {

                    ex.SAVE();
                    MessageBox.Show("erreur d'exportation");
                }

            }


        }
        int checkstg(int month)
        {
            MainMenu menu = (MainMenu)this.ParentForm;
            string sql = "select count(*) from " + table + " where month(du)=@month and  year(du)=@year";

            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = menu.selectedyear;
            cmd.Parameters.Add("@month", SqlDbType.Int).Value = month;
            int x = (int)cmd.ExecuteScalar();
            return x;
        }
        void exportaccstagiaire(int month, excel ex)
        {
            MainMenu menu = (MainMenu)this.ParentForm;


            DataTable dt = new DataTable();
            string sql = "select * from " + table + " where month(du)=@month and  year(du)=@year";

            SqlCommand cmd = new SqlCommand(sql, Program.con);
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = menu.selectedyear;
            cmd.Parameters.Add("@month", SqlDbType.Int).Value = month;
            dt.Load(cmd.ExecuteReader());
            int row = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime currentdate = (DateTime)dt.Rows[i][4];
                switch (currentdate.Month)
                {
                    case 1: row = 4; break;
                    case 2: row = 26; break;
                    case 3: row = 48; break;
                    case 4: row = 70; break;
                    case 5: row = 92; break;
                    case 6: row = 114; break;
                    case 7: row = 136; break;
                    case 8: row = 158; break;
                    case 9: row = 180; break;
                    case 10: row = 202; break;
                    case 11: row = 224; break;
                    case 12: row = 246; break;


                    default:
                        row = 266;
                        break;
                }
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 4 || j == 5 || j == 8)
                    {
                        ex.writecell(i, j, ((DateTime)dt.Rows[i][j]).ToShortDateString(), row, 1, true);
                    }
                    else
                    {
                        ex.writecell(i, j, dt.Rows[i][j].ToString(), row, 1, false);

                    }
                }

            }



        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {



        }
        public void Search(int x, string filter, DateTime date, string year, int month, string year2, string ecole, string service, string specialite)
        {
            string[] filters2 = { "Nom", "Prenom", "Service", "Date debut", "Ecole", "Mois et Anné", "Anné" };

            if (x == 0)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where nom like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + filter + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 1)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where prenom like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + filter + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 2)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where service like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + service + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 3)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where Du like @nom ", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Date).Value = date;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 4)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where ecole like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + ecole + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;

            }
            else if (x == 5)
            {


                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where MONTH(du) like @month and YEAR(du) like @year", Program.con);
                cmd.Parameters.Add("@month", SqlDbType.Int).Value = month + 1;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year;


                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;


            }
            else if (x == 6)
            {

                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where  YEAR(du) like @year", Program.con);

                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;


                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;

            }
            else if (x == 7)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' , nom as 'Nom', Prenom as 'Prénom',Specialite as 'Spécialite',Du,Au ,Ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot',Service,sexe as 'Genre' from " + table + " where nom like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + specialite + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            checketat();
        }
        void checketat()
        {


            for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
            {
                SqlCommand cmd;
                if (table != "acc")
                {
                    string sql = "select etat from archiveinfo where id =@id ";
                    cmd = new SqlCommand(sql, Program.con);
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = gunaDataGridView1.Rows[i].Cells[0].Value;

                }
                else
                {
                    string sql = "select etat from  accinfo where id =@id ";
                    cmd = new SqlCommand(sql, Program.con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = gunaDataGridView1.Rows[i].Cells[0].Value;

                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr.GetValue(0).ToString() == "A")
                    {
                        gunaDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                        gunaDataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

                    }
                    else if (dr.GetValue(0).ToString() == "L")
                    {
                        gunaDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                        gunaDataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;


                    }

                }
                dr.Close();



            }


        }

        private void gunaCircleButton3_Click(object sender, EventArgs e)
        {


        }

        private async void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            word w = new word();
            string filename = "";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (checksexe(gunaDataGridView1.CurrentRow.Cells[0].Value.ToString()) == "M")
            {
                filename = path + @"\GSMODELS\AttestationdestageM.docx";
            }
            else
            {
                filename = path + @"\GSMODELS\AttestationdestageF.docx";
            }

            SaveFileDialog f2 = new SaveFileDialog();
            f2.Filter = "Word file |*.Docx";


            string name = gunaDataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + gunaDataGridView1.CurrentRow.Cells[2].Value.ToString();
            string Du = ((DateTime)gunaDataGridView1.CurrentRow.Cells[4].Value).ToShortDateString();
            string nom = gunaDataGridView1.CurrentRow.Cells[1].Value.ToString();
            string prenom = gunaDataGridView1.CurrentRow.Cells[2].Value.ToString();
            string n = gunaDataGridView1.CurrentRow.Cells[0].Value.ToString();


            string au = ((DateTime)gunaDataGridView1.CurrentRow.Cells[5].Value).ToShortDateString();


            string date = DateTime.Now.ToShortDateString();
            string y = DateTime.Now.ToString("yy");

            string[] tofind = { "<date>", "<name>", "<Du>", "<Au>", "<y>" };
            string[] toreplace = { date, name, Du, au, y };
            f2.FileName = "Attestation de stage du " + name;

            MainMenu menu = (MainMenu)this.ParentForm;
            if (menu.nbfichier > 0)
            {
                Confirmationbox.ShowDialog("il ya deja un fichier est en cours d'exportation", false);
                return;
            }
            if (f2.ShowDialog() == DialogResult.OK)
            {
                string x = Path.GetFileNameWithoutExtension(f2.FileName);

                if (Program.checkifprocessalreadyopned(x))
                {
                    Confirmationbox.Show("Fichier Deja ouvert");
                    return;
                }
                if (Confirmationbox.ShowDialog("vous voulez imprimer ce document",true) == DialogResult.OK)
                {

                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, true, 2, pr));

                    menu.nbfichier -= 1;

                    insert("A");
                }
                else
                {
                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, false, 0, pr));
                    
                    menu.nbfichier -= 1;
                    insert("A");
                    System.Diagnostics.Process.Start(f2.FileName);
                }
                Confirmationbox.Show("Operation complet");
                MainMenu.insertnotif("Attestation Imprimé du : " + prenom + " " + nom + " N:" + n, alertTypeEnum.Success.ToString());
                checketat();
            }

        }
        string checksexe(object x)
        {

            string sql = "select sexe from " + table + " where id =@id";
            SqlCommand cmd = new SqlCommand(sql, Program.con);
            
            if (table == "acc")
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = x;

            }
            else
            {
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = x;

            }
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string z = dr.GetValue(0).ToString();
            dr.Close();

            return z;


        }

        void insert(string value)
        {
            if (table == "acc")
            {
                string sql = "update accinfo set etat=@etat where id =@id ";
                SqlCommand cmd = new SqlCommand(sql, Program.con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = gunaDataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.Add("@etat", SqlDbType.Char).Value = value;
                int x = cmd.ExecuteNonQuery();
               


            }
            else
            {
                string sql = "update archiveinfo set etat=@etat where id =@id ";
                SqlCommand cmd = new SqlCommand(sql, Program.con);
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = gunaDataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.Add("@etat", SqlDbType.Char).Value = value;
                int x = cmd.ExecuteNonQuery();
               


            }

        }
        private async void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            word w = new word();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string filename = path + @"\GSMODELS\LAISSEZPASSER.docx";
            SaveFileDialog f2 = new SaveFileDialog();
            f2.Filter = "Word file |*.Docx";

            string nom = gunaDataGridView1.CurrentRow.Cells[1].Value.ToString();
            string prenom = gunaDataGridView1.CurrentRow.Cells[2].Value.ToString();
            string service = gunaDataGridView1.CurrentRow.Cells[9].Value.ToString();
            string Du = ((DateTime)gunaDataGridView1.CurrentRow.Cells[4].Value).ToShortDateString();
            string au = ((DateTime)gunaDataGridView1.CurrentRow.Cells[5].Value).ToShortDateString();
            string n = gunaDataGridView1.CurrentRow.Cells[0].Value.ToString();

            string date = DateTime.Now.ToShortDateString();

            string[] tofind = { "<date>", "<nom>", "<prenom>", "<du>", "<au>", "<service>", "<nu>" };
            string[] toreplace = { date, nom, prenom, Du, au, service, n };
            f2.FileName = "LaisserPasser du " + nom + prenom;

            MainMenu menu = (MainMenu)this.ParentForm;
            if (menu.nbfichier > 0)
            {
                Confirmationbox.ShowDialog("il ya deja un fichier est en cours d'exportation", false);
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



                    insert("L");
                }
                else
                {
                    menu.nbfichier += 1;
                    Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                    await Task.Run(() => w.CreateWordDocument(filename, f2.FileName, tofind, toreplace, false, 0, pr));

                    menu.nbfichier -= 1;



                    System.Diagnostics.Process.Start(f2.FileName);
                    insert("L");

                }
                Confirmationbox.ShowDialog("Operation complet", false);
                MainMenu.insertnotif("LP Imprimé du : " + prenom + " " + nom + " N:" + n, alertTypeEnum.Success.ToString());
                checketat();




            }

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel3.Left = (panel3.Parent.Width - panel3.Width) / 2;
            panel3.Top = (panel3.Parent.Height - panel3.Height) / 2;
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            MainMenu.resettimer();

            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            MainMenu menu = (MainMenu)this.ParentForm;
            int x = (int)gunaDataGridView1.CurrentRow.Cells[0].Value;
            menu.scroll = gunaDataGridView1.FirstDisplayedScrollingRowIndex;
            menu.selectedrow = gunaDataGridView1.SelectedRows[0].Index;

            menu.showMenu2(x);
            menu.tempdt = (DataTable)gunaDataGridView1.DataSource;
        }
        public void check2(int scroll, int selected)
        {
            if (gunaDataGridView1.Rows.Count == 0)
            {
                return;
            }
            gunaDataGridView1.FirstDisplayedScrollingRowIndex = scroll;
            for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
            {
                gunaDataGridView1.Rows[i].Selected = false;
            }
            gunaDataGridView1.Rows[selected].Selected = true;
            gunaAdvenceButton3.Checked = false;
        }
        private void gunaDataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            MainMenu.resettimer();

            gunaLabel2.Text = gunaDataGridView1.SelectedRows.Count.ToString();

        }

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LOGIN2.isboss != "Admin")
            {
                return;
            }
            MainMenu.resettimer();
            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            if (table != "acc")
            {
                return;
            }
            if (gunaDataGridView1.SelectedRows.Count > 1)
            {
                return;
            }
            MainMenu menu = (MainMenu)this.ParentForm;
            int x = (int)gunaDataGridView1.CurrentRow.Cells[0].Value;
            menu.scroll = gunaDataGridView1.FirstDisplayedScrollingRowIndex;
            menu.selectedrow = gunaDataGridView1.SelectedRows[0].Index;
            menu.showMenu2(x);
            menu.tempdt = (DataTable)gunaDataGridView1.DataSource;
        }

        private void gunaDataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            checketat();
        }

        private void gunaDataGridView1_Sorted(object sender, EventArgs e)
        {
            checketat();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
