using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlashCap;
namespace MusteriData
{
    public partial class Deneme : Form
    {
        //Denemeler için oluşturuan form
        public Deneme()
        {
            InitializeComponent();

        }

        private async void btnStartStop_Click(object sender, EventArgs e)
        {
           await KayıtOnAsync();
        }

        private async Task KayıtOnAsync()
        {

            // Capture device enumeration:
            var devices = new CaptureDevices();
            // Open a device with a video characteristics:
            var descriptor0 = devices.EnumerateDescriptors().ElementAt(0);

            using (var device = await descriptor0.OpenAsync(
              descriptor0.Characteristics[0],
              async bufferScope =>
              {
                  // Captured into a pixel buffer from an argument.

                  // Get image data (Maybe DIB/Jpeg/PNG):
                  byte[] image = bufferScope.Buffer.ExtractImage();


                  using (var mse = new MemoryStream(image))
                  using (var bitmap = Image.FromStream(mse) as Bitmap)
                  {
                      if (bitmap != null)
                      {
                          pictureBox1.Image?.Dispose(); // Önceki resmi serbest bırak
                          pictureBox1.Image = (Bitmap)bitmap.Clone(); // Yeni bir kopyasını oluşturarak atan
                      }
                  }

                  // ...
              }))
            {
            device.Start();
            }
        }

        private void Deneme_Load(object sender, EventArgs e)
        {
            KayıtOnAsync();
        }
    }
}
