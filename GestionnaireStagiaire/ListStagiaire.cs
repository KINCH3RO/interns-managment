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
using System.IO;

namespace GestionnaireStagiaire
{
    public partial class ListStagiaire : UserControl
    {
        public ListStagiaire()
        {
            InitializeComponent();
        }
        public static string table = "stagiaire";
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
            panel5.BackColor = MainMenu.hoverdark;
            gunaLabel1.ForeColor = MainMenu.whitecolor;
            gunaLabel2.ForeColor = MainMenu.whitecolor;
            gunaLabel3.ForeColor = MainMenu.whitecolor;
            gunaLabel4.ForeColor = MainMenu.whitecolor;
            gunaAdvenceButton2.ForeColor = MainMenu.whitecolor;
            gunaAdvenceButton2.BaseColor = MainMenu.dark2;




        }

        private void ListStagiaire_Load(object sender, EventArgs e)
        {







        }
        public void loadstg()
        {
            if (this.DesignMode)
            {
                return;
            }
            if (LOGIN2.isboss == "Non Admin" || table != "stagiaire")
            {
                gunaAdvenceButton2.Visible = false;

            }
            else
            {
                gunaAdvenceButton2.Visible = true;
            }

            MainMenu menu = (MainMenu)this.ParentForm;
           
            SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where year(du) LIKE @year", Program.con);
            if (table != "stagiaire")
            {
                cmd.CommandText += " order by idd";
            }
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = menu.selectedyear;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            gunaDataGridView1.DataSource = dt;
            if (table == "stagiaire")
            {
                if (gunaDataGridView1.Rows.Count>=0)
                {
                    return;
                }
                gunaLabel3.Text = checkstatus(int.Parse(gunaDataGridView1.CurrentRow.Cells[0].Value.ToString()));

            }
            

        }


        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private async void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            MainMenu.resettimer();
            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            SaveFileDialog f2 = new SaveFileDialog();
            f2.Filter = "excel file |*.xlsx";
            f2.FileName= "list des stagiaire " + " " + DateTime.Now.Year.ToString() + " " + "le " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            string from = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GSMODELS\Stagiares2020.xlsx";
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
             
                menu.nbfichier += 1;
                Progress<int> pr = new Progress<int>(percent => menu.startprogressbar(percent));
                await Task.Run(() => export(to, f2.FileName, pr));
            
