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

        
        string name;    
        string surname;
        string phone;
        string username;
        string password;
        string mail;
        string image;
        string rank;

        public string Name
        { get
            { return name; }
            set
            { name = value; }
        }
        public string Surname { get => surname; set => surname = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Image { get => image; set => image = value; }
        public string Rank { get => rank; set => rank = value; }

        public void userLogin(TextBox usernameTxt, TextBox passTxt)
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
                    frmLogin.ActiveForm.Visible = false;
                    frmHomepage homepage = new frmHomepage();
                    homepage.Show();
                    
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız.");
                }
                connection.Close();
            }


        }

        public void newUser(string _name, string _surname, string _username, string _password, string _rePassword, string _mail, string _phone, string _rank, string _image)
        {

            name = _name;
            surname = _surname;
            username = _username;
            password = _password;
            mail = _mail;
            phone = _phone;
            rank = _rank;
            image = _image;
            Cryptology cryptology = new Cryptology();
            string encryptedText = cryptology.Encryption(_password);
            //MySqlCommand command = new MySqlCommand("insert into users (name, surname, username, password, mail, phone, rank, image) values (" + @name + ",'" + @surname + "','" + @username + "','" + @encryptedText + "','" + @mail + "','" + @phone + "','" + @rank + "','" + @image + "')", connection);
            MySqlCommand command = new MySqlCommand("insert into users (name, surname, username, password, mail, phone, rank, image) values (@name, @surname, @username, @password, @mail, @phone, @rank, @image)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", encryptedText);
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@rank", rank);
            command.Parameters.AddWithValue("@image", image);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yeni Kullanıcı Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void listUsers(DataGridView data, ListBox listPass)
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
                decryptedText = cryptology.Decrypt(reader.GetString("password"));
                listPass.Items.Add(decryptedText);
                

            }
            connection.Close();
            for (int i = 0; i < listPass.Items.Count; i++)
            {
                data.Rows[i].Cells[4].Value = listPass.Items[i];
            }
        }

        public void searchUsers(DataGridView data, TextBox searchString, ListBox listPass)
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
            data.Columns[0].Visible = false;
            data.Columns[1].HeaderText = "Ad";
            data.Columns[2].HeaderText = "Soyad";
            data.Columns[3].HeaderText = "Kullanıcı Adı";
            data.Columns[4].HeaderText = "Şifre";
            data.Columns[5].HeaderText = "E-Mail";
            data.Columns[6].HeaderText = "Telefon Numarası";
            data.Columns[7].HeaderText = "Pozisyon";
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
        }
    }
    }
    

