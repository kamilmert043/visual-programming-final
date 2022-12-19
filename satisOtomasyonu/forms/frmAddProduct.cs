using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace satisOtomasyonu.forms
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }
        product process = new product();
        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            process.loadProudctType(cbProductType);
        }

        private void cbProductType_SelectedValueChanged(object sender, EventArgs e)
        {
            process.productComboList(cbProductType, cbProductName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.addProduct(cbProductType, cbProductName, txtProductQuantity, txtProductPurchasePrice, dateProductPurchaseDate, txtProductSalePrice, txtProductTax);
        }
    }
}
