﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace satisOtomasyonu
{
    class product
    {
        MySqlConnection connection = new MySqlConnection(database.connection);

        public void productComboList(ComboBox productType, ComboBox productName)
        {

            if (productType.SelectedIndex == 0)
            {
                productName.Items.Clear();
                connection.Open();
                MySqlCommand command = new MySqlCommand("Select * from products_name where typeID ='1'", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productName.Items.Add(reader.GetString("pName"));
                }
                connection.Close();
            }

            if (productType.SelectedIndex == 1)
            {
                productName.Items.Clear();
                connection.Open();
                MySqlCommand command = new MySqlCommand("Select * from products_name where typeID ='2'", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productName.Items.Add(reader.GetString("pName"));
                }
                connection.Close();
            }
        }
        public void addProductGroup(ComboBox productType, TextBox productName)
        {
            if (productType.SelectedIndex == 0)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO products_name (typeID, pName) values (@typeID, @pName)", connection);
                command.Parameters.AddWithValue("@typeID", 1);
                command.Parameters.AddWithValue("@pName", productName.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ürün Başarıyla Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (productType.SelectedIndex == 1)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO products_name (typeID, pName) values (@typeID, @pName)", connection);
                command.Parameters.AddWithValue("@typeID", 2);
                command.Parameters.AddWithValue("@pName", productName.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Ürün Başarıyla Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void loadProudctType(ComboBox productType)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("Select productType from products_type", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                productType.Items.Add(reader.GetString("productType"));
            }
            connection.Close();
        }
        public void addProduct(ComboBox productType, ComboBox productName, TextBox productQuantity, TextBox productPurchasePrice, DateTimePicker productPurchaseDate, TextBox productSalePrice, TextBox productTax)
        {
            string query = "INSERT INTO products (productName, productType, productQuantity, productPurchasePrice, productPurchaseDate, productSalePrice, productTax) values(@name, @type, @quantity, @purchasePrice, @purchaseDate, @salePrice, @tax)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", productName.SelectedItem.ToString());
            command.Parameters.AddWithValue("@type", productType.SelectedItem.ToString());
            command.Parameters.AddWithValue("@quantity", int.Parse(productQuantity.Text));
            command.Parameters.AddWithValue("@purchasePrice", int.Parse(productPurchasePrice.Text));
            command.Parameters.AddWithValue("@purchaseDate", productPurchaseDate.Value);
            command.Parameters.AddWithValue("@salePrice", int.Parse(productSalePrice.Text));
            command.Parameters.AddWithValue("@tax", int.Parse(productTax.Text));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void listProduct(DataGridView data)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select id, productName, productType, productQuantity, productPurchasePrice, productPurchaseDate, productSalePrice, productTax from products", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            data.Columns[0].Visible = false;
            data.Columns[1].HeaderText = "Ürün İsmi";
            data.Columns[2].HeaderText = "Ürün Cinsi";
            data.Columns[3].HeaderText = "Ürün Miktarı";
            data.Columns[4].HeaderText = "Ürün Alış Fiyatı";
            data.Columns[5].HeaderText = "Ürün Alım Tarihi";
            data.Columns[6].HeaderText = "Ürün Satış Fiyatı";
            data.Columns[7].HeaderText = "Vergi Oranı(%)";
        }
        public void loadUpdateProduct(DataGridView data, ComboBox productType, ComboBox productName, TextBox productQuantity, TextBox productPurchasePrice, DateTimePicker productPurchaseDate, TextBox productSalePrice, TextBox productTax)
        {
            productName.Items.Clear();
            productType.Items.Clear();
            if (true)
            {

            
            connection.Open();
            MySqlCommand command = new MySqlCommand("Select pName from products_name", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                productName.Items.Add(reader.GetString("pName"));
            }
            connection.Close();
            }
            connection.Open();
            if (true)
            {

            
            MySqlCommand command = new MySqlCommand("Select productType from products_type", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                productType.Items.Add(reader.GetString("productType"));
            }
            }
            connection.Close();
            productName.SelectedItem = data.CurrentRow.Cells[1].Value.ToString();
            productType.SelectedItem = data.CurrentRow.Cells[2].Value.ToString();
            productQuantity.Text = data.CurrentRow.Cells[3].Value.ToString();
            productPurchasePrice.Text = data.CurrentRow.Cells[4].Value.ToString();
            DateTime date = DateTime.Parse(data.CurrentRow.Cells[5].Value.ToString());
            productPurchaseDate.Value = date;
            productSalePrice.Text = data.CurrentRow.Cells[6].Value.ToString();
            productTax.Text = data.CurrentRow.Cells[7].Value.ToString();
        }

        public void updateProduct(DataGridView data, ComboBox productType, ComboBox productName, TextBox productQuantity, TextBox productPurchasePrice, DateTimePicker productPurchaseDate, TextBox productSalePrice, TextBox productTax)
        {
            int selRow = Convert.ToInt32((data.CurrentRow.Cells[0].Value));

            MySqlCommand command = new MySqlCommand("UPDATE products SET productName = @name, productType = @type, productQuantity = @quantity, productPurchasePrice = @purchasePrice, productPurchaseDate = @purchaseDate, productSalePrice = @salePrice, productTax = @tax where id = @row", connection);
            command.Parameters.AddWithValue("@name", productName.SelectedItem.ToString());
            command.Parameters.AddWithValue("@type", productType.SelectedItem.ToString());
            command.Parameters.AddWithValue("@quantity", int.Parse(productQuantity.Text));
            command.Parameters.AddWithValue("@purchasePrice", int.Parse(productPurchasePrice.Text));
            command.Parameters.AddWithValue("@purchaseDate", productPurchaseDate.Value);
            command.Parameters.AddWithValue("@salePrice", int.Parse(productSalePrice.Text));
            command.Parameters.AddWithValue("@tax", int.Parse(productTax.Text));
            command.Parameters.AddWithValue("@row", selRow);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void searchProduct(DataGridView data, TextBox searchString)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, productName, productType, productQuantity, productPurchasePrice, productPurchaseDate, productSalePrice, productTax FROM products WHERE productName LIKE CONCAT(@name, '%')", connection);
            da.SelectCommand.Parameters.AddWithValue("@name", searchString.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            data.Columns[0].Visible = false;
            data.Columns[1].HeaderText = "Ürün İsmi";
            data.Columns[2].HeaderText = "Ürün Cinsi";
            data.Columns[3].HeaderText = "Ürün Miktarı";
            data.Columns[4].HeaderText = "Ürün Alış Fiyatı";
            data.Columns[5].HeaderText = "Ürün Alım Tarihi";
            data.Columns[6].HeaderText = "Ürün Satış Fiyatı";
            data.Columns[7].HeaderText = "Vergi Oranı(%)";
        }
    }
}