using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace GestionnaireStagiaire
{
    class Sqlcon
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABSR6JD\SQLEXPRESS;Initial Catalog=stagiaire;Integrated Security=True");
        public static void connecter()
        {
          
            con.Open();
        }
        public static void deconnecter()
        {
            con.Close();
        }
            
    }
}
