using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace satisOtomasyonu
{

    public partial class frmLogin : Form
        
    {
        
        public frmLogin()
        {
            InitializeComponent();
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            forms.frmLostPassword lostPassword = new forms.frmLostPassword();
            lostPassword.Show();
        }
        classes.users login = new classes.users();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmHomepage homepage = new frmHomepage();
            
            login.userLogin(txtUsername, txtPassword, homepage);


        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.BackColor = Color.White;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.PasswordChar = '\0';
                checkBox1.Text = "Gizle";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                checkBox1.Text = "Göster";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
