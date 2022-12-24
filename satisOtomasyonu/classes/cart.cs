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

    class cart

    {
        MySqlConnection connection = new MySqlConnection(database.connection);

        public void searchCustomers(TextBox searchString, TextBox customerNameSurname, TextBox customerPhone, TextBox customerMail, TextBox customerID)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM customers WHERE NameSurname LIKE CONCAT(@name, '%')", connection);
            command.Parameters.AddWithValue("@name", searchString.Text);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                customerNameSurname.Text = dr["nameSurname"].ToString();
                customerPhone.Text = dr["phone"].ToString();
                customerMail.Text = dr["mail"].ToString();
                customerID.Text = dr["id"].ToString();
                
            }
            connection.Close();
            if (string.IsNullOrWhiteSpace(searchString.Text))
            {
                customerNameSurname.Text = "";
                customerPhone.Text = "";
                customerMail.Text = "";
                customerID.Text = "";
            }
        }

        public void searchProduct(TextBox searchString, TextBox productType, TextBox productName, TextBox stockQuantity, TextBox unitPrice, TextBox productQuantity, TextBox totalPrice, TextBox productID, TextBox productTax)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM productss WHERE productName LIKE CONCAT(@name, '%')", connection);
            command.Parameters.AddWithValue("@name", searchString.Text);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                productType.Text = dr["productType"].ToString();
                productName.Text = dr["productName"].ToString();
                stockQuantity.Text = dr["productQuantity"].ToString();
                unitPrice.Text = dr["productSalePrice"].ToString();
                productTax.Text = dr["productTax"].ToString();
                productID.Text = dr["id"].ToString();
                productQuantity.Text = "1";
            }
            connection.Close();
            if (string.IsNullOrWhiteSpace(productQuantity.Text))
            {

            }
            else
            {
                double quantity = double.Parse(productQuantity.Text);
                double unit = double.Parse(unitPrice.Text);
                double price = quantity * unit;
                totalPrice.Text = price.ToString();
            }
            if (string.IsNullOrWhiteSpace(searchString.Text))
            {
                productType.Text = "";
                productName.Text = "";
                stockQuantity.Text ="";
                productID.Text = "";
                unitPrice.Text = "";
                productQuantity.Text = "";
                totalPrice.Text = "";
            }
        }
        public void calcPrice(TextBox productQuantity, TextBox unitPrice, TextBox totalPrice)
        {
            if (string.IsNullOrWhiteSpace(productQuantity.Text)) 
            {

            }
            else
            {
                double quantity = double.Parse(productQuantity.Text);
                double unit = double.Parse(unitPrice.Text);
                double price = quantity * unit;
                totalPrice.Text = price.ToString();
            }



        }

        public void listCart(DataGridView data)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from carts", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            /*data.Columns[0].Visible = false;
            data.Columns[1].HeaderText = "Ürün İsmi";
            data.Columns[2].HeaderText = "Ürün Cinsi";
            data.Columns[3].HeaderText = "Ürün Miktarı";
            data.Columns[4].HeaderText = "Ürün Alış Fiyatı";
            data.Columns[5].HeaderText = "Ürün Alım Tarihi";
            data.Columns[6].HeaderText = "Ürün Satış Fiyatı";
            data.Columns[7].HeaderText = "Vergi Oranı(%)";*/
        }
        public void addCart(TextBox customerNameSurname, TextBox customerPhone, TextBox customerMail, TextBox customerID, TextBox productType, TextBox productName, TextBox productID, TextBox productStockQuantity, TextBox productQuantity, TextBox productUnitPrice, TextBox productTotalPrice, TextBox productTax)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO carts (customerID, nameSurname, productID, productName, productType, unitPrice, amount, totalPrice, tax) values (@customerID, @nameSurname, @productID, @productName, @productType, @unitPrice, @amount, @totalPrice, @tax)", connection);
            command.Parameters.AddWithValue("@customerID", customerID.Text);
            command.Parameters.AddWithValue("@nameSurname", customerNameSurname.Text);
            command.Parameters.AddWithValue("@productID", productID.Text);
            command.Parameters.AddWithValue("@productName", productName.Text);
            command.Parameters.AddWithValue("@productType", productType.Text);
            command.Parameters.AddWithValue("@unitPrice", Double.Parse(productUnitPrice.Text));
            command.Parameters.AddWithValue("@amount", Double.Parse(productQuantity.Text));
            command.Parameters.AddWithValue("@totalPrice", Double.Parse(productTotalPrice.Text));
            command.Parameters.AddWithValue("@tax", productTax.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün Başarıyla Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void deleteCart()
        {
            DialogResult status = MessageBox.Show("Sepeti Boşaltmak üzeresiniz bu işlemden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == status)
            {
                MySqlCommand command = new MySqlCommand("delete from carts", connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Sepet Temizlendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
