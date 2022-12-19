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
    public partial class frmListUsers : Form
    {
        classes.users process = new classes.users();
        public frmListUsers()
        {
            InitializeComponent();
        }
        
        private void frmListUsers_Load(object sender, EventArgs e)
        {
            process.listUsers(dataGridView1, listBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            process.searchUsers(dataGridView1, textBox1, listBox1);
        }
    }
}
