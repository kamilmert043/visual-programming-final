using satisOtomasyonu.forms;
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
    public partial class frmHomepage : Form
    {
        public frmHomepage()
        {
            InitializeComponent();
        }

        private void getForm(Form frm)
        {
            panelPages.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Left;
            panelPages.Controls.Add(frm);
            frm.Show();

        }
        public int rank;
        private void frmHomepage_Load(object sender, EventArgs e)
        {
            
        }
        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProduct addProduct = new frmAddProduct();
            getForm(addProduct);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (rank < 4)
            {
                MessageBox.Show("Bu bölüme giriş için yetkiniz yetersiz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { 
            frmRegister userRegister = new frmRegister();
            getForm(userRegister);
            }
        }

        private void frmHomepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            frmListProduct listProduct = new frmListProduct();
            getForm(listProduct);
        }

        private void btnAddProductGroup_Click(object sender, EventArgs e)
        {
            frmAddProductGroup addProductGroup = new frmAddProductGroup();
            getForm(addProductGroup);
        }

        private void btnListUser_Click(object sender, EventArgs e)
        {
            frmListUsers listUsers = new frmListUsers();
            getForm(listUsers);
        }

        private void btnAddCostumers_Click(object sender, EventArgs e)
        {
            frmAddCustomers addCustomers = new frmAddCustomers();
            getForm(addCustomers);
        }

        private void btnListCustomers_Click(object sender, EventArgs e)
        {
            frmListCustomers listCustomers = new frmListCustomers();
            getForm(listCustomers);
        }

        private void btnListProductGroup_Click(object sender, EventArgs e)
        {
            frmListProductGroup listProductGroup = new frmListProductGroup();
            getForm(listProductGroup);
        }

        private void btnSaleOrder_Click(object sender, EventArgs e)
        {
            frmProductSale productSale = new frmProductSale();
            getForm(productSale);
        }

        private void btnListSales_Click(object sender, EventArgs e)
        {
            if (rank <= 4)
            {
                MessageBox.Show("Bu bölüme giriş için yetkiniz yetersiz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                frmListSales listSales = new frmListSales();
                getForm(listSales);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forms.frmSalesGraphic salesGraphic = new forms.frmSalesGraphic();
            getForm(salesGraphic);
        }
    }
}
