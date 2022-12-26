using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace satisOtomasyonu.classes
{
    class users
    {
        MySqlConnection connection = new MySqlConnection(database.connection);


        public void userLogin(TextBox usernameTxt, TextBox passTxt, Form homepageGet)
        {
            if (usernameTxt.Text=="" || passTxt.Text=="")
            {
  
                MessageBox.Show("Kullanıcı adı ve/veya Şifre Boş Bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Cryptology cryptology = new Cryptology();
                string encryptedText = cryptology.Encryption(passTxt.Text);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from users where username='" + usernameTxt.Text + "'and password='" + encryptedText + "'", connection);
               MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    frmHomepage homepage = new frmHomepage();
                    homepage.rank = Convert.ToInt32((dr["rank"]));
     
                    frmLogin.ActiveForm.Visible = false;
                    homepage.Show();
                    
                    
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız.");
                }
                connection.Close();
            }


        }

        public void newUser(string name, string surname, string username, string password, string rePassword, string mail, string phone, string rank)
        {
            
            int uNameControl = 0;
            connection.Open();

            MySqlCommand controlUserNameComannd = new MySqlCommand("SELECT COUNT(username) from users where username = @username", connection);
            controlUserNameComannd.Parameters.AddWithValue("@username", username);
            uNameControl = int.Parse(controlUserNameComannd.ExecuteScalar().ToString());
            connection.Close();

            int mailControl = 0;
            connection.Open();

            MySqlCommand controlMailComannd = new MySqlCommand("SELECT COUNT(mail) from users where mail = @mail", connection);
            controlMailComannd.Parameters.AddWithValue("@mail", mail);
            mailControl = int.Parse(controlMailComannd.ExecuteScalar().ToString());
            connection.Close();

            int phoneControl = 0;
            connection.Open();

            MySqlCommand controlPhoneComannd = new MySqlCommand("SELECT COUNT(phone) from users where phone = @phone", connection);
            controlPhoneComannd.Parameters.AddWithValue("@phone", phone);
            phoneControl = int.Parse(controlPhoneComannd.ExecuteScalar().ToString());
            connection.Close();

            if (uNameControl == 0 && mailControl == 0 && phoneControl == 0) { 
            Cryptology cryptology = new Cryptology();
            string encryptedText = cryptology.Encryption(password);
            MySqlCommand command = new MySqlCommand("insert into users (name, surname, username, password, mail, phone, rank) values (@name, @surname, @username, @password, @mail, @phone, @rank)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", encryptedText);
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@rank", rank);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yeni Kullanıcı Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (uNameControl >= 1 && mailControl >= 1 && phoneControl >= 1)
                {
                    MessageBox.Show("Bu mail adresi, telefon numarası ve kullanıcı adı ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    
                }

                if (uNameControl >= 1 && mailControl >= 1)
                {
                    MessageBox.Show("Bu mail adresi ve kullanıcı adı ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (uNameControl >= 1 && phoneControl >= 1)
                {
                    MessageBox.Show("Bu telefon numarası ve kullanıcı adı ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (phoneControl >= 1 && mailControl >= 1)
                {
                    MessageBox.Show("Bu telefon numarası ve mail adresi ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (mailControl >= 1)
                {
                    MessageBox.Show("Bu mail adresi ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (uNameControl >= 1)
                {
                    MessageBox.Show("Bu kullanıcı adı ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (phoneControl >= 1)
                {
                    MessageBox.Show("Bu telefon numarası ile kayıt oluşturulmuş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        public void loadUsers(DataGridView data, ListBox listPass, Label count)
        {
            listPass.Items.Clear();
            Cryptology cryptology = new Cryptology();
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select id, name, surname, username, password, mail, phone, rank from users", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            data.Columns[0].Visible = false;
            data.Columns[1].HeaderText = "Ad";
            data.Columns[2].HeaderText = "Soyad";
            data.Columns[3].HeaderText = "Kullanıcı Adı";
            data.Columns[4].HeaderText = "Şifre";
            data.Columns[5].HeaderText = "E-Mail";
            data.Columns[6].HeaderText = "Telefon Numarası";
            data.Columns[7].HeaderText = "Pozisyon";
            connection.Open();
            MySqlCommand command = new MySqlCommand("Select password from users", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                   
                string decryptedText = "";
                decryptedText = cryptology.Encryption(reader.GetString("password"));
                listPass.Items.Add(decryptedText);
                

            }
            connection.Close();
            for (int i = 0; i < listPass.Items.Count; i++)
            {
                data.Rows[i].Cells[4].Value = listPass.Items[i];
            }
            count.Text = "Toplam Kayıt Sayısı:" + (data.Rows.Count);
        }

        public void searchUsers(DataGridView data, TextBox searchString, ListBox listPass, Label count, TextBox name, TextBox surname, TextBox username, TextBox password, TextBox mail, TextBox phone, TextBox rank)
        {
            listPass.Items.Clear();
            Cryptology cryptology = new Cryptology();
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM users WHERE name LIKE CONCAT(@name, '%')", connection);
            da.SelectCommand.Parameters.AddWithValue("@name", searchString.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.DataSource = dt;
            connection.Close();
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name LIKE CONCAT(@name, '%')", connection);
            command.Parameters.AddWithValue("@name", searchString.Text);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string decryptedText = "";
                decryptedText = cryptology.Decrypt(reader.GetString("password"));
                listPass.Items.Add(decryptedText);

            }
            connection.Close();
            for (int i = 0; i < listPass.Items.Count; i++)
            {
                data.Rows[i].Cells[4].Value = listPass.Items[i];
            }
            count.Text = "Toplam Kayıt Sayısı:" + (data.Rows.Count);
            if (data.Rows.Count != 0)
            {
                name.Text = data.CurrentRow.Cells[1].Value.ToString();
                surname.Text = data.CurrentRow.Cells[2].Value.ToString();
                username.Text = data.CurrentRow.Cells[3].Value.ToString();
                password.Text = data.CurrentRow.Cells[4].Value.ToString();
                mail.Text = data.CurrentRow.Cells[5].Value.ToString();
                phone.Text = data.CurrentRow.Cells[6].Value.ToString();
                rank.Text = data.CurrentRow.Cells[7].Value.ToString();
            }


        }

        public void listSelectedUser(DataGridView data, TextBox name, TextBox surname, TextBox username, TextBox password, TextBox mail, TextBox phone, TextBox rank)
        {
            
            name.Text = data.CurrentRow.Cells[1].Value.ToString();
            surname.Text = data.CurrentRow.Cells[2].Value.ToString();
            username.Text = data.CurrentRow.Cells[3].Value.ToString();
            password.Text = data.CurrentRow.Cells[4].Value.ToString();
            mail.Text = data.CurrentRow.Cells[5].Value.ToString();
            phone.Text = data.CurrentRow.Cells[6].Value.ToString();
            rank.Text = data.CurrentRow.Cells[7].Value.ToString();
        }

        public void updateUser(DataGridView data, TextBox name, TextBox surname, TextBox username, TextBox password, TextBox mail, TextBox phone, TextBox rank)
        {
            int selRow = Convert.ToInt32((data.CurrentRow.Cells[0].Value));
            Cryptology cryptology = new Cryptology();
            MySqlCommand command = new MySqlCommand("UPDATE users SET name = @name, surname = @surname, username = @username, password = @password, mail = @mail, phone = @phone, rank = @rank where id = @row", connection);
            command.Parameters.AddWithValue("@name", name.Text);
            command.Parameters.AddWithValue("@surname", surname.Text);
            command.Parameters.AddWithValue("@username", username.Text);
            string encryptedText = "";
            encryptedText = cryptology.Encryption(password.Text);
            command.Parameters.AddWithValue("@password", encryptedText);
            command.Parameters.AddWithValue("@mail", mail.Text);
            command.Parameters.AddWithValue("@phone", phone.Text);
            command.Parameters.AddWithValue("@rank", rank.Text);
            command.Parameters.AddWithValue("@row", selRow);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kullanıcı Başarıyla Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            name.Text = "";
            surname.Text = "";
            username.Text = "";
            password.Text = "";
            mail.Text = "";
            phone.Text = "";
            rank.Text = "";

        }

        public void dropUser(DataGridView data)
        {
            DialogResult status = MessageBox.Show("Seçili Kayıtı Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == status)
            {
                int selRow = Convert.ToInt32((data.CurrentRow.Cells[0].Value));
                MySqlCommand command = new MySqlCommand("delete from users where id = @srow", connection);
                command.Parameters.AddWithValue("@srow", selRow);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ürün Başarıyla Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }



    }
    }
    

