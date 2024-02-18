namespace Proje_Hastane
{
    partial class FrmDoktorGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoktorGiris));
            this.btnDoktorGirisYap = new System.Windows.Forms.Button();
            this.txtDoktorSifre = new System.Windows.Forms.TextBox();
            this.mskDoktorTC = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDoktorGirisYap
            // 
            this.btnDoktorGirisYap.Location = new System.Drawing.Point(333, 144);
            this.btnDoktorGirisYap.Name = "btnDoktorGirisYap";
            this.btnDoktorGirisYap.Size = new System.Drawing.Size(83, 40);
            this.btnDoktorGirisYap.TabIndex = 3;
            this.btnDoktorGirisYap.Text = "Login";
            this.btnDoktorGirisYap.UseVisualStyleBackColor = true;
            this.btnDoktorGirisYap.Click += new System.EventHandler(this.btnDoktorGirisYap_Click);
            // 
            // txtDoktorSifre
            // 
            this.txtDoktorSifre.Location = new System.Drawing.Point(208, 107);
            this.txtDoktorSifre.Name = "txtDoktorSifre";
            this.txtDoktorSifre.Size = new System.Drawing.Size(208, 29);
            this.txtDoktorSifre.TabIndex = 2;
            this.txtDoktorSifre.UseSystemPasswordChar = true;
            // 
            // mskDoktorTC
            // 
            this.mskDoktorTC.Location = new System.Drawing.Point(208, 70);
            this.mskDoktorTC.Mask = "00000000000";
            this.mskDoktorTC.Name = "mskDoktorTC";
            this.mskDoktorTC.Size = new System.Drawing.Size(208, 29);
            this.mskDoktorTC.TabIndex = 1;
            this.mskDoktorTC.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Identification Number :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(46, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "DOCTOR LOGIN PANEL";
            // 
            // FrmDoktorGiris
            // 
            this.AcceptButton = this.btnDoktorGirisYap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(435, 194);
            this.Controls.Add(this.btnDoktorGirisYap);
            this.Controls.Add(this.txtDoktorSifre);
            this.Controls.Add(this.mskDoktorTC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDoktorGiris";
            this.Text = "Doctor Login Panel";
            this.Load += new System.EventHandler(this.FrmDoktorGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoktorGirisYap;
        private System.Windows.Forms.TextBox txtDoktorSifre;
        private System.Windows.Forms.MaskedTextBox mskDoktorTC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}