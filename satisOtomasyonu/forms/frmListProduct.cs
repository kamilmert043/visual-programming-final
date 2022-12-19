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
    public partial class frmListProduct : Form
    {
        public frmListProduct()
        {
            InitializeComponent();
        }
        product process = new product();
        private void frmListProduct_Load(object sender, EventArgs e)
        {
            process.listProduct(dataListProduct);
        }

        private void dataListProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            process.loadUpdateProduct(dataListProduct, cbProductType, cbProductName, txtProductQuantity, txtProductPurchasePrice, dateProductPurchaseDate, txtProductSalePrice, txtProductTax);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.updateProduct(dataListProduct, cbProductType, cbProductName, txtProductQuantity, txtProductPurchasePrice, dateProductPurchaseDate, txtProductSalePrice, txtProductTax);
            process.listProduct(dataListProduct);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            process.searchProduct(dataListProduct, textBox1);
            /*DataView search = new DataView;
            search.RowFilter = "ismi like '" + textBox1.Text + "%'";
            dataListProduct.DataSource = search;*/
        }
    }
}
