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
    public partial class frmProductReturn : Form
    {
        public frmProductReturn()
        {
            InitializeComponent();
        }
        classes.cart process = new classes.cart();
        private void txtSalesIDSearch_TextChanged(object sender, EventArgs e)
        {
            process.productReturnSearch(txtSalesIDSearch, txtProductType, txtProductName, txtProductID, numericProductAmount, txtCustomerNameSurname, txtCustomerPhone, txtSalesID, txtSalesAmount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.productReturn(txtSalesID, numericProductAmount, txtProductID);
            process.productReturnSearch(txtSalesIDSearch, txtProductType, txtProductName, txtProductID, numericProductAmount, txtCustomerNameSurname, txtCustomerPhone, txtSalesID, txtSalesAmount);
        }

        private void frmProductReturn_Load(object sender, EventArgs e)
        {

        }
    }
}
