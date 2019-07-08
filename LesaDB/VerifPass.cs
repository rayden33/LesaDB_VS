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
    class VerifPass
    {
        private string loginFilePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "\\pwdData.raydb";
        private bool passCorrect = false;
        private string correctPass;
        public bool VerPass(string currentPass)
        {
            try
            {
                /// login fayli mavjud bo`lsa ya`ni parol mavjud bo`lsa
                using (StreamReader sr = new StreamReader(loginFilePath))
                {
                    correctPass = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dasturda xatolik, dasturni yopib qayta oching");
            }
            chPass cp = new chPass();
            if (correctPass == cp.hashP(currentPass))
                passCorrect = true;
            else
                passCorrect = false;

            return passCorrect;
        }
    }
}
