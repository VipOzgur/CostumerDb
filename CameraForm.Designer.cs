﻿namespace MusteriData
{
    partial class CameraForm
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
            label1 = new Label();
            comboBoxKameralar = new ComboBox();
            pictureBox1 = new PictureBox();
            btnResimCek = new Button();
            btnKaydet = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 47);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 28);
            label1.TabIndex = 0;
            label1.Text = "Kameralar";
            // 
            // comboBoxKameralar
            // 
            comboBoxKameralar.FormattingEnabled = true;
            comboBoxKameralar.Location = new Point(133, 44);
            comboBoxKameralar.Margin = new Padding(4);
            comboBoxKameralar.Name = "comboBoxKameralar";
            comboBoxKameralar.Size = new Size(468, 36);
            comboBoxKameralar.TabIndex = 1;
            comboBoxKameralar.SelectedIndexChanged += comboBoxKameralar_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(934, 556);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnResimCek
            // 
            btnResimCek.Location = new Point(629, 38);
            btnResimCek.Name = "btnResimCek";
            btnResimCek.Size = new Size(113, 47);
            btnResimCek.TabIndex = 3;
            btnResimCek.Text = "Çek";
            btnResimCek.UseVisualStyleBackColor = true;
            btnResimCek.Click += btnResimCek_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Enabled = false;
            btnKaydet.Location = new Point(776, 38);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(113, 47);
            btnKaydet.TabIndex = 4;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxKameralar);
            panel1.Controls.Add(btnKaydet);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnResimCek);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 151);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(934, 556);
            panel2.TabIndex = 6;
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 717);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            MinimumSize = new Size(962, 764);
            Name = "CameraForm";
            Padding = new Padding(5);
            Text = "Kamera";
            WindowState = FormWindowState.Maximized;
            Load += CameraForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxKameralar;
        private PictureBox pictureBox1;
        private Button btnResimCek;
        private Button btnKaydet;
        private Panel panel1;
        private Panel panel2;
    }
}