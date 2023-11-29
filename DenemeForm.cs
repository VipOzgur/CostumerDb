using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriData
{
    public partial class DenemeForm : Form
    {
        public DenemeForm()
        {
            InitializeComponent();
            // Resmi kırpmak için 3x4 oranı kullan
            // PictureBox1'in içindeki resmi PictureBox2'ye kopyala
            // Resmi taşırken kalite kaybını en aza indirmek için resampling kullanın
            //using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            //{
            //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), GraphicsUnit.Pixel);
            //}



            // Get the original image
            Bitmap originalImage = new Bitmap(pictureBox1.Image);

            // Calculate the new image's size and position
            int newWidth = originalImage.Width - 60;
            int newHeight = originalImage.Height - 60;
            int newX = 30;
            int newY = 30;

            // Create a new image with the calculated size and position
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // Copy the original image's area to the new image
                Rectangle sourceRect = new Rectangle(newX, newY, newWidth, newHeight);
                Rectangle destRect = new Rectangle(0, 0, newWidth, newHeight);
                g.DrawImage(originalImage, destRect, sourceRect, GraphicsUnit.Pixel);
            }
            pictureBox2.Image = newImage;  
        }
        public static Image CropImage(string sourceImagePath, int aspectRatioWidth, int aspectRatioHeight)
        {
            // Kaynak resmi aç
            using Bitmap sourceImage = new Bitmap(sourceImagePath);

            // Yeni resmin boyutlarını hesapla
            int newWidth = aspectRatioWidth;
            int newHeight = aspectRatioHeight;

            // Yeni resmi oluştur
            using Bitmap croppedImage = new Bitmap(newWidth, newHeight);

            // Kaynak resmi yeni resme kopyala
            using Graphics graphics = Graphics.FromImage(croppedImage);
            graphics.DrawImage(sourceImage, 0, 0, newWidth, newHeight);

            // Sonuç resmini diske kaydet
            return croppedImage;
        }




        public static Image CropTo3x4(Image img)
        {
            // Ölçeklendirme büyüklüğünü hesaplayın
            double ratio = img.Width / (double)img.Height;
            int newWidth = 3 * 4; // 3*4 oranı
            int newHeight = (int)Math.Round(newWidth / ratio);

            // Ölçeklendirilmiş görüntüyü oluşturun
            Image newImg = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImg))
            {
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return newImg;
        }

    }
}
