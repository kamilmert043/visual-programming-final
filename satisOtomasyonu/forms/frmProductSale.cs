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
            process.listCart(dataGridView1, label3);
            process.priceUpdate(dataGridView1, lblPrice, lblTax);
            payback();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text != "" && txtCustomerNameSurname.Text != "")
            {
                process.addCart(dataGridView1, txtCustomerNameSurname, txtCustomerPhone, txtCustomerMail, txtCustomerID, txtProductType, txtProductName, txtProductID, txtProductStockQuantity, txtProductQuantity, txtProductUnitPrice, txtProductTotalPrice, txtProductTax);
                process.listCart(dataGridView1, label3);
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
            process.listCart(dataGridView1, label3);
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
                process.listCart(dataGridView1, label3);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                payback();
            }

            if (e.ColumnIndex == 1)
            {
                process.increaseCart(dataGridView1);
                process.listCart(dataGridView1, label3);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                payback();
            }

            if (e.ColumnIndex == 2)
            {
                process.decreaseCart(dataGridView1);
                process.listCart(dataGridView1, label3);
                process.priceUpdate(dataGridView1, lblPrice, lblTax);
                payback();
            }
        }

        private void frmProductSale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) 
            {
                cbPaymentMethod.SelectedIndex = 0;
                txtPaid.Focus();
            }
            if (e.KeyCode == Keys.F2) 
            {
                cbPaymentMethod.SelectedIndex = 1;
                txtPaid.Text = lblPrice.Text;
                txtChange.Text = "0.00";
            }
            if (e.KeyCode == Keys.F3)
            {

            }

            if (e.KeyCode == Keys.F4)
            {
                btnAcceptOrder.PerformClick();
            }

            if (e.KeyCode == Keys.F5)
            {
                btnPrintPage.PerformClick();
            }

            if (e.KeyCode == Keys.F6)
            {
                
            }

            if (e.KeyCode == Keys.F7)
            {
                btnProductReturn.PerformClick();
            }

            if (e.KeyCode == Keys.F8)
            {
                btnViewPrice.PerformClick();
            }

            if (e.KeyCode == Keys.F9)
            {
                btnViewSales.PerformClick();
            }
        }

        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {
            process.makeSale(dataGridView1);
            process.listCart(dataGridView1, label3);
            process.priceUpdate(dataGridView1, lblPrice, lblTax);
        }

        private void btnViewPrice_Click(object sender, EventArgs e)
        {
            frmShowPrice showPrice = new frmShowPrice();
            showPrice.Show();
        }

        private void btnProductReturn_Click(object sender, EventArgs e)
        {
            frmProductReturn productReturn = new frmProductReturn();
            productReturn.Show();
        }

        private void btnDeclineOrder_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        int satirsayisi = 0;

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Font font = new Font("Arial", 20);
            SolidBrush firca = new SolidBrush(Color.Black);
            Pen kalem = new Pen(Color.Black);

            e.Graphics.DrawString("Düzenlenme Tarihi: " + DateTime.Now.ToLongDateString() + " " +
                    "" + DateTime.Now.ToLongTimeString(), font, firca, 50, 25);
            e.Graphics.DrawLine(kalem, 50, 65, 770, 65);
            e.Graphics.DrawLine(kalem, 50, 1000, 50, 65);

            e.Graphics.DrawLine(kalem, 50, 1000, 770, 1000);
            e.Graphics.DrawLine(kalem, 770, 1000, 770, 65);
            ////////////////////////////////////////////////////
            font = new Font("Arial", 20, FontStyle.Bold);
            e.Graphics.DrawString("Ürün Listesi", font, firca, 350, 75);
            e.Graphics.DrawLine(kalem, 50, 110, 770, 110);

            font = new Font("Arial", 15, FontStyle.Bold);
            e.Graphics.DrawString("Sıra", font, firca, 60, 118);
            e.Graphics.DrawString("Ürün İsmi", font, firca, 130, 118);
            e.Graphics.DrawString("Ürün Tipi", font, firca, 240, 118);
            e.Graphics.DrawString("Birim fiyat", font, firca, 350, 118);
            e.Graphics.DrawString("Miktar", font, firca, 500, 118);
            e.Graphics.DrawString("Toplam Fiyat", font, firca, 610, 118);
            e.Graphics.DrawLine(kalem, 50, 150, 770, 150);
            ////////////////////////////////////////////////////////
            e.Graphics.DrawString("Ödenen=" + txtPaid.Text + "  TL", font, firca, 60, 1025);
            e.Graphics.DrawString("Paraüstü=" + txtChange.Text + "  TL", font, firca, 60, 1065);
            e.Graphics.DrawString("Genel Toplam=" + lblPrice.Text + "  TL", font, firca, 480, 1065);
            /////////////////////////////////////////////////////////
            int y = 160;

            font = new Font("Arial", 15);
            int i = 0;
            while (i <= dataGridView1.Rows.Count - 1)
            {
                e.Graphics.DrawString((i + 1) + ".", font, firca, 60, y);
                e.Graphics.DrawString(dataGridView1[8, i].Value.ToString(), font, firca, 130, y);
                e.Graphics.DrawString(dataGridView1[9, i].Value.ToString(), font, firca, 250, y);
                e.Graphics.DrawString(dataGridView1[10, i].Value.ToString(), font, firca, 360, y);
                e.Graphics.DrawString(dataGridView1[11, i].Value.ToString(), font, firca, 510, y);
                e.Graphics.DrawString(dataGridView1[12, i].Value.ToString(), font, firca, 620, y);
                y = y + 25;
                i = i + 1;

                if (y > 1000)
                {
                    e.Graphics.DrawString("Devamı Diğer Sayfada---->", font, firca, 700, y + 50);
                    y = 50;
                    break;

                }
            }
            if (i < satirsayisi)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                i = 0;
            }

            StringFormat strformat = new StringFormat();
            strformat.Alignment = StringAlignment.Far;

        }

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            frmListSales listSales = new frmListSales();
            listSales.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook book = application.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet page = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[1];
            for (int i = 3; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)page.Cells[1, i + 1];
                range.Value2 = dataGridView1.Columns[i].HeaderText;
            }
            for (int i = 3; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)page.Cells[j + 2, i + 1];
                    range.Value2 = dataGridView1[i, j].Value;
                }
            }
        }
    }
}
