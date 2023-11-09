namespace yeni
{
    partial class Form2
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
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            btnBuyut = new Button();
            btnKucult = new Button();
            btnGeri = new Button();
            btnIleri = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.Location = new Point(409, 179);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 213);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(30, 30);
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(30);
            panel1.Size = new Size(1132, 624);
            panel1.TabIndex = 5;
            // 
            // btnBuyut
            // 
            btnBuyut.Anchor = AnchorStyles.Bottom;
            btnBuyut.BackColor = Color.Transparent;
            btnBuyut.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnBuyut.Location = new Point(594, 546);
            btnBuyut.Name = "btnBuyut";
            btnBuyut.Size = new Size(94, 56);
            btnBuyut.TabIndex = 10;
            btnBuyut.Text = "+";
            btnBuyut.UseVisualStyleBackColor = false;
            btnBuyut.Click += btnBuyut_Click;
            // 
            // btnKucult
            // 
            btnKucult.Anchor = AnchorStyles.Bottom;
            btnKucult.BackColor = Color.Transparent;
            btnKucult.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnKucult.Location = new Point(441, 546);
            btnKucult.Name = "btnKucult";
            btnKucult.Size = new Size(94, 56);
            btnKucult.TabIndex = 7;
            btnKucult.Text = "-";
            btnKucult.UseVisualStyleBackColor = false;
            btnKucult.Click += btnKucult_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Left;
            btnGeri.BackColor = Color.Transparent;
            btnGeri.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnGeri.Location = new Point(39, 244);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(94, 59);
            btnGeri.TabIndex = 8;
            btnGeri.Text = "<";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // btnIleri
            // 
            btnIleri.Anchor = AnchorStyles.Right;
            btnIleri.BackColor = Color.Transparent;
            btnIleri.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnIleri.Location = new Point(1003, 244);
            btnIleri.Name = "btnIleri";
            btnIleri.Size = new Size(94, 59);
            btnIleri.TabIndex = 11;
            btnIleri.Text = ">";
            btnIleri.UseVisualStyleBackColor = false;
            btnIleri.Click += btnIleri_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 624);
            Controls.Add(btnIleri);
            Controls.Add(btnGeri);
            Controls.Add(btnKucult);
            Controls.Add(btnBuyut);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Form2";
            WindowState = FormWindowState.Maximized;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnKucult;
        private Button btnGeri;
        private Button btnBuyut;
        private Button btnIleri;
    }
}