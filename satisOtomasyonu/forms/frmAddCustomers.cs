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
    public partial class frmAddCustomers : Form
    {
        public frmAddCustomers()
        {
            InitializeComponent();
        }
        customers process = new customers();
        private void frmAddCustomers_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.addCustomers(txtNameSurname, txtPhone, txtAdress, txtMail);
        }
    }
}
