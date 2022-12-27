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
            dataListProduct.AllowUserToAddRows = false;
            dataListProduct.AllowUserToDeleteRows = false;
            dataListProduct.ReadOnly = true;
            process.listProduct(dataListProduct, lblCount);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int error = 0;

            if (string.IsNullOrWhiteSpace(txtProductQuantity.Text))
            {
                txtProductQuantity.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtProductPurchasePrice.Text))
            {
                txtProductPurchasePrice.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtProductSalePrice.Text))
            {
                txtProductSalePrice.BackColor = Color.Red;
                error = 1;
            }

            if (string.IsNullOrWhiteSpace(txtProductTax.Text))
            {
                txtProductTax.BackColor = Color.Red;
                error = 1;
            }
            if (error == 1)
            {
                MessageBox.Show("Kırmızı Olan Alanları Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 0)
            {
                process.updateProduct(dataListProduct, cbProductType, cbProductName, txtProductQuantity, txtProductPurchasePrice, dateProductPurchaseDate, txtProductSalePrice, txtProductTax);
                process.listProduct(dataListProduct, lblCount);
                cbProductType.SelectedIndex = -1;
                cbProductName.SelectedIndex = -1;
                txtProductQuantity.Text = "";
                txtProductPurchasePrice.Text = "";
                txtProductSalePrice.Text = "";
                txtProductTax.Text = "";


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            process.searchProduct(dataListProduct, textBox1, lblCount, cbProductType, cbProductName, txtProductQuantity, txtProductPurchasePrice, dateProductPurchaseDate, txtProductSalePrice, txtProductTax);
            /*DataView search = new DataView;
            search.RowFilter = "ismi like '" + textBox1.Text + "%'";
            dataListProduct.DataSource = search;*/
        }

        private void txtProductQuantity_TextChanged(object sender, EventArgs e)
        {
            txtProductQuantity.BackColor = Color.White;
        }

        private void txtProductPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            txtProductPurchasePrice.BackColor = Color.White;
        }

        private void txtProductSalePrice_TextChanged(object sender, EventArgs e)
        {
            txtProductSalePrice.BackColor = Color.White;
        }

        private void txtProductTax_TextChanged(object sender, EventArgs e)
        {
            txtProductTax.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process.dropProduct(dataListProduct);
            process.listProduct(dataListProduct, lblCount);
        }

        private void dataListProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            process.loadUpdateProduct(dataListProduct, cbProductType, cbProductName, txtProductQuantity, txtProductPurchasePrice, dateProductPurchaseDate, txtProductSalePrice, txtProductTax);
        }

    }
}
