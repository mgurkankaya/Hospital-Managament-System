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

namespace Proje_Hastane
{
    public partial class FrmDoktorGiris : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        private void btnDoktorGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komutNesnesi = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC = @d1 and DoktorSifre=@d2",bgl.baglantiMethodu());
            komutNesnesi.Parameters.AddWithValue("@d1",mskDoktorTC.Text);
            komutNesnesi.Parameters.AddWithValue("@d2", txtDoktorSifre.Text);

            SqlDataReader drNesne = komutNesnesi.ExecuteReader();

            
            if (drNesne.Read() && drNesne!=null)
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.globaltc = mskDoktorTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bgl.baglantiMethodu().Close();
        }

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
