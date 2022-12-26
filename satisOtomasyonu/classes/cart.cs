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
        public void addCart(DataGridView data, TextBox customerNameSurname, TextBox customerPhone, TextBox customerMail, TextBox customerID, TextBox productType, TextBox productName, TextBox productID, TextBox productStockQuantity, TextBox productQuantity, TextBox productUnitPrice, TextBox productTotalPrice, TextBox productTax)
        {

            double quantity = 0;
            connection.Open();
            MySqlCommand controlCommand = new MySqlCommand("select productQuantity from productss where id=@id", connection);
            controlCommand.Parameters.AddWithValue("@id", productID.Text);
            MySqlDataReader dr = controlCommand.ExecuteReader();
            if (dr.Read())
            {
                quantity = Convert.ToDouble(dr["productQuantity"]);

            }
            connection.Close();
            if (quantity < Convert.ToDouble(productQuantity.Text))
            {
                MessageBox.Show("Stokta bu kadar fazla ürün yok.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
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


        }
        public void deleteCart(DataGridView data)
        {
            DialogResult status = MessageBox.Show("Sepeti Boşaltmak üzeresiniz bu işlemden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == status)
            {
                for (int i = 0; i < data.RowCount ; i++)
                {
                    MySqlCommand command2 = new MySqlCommand("update productss set productQuantity=productQuantity+@amount where id=@id", connection);
                    command2.Parameters.AddWithValue("@id", data.Rows[i].Cells["productID"].Value.ToString());
                    command2.Parameters.AddWithValue("@amount", data.Rows[i].Cells["amount"].Value.ToString());
                    connection.Open();
                    command2.ExecuteNonQuery();
                    connection.Close();
                }

                MySqlCommand command = new MySqlCommand("delete from carts", connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Sepet Temizlendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void priceUpdate(DataGridView data, Label lblPrice, Label lblTax)
        {
            double price = 0, tax = 0;
            for (int i = 0; i < data.Rows.Count-1; i++)
            {
                price += double.Parse(data.Rows[i].Cells["totalPrice"].Value.ToString());
                tax += price * 0.18;
            }
            lblPrice.Text = price.ToString();
            lblTax.Text = tax.ToString();
        }

        public void removeCart(DataGridView data)
        {

             MySqlCommand command2 = new MySqlCommand("update productss set productQuantity=productQuantity+@amount where id=@id2", connection);
            command2.Parameters.AddWithValue("@id2", data.CurrentRow.Cells["productID"].Value.ToString());
            command2.Parameters.AddWithValue("@amount", data.CurrentRow.Cells["amount"].Value.ToString());

            MySqlCommand command = new MySqlCommand("delete from carts where id=@id", connection);
            command.Parameters.AddWithValue("@id", data.CurrentRow.Cells["id"].Value.ToString());
            connection.Open();
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void increaseCart(DataGridView data, Label lblamount, Label lblquantity)
        {
            double quantity = 0;
            connection.Open();
            MySqlCommand controlCommand = new MySqlCommand("select productQuantity from productss where id=@id", connection);
            controlCommand.Parameters.AddWithValue("@id", data.CurrentRow.Cells["productID"].Value.ToString());
            MySqlDataReader dr = controlCommand.ExecuteReader();
            if (dr.Read())
            {
                quantity = Convert.ToDouble(dr["productQuantity"]);
                lblquantity.Text = dr["productQuantity"].ToString();

            }
            connection.Close();


            double amount = 0;
            connection.Open();
            MySqlCommand controlCommand2 = new MySqlCommand("select amount from carts where id=@id", connection);
            controlCommand2.Parameters.AddWithValue("@id", data.CurrentRow.Cells["id"].Value.ToString());
            MySqlDataReader dr2 = controlCommand2.ExecuteReader();
            if (dr2.Read())
            {
                amount = Convert.ToDouble(dr2["amount"]);
                lblamount.Text = dr2["amount"].ToString();

            }
            connection.Close();

            if (quantity != 0)
            {
                MySqlCommand command = new MySqlCommand("update carts set amount=amount+1 where id=@id", connection);
                command.Parameters.AddWithValue("@id", data.CurrentRow.Cells["id"].Value.ToString());

                MySqlCommand command2 = new MySqlCommand("update carts set totalPrice=amount*unitPrice where id=@id2", connection);
                command2.Parameters.AddWithValue("@id2", data.CurrentRow.Cells["id"].Value.ToString());

                MySqlCommand command3 = new MySqlCommand("update productss set productQuantity=productQuantity-1 where id=@id3", connection);
                command3.Parameters.AddWithValue("@id3", data.CurrentRow.Cells["productID"].Value.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                connection.Close();
 
            }
            else
            {
                MessageBox.Show("Stokta yeterli miktarda ürün yok.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
            public void decreaseCart(DataGridView data)
        {


            if ( double.Parse(data.CurrentRow.Cells["amount"].Value.ToString()) > 1)
            {
                MySqlCommand command = new MySqlCommand("update carts set amount=amount-1 where id=@id", connection);
                command.Parameters.AddWithValue("@id", data.CurrentRow.Cells["id"].Value.ToString());

                MySqlCommand command2 = new MySqlCommand("update carts set totalPrice=amount*unitPrice where id=@id2", connection);
                command2.Parameters.AddWithValue("@id2", data.CurrentRow.Cells["id"].Value.ToString());

                MySqlCommand command3 = new MySqlCommand("update productss set productQuantity=productQuantity+1 where id=@id3", connection);
                command3.Parameters.AddWithValue("@id3", data.CurrentRow.Cells["ProductID"].Value.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void dropStock(TextBox amount, TextBox productID)
        {
            MySqlCommand command = new MySqlCommand("update productss set productQuantity=productQuantity-@dropAmount where id=@id", connection);
            command.Parameters.AddWithValue("@dropAmount", amount.Text);
            command.Parameters.AddWithValue("@id", productID.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
