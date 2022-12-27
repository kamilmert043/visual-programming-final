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
    public partial class frmListSales : Form
    {
        public frmListSales()
        {
            InitializeComponent();
        }
        classes.sales process = new classes.sales();
        private void dataCount()
        {
            label7.Text = "Toplam Kayıt Sayısı: " + dataGridView1.Rows.Count.ToString();
        }
        private void frmListSales_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            process.loadSales(dataGridView1);
            dataCount();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            process.searchProductID(dataGridView1, txtProductID);
            dataCount();
        }


        private void txtProductType_TextChanged(object sender, EventArgs e)
        {
            process.searchProductType(dataGridView1, txtProductType);
            dataCount();
        }

        private void dateDaily_ValueChanged(object sender, EventArgs e)
        {
            process.searchDaily(dataGridView1, dateDaily);
            dataCount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process.searchBetweenDate(dataGridView1, dateOne, dateTwo);
            dataCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(txtMonth.Text))
            {
                MessageBox.Show("Ay ve/veya yıl girişi yapın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                process.searchMonthYear(dataGridView1, txtMonth, txtYear);
                dataCount();
            }

        }

        private void onlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYear2.Text))
            {
                MessageBox.Show("Yıl girişi yapın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                process.searchYear(dataGridView1, txtYear2);
                dataCount();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            process.searchWeekly(dataGridView1);
            dataCount();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            process.searchMonthly(dataGridView1);
            dataCount();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook book = application.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet page = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[1];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)page.Cells[1, i + 1];
                range.Value2 = dataGridView1.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
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
