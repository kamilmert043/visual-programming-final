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

        private void payback()
        {
            if (!string.IsNullOrWhiteSpace(txtPaid.Text)) { 
                double price = 0, paid = 0;
            price = double.Parse(lblPrice.Text);
            paid = double.Parse(txtPaid.Text);
            double giveback = paid - price;
            txtChange.Text = giveback.ToString("C2");
            }
        }
        private void clearSearch()
        {
           
        }
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
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            process.listCart(dataGridView1);
            process.priceUpdate(dataGridView1, lblPrice, lblTax);
            label22.Text = dataGridView1.RowCount.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text != "" && txtCustomerNameSurname.Text != "")
            {
                process.addCart(dataGridView1, txtCustomerNameSurname, txtCustomerPhone, txtCustomerMail, txtCustomerID, txtProductType, txtProductName, txtProductID, txtProductStockQuantity, txtProductQuantity, txtProductUnitPrice, txtProductTotalPrice, txtProductTax);
                process.listCart(dataGridView1);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                process.dropStock(txtProductQuantity,txtProductID);
                txtProductSearch.Text = "";
                payback();
            }
            else
            {
                if (txtProductName.Text == "" && txtCustomerNameSurname.Text == "")
                {
                    MessageBox.Show("Ürün ve müşteri Seçimi gerçekleştirmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtProductName.Text == "")
                {
                    MessageBox.Show("Ürün Seçimi gerçekleştirmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Müşteri Seçimi gerçekleştirmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.deleteCart(dataGridView1);
            process.listCart(dataGridView1);
            process.priceUpdate(dataGridView1, lblPrice, lblTax);
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPaid.Text))
            {
                payback();
            }
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                process.removeCart(dataGridView1);
                process.listCart(dataGridView1);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                payback();
            }

            if (e.ColumnIndex == 1)
            {
                process.increaseCart(dataGridView1, label21, label22);
                process.listCart(dataGridView1);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                payback();
            }

            if (e.ColumnIndex == 2)
            {
                process.decreaseCart(dataGridView1);
                process.listCart(dataGridView1);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                payback();
            }
        }
    }
}
