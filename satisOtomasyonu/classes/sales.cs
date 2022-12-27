using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace satisOtomasyonu.classes
{
    class sales

    {
        MySqlConnection connection = new MySqlConnection(database.connection);
        public void loadSales(DataGridView data)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();

            data.Columns[1].HeaderText = "Müşteri ID";
            data.Columns[2].HeaderText = "Adı Soyadı";
            data.Columns[3].HeaderText = "Telefon";
            data.Columns[4].HeaderText = "Ürün ID";
            data.Columns[5].HeaderText = "Ürün İsmi";
            data.Columns[6].HeaderText = "Ürün Tipi";
            data.Columns[7].HeaderText = "Birim Fiyatı";    
            data.Columns[8].HeaderText = "Miktarı";
            data.Columns[9].HeaderText = "Toplam Tutar";
            data.Columns[10].HeaderText = "Vergi";
            data.Columns[11].HeaderText = "Satış Tarihi";
            data.Columns[12].HeaderText = "Açıklama";
            //data.Columns[13].HeaderText = "Sepet ID";
        }

        public void searchProductID(DataGridView data, TextBox productID)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE sales.productID LIKE CONCAT(@id, '%')", connection);
            da.SelectCommand.Parameters.AddWithValue("@id", productID.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchProductType(DataGridView data, TextBox productType)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE sales.productType LIKE CONCAT(@type, '%')", connection);
            da.SelectCommand.Parameters.AddWithValue("@type", productType.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchDaily(DataGridView data, DateTimePicker daily)
        {

            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE sales.orderTime LIKE CONCAT(@date, '%')", connection);
            da.SelectCommand.Parameters.AddWithValue("@date", daily.Value.ToString("yyyy-MM-dd"));
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchBetweenDate(DataGridView data, DateTimePicker day1, DateTimePicker day2)
        {


            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE sales.orderTime between @date and @date2", connection);
            da.SelectCommand.Parameters.AddWithValue("@date", day1.Value.ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.AddWithValue("@date2", day2.Value.ToString("yyyy-MM-dd"));
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchMonthYear(DataGridView data, TextBox month, TextBox year)
        {


            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE month(sales.orderTime) = @date and year(sales.orderTime) = @date2", connection);
            da.SelectCommand.Parameters.AddWithValue("@date", month.Text);
            da.SelectCommand.Parameters.AddWithValue("@date2", year.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchYear(DataGridView data, TextBox year)
        {


            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE year(sales.orderTime) = @date", connection);
            da.SelectCommand.Parameters.AddWithValue("@date", year.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchWeekly(DataGridView data)
        {             
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE sales.orderTime between @date and @date2", connection);
            da.SelectCommand.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.AddWithValue("@date2", DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }

        public void searchMonthly(DataGridView data)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT sales.id, customers.id, customers.nameSurname, customers.phone, sales.productID, productss.productName, productss.productType, sales.unitPrice, sales.amount, sales.totalPrice, sales.tax, sales.orderTime, sales.description FROM sales INNER JOIN customers ON sales.customerID = customers.id INNER JOIN productss ON sales.productID = productss.id WHERE sales.orderTime between @date and @date2", connection);
            da.SelectCommand.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.AddWithValue("@date2", DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
        }
    }
}
