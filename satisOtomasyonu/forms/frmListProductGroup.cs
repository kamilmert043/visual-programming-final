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
    public partial class frmListProductGroup : Form
    {
        public frmListProductGroup()
        {
            InitializeComponent();
        }
        product process = new product();
        private void frmListProductGroup_Load(object sender, EventArgs e)
        {
            process.listProductName(dataGridView1, lblCount);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            process.listSelectedProductName(dataGridView1, txtProductName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.updateProductName(dataGridView1, txtProductName);
            process.listProductName(dataGridView1, lblCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process.deleteProductName(dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            process.searchProductName(dataGridView1, txtSearchString);
        }
    }
}
