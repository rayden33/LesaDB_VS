using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace LesaDB
{
    class HisobKitob
    {
        private string dbFileName;
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;

        private int soni, narxi, avans,taksi;
        private int[] summa = new int[1000];
        private int[] curId = new int[1000];
        private int[] kun = new int[1000];

        public int dateDifToDay(DateTimePicker startDtp, DateTimePicker endDtp)
        {
            int startDays, endDays, difDays;
            startDays = (365 * (startDtp.Value.Year - 1) + startDtp.Value.DayOfYear);
            endDays = (365 * (endDtp.Value.Year - 1) + endDtp.Value.DayOfYear);
            difDays = endDays - startDays;
            return difDays;
        }

        private void sqlConnect()
        {
            /// Bazaga ulanish qismi
            
            sqlConn = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();

            dbFileName = "lesaDB.db";
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
            }
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

        public void summaHisobKitob()
        {
            sqlConnect();

            sqlCmd.CommandText = "SELECT `id`,`soni`,`narxi`,`sana`,`avans`,`taksi` FROM `clients`;";

            try
            {
                SQLiteDataReader sqldr = sqlCmd.ExecuteReader();
                int i = 0, mx = 0;
                while(sqldr.Read())
                {
                    if (i > mx)
                        mx = i;
                    curId[i] = Convert.ToInt32(sqldr["id"]);
                    avans = Convert.ToInt32(sqldr["avans"]);
                    soni = Convert.ToInt32(sqldr["soni"]);
                    narxi = Convert.ToInt32(sqldr["narxi"]);
                    taksi = Convert.ToInt32(sqldr["taksi"]);
                    ///kuni hisoblash
                    DateTimePicker dtpTemp = new DateTimePicker();
                    DateTimePicker dtpTemp2 = new DateTimePicker();
                    dtpTemp2.Value = DateTime.Now;
                    dtpTemp.Text = sqldr["sana"].ToString();
                    kun[i] = dateDifToDay(dtpTemp, dtpTemp2);
                    //MessageBox.Show(kun.ToString());

                    summa[i] = avans;
                    summa[i] -= soni * narxi * kun[i];
                    summa[i] -= taksi;
                    //MessageBox.Show(summa[i].ToString());
                    i++;
                    
                }
                sqldr.Close();
                //MessageBox.Show(mx.ToString());
                for (i = 0; i <= mx; i++)
                {
                    //MessageBox.Show(summa[i].ToString());
                    sqlCmd.CommandText = "UPDATE `clients` SET " +
                        "`summa`=" + summa[i].ToString() +
                        ", `kun`=" + kun[i].ToString() +
                        " WHERE `id`=" + curId[i].ToString() + ";";
                    sqlCmd.ExecuteNonQuery();
                }
                //sqlConn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(summa.ToString());
        }
        
        public string converterK(string text)
        {
            string temp = "";
            int n = text.Length;
            for (int i = 0; i < n; i++)
            {
                if (text[i] == '\'')
                {
                    temp = temp + "\\`";
                    //n++;
                }
                else
                {
                    if (text[i] == '`')
                    {
                        temp = temp + '\\';
                        //n++;
                    }
                    temp = temp + text[i];
                }
            }
            return temp;
        }

        public string converterDK(string text)
        {
            string temp = "";
            int n = text.Length;
            for (int i = 0; i < n; i++)
            {
                if (text[i] == '\\'&&text[i+1] == '`')
                {
                    continue;
                }
                else
                {
                    temp = temp + text[i];
                }
            }
            return temp;
        }


        /////////////////////////Probelll

        public string converterP(string text)
        {
            string temp = "",tmp1="";
            int n = text.Length, t = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (t%3==0&&t!=0)
                {
                    temp = temp + " ";
                    //n++;
                }
                temp = temp + text[i];
                t++;
            }
            n = temp.Length;
            ////Reverse
            for (int i = n - 1; i >= 0; i--)
            {
                tmp1 = tmp1 + temp[i];
            }
            //MessageBox.Show(tmp1);
            return tmp1;
        }

        public string converterDP(string text)
        {
            string temp = "", tmp1="";
            int n = text.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                if (text[i] == ' ')
                {
                    continue;
                }
                else
                {
                    temp = temp + text[i];
                }
            }
            n = temp.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                tmp1 = tmp1 + temp[i];
            }
            return tmp1;
        }
    }
}
