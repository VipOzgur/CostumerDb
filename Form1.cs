using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Windows.Forms;
using System.Linq;
using MusteriData.Models;
using MusteriData;
using System.Drawing.Imaging;

namespace yeni;

public partial class Form1 : Form
{
    private readonly CustomerDbContext _context;
    private readonly string imagesFilePath = $"{Application.StartupPath}\\images\\";
    List<long> DeleteImages = new List<long>();
    public Form1()
    {
        _context = new CustomerDbContext();
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        label2.Text = "";
        btnNoUpdate.Visible = true;
        dataGridView1.MultiSelect = false;
        MusteriListele();
    }
    private async void btnEkle_Click(object sender, EventArgs e)
    {
        #region Kayýt Ekleme && Güncelleme
        if (string.IsNullOrEmpty(txtAdSoyad.Text))
        {
            MessageBox.Show("Ad alanýný boþ býrakmayýnýz");
            return;
        }
        if (string.IsNullOrEmpty(txtKulId.Text))
        {
            DialogResult msg = MessageBox.Show("Kayýt Eklensin mi? ", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                try
                {
                    Musteri musteri = new Musteri();
                    musteri.AdSoyad = txtAdSoyad.Text;
                    musteri.UploadDate = $"{new CultureInfo("tr-TR").DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)}  {DateTime.Now.ToString("dd/MM/yyyy HH-mm")}";
                    _context.Musteris.Add(musteri);
                    await _context.SaveChangesAsync();
                    MusteriListele();
                    if (flowLayoutPanel2.Controls.Count != 0)
                    {
                        int sayac = 1;
                        foreach (Control c in flowLayoutPanel2.Controls)
                        {
                            PictureBox pictureBox = (PictureBox)c;
                            CImage image = new CImage();
                            if (pictureBox.ImageLocation != null)
                            {
                                string resimPath = pictureBox.ImageLocation;
                                image.ImagePath = ResimKaydet(resimPath, txtAdSoyad.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + sayac + Path.GetExtension(resimPath));
                            }
                            else
                            {
                                image.ImagePath = ResimKaydet(pictureBox.Image, txtAdSoyad.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + sayac);
                            }
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
        }//Güncelleme iþlemi
        else
        {
            DialogResult dior = MessageBox.Show("Veri Güncellensin mi?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dior == DialogResult.Yes)
            {
                long id = Convert.ToInt64(txtKulId.Text);
                var musteri = _context.Musteris.First(x => x.Id == id);
                if (DeleteImages != null)
                {

                    foreach (var x in DeleteImages) //Silinecek resimleri sil
                    {
                        var delImage = _context.CImages.FirstOrDefault(p => p.Id == x);
                        if (delImage != null)
                        {
                            _context.CImages.Remove(delImage);
                        }
                    }
                    DeleteImages.Clear();
                }
                _context.SaveChanges();
                if (musteri.AdSoyad != txtAdSoyad.Text.Trim())//Ýsmin farklý olduðu durumlar
                {
                    var updImage = _context.CImages.Where(x => x.MusteriId == id).ToList();
                    foreach (var x in updImage)
                    {
                        string resimYolu = imagesFilePath + x.ImagePath;// Deðiþtirmek istediðiniz resmin mevcut yolu
                        x.ImagePath = x.ImagePath.Replace(musteri.AdSoyad, txtAdSoyad.Text.Trim());
                        string yeniAd = x.ImagePath; // Yeni ad

                        if (File.Exists(resimYolu))
                        {
                            string hedefYol = Path.Combine(Path.GetDirectoryName(resimYolu), yeniAd);

                            try
                            {
                                File.Move(resimYolu, hedefYol);
                                //Console.WriteLine("Resim adý baþarýyla deðiþtirildi.");
                            }
                            catch (Exception erorr)
                            {
                                //Console.WriteLine("Resim adý deðiþtirilirken bir hata oluþtu: " + erorr.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Belirtilen dosya bulunamadý.");
                        }
                        _context.CImages.Update(x);
                    }
                    _context.SaveChanges();
                }
                musteri.AdSoyad = txtAdSoyad.Text;
                int sayac = 1;
                foreach (Control c in flowLayoutPanel2.Controls)
                {
                    PictureBox pictureBox = (PictureBox)c;
                    if (pictureBox.Tag == null)
                    {
                        CImage img = new CImage();
                        if (pictureBox.ImageLocation != null)
                        {
                            string resimPath = pictureBox.ImageLocation;
                            img.ImagePath = ResimKaydet(resimPath, txtAdSoyad.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + sayac + Path.GetExtension(resimPath));
                        }
                        else
                        {
                            img.ImagePath = ResimKaydet(pictureBox.Image, txtAdSoyad.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + sayac);
                        }
                        img.MusteriId = musteri.Id;
                        _context.CImages.Add(img);
                    }
                    sayac++;
                }
                await _context.SaveChangesAsync();
                lblAd.Text = musteri.AdSoyad;
                label2.Text = musteri.UploadDate;
                var images = _context.CImages.Where(x => x.MusteriId == musteri.Id).ToList();
                flowLayoutPanel1.Controls.Clear();
                if (images.Count > 0)
                {
                    ListeleResimler(images.Select(x => x.ImagePath).ToArray(), images.Select(x => x.Id).ToArray(), 0);
                }
                MessageBox.Show("Güncelleme Ýþlemi Baþarýlý");
                MusteriListele();
                btnNoUpdate_Click(sender, e);
            }
        }
        #endregion
    }
    ///<summary>
    ///Müþteri Verilerini DataGridView e Listeler
    ///</summary>
    private void MusteriListele()
    {
        var musteriler = _context.Musteris.ToList();
        dataGridView1.Rows.Clear();
        foreach (var item in musteriler)
        {
            dataGridView1.Rows.Add(item.AdSoyad, item.UploadDate, item.Id);
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
                    PictureBox clickedPictureBox = (PictureBox)sender; // Týklanan PictureBox'ý alýn

                    Control.ControlCollection controls = (flowLayoutPanel1.Controls.Contains(clickedPictureBox)) ? flowLayoutPanel1.Controls : flowLayoutPanel2.Controls;
                    int index = controls.IndexOf(clickedPictureBox);
                    int lastindex = controls.Count - 1;
                    Form2 form2 = new Form2(index, lastindex, controls);
                    form2.Show();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    flowLayoutPanel2.ContextMenuStrip = new ContextMenuStrip();
                    ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Sil");
                    silMenuItem.Click += (senderMenuItem, eMenuItem) =>
                    {
                        flowLayoutPanel2.Controls.Remove(pictureBox); // PictureBox'ý FlowLayoutPanel'dan kaldýr
                        if (pictureBox.Tag != null)
                        {
                            DeleteImages.Add(Convert.ToInt64(pictureBox.Tag));
                        }
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
    private string ResimKaydet(Image img, string dosyaAdi)
    {
        img.Save(imagesFilePath + dosyaAdi + ".jpeg", ImageFormat.Jpeg);
        return dosyaAdi + ".jpeg";
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        #region Týklandýðýnda Göster
        if (e.RowIndex < 0) { return; }
        btnGoUpdate.Enabled = true;
        btnKayitSil.Enabled = true;
        lblAd.Text = dataGridView1.Rows[e.RowIndex].Cells["nameColumn"].Value.ToString();
        int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        label2.Text = dataGridView1.Rows[e.RowIndex].Cells["uploadDate"].Value.ToString();
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
        string searchUp = textBox1.Text.Trim().ToUpper(new CultureInfo("tr-TR", false));
        if (searchUp.Count() > 0)
        { //Arama yapýlacak
            var veri = _context.Musteris.AsEnumerable().Where(x => x.AdSoyad.ToUpper(new CultureInfo("tr-TR", false)).Contains(searchUp)).ToList();
            dataGridView1.Rows.Clear();
            foreach (var item in veri)
            {
                dataGridView1.Rows.Add(item.AdSoyad, item.UploadDate, item.Id);
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
        //btnNoUpdate.Visible = true;
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
        //btnNoUpdate.Visible = false;
        if (DeleteImages != null)
        {
            DeleteImages.Clear();
        }
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
                        label2.Text = "";
                        if (textBox1.Text.Length > 0)
                        {
                            textBox1_TextChanged(sender, e);
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

    private void btnOpenCamera_Click(object sender, EventArgs e)
    {
        CameraForm form = new CameraForm();
        form.FormClosed += CameraForm_FormClosed;
        form.ShowDialog();
    }

    private void CameraForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        if (PublicClass.Durum)
        {
            PublicClass.Durum = false;
            //ListeleResimler([$"{PublicClass.SharedImg}"], [0], 1);
            PictureBox pictureBox = new PictureBox
            {
                Image = PublicClass.SharedImg,
                SizeMode = PictureBoxSizeMode.Zoom, // Ýsteðe baðlý olarak resim boyutunu ayarla
                Width = 150, // Ýsteðe baðlý olarak geniþlik ayarla
                Height = 150, // Ýsteðe baðlý olarak yükseklik ayarla
                Tag = null
            };
            // PictureBox'a týklandýðýnda yapýlacak iþlemi tanýmla 
            pictureBox.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    PictureBox clickedPictureBox = (PictureBox)sender; // Týklanan PictureBox'ý alýn

                    Control.ControlCollection controls = (flowLayoutPanel1.Controls.Contains(clickedPictureBox)) ? flowLayoutPanel1.Controls : flowLayoutPanel2.Controls;
                    int index = controls.IndexOf(clickedPictureBox);
                    int lastindex = controls.Count - 1;
                    Form2 form2 = new Form2(index, lastindex, controls);
                    form2.Show();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    flowLayoutPanel2.ContextMenuStrip = new ContextMenuStrip();
                    ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Sil");
                    silMenuItem.Click += (senderMenuItem, eMenuItem) =>
                    {
                        flowLayoutPanel2.Controls.Remove(pictureBox); // PictureBox'ý FlowLayoutPanel'dan kaldýr
                        if (pictureBox.Tag != null)
                        {
                            DeleteImages.Add(Convert.ToInt64(pictureBox.Tag));
                        }
                    };
                    flowLayoutPanel2.ContextMenuStrip.Items.Add(silMenuItem);
                }
            };
            // PictureBox'ý FlowLayoutPanel'a ekle
            flowLayoutPanel2.Controls.Add(pictureBox);
            //PublicClass.SharedImg.Dispose();
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show("Uygulamayý kapatmak istediðinizden emin misiniz?", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            e.Cancel = true; // Formun kapanmasýný iptal et
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Deneme deneme = new Deneme();
        deneme.ShowDialog();
    }
}
