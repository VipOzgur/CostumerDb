using FlashCap;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MusteriData;

public partial class CameraForm : Form
{
    CaptureDevices devices = new CaptureDevices();
    CaptureDevice device;
    int newWidth;
    int newHeight;
    public CameraForm()
    {
        InitializeComponent();
        foreach (var descriptor in devices.EnumerateDescriptors())
        {
            if (descriptor.Characteristics.Length > 0)
            {
                comboBoxKameralar.Items.Add(descriptor.Name);
            }
        }
        comboBoxKameralar.SelectedIndex = PublicClass.ComboBoxKameralarSelectedIndex;
        comboBox1.Items.Add("Orjinal");
        comboBox1.Items.Add("3:4");
        comboBox1.Items.Add("1:1");
        comboBox1.Items.Add("9:16");
        this.AcceptButton = (btnResimCek.Text == "Çek") ? btnResimCek : btnKaydet;
    }


    private void CameraForm_Load(object sender, EventArgs e)
    {
        KayitOnAsync();
        //comboBox1.SelectedIndex = PublicClass.ComboBox1SelectedIndex;
    }
    private async Task KayitOnAsync()
    {
        try
        {
            // Open a device with a video characteristics:
            var descriptor0 = devices.EnumerateDescriptors().ElementAt(PublicClass.ComboBoxKameralarSelectedIndex);
            if (descriptor0.Characteristics.Length > 0)
            {
                if (device != null)
                {
                    await device.StopAsync();
                    await device.DisposeAsync();
                }
                device = await descriptor0.OpenAsync(descriptor0.Characteristics[0],
                async bufferScope =>
                {
                    // Captured into a pixel buffer from an argument.
                    // Get image data (Maybe DIB/JPEG/PNG):
                    byte[] image = bufferScope.Buffer.ExtractImage();

                    using (var mse = new MemoryStream(image))
                    using (var bitmap = System.Drawing.Image.FromStream(mse) as Bitmap)
                    {
                        if (bitmap != null)
                        {
                            pictureBox1.Image?.Dispose(); // Önceki resmi serbest bırak
                            pictureBox1.Image = (Bitmap)bitmap.Clone(); // Yeni bir kopyasını oluşturarak atan
                        }
                    }
                });
            }
            await device.StartAsync();
            comboBox1.SelectedIndex = PublicClass.ComboBox1SelectedIndex;
        }
        catch (Exception)
        {
            MessageBox.Show("Başka bir cihaz seçin");
        }
    }

    private void comboBoxKameralar_SelectedIndexChanged(object sender, EventArgs e)
    {

        PublicClass.ComboBoxKameralarSelectedIndex = comboBoxKameralar.SelectedIndex;
        KayitOnAsync();
    }
    private void ResimCek(bool durum)
    {
        if (pictureBox1.Image != null)
        {
            if (durum)
            {

                device.StopAsync();
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                btnResimCek.Text = "Yeniden Çek";
                btnKaydet.Enabled = true;
            }
            else
            {
                device.StartAsync();
                btnResimCek.Text = "Çek";
                pictureBox1.BorderStyle = BorderStyle.None;
                btnKaydet.Enabled = false;
            }
        }
    }

    private void btnResimCek_Click(object sender, EventArgs e)
    {
        if (btnResimCek.Text == "Çek")
        {
            ResimCek(true);
        }
        else
        {
            ResimCek(false);
        }
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
        if (pictureBox1.Image != null)
        {
            PublicClass.SharedImg = ResimGetir();    ////(Image)pictureBox1.Image.Clone();
            PublicClass.Durum = true;
            this.Close();
        }
        else
        {
            MessageBox.Show("Kaydetmek için geçerli bir görüntü bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (device != null)
            device.Dispose();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (device != null)
        {
            PublicClass.ComboBox1SelectedIndex = comboBox1.SelectedIndex;
            newWidth = device.Characteristics.Width;
            newHeight = device.Characteristics.Height;
            // Yeni boyutları belirle (örneğin, 3/4 oranında)
            if (newHeight < newWidth)
            {
                switch (PublicClass.ComboBox1SelectedIndex)
                {
                    case 1:
                        newWidth = (newHeight / 4) * 3;
                        break;
                    case 2:
                        newWidth = newHeight;
                        break;
                    case 3:
                        newWidth = (newHeight / 16) * 9;
                        break;
                }
            }
            else
            {
                switch (PublicClass.ComboBox1SelectedIndex)
                {
                    case 1:
                        ;
                        newHeight = (newWidth / 3) * 4;
                        break;
                    case 2:
                        newHeight = newWidth;
                        break;
                    case 3:
                        newHeight = (newWidth / 9) * 16;
                        break;
                }
            }
            pictureBox1.Height = newHeight;
            pictureBox1.Width = newWidth;

        }
    }

    private void pictureBox1_SizeChanged(object sender, EventArgs e)
    {
        Ortala();
    }
    private void Ortala()
    {
        pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
        pictureBox1.Top = (panel2.ClientSize.Height - pictureBox1.Height) / 3;
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
    }
    private Image ResimGetir()
    {
        // Get the original image
        using (Bitmap originalImage = new Bitmap(pictureBox1.Image))
        {


            // Get the PictureBox's size and position
            int pictureboxWidth = pictureBox1.Width;
            int pictureboxHeight = pictureBox1.Height;
            int newX = ((originalImage.Width - pictureboxWidth) / 2);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            // Create a new image with the calculated size and position
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // Copy the original image's area to the new image
                Rectangle sourceRect = new Rectangle(newX, 0, pictureboxWidth, pictureboxHeight);
                Rectangle destRect = new Rectangle(0, 0, pictureboxWidth, pictureboxHeight);
                g.DrawImage(originalImage, destRect, sourceRect, GraphicsUnit.Pixel);
            }
            return newImage;
        }

    }
}

