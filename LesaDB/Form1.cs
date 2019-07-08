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

namespace LesaDB
{
    public partial class Form1 : Form
    {
        private string oldPassH, newPass;
        private string loginFilePath= @"" + AppDomain.CurrentDomain.BaseDirectory + "\\pwdData.raydb";
        private bool firstLogin = true;
        VerifPass vp = new VerifPass();
        PassSet ps = new PassSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                /// login fayli mavjud bo`lsa ya`ni parol mavjud bo`lsa
                using (StreamReader sr = new StreamReader(loginFilePath))
                {
                    oldPassH = sr.ReadLine();
                }
                firstLogin = false;
            }
            catch(Exception ex)
            {
                /// login fayli mavjud bo`lmasa
                label2.Text = "Yangi parol:";
                label3.Visible = true;
                textBox2.Visible = true;
                button1.Text = "Saqlash";
                MessageBox.Show("Yangi parolni kiriting (Faqat A-Z, 0-9, a-z)");
                firstLogin = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            chPass cpw = new chPass();

            if (firstLogin)
            {
                /// Yangi parolni saqlash bo`limi
                if (textBox1.Text == textBox2.Text && textBox2.TextLength != 0 && ps.PassLanguageTest(textBox2.Text))
                {
                    newPass = textBox2.Text.ToString();
                    cpw.changePass(newPass);
                    MessageBox.Show("Parol muvofoqiyatli yaratildi");
                    firstLogin = false;
                    button1.PerformClick();
                }
                else
                {
                    MessageBox.Show("Parol kiritishda xatolik");
                }
            }
            else
            {
                /// Tizimga kirish bo`limi
                newPass = textBox1.Text.ToString();
                if (vp.VerPass(newPass))
                {
                    //MessageBox.Show("Parol to`g`ri");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.ShowDialog();
                    this.Close();
                    //this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Parol noto`g`ri");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chPass cpw = new chPass();
            
            if(firstLogin)
            {
                /// Yangi parolni saqlash bo`limi
                if(textBox1.Text == textBox2.Text && textBox2.TextLength != 0 && ps.PassLanguageTest(textBox2.Text))
                {
                    newPass = textBox2.Text.ToString();
                    cpw.changePass(newPass);
                    MessageBox.Show("Parol muvofoqiyatli yaratildi");
                    firstLogin = false;
                    button1.PerformClick();
                }
                else
                {
                    MessageBox.Show("Parol kiritishda xatolik");
                }
            }
            else
            {
                /// Tizimga kirish bo`limi
                newPass = textBox1.Text.ToString();
                if(vp.VerPass(newPass))
                {
                    //MessageBox.Show("Parol to`g`ri");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.ShowDialog();
                    this.Close();
                    //this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Parol noto`g`ri");
                }
            }
        }
    }
}
