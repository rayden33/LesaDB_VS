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
    class chPass
    {
        private string loginFilePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "\\pwdData.raydb";
        public void changePass(string nPass)
        {
            nPass = hashP(nPass);
            //MessageBox.Show(nPass);
            try
            {
                /// login fayli mavjud bo`lsa ya`ni parol mavjud bo`lsa
                using (StreamWriter sw = new StreamWriter(loginFilePath,false,System.Text.Encoding.Default))
                {
                    sw.Write(nPass);
                    sw.Close();
                }
            }
            catch (Exception)
            {
                /// login fayli mavjud bo`lmasa
                File.Create(loginFilePath);
                using (StreamWriter sw = new StreamWriter(loginFilePath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nPass);
                    sw.Close();
                }
            }
        }
        public string hashP(string value)
        {
            string tempS = "";
            int n = value.Length;
            for(int i = 0; i < n; i++)
            {
                tempS = tempS + (Char)(((value[i] + value[i]) % 26) + (int)'A');
                tempS = tempS + (Char)(((value[i] + value[i]) / 26) + (int)'A');
                if(i < n-1)
                    tempS = tempS + '-';
            }
            return tempS;
        }
    }
}
