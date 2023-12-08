namespace MusteriData
{
    partial class Deneme
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
            btnStartStop = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(721, 39);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(159, 62);
            btnStartStop.TabIndex = 0;
            btnStartStop.Text = "button1";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(59, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 461);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Deneme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 562);
            Controls.Add(pictureBox1);
            Controls.Add(btnStartStop);
            Name = "Deneme";
            Text = "Deneme";
            Load += Deneme_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartStop;
        private PictureBox pictureBox1;
    }
}