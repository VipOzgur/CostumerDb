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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        panel3 = new Panel();
        panel4 = new Panel();
        label2 = new Label();
        btnKayitSil = new Button();
        btnGoUpdate = new Button();
        lblAd = new Label();
        flowLayoutPanel1 = new FlowLayoutPanel();
        panel1 = new Panel();
        panel7 = new Panel();
        panel5 = new Panel();
        textBox1 = new TextBox();
        panel2 = new Panel();
        dataGridView1 = new DataGridView();
        nameColumn = new DataGridViewTextBoxColumn();
        uploadDate = new DataGridViewTextBoxColumn();
        Id = new DataGridViewTextBoxColumn();
        tabPage2 = new TabPage();
        btnOpenCamera = new Button();
        panel6 = new Panel();
        flowLayoutPanel2 = new FlowLayoutPanel();
        btnNoUpdate = new Button();
        txtKulId = new TextBox();
        btnEkle = new Button();
        btnResimSec = new Button();
        txtAdSoyad = new TextBox();
        label4 = new Label();
        openFileDialog1 = new OpenFileDialog();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        panel3.SuspendLayout();
        panel4.SuspendLayout();
        panel1.SuspendLayout();
        panel5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        tabPage2.SuspendLayout();
        panel6.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        resources.ApplyResources(tabControl1, "tabControl1");
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Multiline = true;
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        // 
        // tabPage1
        // 
        resources.ApplyResources(tabPage1, "tabPage1");
        tabPage1.Controls.Add(panel3);
        tabPage1.Controls.Add(panel1);
        tabPage1.Name = "tabPage1";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // panel3
        // 
        resources.ApplyResources(panel3, "panel3");
        panel3.Controls.Add(panel4);
        panel3.Controls.Add(flowLayoutPanel1);
        panel3.Name = "panel3";
        // 
        // panel4
        // 
        resources.ApplyResources(panel4, "panel4");
        panel4.BackColor = Color.WhiteSmoke;
        panel4.Controls.Add(label2);
        panel4.Controls.Add(btnKayitSil);
        panel4.Controls.Add(btnGoUpdate);
        panel4.Controls.Add(lblAd);
        panel4.Name = "panel4";
        // 
        // label2
        // 
        resources.ApplyResources(label2, "label2");
        label2.Name = "label2";
        // 
        // btnKayitSil
        // 
        resources.ApplyResources(btnKayitSil, "btnKayitSil");
        btnKayitSil.Name = "btnKayitSil";
        btnKayitSil.Tag = "0";
        btnKayitSil.UseVisualStyleBackColor = true;
        btnKayitSil.Click += btnKayitSil_Click;
        // 
        // btnGoUpdate
        // 
        resources.ApplyResources(btnGoUpdate, "btnGoUpdate");
        btnGoUpdate.Name = "btnGoUpdate";
        btnGoUpdate.Tag = "0";
        btnGoUpdate.UseVisualStyleBackColor = true;
        btnGoUpdate.Click += btnGoUpdate_Click;
        // 
        // lblAd
        // 
        resources.ApplyResources(lblAd, "lblAd");
        lblAd.Name = "lblAd";
        // 
        // flowLayoutPanel1
        // 
        resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
        flowLayoutPanel1.BackColor = Color.Transparent;
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        // 
        // panel1
        // 
        resources.ApplyResources(panel1, "panel1");
        panel1.Controls.Add(panel7);
        panel1.Controls.Add(panel5);
        panel1.Controls.Add(panel2);
        panel1.Controls.Add(dataGridView1);
        panel1.Name = "panel1";
        // 
        // panel7
        // 
        resources.ApplyResources(panel7, "panel7");
        panel7.Name = "panel7";
        // 
        // panel5
        // 
        resources.ApplyResources(panel5, "panel5");
        panel5.Controls.Add(textBox1);
        panel5.Name = "panel5";
        // 
        // textBox1
        // 
        resources.ApplyResources(textBox1, "textBox1");
        textBox1.BackColor = SystemColors.ControlLight;
        textBox1.Name = "textBox1";
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // panel2
        // 
        resources.ApplyResources(panel2, "panel2");
        panel2.BackColor = Color.WhiteSmoke;
        panel2.Name = "panel2";
        // 
        // dataGridView1
        // 
        resources.ApplyResources(dataGridView1, "dataGridView1");
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.BackgroundColor = Color.WhiteSmoke;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameColumn, uploadDate, Id });
        dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        dataGridView1.GridColor = Color.DarkGray;
        dataGridView1.MultiSelect = false;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        dataGridView1.RowTemplate.Height = 29;
        dataGridView1.ShowCellToolTips = false;
        dataGridView1.ShowEditingIcon = false;
        dataGridView1.CellClick += dataGridView1_CellClick;
        // 
        // nameColumn
        // 
        nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        nameColumn.FillWeight = 108.6631F;
        resources.ApplyResources(nameColumn, "nameColumn");
        nameColumn.Name = "nameColumn";
        nameColumn.ReadOnly = true;
        nameColumn.Resizable = DataGridViewTriState.True;
        nameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // uploadDate
        // 
        uploadDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        resources.ApplyResources(uploadDate, "uploadDate");
        uploadDate.Name = "uploadDate";
        uploadDate.ReadOnly = true;
        // 
        // Id
        // 
        Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        Id.FillWeight = 51.3369F;
        resources.ApplyResources(Id, "Id");
        Id.Name = "Id";
        Id.ReadOnly = true;
        Id.Resizable = DataGridViewTriState.False;
        // 
        // tabPage2
        // 
        resources.ApplyResources(tabPage2, "tabPage2");
        tabPage2.BackColor = Color.WhiteSmoke;
        tabPage2.Controls.Add(btnOpenCamera);
        tabPage2.Controls.Add(panel6);
        tabPage2.Controls.Add(btnNoUpdate);
        tabPage2.Controls.Add(txtKulId);
        tabPage2.Controls.Add(btnEkle);
        tabPage2.Controls.Add(btnResimSec);
        tabPage2.Controls.Add(txtAdSoyad);
        tabPage2.Controls.Add(label4);
        tabPage2.Name = "tabPage2";
        // 
        // btnOpenCamera
        // 
        resources.ApplyResources(btnOpenCamera, "btnOpenCamera");
        btnOpenCamera.Name = "btnOpenCamera";
        btnOpenCamera.UseVisualStyleBackColor = true;
        btnOpenCamera.Click += btnOpenCamera_Click;
        // 
        // panel6
        // 
        resources.ApplyResources(panel6, "panel6");
        panel6.Controls.Add(flowLayoutPanel2);
        panel6.Name = "panel6";
        // 
        // flowLayoutPanel2
        // 
        resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
        flowLayoutPanel2.BackColor = Color.Transparent;
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        // 
        // btnNoUpdate
        // 
        resources.ApplyResources(btnNoUpdate, "btnNoUpdate");
        btnNoUpdate.Name = "btnNoUpdate";
        btnNoUpdate.UseVisualStyleBackColor = true;
        btnNoUpdate.Click += btnNoUpdate_Click;
        // 
        // txtKulId
        // 
        resources.ApplyResources(txtKulId, "txtKulId");
        txtKulId.Name = "txtKulId";
        // 
        // btnEkle
        // 
        resources.ApplyResources(btnEkle, "btnEkle");
        btnEkle.Name = "btnEkle";
        btnEkle.UseVisualStyleBackColor = true;
        btnEkle.Click += btnEkle_Click;
        // 
        // btnResimSec
        // 
        resources.ApplyResources(btnResimSec, "btnResimSec");
        btnResimSec.Name = "btnResimSec";
        btnResimSec.UseVisualStyleBackColor = true;
        btnResimSec.Click += btnResimSec_Click;
        // 
        // txtAdSoyad
        // 
        resources.ApplyResources(txtAdSoyad, "txtAdSoyad");
        txtAdSoyad.Name = "txtAdSoyad";
        // 
        // label4
        // 
        resources.ApplyResources(label4, "label4");
        label4.Name = "label4";
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        resources.ApplyResources(openFileDialog1, "openFileDialog1");
        // 
        // Form1
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tabControl1);
        Name = "Form1";
        WindowState = FormWindowState.Maximized;
        Load += Form1_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        panel3.ResumeLayout(false);
        panel4.ResumeLayout(false);
        panel4.PerformLayout();
        panel1.ResumeLayout(false);
        panel5.ResumeLayout(false);
        panel5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        panel6.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabPage1;
    private TextBox textBox1;
    private TabPage tabPage2;
    private Label lblAd;
    private FlowLayoutPanel flowLayoutPanel1;
    private DataGridView dataGridView1;
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
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Panel panel4;
    private Panel panel5;
    private Panel panel6;
    private Panel panel7;
    private Label label2;
    private DataGridViewTextBoxColumn nameColumn;
    private DataGridViewTextBoxColumn uploadDate;
    private DataGridViewTextBoxColumn Id;
    private Button btnOpenCamera;
}
