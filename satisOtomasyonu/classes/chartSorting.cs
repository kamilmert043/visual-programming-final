using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace satisOtomasyonu.classes
{
    class chartSorting
    {
        MySqlConnection connection = new MySqlConnection(database.connection);

        public void carth(DataGridView data, Chart chart, Label most, Label least, Label mostName, Label leastName)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT productName,SUM(amount) from sales group By (productName) ORDER BY `SUM(amount)` DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();

            for (int i = 0; i < data.RowCount-1; i++)
            {
                chart.Series["Satış Miktarı"].Points.AddXY(data.Rows[i].Cells[0].Value.ToString(), data.Rows[i].Cells[1].Value.ToString());
            }

            most.Text ="Miktarı: " + data.Rows[0].Cells[1].Value.ToString();
            mostName.Text = "En Çok Satılan ürün: " + data.Rows[0].Cells[0].Value.ToString();

            least.Text = "Miktarı: " + data.Rows[data.Rows.Count - 2].Cells[1].Value.ToString();
            leastName.Text = "En Az Satılan ürün: " + data.Rows[data.Rows.Count - 2].Cells[0].Value.ToString();
        }
    }
}
