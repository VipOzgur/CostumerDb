namespace yeni;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        btnKayitSil = new Button();
        btnGoUpdate = new Button();
        lblAd = new Label();
        label2 = new Label();
        flowLayoutPanel1 = new FlowLayoutPanel();
        dataGridView1 = new DataGridView();
        Id = new DataGridViewTextBoxColumn();
        nameColumn = new DataGridViewButtonColumn();
        textBox1 = new TextBox();
        label1 = new Label();
        tabPage2 = new TabPage();
        btnNoUpdate = new Button();
        txtKulId = new TextBox();
        flowLayoutPanel2 = new FlowLayoutPanel();
        btnEkle = new Button();
        btnResimSec = new Button();
        txtAdSoyad = new TextBox();
        label4 = new Label();
        openFileDialog1 = new OpenFileDialog();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        tabPage2.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Location = new Point(4, 3);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1245, 677);
        tabControl1.TabIndex = 0;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(btnKayitSil);
        tabPage1.Controls.Add(btnGoUpdate);
        tabPage1.Controls.Add(lblAd);
        tabPage1.Controls.Add(label2);
        tabPage1.Controls.Add(flowLayoutPanel1);
        tabPage1.Controls.Add(dataGridView1);
        tabPage1.Controls.Add(textBox1);
        tabPage1.Controls.Add(label1);
        tabPage1.Location = new Point(4, 29);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(1237, 644);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Ara";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // btnKayitSil
        // 
        btnKayitSil.Enabled = false;
        btnKayitSil.Location = new Point(1106, 28);
        btnKayitSil.Name = "btnKayitSil";
        btnKayitSil.Size = new Size(94, 29);
        btnKayitSil.TabIndex = 6;
        btnKayitSil.Tag = "0";
        btnKayitSil.Text = "Sil";
        btnKayitSil.UseVisualStyleBackColor = true;
        btnKayitSil.Click += btnKayitSil_Click;
        // 
        // btnGoUpdate
        // 
        btnGoUpdate.Enabled = false;
        btnGoUpdate.Location = new Point(989, 28);
        btnGoUpdate.Name = "btnGoUpdate";
        btnGoUpdate.Size = new Size(94, 29);
        btnGoUpdate.TabIndex = 0;
        btnGoUpdate.Tag = "0";
        btnGoUpdate.Text = "Güncelle";
        btnGoUpdate.UseVisualStyleBackColor = true;
        btnGoUpdate.Click += btnGoUpdate_Click;
        // 
        // lblAd
        // 
        lblAd.AutoSize = true;
        lblAd.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
        lblAd.Location = new Point(547, 22);
        lblAd.Name = "lblAd";
        lblAd.Size = new Size(70, 35);
        lblAd.TabIndex = 5;
        lblAd.Text = "...........";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(445, 26);
        label2.Name = "label2";
        label2.Size = new Size(75, 20);
        label2.TabIndex = 4;
        label2.Text = "Ad-Soyad";
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Location = new Point(417, 106);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(800, 513);
        flowLayoutPanel1.TabIndex = 3;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, nameColumn });
        dataGridView1.Location = new Point(31, 106);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.RowTemplate.Height = 29;
        dataGridView1.Size = new Size(300, 490);
        dataGridView1.TabIndex = 2;
        dataGridView1.CellClick += dataGridView1_CellClick;
        // 
        // Id
        // 
        Id.HeaderText = "id";
        Id.MinimumWidth = 6;
        Id.Name = "Id";
        Id.ReadOnly = true;
        Id.Width = 125;
        // 
        // nameColumn
        // 
        nameColumn.HeaderText = "Ad-Soyad";
        nameColumn.MinimumWidth = 6;
        nameColumn.Name = "nameColumn";
        nameColumn.ReadOnly = true;
        nameColumn.Width = 125;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(54, 22);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(125, 27);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(16, 25);
        label1.Name = "label1";
        label1.Size = new Size(32, 20);
        label1.TabIndex = 0;
        label1.Text = "Ara";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(btnNoUpdate);
        tabPage2.Controls.Add(txtKulId);
        tabPage2.Controls.Add(flowLayoutPanel2);
        tabPage2.Controls.Add(btnEkle);
        tabPage2.Controls.Add(btnResimSec);
        tabPage2.Controls.Add(txtAdSoyad);
        tabPage2.Controls.Add(label4);
        tabPage2.Location = new Point(4, 29);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1237, 644);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Ekle";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // btnNoUpdate
        // 
        btnNoUpdate.Location = new Point(140, 72);
        btnNoUpdate.Name = "btnNoUpdate";
        btnNoUpdate.Size = new Size(94, 29);
        btnNoUpdate.TabIndex = 6;
        btnNoUpdate.Text = "İptal";
        btnNoUpdate.UseVisualStyleBackColor = true;
        btnNoUpdate.Visible = false;
        btnNoUpdate.Click += btnNoUpdate_Click;
        // 
        // txtKulId
        // 
        txtKulId.Location = new Point(275, 19);
        txtKulId.Name = "txtKulId";
        txtKulId.Size = new Size(52, 27);
        txtKulId.TabIndex = 5;
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.Location = new Point(422, 72);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new Size(761, 540);
        flowLayoutPanel2.TabIndex = 4;
        // 
        // btnEkle
        // 
        btnEkle.Location = new Point(21, 72);
        btnEkle.Name = "btnEkle";
        btnEkle.Size = new Size(94, 29);
        btnEkle.TabIndex = 3;
        btnEkle.Text = "Ekle";
        btnEkle.UseVisualStyleBackColor = true;
        btnEkle.Click += btnEkle_Click;
        // 
        // btnResimSec
        // 
        btnResimSec.Location = new Point(422, 22);
        btnResimSec.Name = "btnResimSec";
        btnResimSec.Size = new Size(94, 29);
        btnResimSec.TabIndex = 2;
        btnResimSec.Text = "Resim Seç";
        btnResimSec.UseVisualStyleBackColor = true;
        btnResimSec.Click += btnResimSec_Click;
        // 
        // txtAdSoyad
        // 
        txtAdSoyad.Location = new Point(102, 23);
        txtAdSoyad.Name = "txtAdSoyad";
        txtAdSoyad.Size = new Size(155, 27);
        txtAdSoyad.TabIndex = 1;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(21, 26);
        label4.Name = "label4";
        label4.Size = new Size(75, 20);
        label4.TabIndex = 0;
        label4.Text = "Ad-Soyad";
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1261, 692);
        Controls.Add(tabControl1);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabPage1;
    private TextBox textBox1;
    private Label label1;
    private TabPage tabPage2;
    private Label lblAd;
    private Label label2;
    private FlowLayoutPanel flowLayoutPanel1;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn Id;
    private DataGridViewButtonColumn nameColumn;
    private Button btnEkle;
    private Button btnResimSec;
    private TextBox txtAdSoyad;
    private Label label4;
    private FlowLayoutPanel flowLayoutPanel2;
    private OpenFileDialog openFileDialog1;
    private Button btnGoUpdate;
    private TextBox txtKulId;
    private Button btnNoUpdate;
    private Button btnKayitSil;
}
