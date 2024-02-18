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
    public partial class frmHastaGiris : Form
    {
        SqlBaglantisi bgl= new SqlBaglantisi();
        public frmHastaGiris()
        {
            InitializeComponent();
        }

        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komutNesnesi = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre = @p2",bgl.baglantiMethodu());
            komutNesnesi.Parameters.AddWithValue("@p1",mskTC.Text);
            komutNesnesi.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komutNesnesi.ExecuteReader();
            if (dr.Read() && dr!=null)
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc= mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            bgl.baglantiMethodu().Close();
        }
    }
}
