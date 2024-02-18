using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    internal class SqlBaglantisi
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\Test.txt");
        public SqlConnection baglantiMethodu()
        {
           
            SqlConnection baglantiNesnesi = new SqlConnection(Adres);
            baglantiNesnesi.Open();
            return baglantiNesnesi;
        }
    }
}
