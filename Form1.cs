using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Windows.Forms;
using System.Linq;
using yeni.Models;

namespace yeni;

public partial class Form1 : Form
{
    private readonly CustomerDbContext _context;
    private readonly string imagesFilePath = $"{Application.StartupPath}\\images\\";
    List<long> DeleteImages = new List<long>();
    CultureInfo culture = new CultureInfo("tr-TR");
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
        #region Kay�t Ekleme
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
                            image.ImagePath = ResimKaydet(resimPath, txtAdSoyad.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + sayac + Path.GetExtension(resimPath));
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
        }
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
                                Console.WriteLine("Resim ad� ba�ar�yla de�i�tirildi.");
                            }
                            catch (Exception erorr)
                            {
                                Console.WriteLine("Resim ad� de�i�tirilirken bir hata olu�tu: " + erorr.Message);
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
                    string resimPath = pictureBox.ImageLocation;
                    if (pictureBox.Tag == null)
                    {
                        CImage img = new CImage();
                        img.ImagePath = ResimKaydet(resimPath, txtAdSoyad.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + sayac + Path.GetExtension(resimPath));
                        img.MusteriId = musteri.Id;
                        _context.CImages.Add(img);
                    }
                    sayac++;
                }
                await _context.SaveChangesAsync();
                lblAd.Text = musteri.AdSoyad;
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
            dataGridView1.Rows.Add(item.Id, item.AdSoyad);
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
                //Image = new System.Drawing.Bitmap(resimDosya),
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

                    //MessageBox.Show($"T�klanan resim: {pictureBox.ImageLocation}");
                    // Yeni bir Form (popup) olu�turun
                    /* Form yeniPopup = new Form();
                     yeniPopup.Text = $"{Path.GetFileName(pictureBox.ImageLocation)}";
                     // Yeni bir PictureBox kontrol� olu�turun ve resmi y�kleyin
                     PictureBox yeniPictureBox = new PictureBox();
                     yeniPictureBox.Image = pictureBox.Image; // Orijinal PictureBox'tan resmi al�n
                     yeniPictureBox.Dock = DockStyle.Fill; // Resmi Form'un boyutuna s��acak �ekilde ayarlay�n
                     yeniPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                     // PictureBox'� yeni Form'un i�ine ekleyin
                     yeniPopup.Controls.Add(yeniPictureBox);

                     // Yeni Form'u g�sterin
                     yeniPopup.ShowDialog(); */
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

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        #region T�kland���nda G�ster
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
        #region Arama ��lemi
        string searchUp = textBox1.Text.Trim().ToUpper(new CultureInfo("tr-TR", false));
        if (searchUp.Count() > 0)
        { //Arama yap�lacak
            var veri = _context.Musteris.AsEnumerable().Where(x => x.AdSoyad.ToUpper(new CultureInfo("tr-TR", false)).Contains(searchUp)).ToList();
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
        tabPage2.Text = "G�ncelle";
        btnEkle.Text = "G�ncelle";
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
    /// <summary>
    /// T�rk�e ToLower ��lemi
    /// </summary>
    /// <param name="text"></param>
    /// <returns>String</returns>
    public static string ToTurkishLower(string text)
    {
        var culture = new CultureInfo("tr-TR");
        return text.ToLower(culture);
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }

    private void panel4_Paint(object sender, PaintEventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void panel5_Paint(object sender, PaintEventArgs e)
    {

    }
}
