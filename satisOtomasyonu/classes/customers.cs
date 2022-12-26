using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace satisOtomasyonu
{
    class customers
    {
        MySqlConnection connection = new MySqlConnection(database.connection);
        public void addCustomers(TextBox nameSurname, MaskedTextBox phone, TextBox adress, TextBox mail)
        {
            int phoneControl;
            connection.Open();

            MySqlCommand controlUserNameComannd = new MySqlCommand("SELECT COUNT(username) from users where username = @phone", connection);
            controlUserNameComannd.Parameters.AddWithValue("@username", phone);
            phoneControl = int.Parse(controlUserNameComannd.ExecuteScalar().ToString());
            connection.Close();


            int mailControl;
            connection.Open();

            MySqlCommand controlMailComannd = new MySqlCommand("SELECT COUNT(mail) from users where mail = @mail", connection);
            controlMailComannd.Parameters.AddWithValue("@mail", mail);
            mailControl = int.Parse(controlMailComannd.ExecuteScalar().ToString());
            connection.Close();

            if (phoneControl == 0 && mailControl == 0)
            {
                MySqlCommand command = new MySqlCommand("insert into customers (nameSurname, phone, adress, mail) values (@nameSurname, @phone, @adress, @mail)", connection);
                command.Parameters.AddWithValue("@nameSurname", nameSurname.Text);
                command.Parameters.AddWithValue("@phone", phone.Text);
                command.Parameters.AddWithValue("@adress", adress.Text);
                command.Parameters.AddWithValue("@mail", mail.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Yeni Müşteri Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (phoneControl >= 1 && mailControl >= 1)
                {
                    MessageBox.Show("Bu mail adresi ve telefon numarası ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (phoneControl >= 1)
                {
                    MessageBox.Show("Bu telefon numarası ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (mailControl >= 1)
                {
                    MessageBox.Show("Bu mail adresi ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
           
        }

        public void loadCustomers(DataGridView data, Label count)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from customers", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            data.Columns[0].Visible = false;
            data.Columns[1].HeaderText = "Ad Soyad";
            data.Columns[2].HeaderText = "Telefon";
            data.Columns[3].HeaderText = "Adres";
            data.Columns[4].HeaderText = "E-Mail";
            count.Text = "Toplam Kayıt Sayısı:" + (data.Rows.Count);
        }
        public void searchCustomers(DataGridView data, TextBox searchString, Label count)
        {
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM customers WHERE nameSurname LIKE CONCAT(@nameSurname, '%')", connection);
            da.SelectCommand.Parameters.AddWithValue("@nameSurname", searchString.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            count.Text = "Toplam Kayıt Sayısı:" + (data.Rows.Count);
        }

        public void listCustomers(DataGridView data, TextBox nameSurname, MaskedTextBox phone, TextBox adress, TextBox mail)
        {
            nameSurname.Text= data.CurrentRow.Cells[1].Value.ToString();
            phone.Text = data.CurrentRow.Cells[2].Value.ToString();
            adress.Text = data.CurrentRow.Cells[3].Value.ToString();
            mail.Text = data.CurrentRow.Cells[4].Value.ToString();
        }

        public void updateCustomers(DataGridView data, TextBox nameSurname, MaskedTextBox phone, TextBox adress, TextBox mail)
        {
            int selRow = Convert.ToInt32((data.CurrentRow.Cells[0].Value));
            MySqlCommand command = new MySqlCommand("UPDATE customers SET nameSurname = @nameSurname, phone = @phone, adress = @adress, mail = @mail where id = @row", connection);
            command.Parameters.AddWithValue("@nameSurname", nameSurname.Text);
            command.Parameters.AddWithValue("@phone", phone.Text);
            command.Parameters.AddWithValue("@adress", adress.Text);
            command.Parameters.AddWithValue("@mail", mail.Text);
            command.Parameters.AddWithValue("@row", selRow);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Müşteri Başarıyla Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            nameSurname.Text = "";
            phone.Text = "";
            adress.Text = "";
            mail.Text = "";

        }
        public void dropCustomer(DataGridView data)
        {
            
        
                DialogResult status = MessageBox.Show("Seçili Kayıtı Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == status)
                {
                    int selRow = Convert.ToInt32((data.CurrentRow.Cells[0].Value));
                    MySqlCommand command = new MySqlCommand("delete from customers where id = @srow", connection);
                    command.Parameters.AddWithValue("@srow", selRow);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Müşteri Başarıyla Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
    }
}
