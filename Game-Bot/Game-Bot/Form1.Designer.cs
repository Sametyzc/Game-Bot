namespace Game_Bot
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
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label_AvantajK = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Label_Bilgi = new System.Windows.Forms.Label();
            this.Label_Sure = new System.Windows.Forms.Label();
            this.Label_Bilgilendirme = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ResimCekmekIcınTikla
            // 
            this.ResimCekmekIcınTikla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ResimCekmekIcınTikla.Location = new System.Drawing.Point(12, 10);
            this.ResimCekmekIcınTikla.Name = "ResimCekmekIcınTikla";
            this.ResimCekmekIcınTikla.Size = new System.Drawing.Size(168, 41);
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
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 355);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Label_AvantajK
            // 
            this.Label_AvantajK.AutoSize = true;
            this.Label_AvantajK.Location = new System.Drawing.Point(12, 105);
            this.Label_AvantajK.Name = "Label_AvantajK";
            this.Label_AvantajK.Size = new System.Drawing.Size(85, 13);
            this.Label_AvantajK.TabIndex = 4;
            this.Label_AvantajK.Text = "Avantaj Kutusu :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sıfırla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Label_Bilgi
            // 
            this.Label_Bilgi.AutoSize = true;
            this.Label_Bilgi.Location = new System.Drawing.Point(12, 79);
            this.Label_Bilgi.Name = "Label_Bilgi";
            this.Label_Bilgi.Size = new System.Drawing.Size(159, 13);
            this.Label_Bilgi.TabIndex = 7;
            this.Label_Bilgi.Text = "Durdurmak için P tuşuna Basınız";
            // 
            // Label_Sure
            // 
            this.Label_Sure.AutoSize = true;
            this.Label_Sure.Location = new System.Drawing.Point(13, 130);
            this.Label_Sure.Name = "Label_Sure";
            this.Label_Sure.Size = new System.Drawing.Size(84, 13);
            this.Label_Sure.TabIndex = 8;
            this.Label_Sure.Text = "Çalışma Süresi : ";
            // 
            // Label_Bilgilendirme
            // 
            this.Label_Bilgilendirme.AutoSize = true;
            this.Label_Bilgilendirme.Location = new System.Drawing.Point(13, 57);
            this.Label_Bilgilendirme.Name = "Label_Bilgilendirme";
            this.Label_Bilgilendirme.Size = new System.Drawing.Size(0, 13);
            this.Label_Bilgilendirme.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(16, 157);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 349);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Label_Bilgilendirme);
            this.Controls.Add(this.Label_Sure);
            this.Controls.Add(this.Label_Bilgi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Label_AvantajK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ResimCekmekIcınTikla);
            this.Name = "Form1";
            this.Text = "Game-Bot";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResimCekmekIcınTikla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Label_AvantajK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Label_Bilgi;
        private System.Windows.Forms.Label Label_Sure;
        private System.Windows.Forms.Label Label_Bilgilendirme;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

