namespace MusteriData
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 45);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 28);
            label1.TabIndex = 0;
            label1.Text = "Kameralar";
            // 
            // comboBoxKameralar
            // 
            comboBoxKameralar.FormattingEnabled = true;
            comboBoxKameralar.Location = new Point(150, 42);
            comboBoxKameralar.Margin = new Padding(4);
            comboBoxKameralar.Name = "comboBoxKameralar";
            comboBoxKameralar.Size = new Size(468, 36);
            comboBoxKameralar.TabIndex = 1;
            comboBoxKameralar.SelectedIndexChanged += comboBoxKameralar_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(33, 153);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1168, 498);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnResimCek
            // 
            btnResimCek.Location = new Point(646, 36);
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
            btnKaydet.Location = new Point(793, 36);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(113, 47);
            btnKaydet.TabIndex = 4;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 717);
            Controls.Add(btnKaydet);
            Controls.Add(btnResimCek);
            Controls.Add(pictureBox1);
            Controls.Add(comboBoxKameralar);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "CameraForm";
            Text = "CameraForm";
            Load += CameraForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxKameralar;
        private PictureBox pictureBox1;
        private Button btnResimCek;
        private Button btnKaydet;
    }
}