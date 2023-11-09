using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yeni
{
    public partial class Form2 : Form
    {
        int indexx = 0; int indexLast = 0;
        Control.ControlCollection controls = null;
        public Form2(int index, int lastIndex, Control.ControlCollection control)
        {
            indexx = index;
            indexLast = lastIndex;
            controls = control;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ResimGoster();
        }
        private void ResimGoster()
        {
            if (indexx >= 0)
            {
                PictureBox selectedPictureBox = controls[indexx] as PictureBox;
                if (selectedPictureBox.Image != null)
                {
                    this.Text = $"{Path.GetFileName(selectedPictureBox.ImageLocation)}";
                    pictureBox1.Image = selectedPictureBox.Image;
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                Ortala();
            }
        }

        private void btnBuyut_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Height < 2500)
            {

                Size newSize = new Size((int)(pictureBox1.Width * 1.1), (int)(pictureBox1.Height * 1.1));
                pictureBox1.Size = newSize;
                pictureBox1.Image = new Bitmap(pictureBox1.Image, newSize);
                Ortala();
            }
        }

        private void btnKucult_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Height > 100)
            {
                Size newSize = new Size((int)(pictureBox1.Width * 0.9), (int)(pictureBox1.Height * 0.9));
                pictureBox1.Size = newSize;
                pictureBox1.Image = new Bitmap(pictureBox1.Image, newSize);
                Ortala();
            }
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            if (indexx < indexLast)
            {
                indexx++;
                ResimGoster();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (indexx > 0)
            {
                indexx--;
                ResimGoster();
            }
        }

        private void Ortala()
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
            if (pictureBox1.Width > panel1.Width - 30 || pictureBox1.Height > panel1.Height - 30)
            {
                panel1.AutoScroll = true;
                //panel1.AutoScrollMinSize=new Size(pictureBox1.Width, pictureBox1.Height);
                panel1.AutoScrollMinSize = new Size(panel1.Width, panel1.Height);
            }
        }
    }
}
