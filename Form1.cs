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
        #region Kay�t Ekleme && G�ncelleme
        if (string.IsNullOrEmpty(txtAdSoyad.Text))
        {
            MessageBox.Show("Ad alan�n� bo� b�rakmay�n�z");
            return;
        }
        if (string.IsNullOrEmpty(txtKulId.Text))
        {
            DialogResult msg = MessageBox.Show("Kay�t Eklensin mi? ", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    MessageBox.Show("Kay�t ��lemi Ba�ar�l�");

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Kay�t i�lemi s�ras�nda bir sorun olu�tu " + hata);
                }
            }
            else
            {
                return;
            }
        }//G�ncelleme i�lemi
        else
        {
            DialogResult dior = MessageBox.Show("Veri G�ncellensin mi?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                if (musteri.AdSoyad != txtAdSoyad.Text.Trim())//�smin farkl� oldu�u durumlar
                {
                    var updImage = _context.CImages.Where(x => x.MusteriId == id).ToList();
                    foreach (var x in updImage)
                    {
                        string resimYolu = imagesFilePath + x.ImagePath;// De�i�tirmek istedi�iniz resmin mevcut yolu
                        x.ImagePath = x.ImagePath.Replace(musteri.AdSoyad, txtAdSoyad.Text.Trim());
                        string yeniAd = x.ImagePath; // Yeni ad

                        if (File.Exists(resimYolu))
                        {
                            string hedefYol = Path.Combine(Path.GetDirectoryName(resimYolu), yeniAd);

                            try
                            {
                                File.Move(resimYolu, hedefYol);
                                //Console.WriteLine("Resim ad� ba�ar�yla de�i�tirildi.");
                            }
                            catch (Exception erorr)
                            {
                                //Console.WriteLine("Resim ad� de�i�tirilirken bir hata olu�tu: " + erorr.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Belirtilen dosya bulunamad�.");
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
                MessageBox.Show("G�ncelleme ��lemi Ba�ar�l�");
                MusteriListele();
                btnNoUpdate_Click(sender, e);
            }
        }
        #endregion
    }
    ///<summary>
    ///M��teri Verilerini DataGridView e Listeler
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
            // PictureBox olu�tur
            PictureBox pictureBox = new PictureBox
            {
                ImageLocation = (tag[0] != 0) ? imagesFilePath + resimDosya : resimDosya,
                SizeMode = PictureBoxSizeMode.Zoom, // �ste�e ba�l� olarak resim boyutunu ayarla
                Width = 150, // �ste�e ba�l� olarak geni�lik ayarla
                Height = 150, // �ste�e ba�l� olarak y�kseklik ayarla
                Tag = (tag[0] != 0) ? tag[sayac] : null
            };
            sayac++;

            // PictureBox'a t�kland���nda yap�lacak i�lemi tan�mla 
            pictureBox.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    PictureBox clickedPictureBox = (PictureBox)sender; // T�klanan PictureBox'� al�n

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
                        flowLayoutPanel2.Controls.Remove(pictureBox); // PictureBox'� FlowLayoutPanel'dan kald�r
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
                // PictureBox'� FlowLayoutPanel'a ekle
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
            else
            {
                // PictureBox'� FlowLayoutPanel'a ekle
                flowLayoutPanel2.Controls.Add(pictureBox);
            }
        }
        #endregion
    }

    private void btnResimSec_Click(object sender, EventArgs e)
    {
        #region Resim Se�
        // Kullan�c�ya resim se�tir

        openFileDialog1.Filter = "Resim Dosyalar�|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
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
        #region T�kland���nda G�ster
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
        #region Arama ��lemi
        string searchUp = textBox1.Text.Trim().ToUpper(new CultureInfo("tr-TR", false));
        if (searchUp.Count() > 0)
        { //Arama yap�lacak
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
        tabPage2.Text = "G�ncelle";
        btnEkle.Text = "G�ncelle";
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
        #region Kay�t Silme ��lemi
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
                        MessageBox.Show("Kay�t Silme i�lemi ba�ar�l�");
                    }
                    else
                    {
                        MessageBox.Show("Kay�t Bulunamad�");
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("Silme i�lemi s�ras�nda bir sorun olu�tu " + hata);
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
                SizeMode = PictureBoxSizeMode.Zoom, // �ste�e ba�l� olarak resim boyutunu ayarla
                Width = 150, // �ste�e ba�l� olarak geni�lik ayarla
                Height = 150, // �ste�e ba�l� olarak y�kseklik ayarla
                Tag = null
            };
            // PictureBox'a t�kland���nda yap�lacak i�lemi tan�mla 
            pictureBox.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    PictureBox clickedPictureBox = (PictureBox)sender; // T�klanan PictureBox'� al�n

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
                        flowLayoutPanel2.Controls.Remove(pictureBox); // PictureBox'� FlowLayoutPanel'dan kald�r
                        if (pictureBox.Tag != null)
                        {
                            DeleteImages.Add(Convert.ToInt64(pictureBox.Tag));
                        }
                    };
                    flowLayoutPanel2.ContextMenuStrip.Items.Add(silMenuItem);
                }
            };
            // PictureBox'� FlowLayoutPanel'a ekle
            flowLayoutPanel2.Controls.Add(pictureBox);
            //PublicClass.SharedImg.Dispose();
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show("Uygulamay� kapatmak istedi�inizden emin misiniz?", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            e.Cancel = true; // Formun kapanmas�n� iptal et
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Deneme deneme = new Deneme();
        deneme.ShowDialog();
    }
}
