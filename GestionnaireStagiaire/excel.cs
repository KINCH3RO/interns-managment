using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Globalization;
using System.Threading;

namespace GestionnaireStagiaire
{
    class excel
    {
        string path = "";
        _Application Excel = new _excel.Application();
        Workbook wb;
        Worksheet ws;

        public excel(string path, int sheet)
        {
            this.path = path;
            wb = Excel.Workbooks.Open(path);
            
            ws = wb.Worksheets[sheet];
      
        }
        public void excelclose()
        {
            wb.Close();
        }
        public string readcell(int i, int j)
        {
            i++;
            j++;
            return ws.Cells[i, j].Value2;
        }
        public void writecell(int i, int j,string value,int x,int y,bool date)
        {
            i+=x;
            j+=y;
            CultureInfo ci = CultureInfo.InstalledUICulture;
            if (date)
            {
                ws.Cells[i, j].Value2 = value;
                //if (ci.Name.ToString().Contains("fr"))
                //{
                //    ws.Cells[i, j].NumberFormat = "MM/jj/aaaa";

                //}
                //else
                //{
                //    ws.Cells[i, j].NumberFormat = "MM/DD/YYYY";
                //}
            }
            else
            {
                ws.Cells[i, j].Value = value;


            }










        }
        public void SAVE()
        {
            wb.Save();
            wb.Close();
        }


    }
}
