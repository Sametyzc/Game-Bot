﻿namespace Game_Bot
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ResimCekmekIcınTikla = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label_Bilgilendirme = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ResimCekmekIcınTikla
            // 
            this.ResimCekmekIcınTikla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ResimCekmekIcınTikla.Location = new System.Drawing.Point(12, 12);
            this.ResimCekmekIcınTikla.Name = "ResimCekmekIcınTikla";
            this.ResimCekmekIcınTikla.Size = new System.Drawing.Size(105, 57);
            this.ResimCekmekIcınTikla.TabIndex = 0;
            this.ResimCekmekIcınTikla.Text = "Alanı Belirlemek Icin Tıklayın";
            this.ResimCekmekIcınTikla.UseVisualStyleBackColor = true;
            this.ResimCekmekIcınTikla.Click += new System.EventHandler(this.ResimCekmekIcınTikla_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Label_Bilgilendirme
            // 
            this.Label_Bilgilendirme.AutoSize = true;
            this.Label_Bilgilendirme.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Bilgilendirme.Location = new System.Drawing.Point(12, 98);
            this.Label_Bilgilendirme.Name = "Label_Bilgilendirme";
            this.Label_Bilgilendirme.Size = new System.Drawing.Size(0, 18);
            this.Label_Bilgilendirme.TabIndex = 1;
            // 
            // timer2
            // 
            this.timer2.Interval = 400;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(185, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer3
            // 
            this.timer3.Interval = 50;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 168);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label_Bilgilendirme);
            this.Controls.Add(this.ResimCekmekIcınTikla);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResimCekmekIcınTikla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Label_Bilgilendirme;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer3;
    }
}

