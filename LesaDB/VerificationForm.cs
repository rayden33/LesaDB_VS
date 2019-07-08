using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LesaDB
{
    public partial class VerificationForm : Form
    {
        VerifPass vp = new VerifPass();
        public VerificationForm()
        {
            InitializeComponent();
            
        }

        private void btnTasd_Click(object sender, EventArgs e)
        {
            if(vp.VerPass(tbPass.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
            tbPass.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbPass.Clear();
            this.Close();
        }
    }
}
