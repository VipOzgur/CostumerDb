using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using yeni.Models;

namespace yeni;

public partial class Form1 : Form
{
    private readonly CustomerDbContext _context;
    private readonly string imagesFilePath = $"{Application.StartupPath}\\images\\";
    public Form1()
    {
        _context = new CustomerDbContext();
        InitializeComponent();

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.MultiSelect = false;
        MusteriListele();
    }
    private async void btnEkle_Click(object sender, EventArgs e)
    {
        #region Kayýt Ekleme
        if (string.IsNullOrEmpty(txtAdSoyad.Text))
        {
            MessageBox.Show("Ad alanýný boþ býrakmayýnýz");
            return;
        }
        if (string.IsNullOrEmpty(txtKulId.Text))
        {
            DialogResult msg=MessageBox.Show("Kayýt Eklensin mi? ","Onayla",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (msg != DialogResult.Yes) { 
            try
            {
                Musteri musteri = new Musteri();
                musteri.AdSoyad = txtAdSoyad.Text;
                _context.Musteris.Add(musteri);
                await _context.SaveChangesAsync();
                MusteriListele();
                if (flowLayoutPanel2.Controls.Count != 0)
                {
                    int sayac = 1;
                    foreach (Control c in flowLayoutPanel2.Controls)
                    {
                        PictureBox pictureBox = (PictureBox)c;
                        string resimPath = pictureBox.ImageLocation;
                        CImage image = new CImage();
                        image.ImagePath = ResimKaydet(resimPath, txtAdSoyad.Text + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + sayac + Path.GetExtension(resimPath));
                        image.MusteriId = musteri.Id;
                        _context.CImages.Add(image);
                        await _context.SaveChangesAsync();
                        sayac++;
                    }
                }
                    txtAdSoyad.Text = "";
                    flowLayoutPanel2.Controls.Clear();  
                MessageBox.Show("Kayýt Ýþlemi Baþarýlý");

            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayýt iþlemi sýrasýnda bir sorun oluþtu " + hata);
            }
            }
            else
            {
                return;
            }
        }
        else
        {
            DialogResult dior = MessageBox.Show("Veri Güncellensin mi?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dior == DialogResult.Yes)
            {
                long id = Convert.ToInt64(txtKulId.Text);
                var musteri = _context.Musteris.First(x => x.Id == id);
                musteri.AdSoyad = txtAdSoyad.Text;
                var images = _context.CImages.Where(x => x.MusteriId == id);
                if (images.Any())
                {

                }
                foreach (var image in images)
                {
                    int sayac = 1;
                    bool durum = false;
                    foreach (Control c in flowLayoutPanel2.Controls)
                    {
                        PictureBox pictureBox = (PictureBox)c;
                        string resimPath = pictureBox.ImageLocation;
                        if (imagesFilePath + image.ImagePath == resimPath)
                        {
                            durum = true;
                        }
                        if (pictureBox.Tag == null && sayac == 1)
                        {
                            CImage img = new CImage();
                            img.ImagePath = ResimKaydet(resimPath, txtAdSoyad.Text + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + sayac + Path.GetExtension(resimPath));
                            img.MusteriId = musteri.Id;
                            _context.CImages.Add(img);
                        }
                        sayac++;
                    }
                    if (!durum)
                    {
                        _context.CImages.Remove(image);
                    }
                }
                await _context.SaveChangesAsync();
                MessageBox.Show("Güncelleme Ýþlemi Baþarýlý");
                btnNoUpdate_Click(sender, e);
            }
        }
        #endregion
    }
    private void MusteriListele()
    {
        var musteriler = _context.Musteris.ToList();
        dataGridView1.Rows.Clear();
        foreach (var item in musteriler)
        {
            dataGridView1.Rows.Add(item.Id, item.AdSoyad);
        }
    }





    private void ListeleResimler(string[] imagesPath, long[] tag, int? deger)
    {
        #region Resim Listeleme
        int sayac = 0;
        foreach (var resimDosya in imagesPath)
        {
            // PictureBox oluþtur
            PictureBox pictureBox = new PictureBox
            {
                //Image = new System.Drawing.Bitmap(resimDosya),
                ImageLocation = (tag[0] != 0) ? imagesFilePath + resimDosya : resimDosya,
                SizeMode = PictureBoxSizeMode.Zoom, // Ýsteðe baðlý olarak resim boyutunu ayarla
                Width = 150, // Ýsteðe baðlý olarak geniþlik ayarla
                Height = 150, // Ýsteðe baðlý olarak yükseklik ayarla
                Tag = (tag[0] != 0) ? tag[sayac] : null
            };
            sayac++;

            // PictureBox'a týklandýðýnda yapýlacak iþlemi tanýmla 
            pictureBox.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    //MessageBox.Show($"Týklanan resim: {pictureBox.ImageLocation}");
                    // Yeni bir Form (popup) oluþturun
                    Form yeniPopup = new Form();
                    yeniPopup.Text = $"{pictureBox.ImageLocation}";
                    // Yeni bir PictureBox kontrolü oluþturun ve resmi yükleyin
                    PictureBox yeniPictureBox = new PictureBox();
                    yeniPictureBox.Image = pictureBox.Image; // Orijinal PictureBox'tan resmi alýn
                    yeniPictureBox.Dock = DockStyle.Fill; // Resmi Form'un boyutuna sýðacak þekilde ayarlayýn
                    yeniPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // PictureBox'ý yeni Form'un içine ekleyin
                    yeniPopup.Controls.Add(yeniPictureBox);

                    // Yeni Form'u gösterin
                    yeniPopup.ShowDialog();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    flowLayoutPanel2.ContextMenuStrip = new ContextMenuStrip();
                    ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Sil");
                    silMenuItem.Click += (senderMenuItem, eMenuItem) =>
                    {
                        flowLayoutPanel2.Controls.Remove(pictureBox); // PictureBox'ý FlowLayoutPanel'dan kaldýr
                    };
                    flowLayoutPanel2.ContextMenuStrip.Items.Add(silMenuItem);
                }
            };

            if (deger == 0)
            {
                // PictureBox'ý FlowLayoutPanel'a ekle
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
            else
            {
                // PictureBox'ý FlowLayoutPanel'a ekle
                flowLayoutPanel2.Controls.Add(pictureBox);
            }
        }
        #endregion
    }

    private void btnResimSec_Click(object sender, EventArgs e)
    {
        #region Resim Seç
        // Kullanýcýya resim seçtir

        openFileDialog1.Filter = "Resim Dosyalarý|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        openFileDialog1.Multiselect = true;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            ListeleResimler(openFileDialog1.FileNames, [0], 2);
        }
        #endregion
    }
    private string ResimKaydet(string resimYolu, string dosyaAdi)
    {
        File.Copy(resimYolu, imagesFilePath + dosyaAdi, true);
        return dosyaAdi;
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        #region Týklandýðýnda Göster
        if (e.RowIndex < 0) { return; }
        btnGoUpdate.Enabled = true;
        btnKayitSil.Enabled = true;
        lblAd.Text = dataGridView1.Rows[e.RowIndex].Cells["nameColumn"].Value.ToString();
        int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        btnGoUpdate.Tag = id;
        btnKayitSil.Tag = id;
        var images = _context.CImages.Where(x => x.MusteriId == id).ToList();
        flowLayoutPanel1.Controls.Clear();
        if (images.Count > 0)
        {
            ListeleResimler(images.Select(x => x.ImagePath).ToArray(), images.Select(x => x.Id).ToArray(), 0);
        }
        #endregion
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        #region Arama Ýþlemi
        string search = textBox1.Text.Trim();
        if (search.Count() > 0)
        { //Arama yapýlacak
            var veri = _context.Musteris.Where(x => x.AdSoyad.ToLower().Contains(search.ToLower()) || x.AdSoyad.ToUpper().Contains(search.ToUpper())||x.AdSoyad.Contains(search));
            dataGridView1.Rows.Clear();
            foreach (var item in veri)
            {
                dataGridView1.Rows.Add(item.Id, item.AdSoyad);
            }
        }
        else
        {
            MusteriListele();
        }
        #endregion
    }

