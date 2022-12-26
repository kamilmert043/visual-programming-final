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
    public partial class frmListCustomers : Form
    {
        public frmListCustomers()
        {
            InitializeComponent();
        }
        customers process = new customers();
        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            dataListCustomers.AllowUserToAddRows = false;
            dataListCustomers.AllowUserToDeleteRows = false;
            dataListCustomers.ReadOnly = true;
            process.loadCustomers(dataListCustomers, lblCount);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            process.searchCustomers(dataListCustomers, txtSearch, lblCount);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (string.IsNullOrWhiteSpace(txtNameSurname.Text))
            {
                txtNameSurname.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtAdress.Text))
            {
                txtAdress.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMail.BackColor = Color.Red;
                error = 1;
            }
            if (error == 1)
            {
                MessageBox.Show("Kırmızı Olan Alanları Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                process.updateCustomers(dataListCustomers, txtNameSurname, txtPhone, txtAdress, txtMail);
                process.loadCustomers(dataListCustomers, lblCount);
            }

        }

        private void txtNameSurname_TextChanged(object sender, EventArgs e)
        {
            txtNameSurname.BackColor = Color.White;
        }


        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            txtMail.BackColor = Color.White;
        }

        private void txtAdress_TextChanged(object sender, EventArgs e)
        {
            txtAdress.BackColor = Color.White;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            txtPhone.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process.dropCustomer(dataListCustomers);
            process.loadCustomers(dataListCustomers, lblCount);
            
        }

        private void dataListCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            process.listCustomers(dataListCustomers, txtNameSurname, txtPhone, txtAdress, txtMail);
        }
    }
}
