namespace LesaDB
{
    partial class Trash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmFish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmShartnoma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmSana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmSoat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmKun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmOyogi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmKrestigi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTaxtasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmSoni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmNarxi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmHujjat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAvans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmSumma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmQaytgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmKomm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 48);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 276);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(809, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Chiqish";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmId,
            this.cmFish,
            this.cmShartnoma,
            this.cmSana,
            this.cmSoat,
            this.cmKun,
            this.cmOyogi,
            this.cmKrestigi,
            this.cmTaxtasi,
            this.cmSoni,
            this.cmNarxi,
            this.cmTelefon,
            this.cmHujjat,
            this.cmAvans,
            this.cmSumma,
            this.cmTaksi,
            this.cmQaytgan,
            this.cmKomm});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(884, 276);
            this.dataGridView1.TabIndex = 1;
            // 
            // cmId
            // 
            this.cmId.HeaderText = "ID";
            this.cmId.Name = "cmId";
            this.cmId.ReadOnly = true;
            this.cmId.Visible = false;
            this.cmId.Width = 41;
            // 
            // cmFish
            // 
            this.cmFish.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmFish.HeaderText = "F.I.SH.";
            this.cmFish.Name = "cmFish";
            this.cmFish.ReadOnly = true;
            this.cmFish.Width = 63;
            // 
            // cmShartnoma
            // 
            this.cmShartnoma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmShartnoma.HeaderText = "SHARTNOMA";
            this.cmShartnoma.Name = "cmShartnoma";
            this.cmShartnoma.ReadOnly = true;
            this.cmShartnoma.Width = 99;
            // 
            // cmSana
            // 
            this.cmSana.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmSana.HeaderText = "SANA";
            this.cmSana.Name = "cmSana";
            this.cmSana.ReadOnly = true;
            this.cmSana.Width = 59;
            // 
            // cmSoat
            // 
            this.cmSoat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmSoat.HeaderText = "SOAT";
            this.cmSoat.Name = "cmSoat";
            this.cmSoat.ReadOnly = true;
            this.cmSoat.Width = 59;
            // 
            // cmKun
            // 
            this.cmKun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmKun.HeaderText = "KUN";
            this.cmKun.Name = "cmKun";
            this.cmKun.ReadOnly = true;
            this.cmKun.Width = 53;
            // 
            // cmOyogi
            // 
            this.cmOyogi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmOyogi.HeaderText = "OYOG\'I";
            this.cmOyogi.Name = "cmOyogi";
            this.cmOyogi.ReadOnly = true;
            this.cmOyogi.Width = 66;
            // 
            // cmKrestigi
            // 
            this.cmKrestigi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmKrestigi.HeaderText = "KRESTIGI";
            this.cmKrestigi.Name = "cmKrestigi";
            this.cmKrestigi.ReadOnly = true;
            this.cmKrestigi.Width = 80;
            // 
            // cmTaxtasi
            // 
            this.cmTaxtasi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmTaxtasi.HeaderText = "TAXTASI";
            this.cmTaxtasi.Name = "cmTaxtasi";
            this.cmTaxtasi.ReadOnly = true;
            this.cmTaxtasi.Width = 75;
            // 
            // cmSoni
            // 
            this.cmSoni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmSoni.HeaderText = "SONI";
            this.cmSoni.Name = "cmSoni";
            this.cmSoni.ReadOnly = true;
            this.cmSoni.Width = 56;
            // 
            // cmNarxi
            // 
            this.cmNarxi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmNarxi.HeaderText = "NARXI";
            this.cmNarxi.Name = "cmNarxi";
            this.cmNarxi.ReadOnly = true;
            this.cmNarxi.Width = 63;
            // 
            // cmTelefon
            // 
            this.cmTelefon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmTelefon.HeaderText = "TELEFON";
            this.cmTelefon.Name = "cmTelefon";
            this.cmTelefon.ReadOnly = true;
            this.cmTelefon.Width = 79;
            // 
            // cmHujjat
            // 
            this.cmHujjat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmHujjat.HeaderText = "HUJJAT";
            this.cmHujjat.Name = "cmHujjat";
            this.cmHujjat.ReadOnly = true;
            this.cmHujjat.Width = 70;
            // 
            // cmAvans
            // 
            this.cmAvans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmAvans.HeaderText = "AVANS";
            this.cmAvans.Name = "cmAvans";
            this.cmAvans.ReadOnly = true;
            this.cmAvans.Width = 66;
            // 
            // cmSumma
            // 
            this.cmSumma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmSumma.HeaderText = "SUMMA";
            this.cmSumma.Name = "cmSumma";
            this.cmSumma.ReadOnly = true;
            this.cmSumma.Width = 70;
            // 
            // cmTaksi
            // 
            this.cmTaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmTaksi.HeaderText = "TAKSI";
            this.cmTaksi.Name = "cmTaksi";
            this.cmTaksi.ReadOnly = true;
            this.cmTaksi.Width = 61;
            // 
            // cmQaytgan
            // 
            this.cmQaytgan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmQaytgan.HeaderText = "QAYTGAN SANA";
            this.cmQaytgan.Name = "cmQaytgan";
            this.cmQaytgan.ReadOnly = true;
            this.cmQaytgan.Width = 104;
            // 
            // cmKomm
            // 
            this.cmKomm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmKomm.HeaderText = "KOMMENT";
            this.cmKomm.Name = "cmKomm";
            this.cmKomm.ReadOnly = true;
            // 
            // Trash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 324);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Trash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trash";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Trash_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmFish;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmShartnoma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmSana;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmSoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmKun;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmOyogi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmKrestigi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmTaxtasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmSoni;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmNarxi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmHujjat;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmAvans;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmSumma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmTaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmQaytgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmKomm;
    }
}