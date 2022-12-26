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
            process.UpdateProudctType(dataGridView1, comboBox1, lblCount);
        }
    }
}
