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
    public partial class frmProductSale : Form
    {
        public frmProductSale()
        {
            InitializeComponent();
        }
        classes.cart process = new classes.cart();
        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            process.searchCustomers(txtCustomerSearch, txtCustomerNameSurname, txtCustomerPhone, txtCustomerMail, txtCustomerID);
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            process.searchProduct(txtProductSearch, txtProductType, txtProductName, txtProductStockQuantity, txtProductUnitPrice,txtProductQuantity,txtProductTotalPrice, txtProductID, txtProductTax);
        }

        private void txtProductQuantity_TextChanged(object sender, EventArgs e)
        {
            process.calcPrice(txtProductQuantity, txtProductUnitPrice, txtProductTotalPrice);
        }

        private void txtProductQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmProductSale_Load(object sender, EventArgs e)
        {
            process.listCart(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process.addCart(txtCustomerNameSurname, txtCustomerPhone, txtCustomerMail, txtCustomerID, txtProductType, txtProductName, txtProductID, txtProductStockQuantity, txtProductQuantity, txtProductUnitPrice, txtProductTotalPrice, txtProductTax);
            process.listCart(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.deleteCart();
            process.listCart(dataGridView1);
        }
    }
}
