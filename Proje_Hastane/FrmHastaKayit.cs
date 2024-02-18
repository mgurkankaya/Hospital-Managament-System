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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        
        
        private void FrmHastaKayit_Load(object sender, EventArgs e)
        {

        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand hastakayitKomutNesnesi = new SqlCommand("Insert Into Tbl_Hastalar(HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglantiMethodu());
            hastakayitKomutNesnesi.Parameters.AddWithValue("@p1", txtHastaAdi.Text);
            hastakayitKomutNesnesi.Parameters.AddWithValue("@p2", txtHastaSoyadi.Text);
            hastakayitKomutNesnesi.Parameters.AddWithValue("@p3", mskHastaTC.Text);
            hastakayitKomutNesnesi.Parameters.AddWithValue("@p4", mskHastaTel.Text);
            hastakayitKomutNesnesi.Parameters.AddWithValue("@p5", txtSifre.Text);
            hastakayitKomutNesnesi.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            hastakayitKomutNesnesi.ExecuteNonQuery();

            bgl.baglantiMethodu().Close();

            MessageBox.Show("Registration Succesfull :)","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
