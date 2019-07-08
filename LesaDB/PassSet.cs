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
    public partial class PassSet : Form
    {

        chPass cp = new chPass();
        VerificationForm vf = new VerificationForm();
        private string loginFilePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "\\pwdData.raydb";

        public PassSet()
        {
            InitializeComponent();
        }

        private void PasswordChange()
        {
            if(tbPass1.Text == tbPass2.Text && tbPass2.TextLength != 0 && PassLanguageTest(tbPass2.Text))
            {
                if (vf.ShowDialog() == DialogResult.OK)
                {
                    cp.changePass(tbPass2.Text.ToString());
                }
                else
                {
                    MessageBox.Show("Buyruq tasdiqlanmadi");
                }
            }
            else
            {
                MessageBox.Show("Parol kiritishda xatolik");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            PasswordChange();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool PassLanguageTest(string pass)
        {

            for(int i=0;i<pass.Length;i++)
            {
                if((pass[i]>='A'&&pass[i]<='Z')||(pass[i] >= 'a' && pass[i] <= 'z')||(pass[i] >= '0' && pass[i] <= '9'))
                {
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
