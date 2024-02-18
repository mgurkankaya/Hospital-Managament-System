﻿using System;
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
    
    public partial class FrmSekreterGiris : Form
    {
        SqlBaglantisi baglantiNesnesi = new SqlBaglantisi();
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komutNesnesi = new SqlCommand("Select * From Tbl_Sekreter Where SekreterTC = @s1 and SekreterSifre = @s2",baglantiNesnesi.baglantiMethodu());
            komutNesnesi.Parameters.AddWithValue("@s1",mskTC.Text);
            komutNesnesi.Parameters.AddWithValue("@s2",txtSifre.Text);

            SqlDataReader drNesne = komutNesnesi.ExecuteReader();

            if (drNesne.Read() && drNesne!=null) 
            {
                FrmSekreterDetay fr = new FrmSekreterDetay();
                fr.tcsno = mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglantiNesnesi.baglantiMethodu().Close();
        }

        private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
