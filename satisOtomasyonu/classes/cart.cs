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
                productTax.Text = "";
            }
        }
        public void calcPrice(TextBox productQuantity, TextBox unitPrice, TextBox totalPrice)
        {
            if (!string.IsNullOrWhiteSpace(productQuantity.Text) && !string.IsNullOrWhiteSpace(unitPrice.Text)) 
            {
                double quantity = double.Parse(productQuantity.Text);
                double unit = double.Parse(unitPrice.Text);
                double price = quantity * unit;
                totalPrice.Text = price.ToString();
            }



        }

        public void listCart(DataGridView data, Label count)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from carts", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            data.Columns[4].HeaderText = "Müşteri ID";
            data.Columns[5].HeaderText = "Adı Soyadı";
            data.Columns[6].HeaderText = "Telefon";
            data.Columns[7].HeaderText = "Ürün ID";
            data.Columns[8].HeaderText = "Ürün İsmi";
            data.Columns[9].HeaderText = "Ürün Tipi";
            data.Columns[10].HeaderText = "Birim Fiyatı";
            data.Columns[11].HeaderText = "Miktarı";
            data.Columns[12].HeaderText = "Toplam Tutar";
            data.Columns[13].HeaderText = "Vergi";
            count.Text = "Sepetteki Ürün Sayısı: " + data.Rows.Count.ToString();
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
                MySqlCommand command = new MySqlCommand("INSERT INTO carts (customerID, nameSurname, phone, productID, productName, productType, unitPrice, amount, totalPrice, tax) values (@customerID, @nameSurname, @phone, @productID, @productName, @productType, @unitPrice, @amount, @totalPrice, @tax)", connection);
                command.Parameters.AddWithValue("@customerID", customerID.Text);
                command.Parameters.AddWithValue("@nameSurname", customerNameSurname.Text);
                command.Parameters.AddWithValue("@phone", customerPhone.Text);
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
            for (int i = 0; i < data.Rows.Count; i++)
            {
                price += double.Parse(data.Rows[i].Cells["totalPrice"].Value.ToString());
            }
            tax += price * 0.18;
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

        public void increaseCart(DataGridView data)
        {
            double quantity = 0;
            connection.Open();
            MySqlCommand controlCommand = new MySqlCommand("select productQuantity from productss where id=@id", connection);
            controlCommand.Parameters.AddWithValue("@id", data.CurrentRow.Cells["productID"].Value.ToString());
            MySqlDataReader dr = controlCommand.ExecuteReader();
            if (dr.Read())
            {
                quantity = Convert.ToDouble(dr["productQuantity"]);

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

        public void makeSale(DataGridView data)
        {
            for (int i = 0; i < data.RowCount; i++)
            {
                
                MySqlCommand command = new MySqlCommand("insert into sales (customerID, customerNameSurname, customerPhone, productID, productName, productType, unitPrice, amount, totalPrice, tax, CartID) values (@customerID, @customerNameSurname, @customerphone, @productID, @productName, @productType, @unitPrice, @amount, @totalPrice, @tax, @CartID)", connection);
                MySqlCommand command2 = new MySqlCommand("delete from carts", connection);
                command.Parameters.AddWithValue("@customerID", data.Rows[i].Cells["customerID"].Value.ToString());
                command.Parameters.AddWithValue("@customerNameSurname", data.Rows[i].Cells["nameSurname"].Value.ToString());
                command.Parameters.AddWithValue("@customerPhone", data.Rows[i].Cells["phone"].Value.ToString());
                command.Parameters.AddWithValue("@productID", data.Rows[i].Cells["productID"].Value.ToString());
                command.Parameters.AddWithValue("@productName", data.Rows[i].Cells["productName"].Value.ToString());
                command.Parameters.AddWithValue("@productType", data.Rows[i].Cells["productType"].Value.ToString());
                command.Parameters.AddWithValue("@unitPrice", data.Rows[i].Cells["unitPrice"].Value.ToString());
                command.Parameters.AddWithValue("@amount", data.Rows[i].Cells["amount"].Value.ToString());
                command.Parameters.AddWithValue("@totalPrice", data.Rows[i].Cells["totalPrice"].Value.ToString());
                command.Parameters.AddWithValue("@tax", data.Rows[i].Cells["tax"].Value.ToString());
                command.Parameters.AddWithValue("@CartID", data.Rows[i].Cells["id"].Value.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connection.Close();
                
            }
        }

        public void productReturnSearch(TextBox searchString, TextBox productType, TextBox productName, TextBox productID, NumericUpDown productAmount, TextBox customerNameSurname, TextBox customerPhone, TextBox salesID, TextBox salesAmount)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from sales where id LIKE CONCAT(@id, '%')", connection);
            command.Parameters.AddWithValue("@id", searchString.Text);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                salesID.Text = dr["id"].ToString();
                productType.Text = dr["productType"].ToString();
                productName.Text = dr["productName"].ToString();
                productID.Text = dr["productID"].ToString();
                salesAmount.Text = dr["amount"].ToString();
                productAmount.Value = 0;
                customerNameSurname.Text = dr["customerNameSurname"].ToString();
                customerPhone.Text = dr["customerPhone"].ToString();


            }
            connection.Close();


            if (string.IsNullOrWhiteSpace(searchString.Text))
            {
                salesID.Text = "";
                productType.Text = "";
                productName.Text = "";
                productID.Text = "";
                productAmount.Text = "";
                customerNameSurname.Text = "";
                customerPhone.Text = "";
            }

        }
        public void productReturn (TextBox salesID, NumericUpDown productAmount, TextBox productID)
        {
            double amount = 0;
            string description = "";
            connection.Open();
            MySqlCommand command = new MySqlCommand("select amount, description from sales where id = @id", connection);
            command.Parameters.AddWithValue("@id", salesID.Text);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                amount = Convert.ToDouble(dr["amount"].ToString());
                description = dr["description"].ToString();
            }
            connection.Close();
            if (Convert.ToDouble(productAmount.Value) <= amount)
            {
                MySqlCommand command2 = new MySqlCommand("update productss set productQuantity=productQuantity+@amount where id=@id1", connection);
                command2.Parameters.AddWithValue("@id1", productID.Text);
                command2.Parameters.AddWithValue("@amount", productAmount.Text);

                MySqlCommand command3 = new MySqlCommand("update sales set amount = amount-@amount where id=@id2", connection);
                command3.Parameters.AddWithValue("@id2", salesID.Text);
                command3.Parameters.AddWithValue("@amount", productAmount.Text);

                MySqlCommand command4 = new MySqlCommand("update sales set totalPrice=unitPrice*amount where id=@id3", connection);
                command4.Parameters.AddWithValue("@id3", salesID.Text);



                string description2 = description +"   " + productAmount.Value.ToString() + " adet ürün iadesi gerçekleştirildi." + DateTime.Now.ToString();
                MySqlCommand command5 = new MySqlCommand("UPDATE sales SET description = @text WHERE id = @id4", connection);
                command5.Parameters.AddWithValue("@id4", salesID.Text);
                command5.Parameters.AddWithValue("@text",description2);

                connection.Open();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
                command5.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Ürün İadesi Gerçekleştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Satılandan Fazla Ürün İade Edemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
