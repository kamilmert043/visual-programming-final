using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace satisOtomasyonu.forms
{
    public partial class frmLostPassword : Form
    {
        public frmLostPassword()
        {
            InitializeComponent();
        }
        classes.lostPassword process = new classes.lostPassword();
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int code = rnd.Next(100000, 1000000);
            string scode = "Şifre Sıfırlama Kodunuz: <h2>" + code.ToString() + "</h2>";
            string title = "Sıfırlama Kodu";
            string mail = "toptanmanav10@gmail.com";
            string pass = "jaolunqoxjomqtgi";

            process.Send(txtMail.Text, title, mail, pass);


        }

        private void frmLostPassword_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int code = rnd.Next(100000, 1000000);
            string scode = "Şifre Sıfırlama Kodunuz: <h2>" + code.ToString() + "</h2>";


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPasswordCode passwordCode = new frmPasswordCode();
            passwordCode.Show();
            this.Close();
        }
    }
}
