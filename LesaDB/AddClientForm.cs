using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LesaDB
{
    public partial class AddClientForm : Form
    {
        public String Fish { get; set; }
        public String DogNomer { get; set; }
        public String Sana { get; set; }
        public String Soat { get; set; }
        public String Kun { get; set; }
        public String Oyogi { get; set; }
        public String Krestigi { get; set; }
        public String Taxtasi { get; set; }
        public String Soni { get; set; }
        public String Narxi { get; set; }
        public String Telefon { get; set; }
        public String Xujjat { get; set; }
        public String Avans { get; set; }
        public String Summa { get; set; }
        public String Taksi { get; set; }
        public String Qaytgan { get; set; }
        public String Komm { get; set; }

        private string dbFileName;
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;

        public bool qaytBool = false;

        DateTimePicker dtpTemp = new DateTimePicker();

        HisobKitob hk = new HisobKitob();

        public AddClientForm()
        {
            InitializeComponent();
            dtpTemp.Value = DateTime.Now;
        }

        private void btnSaqlash_Click(object sender, EventArgs e)
        {
            Fish = tbFish.Text;
            DogNomer = tbDogNo.Text;
            Sana = dtpSana.Text;
            Soat = tbSoat.Text;
            Kun = Convert.ToString(hk.dateDifToDay(dtpSana, dtpTemp));
            //MessageBox.Show(hk.dateDifToDay(dtpSana, dtpTemp).ToString());
            Oyogi = tbOyogi.Text;
            Krestigi = tbKrestigi.Text;
            Taxtasi = tbTaxtasi.Text;
            Soni = tbSoni.Text;
            Narxi = tbNarxi.Text;
            Telefon = tbTelefon.Text;
            Xujjat = tbXujjat.Text;
            Avans = tbAvans.Text;
            Taksi = tbTaksi.Text;
            Summa = Convert.ToString(summaHisobKitob());
            //MessageBox.Show(Summa);

            if(checkBox1.Checked)
            {
                qaytBool = true;
                Qaytgan = dtpQaytgan.Text;
            }
            else
            {
                qaytBool = false;
                Qaytgan = "Qaytmagan";
            }

            if (tbFish.TextLength > 0 &&
                tbDogNo.TextLength > 0 &&
                tbSoat.TextLength > 0 &&
                tbOyogi.TextLength > 0 &&
                tbKrestigi.TextLength > 0 &&
                tbTaxtasi.TextLength > 0 &&
                tbSoni.TextLength > 0 &&
                tbNarxi.TextLength > 0 &&
                tbTelefon.TextLength > 0 &&
                tbXujjat.TextLength > 0 &&
                tbAvans.TextLength > 0 &&
                tbTaksi.TextLength > 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Malumotla to`liq kiritilmagan");
            }
        }

        public int summaHisobKitob()
        {
            int summa = 0,narxi,avans,kun,soni;

            soni = Convert.ToInt32(hk.converterDP(Soni));
            avans = Convert.ToInt32(hk.converterDP(Avans));
            narxi = Convert.ToInt32(hk.converterDP(Narxi));
            kun = Convert.ToInt32(Kun);
            summa = avans;
            summa -= narxi * kun * soni;
            //MessageBox.Show(summa.ToString() + " " + narxi.ToString() + " " + kun.ToString() + " " + soni.ToString());

            return summa;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                dtpQaytgan.Enabled = true;
            else
                dtpQaytgan.Enabled = false;
        }

        public void syncData()
        {
            tbFish.Text = Fish;
            tbDogNo.Text = DogNomer;
            dtpSana.Text = Sana;
            tbSoat.Text = Soat;
            tbOyogi.Text = Oyogi;
            tbKrestigi.Text = Krestigi;
            tbTaxtasi.Text = Taxtasi;
            tbSoni.Text = Soni;
            tbNarxi.Text = Narxi;
            tbTelefon.Text = Telefon;
            tbXujjat.Text = Xujjat;
            tbAvans.Text = Avans;
            tbTaksi.Text = Taksi;
            if (Qaytgan == "Qaytmagan")
                qaytBool = false;
            else
                qaytBool = true;
            //MessageBox.Show(Qaytgan);
            if(qaytBool)
            {
                checkBox1.Checked = true;
                dtpQaytgan.Text = Qaytgan;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void btnChiqish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpSana_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dtpSana.Value.DayOfYear.ToString());
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            sqlConn = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();

            dbFileName = "lesaDB.db";

            sqlConnect();
        }

        private void sqlConnect()
        {
            /// Bazaga ulanish qismi
            try
            {
                sqlConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;

                //MessageBox.Show("Xush kelibsiz");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
