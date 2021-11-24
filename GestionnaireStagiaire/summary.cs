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
    public partial class summary : UserControl
    {

        public summary()
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
            gunaLabel1.ForeColor = MainMenu.whitecolor;
            gunaLabel2.ForeColor = MainMenu.whitecolor;
        }
            public void color(Color Maincolor)
        {

            gunaDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Maincolor;
           

        }

        private void summary_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
        }
        public void load(string year)
        {
            DataTable dt = new DataTable();
            
            string sql = @"select  ecole as 'Ecole', count(*) as 'nbr du demande' from "+table+" where year(du) = @year group by ecole order by  COUNT(*) desc";
            SqlCommand cmd = new SqlCommand(sql,Program.con);
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = year;
            dt.Load(cmd.ExecuteReader());
            gunaDataGridView1.DataSource = dt;
           




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
            f2.FileName = "Raporting anuelle" +" "+ DateTime.Now.Year.ToString()+" " + "le " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            string from = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GSMODELS\conclusiondanne.xlsx";

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

        void export(string to,string f2, IProgress<int> progress)
        {
            DataGridView dt = gunaDataGridView1;
            excel ex = new excel(to, 1);
            ex.writecell(0, 0, "Raporting anuelle" + DateTime.Now.Year.ToString(), 1, 1, false);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 4 || j == 5 || j == 8)
                    {
                        ex.writecell(i, j, ((DateTime)dt.Rows[i].Cells[j].Value).ToShortDateString(), 6, 1, true);
                    }
                    else
                    {
                        ex.writecell(i, j, dt.Rows[i].Cells[j].Value.ToString(), 3, 1, false);

                    }


                }
                progress.Report(i * 100 / (dt.Rows.Count-1));
            }
            ex.SAVE();
            Confirmationbox.ShowDialog("Exportation complet", false);
            System.Diagnostics.Process.Start(f2);

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            gunaLabel2.Text = gunaDataGridView1.SelectedRows.Count.ToString();
            MainMenu.resettimer();


        }
    }
}
