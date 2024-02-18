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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskHastaTC.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC = @p1",bgl.baglantiMethodu());
            komut.Parameters.AddWithValue("@p1", TCno);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtHastaAdi.Text = dr[1].ToString();
                txtHastaSoyadi.Text = dr[2].ToString();
                mskHastaTel.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }

            bgl.baglantiMethodu().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar Set HastaAd=@p1, HastaSoyad=@p2, Hastatelefon=@p3, HastaSifre=@p4, HastaCinsiyet = @p5 where HastaTc = @p6",bgl.baglantiMethodu());
            komut2.Parameters.AddWithValue("@p1", txtHastaAdi.Text);
            komut2.Parameters.AddWithValue("@p2", txtHastaSoyadi.Text);
            komut2.Parameters.AddWithValue("@p3", mskHastaTel.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskHastaTC.Text);

            komut2.ExecuteNonQuery(); //kayıt

            bgl.baglantiMethodu().Close();
            MessageBox.Show("Your information has been updated","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
       
        
    }
}
