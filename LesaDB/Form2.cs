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
    public partial class Form2 : Form
    {
        private string dbFileName;
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;
        private bool sqlNull = false;
        private bool dbgrvNull = false;
        private string searchName = "";
        private string qushimchaShart = "";

        VerificationForm vf = new VerificationForm();
        HisobKitob hk = new HisobKitob();
        public Form2()
        {
            InitializeComponent();


            this.Size = new Size((Screen.PrimaryScreen.WorkingArea.Width * 80) / 100, (Screen.PrimaryScreen.WorkingArea.Height * 80) / 100);
            dataGridView1.Size = new Size((this.Size.Width * 85) / 100, (this.Size.Height * 75) / 100);
            Point ptExit = new Point(this.Size.Width - 36,0);
            Point ptSet = new Point(10, 10);
            Point ptAdd  = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y);
            Point ptDel = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 80);
            Point ptInfo = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 160);
            Point ptTrash = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + dataGridView1.Size.Height - 65);
            Point ptChan = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 240);
            Point ptQarz = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 305);
            Point ptSklad = new Point((this.Width * 20) / 100, 20);
            Point ptArenda = new Point((this.Width * 40) / 100, 20);
            Point ptSearch = new Point((this.Width * 87) / 100, 20);
            Point ptStSklad = new Point((this.Width * 20) / 100, 40);
            Point ptStArenda = new Point((this.Width * 40) / 100, 40);
            Point ptTbSearch = new Point((this.Width * 87) / 100, 45);
            btnExit.Location = ptExit;
            btnSoz.Location = ptSet;
            btnChange.Location = ptChan;
            btnQarz.Location = ptQarz;
            btnDel.Location = ptDel;
            btnInfo.Location = ptInfo;
            btnTrash.Location = ptTrash;
            btnAddClient.Location = ptAdd;
            lbSklad.Location = ptSklad;
            lbSkStatus.Location = ptStSklad;
            lbArenda.Location = ptArenda;
            lbArStatus.Location = ptStArenda;
            tbSearch.Location = ptTbSearch;
            lbSearch.Location = ptSearch;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlConn = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();

            dbFileName = "lesaDB.db";

            sqlConnect();

        }

        private void sqlConnect()
        {
            /// Bazaga ulanish qismi
            /// Agar baza mavjud bo`lmasa u bazani yaratadi
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
                sqlNull = true;
            }
            try
            {
                sqlConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;
                /// Baza bush bulgan bulsa client jadvalini yaratadi;
                if (sqlNull)
                {
                    sqlCmd.CommandText = "CREATE TABLE `clients` (" +
                        "`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "`fish`	TEXT NOT NULL," +
                        "`shartnoma` TEXT NOT NULL," +
                        "`sana`	TEXT NOT NULL," +
                        "`soat`	TEXT NOT NULL," +
                        "`kun`	INTEGER NOT NULL," +
                        "`oyogi`	INTEGER NOT NULL," +
                        "`krestigi`	INTEGER NOT NULL," +
                        "`taxtasi`	INTEGER NOT NULL," +
                        "`soni`	INTEGER NOT NULL," +
                        "`narxi`	REAL NOT NULL," +
                        "`telefon`	TEXT NOT NULL," +
                        "`xujjat`	TEXT NOT NULL," +
                        "`taksi`	REAL NOT NULL," +
                        "`avans`	REAL NOT NULL," +
                        "`summa`	REAL NOT NULL," +
                        "`qaytgan sanasi`	TEXT NOT NULL," +
                        "`komment` TEXT NOT NULL); ";
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.CommandText = "CREATE TABLE `sklad` (" +
                        "`ostatok`	INTEGER NOT NULL," +
                        "`arenda`	INTEGER NOT NULL," +
                        "`umumiy`	INTEGER NOT NULL," +
                        "`parol`	TEXT NOT NULL); ";
                    sqlCmd.ExecuteNonQuery();
                    sqlNull = false;

                    sqlCmd.CommandText = "INSERT INTO `sklad`(" +
                        "`ostatok`," +
                        "`arenda`," +
                        "`umumiy`," +
                        "`parol`) " +
                        "VALUES (0,0,0,'Rognar');";

                    sqlCmd.ExecuteNonQuery();

                    //////Korzinka

                    sqlCmd.CommandText = "CREATE TABLE `trash` (" +
                        "`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "`fish`	TEXT NOT NULL," +
                        "`shartnoma` TEXT NOT NULL," +
                        "`sana`	TEXT NOT NULL," +
                        "`soat`	TEXT NOT NULL," +
                        "`kun`	INTEGER NOT NULL," +
                        "`oyogi`	INTEGER NOT NULL," +
                        "`krestigi`	INTEGER NOT NULL," +
                        "`taxtasi`	INTEGER NOT NULL," +
                        "`soni`	INTEGER NOT NULL," +
                        "`narxi`	REAL NOT NULL," +
                        "`telefon`	TEXT NOT NULL," +
                        "`xujjat`	TEXT NOT NULL," +
                        "`taksi`	REAL NOT NULL," +
                        "`avans`	REAL NOT NULL," +
                        "`summa`	REAL NOT NULL," +
                        "`qaytgan sanasi`	TEXT NOT NULL," +
                        "`komment` TEXT NOT NULL); ";
                    sqlCmd.ExecuteNonQuery();
                    //MessageBox.Show(sqlCmd.CommandText.ToString());

                }

                //MessageBox.Show("Xush kelibsiz");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readAll()
        {
            hk.summaHisobKitob();

            int arendaVar = 0,ostatokVar = 0, umumiyVar = 0;

            sqlCmd.CommandText = "SELECT * FROM `sklad`;";
            SQLiteDataReader sqldr = sqlCmd.ExecuteReader();
            sqldr.Read();
            ostatokVar = Convert.ToInt32(sqldr["ostatok"]);
            arendaVar = Convert.ToInt32(sqldr["arenda"]);
            umumiyVar = Convert.ToInt32(sqldr["umumiy"]);
            sqldr.Close();

            ostatokVar = umumiyVar - arendaVar;
            sqlCmd.CommandText = "UPDATE `sklad` SET " +
                "`arenda`=" + arendaVar.ToString() +
                ",`ostatok`=" + ostatokVar.ToString() + ";";
            sqlCmd.ExecuteNonQuery();

            ///sklad va arendani labelni yozish
            sqlCmd.CommandText = "SELECT * FROM `sklad`;";
            sqldr = sqlCmd.ExecuteReader();
            sqldr.Read();
            lbSkStatus.Text = sqldr["ostatok"].ToString();
            lbArStatus.Text = sqldr["arenda"].ToString();
            sqldr.Close();




            DataTable dt = new DataTable();
            string sqlQuery;

            try
            {
                if(searchName=="")
                {
                    sqlQuery = "SELECT * FROM clients" + qushimchaShart;
                }
                else
                {
                    sqlQuery = "SELECT * FROM clients WHERE fish LIKE '%" + searchName + "%'";
                }
                
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery,sqlConn);
                adapter.Fill(dt);

                if(dt.Rows.Count>0)
                {
                    dataGridView1.Rows.Clear();

                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i].ItemArray);
                        //MessageBox.Show(dataGridView1.CurrentRow.Cells[14].Value.ToString());
                    }

                    dbgrvNull = false;
                    btnChange.Enabled = true;
                    btnDel.Enabled = true;
                    btnInfo.Enabled = true;
                }
                else
                {
                    //MessageBox.Show("Bazada malumotlar mavjudmas");
                    dbgrvNull = true;
                    btnChange.Enabled = false;
                    btnDel.Enabled = false;
                    btnInfo.Enabled = false;
                    dataGridView1.Rows.Clear();
                    //MessageBox.Show("Hello");
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                /// 1 11 12
                //string tmp1 = 
                //MessageBox.Show(dataGridView1.Rows[i].Cells[1].Value.ToString());
                dataGridView1.Rows[i].Cells[1].Value = hk.converterDK(dataGridView1.Rows[i].Cells[1].Value.ToString());
                dataGridView1.Rows[i].Cells[11].Value = hk.converterDK(dataGridView1.Rows[i].Cells[11].Value.ToString());
                dataGridView1.Rows[i].Cells[12].Value = hk.converterDK(dataGridView1.Rows[i].Cells[12].Value.ToString());
                dataGridView1.Rows[i].Cells[17].Value = hk.converterDK(dataGridView1.Rows[i].Cells[17].Value.ToString());

                dataGridView1.Rows[i].Cells[10].Value = hk.converterP(dataGridView1.Rows[i].Cells[10].Value.ToString());
                dataGridView1.Rows[i].Cells[13].Value = hk.converterP(dataGridView1.Rows[i].Cells[13].Value.ToString());
                dataGridView1.Rows[i].Cells[14].Value = hk.converterP(dataGridView1.Rows[i].Cells[14].Value.ToString());
                dataGridView1.Rows[i].Cells[15].Value = hk.converterP(dataGridView1.Rows[i].Cells[15].Value.ToString());

                ////Qizil qarzdorlik belgisi

                if(dataGridView1.Rows[i].Cells[15].Value.ToString()[0] == '-')
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            ////////////////////////////////////////////Nomerlanish
            for(int i=0;i<dataGridView1.RowCount - 1;i++)
            {
                dataGridView1.Rows[i].Cells[18].Value = (i+1).ToString();
                dataGridView1.Rows[i].Cells[19].Value = dataGridView1.Rows[i].Cells[1].Value;
                dataGridView1.Rows[i].Cells[20].Value = dataGridView1.Rows[i].Cells[2].Value;
                dataGridView1.Rows[i].Cells[21].Value = dataGridView1.Rows[i].Cells[3].Value;
                dataGridView1.Rows[i].Cells[22].Value = dataGridView1.Rows[i].Cells[4].Value;
                dataGridView1.Rows[i].Cells[23].Value = dataGridView1.Rows[i].Cells[5].Value;
                dataGridView1.Rows[i].Cells[24].Value = dataGridView1.Rows[i].Cells[6].Value;
                dataGridView1.Rows[i].Cells[25].Value = dataGridView1.Rows[i].Cells[7].Value;
                dataGridView1.Rows[i].Cells[26].Value = dataGridView1.Rows[i].Cells[8].Value;
                dataGridView1.Rows[i].Cells[27].Value = dataGridView1.Rows[i].Cells[9].Value;
                dataGridView1.Rows[i].Cells[28].Value = dataGridView1.Rows[i].Cells[10].Value;
                dataGridView1.Rows[i].Cells[29].Value = dataGridView1.Rows[i].Cells[11].Value;
                dataGridView1.Rows[i].Cells[30].Value = dataGridView1.Rows[i].Cells[12].Value;
                dataGridView1.Rows[i].Cells[31].Value = dataGridView1.Rows[i].Cells[13].Value;
                dataGridView1.Rows[i].Cells[32].Value = dataGridView1.Rows[i].Cells[14].Value;
                dataGridView1.Rows[i].Cells[33].Value = dataGridView1.Rows[i].Cells[15].Value;
                dataGridView1.Rows[i].Cells[34].Value = dataGridView1.Rows[i].Cells[16].Value;
                dataGridView1.Rows[i].Cells[35].Value = dataGridView1.Rows[i].Cells[17].Value;
            }
            qushimchaShart = "";

        }

        private void addClient()
        {
            AddClientForm addCl = new AddClientForm();
            if(addCl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    addCl.Fish = hk.converterK(addCl.Fish);
                    addCl.Xujjat = hk.converterK(addCl.Xujjat);
                    addCl.Telefon = hk.converterK(addCl.Telefon);
                    addCl.Narxi = hk.converterDP(addCl.Narxi);
                    addCl.Summa = hk.converterDP(addCl.Summa);
                    addCl.Avans = hk.converterDP(addCl.Avans);
                    addCl.Taksi = hk.converterDP(addCl.Taksi);
                    //MessageBox.Show(addCl.Fish);
                    sqlCmd.CommandText = "INSERT INTO `clients`(" +
                        "`fish`," +
                        "`shartnoma`," +
                        "`sana`," +
                        "`soat`," +
                        "`kun`," +
                        "`oyogi`," +
                        "`krestigi`," +
                        "`taxtasi`," +
                        "`soni`," +
                        "`narxi`," +
                        "`telefon`," +
                        "`xujjat`," +
                        "`avans`," +
                        "`summa`," +
                        "`taksi`," +
                        "`qaytgan sanasi`," +
                        "`komment`) " +
                        "VALUES ('" + addCl.Fish +
                        "','" + addCl.DogNomer +
                        "','" + addCl.Sana +
                        "','" + addCl.Soat +
                        "'," + addCl.Kun +
                        "," + addCl.Oyogi +
                        "," + addCl.Krestigi +
                        "," + addCl.Taxtasi +
                        "," + addCl.Soni +
                        ",'" + addCl.Narxi +
                        "','" + addCl.Telefon +
                        "','" + addCl.Xujjat +
                        "','" + addCl.Avans +
                        "'," + addCl.Summa +
                        ",'" + addCl.Taksi +
                        "','" + addCl.Qaytgan +
                        "','" +
                        "');";
                    //MessageBox.Show(sqlCmd.CommandText.ToString());
                    //MessageBox.Show(hk.converterK(addCl.Fish));
                    sqlCmd.ExecuteNonQuery();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                int arendaVar = 0;
                sqlCmd.CommandText = "SELECT * FROM `clients`;";
                SQLiteDataReader sqldr = sqlCmd.ExecuteReader();
                while (sqldr.Read())
                {
                    arendaVar += Convert.ToInt32(sqldr["soni"]);
                }
                sqldr.Close();
                //MessageBox.Show(arendaVar.ToString());

                sqlCmd.CommandText = "UPDATE `sklad` SET " +
                    "`arenda`=" + arendaVar.ToString() +
                    ";";
                sqlCmd.ExecuteNonQuery();
            }
            readAll();
        }

        private void changeClient()
        {
            AddClientForm addCl = new AddClientForm();
            string curId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            addCl.Fish = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            addCl.DogNomer = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            addCl.Sana = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            addCl.Soat = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            addCl.Kun = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            addCl.Oyogi = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            addCl.Krestigi = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            addCl.Taxtasi = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            addCl.Soni = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            addCl.Narxi = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            addCl.Telefon = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            addCl.Xujjat = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            addCl.Taksi = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            addCl.Avans = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            addCl.Summa = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            addCl.Qaytgan = dataGridView1.CurrentRow.Cells[16].Value.ToString();

            //addCl.Komm = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            addCl.syncData();
            
            ///if (vf.ShowDialog() == DialogResult.OK)
            ///{
                if (addCl.ShowDialog() == DialogResult.OK)
                {
                    addCl.Fish = hk.converterK(addCl.Fish);
                    addCl.Xujjat = hk.converterK(addCl.Xujjat);
                    addCl.Telefon = hk.converterK(addCl.Telefon);
                    addCl.Narxi = hk.converterDP(addCl.Narxi);
                    addCl.Summa = hk.converterDP(addCl.Summa);
                    addCl.Avans = hk.converterDP(addCl.Avans);
                    addCl.Taksi = hk.converterDP(addCl.Taksi);
                    try
                    {
                        sqlCmd.CommandText = "UPDATE `clients` SET " +
                            "`id`=" + curId +
                            ",`fish`='" + addCl.Fish + "'" +
                            ",`shartnoma`='" + addCl.DogNomer + "'" +
                            ",`sana`='" + addCl.Sana + "'" +
                            ",`soat`='" + addCl.Soat + "'" +
                            ",`kun`=" + addCl.Kun +
                            ",`oyogi`=" + addCl.Oyogi +
                            ",`krestigi`=" + addCl.Krestigi +
                            ",`taxtasi`=" + addCl.Taxtasi +
                            ",`soni`=" + addCl.Soni +
                            ",`narxi`=" + addCl.Narxi +
                            ",`telefon`='" + addCl.Telefon + "'" +
                            ",`xujjat`='" + addCl.Xujjat + "'" +
                            ",`avans`=" + addCl.Avans +
                            ",`summa`=" + addCl.Summa +
                            ",`taksi`=" + addCl.Taksi +
                            ",`qaytgan sanasi`='" + addCl.Qaytgan + "'" +
                            " WHERE `id`=" + curId + ";";
                        //MessageBox.Show(sqlCmd.CommandText.ToString());
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ma`lumotlarni kiritishda xatolik bo`lgan");
                    }

                    int arendaVar = 0;
                    sqlCmd.CommandText = "SELECT * FROM `clients`;";
                    SQLiteDataReader sqldr = sqlCmd.ExecuteReader();
                    while (sqldr.Read())
                    {
                        arendaVar += Convert.ToInt32(sqldr["soni"]);
                    }
                    sqldr.Close();
                    //MessageBox.Show(arendaVar.ToString());

                    sqlCmd.CommandText = "UPDATE `sklad` SET " +
                        "`arenda`=" + arendaVar.ToString() +
                        ";";
                    sqlCmd.ExecuteNonQuery();
                }
                readAll();
            //}
            //else
              //  MessageBox.Show("Buyruq tasdiqlanmadi");
            
        }

        private void delClient()
        {
            string curId = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            
            //if (vf.ShowDialog() == DialogResult.OK)
            //{

                /*"`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "`fish`	TEXT NOT NULL," +
                        "`shartnoma` TEXT NOT NULL," +
                        "`sana`	TEXT NOT NULL," +
                        "`soat`	TEXT NOT NULL," +
                        "`kun`	INTEGER NOT NULL," +
                        "`oyogi`	INTEGER NOT NULL," +
                        "`krestigi`	INTEGER NOT NULL," +
                        "`taxtasi`	INTEGER NOT NULL," +
                        "`soni`	INTEGER NOT NULL," +
                        "`narxi`	REAL NOT NULL," +
                        "`telefon`	TEXT NOT NULL," +
                        "`xujjat`	TEXT NOT NULL," +
                        "`avans`	REAL NOT NULL," +
                        "`summa`	REAL NOT NULL," +
                        "`taksi`	REAL NOT NULL," +
                        "`qaytgan sanasi`	TEXT NOT NULL," +
                        "`komment` TEXT NOT NULL); ";"*/

                ////Trashga tashlash
                string a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18;
                //MessageBox.Show(curId);
                sqlCmd.CommandText = "SELECT * FROM `clients` WHERE `id`=" + curId + ";";
                SQLiteDataReader sqdr = sqlCmd.ExecuteReader();
                sqdr.Read();
                a1 = sqdr["id"].ToString();
                a2 = sqdr["fish"].ToString();
                a3 = sqdr["shartnoma"].ToString();
                a4 = sqdr["sana"].ToString();
                a5 = sqdr["soat"].ToString();
                a6 = sqdr["kun"].ToString();
                a7 = sqdr["oyogi"].ToString();
                a8 = sqdr["krestigi"].ToString();
                a9 = sqdr["taxtasi"].ToString();
                a10 = sqdr["soni"].ToString();
                a11 = sqdr["narxi"].ToString();
                a12 = sqdr["telefon"].ToString();
                a13 = sqdr["xujjat"].ToString();
                a14 = sqdr["taksi"].ToString(); 
                a15 = sqdr["avans"].ToString(); 
                a16 = sqdr["summa"].ToString();
                a17 = sqdr["qaytgan sanasi"].ToString();
                a18 = sqdr["komment"].ToString();
                sqdr.Close();

                sqlCmd.CommandText = "INSERT INTO `trash`(" +
                        "`id`," +
                        "`fish`," +
                        "`shartnoma`," +
                        "`sana`," +
                        "`soat`," +
                        "`kun`," +
                        "`oyogi`," +
                        "`krestigi`," +
                        "`taxtasi`," +
                        "`soni`," +
                        "`narxi`," +
                        "`telefon`," +
                        "`xujjat`," +
                        "`taksi`," +
                        "`avans`," +
                        "`summa`," +
                        "`qaytgan sanasi`," +
                        "`komment`) " +
                        "VALUES (" + a1 +
                        ",'" + a2 +
                        "','" + a3 +
                        "','" + a4 +
                        "','" + a5 +
                        "'," + a6 +
                        "," + a7 +
                        "," + a8 +
                        "," + a9 +
                        "," + a10 +
                        "," + a11 +
                        ",'" + a12 +
                        "','" + a13 +
                        "'," + a14 +
                        "," + a15 +
                        "," + a16 +
                        ",'" + a17 +
                        "','" + a18 +
                        "');";
                //MessageBox.Show(sqlCmd.CommandText.ToString());
                sqlCmd.ExecuteNonQuery();

                ////Uchirish
                try
                {
                    sqlCmd.CommandText = "DELETE FROM `clients` WHERE " +
                        "`id`=" + curId + ";";
                    sqlCmd.ExecuteNonQuery();

                    int arendaVar = 0;
                    sqlCmd.CommandText = "SELECT * FROM `clients`;";
                    SQLiteDataReader sqldr = sqlCmd.ExecuteReader();
                    while (sqldr.Read())
                    {
                        arendaVar += Convert.ToInt32(sqldr["soni"]);
                    }
                    sqldr.Close();
                    //MessageBox.Show(arendaVar.ToString());

                    sqlCmd.CommandText = "UPDATE `sklad` SET " +
                        "`arenda`=" + arendaVar.ToString() +
                        ";";
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Klient tanlanmagan");
                }
                readAll();
            //}
            //else
            //    MessageBox.Show("Buyruq tasdiqlanmadi");
        }

        private void infoClient()
        {
            ClientInf ci = new ClientInf();
            string curId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show(curId);
            ci.clientId = curId;

            //if (vf.ShowDialog() == DialogResult.OK)
                ci.ShowDialog();
            //else
              //  MessageBox.Show("Buyruq tasdiqlanmadi");
            
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////
            demoBlock();

            if (!dbgrvNull)
                readAll();
            else
            {
                int arendaVar = 0, ostatokVar = 0, umumiyVar = 0;

                sqlCmd.CommandText = "SELECT * FROM `sklad`;";
                SQLiteDataReader sqldr = sqlCmd.ExecuteReader();
                sqldr.Read();
                ostatokVar = Convert.ToInt32(sqldr["ostatok"]);
                arendaVar = Convert.ToInt32(sqldr["arenda"]);
                umumiyVar = Convert.ToInt32(sqldr["umumiy"]);
                sqldr.Close();

                ostatokVar = umumiyVar - arendaVar;
                sqlCmd.CommandText = "UPDATE `sklad` SET " +
                    "`arenda`=" + arendaVar.ToString() +
                    ",`ostatok`=" + ostatokVar.ToString() + ";";
                sqlCmd.ExecuteNonQuery();

                ///sklad va arendani labelni yozish
                sqlCmd.CommandText = "SELECT * FROM `sklad`;";
                sqldr = sqlCmd.ExecuteReader();
                sqldr.Read();
                lbSkStatus.Text = sqldr["ostatok"].ToString();
                lbArStatus.Text = sqldr["arenda"].ToString();
                sqldr.Close();
            }
        }

        public void demoBlock()
        {
           /* if(dataGridView1.Rows.Count > 4)
            {
                MessageBox.Show("BU DEMO VERSIYA!!! FAQATGINA 3 TA KLIENT QO`SHISH MUMKIN");
                this.Close();
            }*/
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
            {
                //MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                demoBlock();
                changeClient();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                demoBlock();
                infoClient();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
            {
                delClient();
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////
            demoBlock();
            //if (vf.ShowDialog() == DialogResult.OK)
                addClient();
            //else
              //  MessageBox.Show("Buyruq tasdiqlanmadi");
        }

        private void btnSoz_Click(object sender, EventArgs e)
        {
            //if(vf.ShowDialog() == DialogResult.OK)
            //{
                Settings stg = new Settings();
                stg.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Buyruq tasdiqlanmadi");
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            Trash tr = new Trash();
            //MessageBox.Show(curId);

            //if (vf.ShowDialog() == DialogResult.OK)
                tr.ShowDialog();
            //else
              //  MessageBox.Show("Buyruq tasdiqlanmadi");
        }

        private void Form2_MaximumSizeChanged(object sender, EventArgs e)
        {
            /*dataGridView1.Size = new Size((this.Size.Width * 80) / 100, (this.Size.Height * 80) / 100);
            Point ptExit = new Point(this.Size.Width - 36, 0);
            Point ptSet = new Point(10, 10);
            Point ptChan = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y);
            Point ptDel = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 30);
            Point ptInfo = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 60);
            Point ptTrash = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 90);
            Point ptAdd = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + dataGridView1.Size.Height - 36);
            Point ptSklad = new Point((this.Width * 30) / 100, 20);
            Point ptArenda = new Point((this.Width * 60) / 100, 20);
            Point ptStSklad = new Point((this.Width * 30) / 100, 40);
            Point ptStArenda = new Point((this.Width * 60) / 100, 40);
            btnExit.Location = ptExit;
            btnSoz.Location = ptSet;
            btnChange.Location = ptChan;
            btnDel.Location = ptDel;
            btnInfo.Location = ptInfo;
            btnTrash.Location = ptTrash;
            btnAddClient.Location = ptAdd;
            lbSklad.Location = ptSklad;
            lbSkStatus.Location = ptStSklad;
            lbArenda.Location = ptArenda;
            lbArStatus.Location = ptStArenda;*/
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Size = new Size((this.Size.Width * 85) / 100, (this.Size.Height * 75) / 100);
            Point ptExit = new Point(this.Size.Width - 36, 0);
            Point ptSet = new Point(10, 10);
            Point ptAdd = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y);
            Point ptDel = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 80);
            Point ptInfo = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 160);
            Point ptTrash = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + dataGridView1.Size.Height - 65); 
            Point ptChan  = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 240);
            Point ptQarz = new Point(dataGridView1.Location.X + dataGridView1.Size.Width + 5, dataGridView1.Location.Y + 305);
            Point ptSklad = new Point((this.Width * 30) / 100, 20);
            Point ptArenda = new Point((this.Width * 60) / 100, 20);
            Point ptStSklad = new Point((this.Width * 30) / 100, 40);
            Point ptStArenda = new Point((this.Width * 60) / 100, 40);
            btnExit.Location = ptExit;
            btnSoz.Location = ptSet;
            btnChange.Location = ptChan;
            btnQarz.Location = ptQarz;
            btnDel.Location = ptDel;
            btnInfo.Location = ptInfo;
            btnTrash.Location = ptTrash;
            btnAddClient.Location = ptAdd;
            lbSklad.Location = ptSklad;
            lbSkStatus.Location = ptStSklad;
            lbArenda.Location = ptArenda;
            lbArStatus.Location = ptStArenda;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchName = tbSearch.Text;
            readAll();
        }

        private void btnQarz_Click(object sender, EventArgs e)
        {
            qushimchaShart = " WHERE summa<0";
            readAll();
        }
    }
}
