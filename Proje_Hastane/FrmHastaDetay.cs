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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTC .Text = tc;
            //Ad Soyad Çeme

            SqlCommand komutNesnesi = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar Where HastaTC =@p1", bgl.baglantiMethodu());
            komutNesnesi.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr = komutNesnesi.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglantiMethodu().Close();

            //Randevu Geçmişi Çekme
            DataTable dtNesne = new DataTable();
            SqlDataAdapter daNesne = new SqlDataAdapter ("Select * From Tbl_Randevular where HastaTC="+tc,bgl.baglantiMethodu());
            daNesne.Fill (dtNesne);
            dataGridView1.DataSource = dtNesne;


            //Bransları Cekme
            SqlCommand komut2Nesnesi = new SqlCommand("Select BransAd From Tbl_Branslar",bgl.baglantiMethodu());
            SqlDataReader dr2 = komut2Nesnesi.ExecuteReader ();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglantiMethodu ().Close();

           
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doktorlari Cekme
            cmbDoktor.Items.Clear(); //Aynı doktorların listelenmemesi için

            SqlCommand komut3Nesnesi = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglantiMethodu());
            komut3Nesnesi.Parameters.AddWithValue("@p1",cmbBrans.Text);
            SqlDataReader dr3 = komut3Nesnesi.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglantiMethodu().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //randevuları listeleme

            DataTable dtNesne = new DataTable();
            SqlDataAdapter daNesne = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans='" + cmbBrans.Text + "'" + " and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", bgl.baglantiMethodu());
            daNesne.Fill(dtNesne);
            dataGridView2.DataSource = dtNesne; 
        }

        private void lnk_Duzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCno = lblTC.Text;
            fr.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtRandevuID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular Set RandevuDurum=1, HastaTC=@p1, HastaSikayet=@p2 where Randevuid=@p3", bgl.baglantiMethodu());
            komut.Parameters.AddWithValue("@p1",lblTC.Text);
            komut.Parameters.AddWithValue("@p2",rchSikayet.Text);
            komut.Parameters.AddWithValue("@p3",txtRandevuID.Text);

            komut.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();
            MessageBox.Show("Your appointment has been created successfully.", "Appointment Created",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