                menu.nbfichier -= 1;



            }




        }


        async Task export(string to, string f2, IProgress<int> progress)
        {
            excel ex = new excel(to, 1);

            try
            {
                DataGridView dt = gunaDataGridView1;
                ex.writecell(0, 0, "Les demandes de Stage Année	" + " " + DateTime.Now.Year.ToString(), 1, 1, false);

                for (int i = 0; i < dt.RowCount; i++)
                {

                    for (int j = 0; j < dt.ColumnCount; j++)
                    {
                        if (j == 4 || j == 5 || j == 8)
                        {
                            ex.writecell(i, j, "  " + ((DateTime)dt.Rows[i].Cells[j].Value).ToShortDateString(), 3, 1, true);

                        }
                        else
                        {
                            ex.writecell(i, j, dt.Rows[i].Cells[j].Value.ToString(), 3, 1, false);


                        }
                        progress.Report(i * 100 / dt.Rows.Count);

                    }

                }
                ex.SAVE();
                Confirmationbox.ShowDialog("Exportation complet", false);
                System.Diagnostics.Process.Start(f2);

            }
            catch (Exception e)
            {
                
                ex.SAVE();
            }
            
            

        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            word w = new word();
            string filename = "";
            string saveAS = "";
            OpenFileDialog f1 = new OpenFileDialog();
            OpenFileDialog f2 = new OpenFileDialog();

            if (f1.ShowDialog() == DialogResult.OK)
            {
                filename = f1.FileName;
            }

            if (f2.ShowDialog() == DialogResult.OK)
            {
                saveAS = f2.FileName;
            }


        }

        private void gunaDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(gunaDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());


        }
        public void Search(int x, string filter, DateTime date, string year, int month, string year2, string ecole, string specialite)
        {

            if (x == 0)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where nom like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + filter + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 1)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where prenom like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + filter + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 2)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where specialite like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + specialite + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 3)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where Du like @nom ", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Date).Value = date;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 4)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where ecole like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + ecole + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;

            }
            else if (x == 5)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where observation like @nom and year(du) like @year", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Char).Value = "%" + filter + "%";
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;
            }
            else if (x == 6)
            {
                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where dateD like @nom", Program.con);
                cmd.Parameters.Add("@nom", SqlDbType.Date).Value = date;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;

            }
            else if (x == 7)
            {


                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where MONTH(du) like @month and YEAR(du) like @year", Program.con);
                cmd.Parameters.Add("@month", SqlDbType.Int).Value = month + 1;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year;


                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;


            }
            else if (x == 8)
            {

                SqlCommand cmd = new SqlCommand("select id as 'Nbr' ,nom as 'Nom' , prenom as 'Prénom',specialite as 'Spécialite', du as 'Du' ,au as 'Au',ecole as 'Ecole',observation as 'Obs',dateD as 'Date depot' from " + table + " where  YEAR(du) like @year", Program.con);

                cmd.Parameters.Add("@year", SqlDbType.Int).Value = year2;


                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gunaDataGridView1.DataSource = dt;

            }
        }

        private void gunaDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void color(Color Maincolor)
        {

            gunaDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Maincolor;
            gunaAdvenceButton2.BorderColor = Maincolor;
            gunaAdvenceButton2.OnHoverBaseColor = Maincolor;
            gunaAdvenceButton2.OnHoverBorderColor = Maincolor;




        }

        private void gunaDataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gunaDataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void panel5_SizeChanged(object sender, EventArgs e)
        {
            gunaCircleButton1.Left = (gunaCircleButton1.Parent.Width / 2) - (gunaCircleButton1.Width / 2);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panel4_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel5.Left = (panel5.Parent.Width - panel5.Width) / 2;
            panel5.Top = (panel5.Parent.Height - panel5.Height) / 2;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public string checkstatus(object value)
        {
            string sql = "";
            if (gunaDataGridView1.SelectedRows.Count > 1)
            {
                return "";

            }

            if (table =="stagiaire")
            {
                sql = " select count(*) from acc where id =@id";
                SqlCommand cmd = new SqlCommand(sql, Program.con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = value;
                int x = (int)cmd.ExecuteScalar();

                if (x > 0)
                {
                    return "Accepté";
                }
                else
                {
                    return "Non Accepté";
                }
            }
            else
            {
                sql = " select count(*) from archiveacc where id =@id";
                SqlCommand cmd = new SqlCommand(sql, Program.con);
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = value;
                int x = (int)cmd.ExecuteScalar();

                if (x > 0)
                {
                    return "Accepté";
                }
                else
                {
                    return "Non Accepté";
                }

            }
          


        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
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
            menu.showMenu(x);
            gunaAdvenceButton2.Checked = false;
            menu.tempdt = (DataTable)gunaDataGridView1.DataSource;

        }
        public void check(int scroll, int selected)
        {
            gunaDataGridView1.FirstDisplayedScrollingRowIndex = scroll;
            for (int i = 0; i < gunaDataGridView1.Rows.Count; i++)
            {
                gunaDataGridView1.Rows[i].Selected = false;
            }
            gunaDataGridView1.Rows[selected].Selected = true;
            
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void gunaDataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void gunaDataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            MainMenu.resettimer();
            gunaLabel2.Text = gunaDataGridView1.SelectedRows.Count.ToString();

        }

        private void gunaDataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            if (LOGIN2.isboss != "Non Admin" && table == "stagiaire")
            {
                if (gunaDataGridView1.SelectedRows.Count > 1)
                {
                    return;
                }
                MainMenu menu = (MainMenu)this.ParentForm;
                int x = (int)gunaDataGridView1.CurrentRow.Cells[0].Value;
                menu.scroll = gunaDataGridView1.FirstDisplayedScrollingRowIndex;
                menu.selectedrow = gunaDataGridView1.SelectedRows[0].Index;
                menu.showMenu(x);
                menu.tempdt = (DataTable)gunaDataGridView1.DataSource;

            }
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MainMenu.resettimer();
            if (gunaDataGridView1.SelectedRows.Count > 1 || gunaDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

           
                gunaLabel3.Text = checkstatus(gunaDataGridView1.CurrentRow.Cells[0].Value.ToString());

            
        }

        private void gunaDataGridView1_KeyDown(object sender, KeyEventArgs e)
        {



        }

        private void gunaDataGridView1_SelectionChanged(object sender, EventArgs e)
        {




        }

        private void gunaDataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void gunaDataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                gunaLabel3.Text = checkstatus(gunaDataGridView1.CurrentRow.Cells[0].Value.ToString());

            }
        }

        private void gunaDataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
