using FlashCap;

namespace MusteriData;

public partial class CameraForm : Form
{
    CaptureDevices devices = new CaptureDevices();
    CaptureDevice device;

    public CameraForm()
    {
        InitializeComponent();
        foreach (var descriptor in devices.EnumerateDescriptors())
        {
            if(descriptor.Characteristics.Length > 0)
            {
                comboBoxKameralar.Items.Add(descriptor.Name);
                //comboBoxKameralar.
            }
        }
        comboBoxKameralar.SelectedIndex = 0;
        //KayitOnAsync();
    }
    

    private void CameraForm_Load(object sender, EventArgs e)
    {

        KayitOnAsync();
        //device.Start();
    }
    private async Task KayitOnAsync()
    {
        if (device != null)
           await device.StopAsync();
        // Open a device with a video characteristics:
        var descriptor0 = devices.EnumerateDescriptors().ElementAt(comboBoxKameralar.SelectedIndex);

        device = await descriptor0.OpenAsync(
   descriptor0.Characteristics[0],
   async bufferScope =>
   {
       // Captured into a pixel buffer from an argument.

       // Get image data (Maybe DIB/JPEG/PNG):
       byte[] image = bufferScope.Buffer.ExtractImage();

       // Anything use of it...
       var ms = new MemoryStream(image);
       var bitmap = Bitmap.FromStream(ms);
       //if (bitmap != null)
       pictureBox1.Image = bitmap;
   });

        await device.StartAsync();

    }

    private async void comboBoxKameralar_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        await KayitOnAsync();
    }
    private void ResimCek()
    {
        Image resim = pictureBox1.Image;
        if (resim != null)
        {
            device.Stop();
            pictureBox1.Image = resim;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            btnResimCek.Text = "Yeniden Çek";
            btnKaydet.Enabled = true;
        }
    }

    private void btnResimCek_Click(object sender, EventArgs e)
    {
        if (btnResimCek.Text == "Çek")
        {
            ResimCek();
        }
        else
        {
            device.Start();
            btnResimCek.Text = "Çek";
            pictureBox1.BorderStyle = BorderStyle.None;
            btnKaydet.Enabled = false;
        }
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
        PublicClass.SharedImg = pictureBox1.Image;
        PublicClass.Durum = true;
        this.Close();

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        KayitOnAsync();
    }
}

