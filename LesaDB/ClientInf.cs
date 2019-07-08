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
    public partial class ClientInf : Form
    {
        private string dbFileName;
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;
        public String clientId { get; set; }
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

        HisobKitob hk = new HisobKitob();

        public ClientInf()
        {
            InitializeComponent();

            this.Size = new Size((Screen.PrimaryScreen.WorkingArea.Width * 80)/100, (Screen.PrimaryScreen.WorkingArea.Height * 80)/100);
        }

        

        private void allRead()
        {
            DataTable dt = new DataTable();
            string sqlQuery;

            try
            {
                sqlQuery = "SELECT * FROM clients WHERE `id`=" + clientId + ";";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConn);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i].ItemArray);
                    }
                    lbFish.Text = hk.converterDK(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    lbDogNomer.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    tbKom.Text = hk.converterDK(dataGridView1.CurrentRow.Cells[17].Value.ToString());
                    //MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                }
                else
                {
                    //MessageBox.Show("Bazada malumotlar mavjudmas");
                    //MessageBox.Show("Hello");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                /// 1 11 12
                //string tmp1 = 
                //MessageBox.Show(dataGridView1.Rows[i].Cells[1].Value.ToString());

                dataGridView1.Rows[i].Cells[10].Value = hk.converterP(dataGridView1.Rows[i].Cells[10].Value.ToString());
                dataGridView1.Rows[i].Cells[13].Value = hk.converterP(dataGridView1.Rows[i].Cells[13].Value.ToString());
                dataGridView1.Rows[i].Cells[14].Value = hk.converterP(dataGridView1.Rows[i].Cells[14].Value.ToString());
                dataGridView1.Rows[i].Cells[15].Value = hk.converterP(dataGridView1.Rows[i].Cells[15].Value.ToString());
            }
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

        private void komWrite()
        {
            try
            {
                string textcha = tbKom.Text.ToString();
                textcha = hk.converterK(textcha);
                sqlCmd.CommandText = "UPDATE `clients` SET " +
                    "`komment`='" + textcha +
                    "' WHERE `id`=" + clientId + ";";
                //MessageBox.Show(sqlCmd.CommandText.ToString());
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClientInf_Load(object sender, EventArgs e)
        {
            sqlConn = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();

            dbFileName = "lesaDB.db";

            sqlConnect();
            allRead();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            komWrite();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
