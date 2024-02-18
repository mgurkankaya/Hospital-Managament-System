using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmBrans : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        public FrmBrans()
        {
            InitializeComponent();
        }

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglantiMethodu());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@d1)", bgl.baglantiMethodu());
            komut.Parameters.AddWithValue("@d1", txtBrans.Text);
            komut.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();

            MessageBox.Show("Branch information added successfully", "Branch Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Delete From Tbl_Branslar where Bransid=@p1", bgl.baglantiMethodu());
            kmt.Parameters.AddWithValue("@p1", txtID.Text);
            kmt.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();
            MessageBox.Show("Branch information was successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Update Tbl_Branslar set BransAd=@d2 where Bransid=@d1", bgl.baglantiMethodu());
            kmt.Parameters.AddWithValue("@d1", txtID.Text);
            kmt.Parameters.AddWithValue("@d2", txtBrans.Text);


            kmt.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();

            MessageBox.Show("Doc information updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
