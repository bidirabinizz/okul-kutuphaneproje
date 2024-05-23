using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Kütüphane_Projesi
{
    internal class Baglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=kütüphaneDB;Integrated Security=True");
            conn.Open();
            return conn;
        }
        
    }
}
