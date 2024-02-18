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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        
        public string tcsno;
        SqlBaglantisi bgl= new SqlBaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {


           

            lblTC.Text = tcsno;
          
           

            //Ad Soyad Çekme

            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter Where SekreterTC=@p1",bgl.baglantiMethodu());
            komut1.Parameters.AddWithValue("@p1",tcsno);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }

            bgl.baglantiMethodu().Close();

            //Branşları DataGrid'e Çekme

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglantiMethodu());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktor bilgisi çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Docs',DoktorBrans From Tbl_Doktorlar", bgl.baglantiMethodu());

            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşı combobax'a çekne

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglantiMethodu());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglantiMethodu().Close();



        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2kaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",bgl.baglantiMethodu());
            komut2kaydet.Parameters.AddWithValue("@r1", mskTarih.Text);
            komut2kaydet.Parameters.AddWithValue("@r2", mskSaat.Text);
            komut2kaydet.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komut2kaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);

            komut2kaydet.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();
            MessageBox.Show("Appointment creation is successful.", "Appointment Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Branşa tıklanınca Doktor Adını Combobox'a çekme

            cmbDoktor.Items.Clear(); //listeyi temizle

            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglantiMethodu());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);  //Sql'deki şartı ekleme
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglantiMethodu().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)",bgl.baglantiMethodu());
            kmt.Parameters.AddWithValue("@d1",rchDuyuru.Text);
            kmt.ExecuteNonQuery();
            bgl.baglantiMethodu().Close();
            MessageBox.Show("Your announcement has been added to the system.","Announcement",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp = new FrmDoktorPaneli();
            drp.Show();
        }

        private void btnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans frm = new FrmBrans();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            
           
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr = new FrmRandevuListesi();
            fr.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();
        }
    }
}
