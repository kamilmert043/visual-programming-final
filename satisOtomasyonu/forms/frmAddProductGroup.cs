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
    public partial class frmAddProductGroup : Form
    {
        public frmAddProductGroup()
        {
            InitializeComponent();
        }
        product process = new product();
        private void button1_Click(object sender, EventArgs e)
        {
            process.addProductGroup(cbProductType, txtProductName);
        }

        private void frmAddProductGroup_Load(object sender, EventArgs e)
        {
            process.loadProudctType(cbProductType);
        }
    }
}
