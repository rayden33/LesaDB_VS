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
using System.IO;

namespace LesaDB
{
    public partial class Settings : Form
    {
        SQLiteConnection sqlConn;
        SQLiteCommand sqlCmd;
        private string dbFileName = "lesaDB.db";

        int umumiy = 0, arenda = 0, ostatok = 0;

        chPass cp = new chPass();
        VerificationForm vf = new VerificationForm();
        private string loginFilePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "\\pwdData.raydb";
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            sqlConn = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();

            lesalarSync();
        }

        private void btnChanPass_Click(object sender, EventArgs e)
        {
            PassSet ps = new PassSet();
            ps.ShowDialog();
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

        private void lesalarSync()
        {
            sqlConnect();

            try
            {
                sqlCmd.CommandText = "SELECT * FROM `sklad`";
                SQLiteDataReader sqlr = sqlCmd.ExecuteReader();
                while(sqlr.Read())
                {
                    umumiy = Convert.ToInt32(sqlr["umumiy"]);
                    ostatok = Convert.ToInt32(sqlr["ostatok"]);
                    arenda = Convert.ToInt32(sqlr["arenda"]);
                }
                //MessageBox.Show(umumiy.ToString());
                tbSkLesa.Text = umumiy.ToString();
                sqlr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lesalarSave()
        {
            sqlConnect();

            umumiy = Convert.ToInt32(tbSkLesa.Text);
            ostatok = umumiy - arenda;

            try
            {
                sqlCmd.CommandText = "UPDATE `sklad` SET " +
                    "`umumiy`=" + umumiy + 
                    ",`arenda`=" + arenda +
                    ",`ostatok`="+ ostatok + ";";
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Saqlandi");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lesalarSave();
            this.Close();
        }

        
    }
}
