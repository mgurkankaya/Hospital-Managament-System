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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tcnodoktor;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskDoktorTC.Text = tcnodoktor;
            SqlCommand kmut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1",bgl.baglantiMethodu());
            kmut.Parameters.AddWithValue("@p1",mskDoktorTC.Text);
            SqlDataReader dr = kmut.ExecuteReader();
            while (dr.Read())
            {
                txtDoktorAd.Text = dr[1].ToString();
                txtDoktorSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtDoktorSifre.Text = dr[5].ToString();
            }
            bgl.baglantiMethodu().Close();


            //branslari comboBox'a çekme

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglantiMethodu());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglantiMethodu().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglantiMethodu());
            komut.Parameters.AddWithValue("@p1",txtDoktorAd.Text);
            komut.Parameters.AddWithValue("@p2",txtDoktorSoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4",txtDoktorSifre.Text);
            komut.Parameters.AddWithValue("@p5",mskDoktorTC.Text);
            komut.ExecuteNonQuery();

            bgl.baglantiMethodu().Close();

            MessageBox.Show("Doctor information has been updated successfully.","Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
