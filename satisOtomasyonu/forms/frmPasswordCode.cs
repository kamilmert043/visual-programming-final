using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satisOtomasyonu.forms
{
    public partial class frmPasswordCode : Form
    {
        public string uid;
        public frmPasswordCode()
        {
            InitializeComponent();
        }
        classes.lostPassword process = new classes.lostPassword();
        private void frmPasswordCode_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(uid);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                process.updatePassword(textBox1, txtCode);
            }
            else
            {
                MessageBox.Show("Şifre Boş bırakılamaz.");
            }
            
        }
    }
}
