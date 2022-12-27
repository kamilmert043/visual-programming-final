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
    public partial class frmSalesGraphic : Form
    {
        public frmSalesGraphic()
        {
            InitializeComponent();
        }
        classes.chartSorting process = new classes.chartSorting();

        private void frmSalesGraphic_Load(object sender, EventArgs e)
        {
            process.carth(dataGridView1, chart1, label4, label3, label1, label2);
        }
    }
}