    private void btnGoUpdate_Click(object sender, EventArgs e)
    {
        string id = btnGoUpdate.Tag.ToString();
        txtKulId.Text = id.ToString();
        txtAdSoyad.Text = lblAd.Text.ToString();
        flowLayoutPanel2.Controls.Clear();
        tabPage2.Text = "Güncelle";
        btnEkle.Text = "Güncelle";
        var images = _context.CImages.Where(x => x.MusteriId == Convert.ToInt16(id)).ToList();
        if (images.Count > 0)
        {
            ListeleResimler(images.Select(x => x.ImagePath).ToArray(), images.Select(x => x.Id).ToArray(), 1);
        }
        btnNoUpdate.Visible = true;
        tabControl1.SelectTab(tabPage2);
    }

    private void btnNoUpdate_Click(object sender, EventArgs e)
    {
        txtKulId.Text = "";
        txtAdSoyad.Text = "";
        flowLayoutPanel2.Controls.Clear();
        tabPage2.Text = "Ekle";
        btnEkle.Text = "Ekle";
        tabControl1.SelectTab(tabPage1);
        btnNoUpdate.Visible = false;
    }

    private void btnKayitSil_Click(object sender, EventArgs e)
    {
        #region Kayýt Silme Ýþlemi
        DialogResult soru = MessageBox.Show("Veri Silinsin mi?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (soru == DialogResult.Yes)
        {
            try
            {
                long id = Convert.ToInt16(btnKayitSil.Tag);
                if (id > 0)
                {
                    var musteri = _context.Musteris.FirstOrDefault(x => x.Id == id);
                    if (musteri != null)
                    {
                        _context.Musteris.Remove(musteri);
                        var images = _context.CImages.Where(x => x.MusteriId == id).ToList();
                        foreach (var item in images)
                        {
                            _context.CImages.Remove(item);
                        }
                        _context.SaveChanges();
                        MusteriListele();
                        btnGoUpdate.Enabled = false;
                        btnKayitSil.Enabled = false;
                        lblAd.Text = "";
                        if(textBox1.Text.Length > 0)
                        {
                            textBox1_TextChanged(sender,e);
                        }
                        else
                        {
                            MusteriListele();
                        }
                        flowLayoutPanel1.Controls.Clear();
                        MessageBox.Show("Kayýt Silme iþlemi baþarýlý");
                    }
                    else
                    {
                        MessageBox.Show("Kayýt Bulunamadý");
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("Silme iþlemi sýrasýnda bir sorun oluþtu " + hata);
            }
        }
        #endregion
    }
}
