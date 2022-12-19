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
using System.ComponentModel.DataAnnotations;

namespace satisOtomasyonu
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
       


 
        private void button2_Click(object sender, EventArgs e)
        {
            // string[] texts = { txtName.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text, txtRepassword.Text, txtMail.Text, txtPhone.Text  };
            {

            }
            int hata = 0;
            string name, surname, username, password, rePassword, mail, phone;
            name = txtName.Text;
            surname = txtSurname.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;
            rePassword = txtRepassword.Text;
            mail = txtMail.Text;
            phone = txtPhone.Text;

            if (name == "")
            {            
                txtName.BackColor = Color.Red;
                hata = 1;
                
            }
            if (surname== "")
            {
                txtSurname.BackColor = Color.Red;
                hata = 1;
            }
            if (username == "")
            {
                txtUsername.BackColor = Color.Red;
                hata = 1;
            }
            if (password == "")
            {
                txtPassword.BackColor = Color.Red;
                hata = 1;
            }
            if (rePassword == "")
            {
                txtRepassword.BackColor = Color.Red;
                hata = 1;
            }
            if (mail == "")
            {
                txtMail.BackColor = Color.Red;
                hata = 1;
            }
            if (phone == "")
            {
                txtPhone.BackColor = Color.Red;
                hata = 1;
            }
            if (hata == 1)
            {
                MessageBox.Show("Lütfen Kırmızı Renkli Alanları Doldurun.", "Hata");
            }
            if (password != rePassword)
            {
                MessageBox.Show("Şifreler Aynı Değil.");
                hata = 1;
            }
            if (new EmailAddressAttribute().IsValid(mail) == false)
            {
                MessageBox.Show("Hatalı Mail Adresi");
                hata = 1;
            }

            if (hata != 1)
            {
                classes.users register = new classes.users();
                register.newUser(txtName.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text, txtRepassword.Text, txtMail.Text, txtPhone.Text, txtRank.Text, pbImage.ImageLocation);
            }

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtName.BackColor = Color.White;
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSurname.BackColor = Color.White;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.BackColor = Color.White;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }

        private void txtRepassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtRepassword.BackColor = Color.White;
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMail.BackColor = Color.White;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhone.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            if (file.ShowDialog()== DialogResult.OK)
            {
                pbImage.ImageLocation = file.FileName;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
