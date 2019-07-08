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
    public partial class Trash : Form
    {
        private string dbFileName;
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;
        public Trash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Trash_Load(object sender, EventArgs e)
        {
            sqlConn = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();

            dbFileName = "lesaDB.db";

            sqlConnect();
            readAll();
        }

        private void readAll()
        {
            DataTable dt = new DataTable();
            string sqlQuery;

            try
            {
                sqlQuery = "SELECT * FROM trash";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConn);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i].ItemArray);
                        //MessageBox.Show(dataGridView1.CurrentRow.Cells[14].Value.ToString());
                    }

                    //dbgrvNull = false;
                    //btnChange.Enabled = true;
                    //btnDel.Enabled = true;
                    //btnInfo.Enabled = true;
                }
                else
                {
                    //MessageBox.Show("Bazada malumotlar mavjudmas");
                    //dbgrvNull = true;
                    //btnChange.Enabled = false;
                    //btnDel.Enabled = false;
                    //btnInfo.Enabled = false;
                    dataGridView1.Rows.Clear();
                    //MessageBox.Show("Hello");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
