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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglantiMethodu());

            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;



            //Branşları Combobox'a çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglantiMethodu());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglantiMethodu().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans, DoktorTC, DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglantiMethodu());
            komut.Parameters.AddWithValue("@d1",txtAd.Text);
            komut.Parameters.AddWithValue("@d2",txtSoyad.Text);
            komut.Parameters.AddWithValue("@d3",cmbBrans.Text);
            komut.Parameters.AddWithValue("@d4",mskTC.Text);
            komut.Parameters.AddWithValue("@d5",txtSifre.Text);

            komut.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();

            MessageBox.Show("Doc information added successfully","Added",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Delete From Tbl_Doktorlar where DoktorTC=@p1", bgl.baglantiMethodu());
            kmt.Parameters.AddWithValue("@p1",mskTC.Text);
            kmt.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();
            MessageBox.Show("doctor information was successfully deleted","Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2, DoktorBrans=@d3, DoktorSifre=@d5 where DoktorTC=@d4",bgl.baglantiMethodu());
            kmt.Parameters.AddWithValue("@d1", txtAd.Text);
            kmt.Parameters.AddWithValue("@d2", txtSoyad.Text);
            kmt.Parameters.AddWithValue("@d3", cmbBrans.Text);
            kmt.Parameters.AddWithValue("@d4", mskTC.Text);
            kmt.Parameters.AddWithValue("@d5", txtSifre.Text);

            kmt.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();

            MessageBox.Show("Doc information updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
