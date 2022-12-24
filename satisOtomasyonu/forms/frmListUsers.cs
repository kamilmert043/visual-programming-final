using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace satisOtomasyonu
{
    public partial class frmListUsers : Form
    {
        classes.users process = new classes.users();
        public frmListUsers()
        {
            InitializeComponent();
        }
        
        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dataListUsers.AllowUserToAddRows = false;
            dataListUsers.AllowUserToDeleteRows = false;
            dataListUsers.ReadOnly = true;

            process.loadUsers(dataListUsers, listBox1);
            process.listSelectedUser(dataListUsers, txtName, txtSurname, txtUsername, txtPassword, txtMail, txtPhone, txtRank);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            process.searchUsers(dataListUsers, textBox1, listBox1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMail.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtRank.Text))
            {
                txtRank.BackColor = Color.Red;
                error = 1;
            }


            if (error == 1)
            {
                MessageBox.Show("Kırmızı Olan Alanları Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (error == 0) 
            {
                process.updateUser(dataListUsers, txtName, txtSurname, txtUsername, txtPassword, txtMail, txtPhone, txtRank);
                process.loadUsers(dataListUsers, listBox1);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            process.dropUser(dataListUsers);
            process.loadUsers(dataListUsers, listBox1);
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.BackColor = Color.White;
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            txtSurname.BackColor = Color.White;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            txtMail.BackColor = Color.White;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            txtPhone.BackColor = Color.White;
        }

        private void txtRank_TextChanged(object sender, EventArgs e)
        {
            txtRank.BackColor = Color.White;
        }

        private void dataListUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            process.listSelectedUser(dataListUsers, txtName, txtSurname, txtUsername, txtPassword, txtMail, txtPhone, txtRank);
        }
    }
}
