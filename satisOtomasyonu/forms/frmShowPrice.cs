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
    public partial class frmShowPrice : Form
    {
        public frmShowPrice()
        {
            InitializeComponent();
        }
        classes.cart process = new classes.cart();
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            process.searchProduct(txtProductSearch, txtProductType, txtProductName, txtProductStockQuantity, txtProductUnitPrice, txtProductQuantity, txtProductTotalPrice, txtProductID, txtProductTax);
        }

        private void txtProductQuantity_TextChanged(object sender, EventArgs e)
        {
            process.calcPrice(txtProductQuantity, txtProductUnitPrice, txtProductTotalPrice);
        }

        private void txtProductQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
