using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
namespace satisOtomasyonu.classes
{
    class lostPassword
    {
        MySqlConnection connection = new MySqlConnection(database.connection);
        private object code;

        public void Send(string to, string subject, string yourMail, string pass)
        {
            int result = 0;
            string uid = "";
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from users where mail=@mail", connection);
            command.Parameters.AddWithValue("@mail", to);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())    
            {
            uid = dr["id"].ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(yourMail, pass);


            using (var message = new MailMessage(yourMail, to))
            {
                try
                {
                        Random rnd = new Random();
                         code = rnd.Next(100000, 1000000);
                        string scode = "Şifre Sıfırlama Kodunuz: <h2>" + code.ToString() + "</h2>";
                        message.Subject = subject;
                    message.Body = scode;
                   
                    message.IsBodyHtml = true;
                    smtp.Send(message);

                    MessageBox.Show("Şifre Sıfırlama Kodunuz Gönderildi.");
                    result = 1;
                        
                }
                catch (Exception ext)
                {
                    MessageBox.Show("Şifre Sıfırlama Kodunuz Gönderilemedi.", ext.ToString());

                }
            }


            }
            else
            {
                MessageBox.Show("Hatalı Mail Adresi.");
            }
            connection.Close();


            if (result == 1)
            {
                int result2 = 0;
                MySqlCommand command3 = new MySqlCommand("select * from lostpassword where userID=@uid", connection);
                command3.Parameters.AddWithValue("@uid", Convert.ToInt32(uid));
                connection.Open();
                MySqlDataReader dr2 = command3.ExecuteReader();
                if (dr2.Read())
                {
                    result2 = 1;
                }

                connection.Close();
                if (result2 == 1) 
                {
                    MySqlCommand command4 = new MySqlCommand("delete from lostpassword where userID = @uid", connection);
                    command4.Parameters.AddWithValue("@uid", uid);
                    connection.Open();
                    command4.ExecuteNonQuery();
                    connection.Close();
                }
                MySqlCommand command2 = new MySqlCommand("insert into lostpassword (code, userID) values (@code, @uID)", connection);
                command2.Parameters.AddWithValue("@code", code);
                command2.Parameters.AddWithValue("@uID", Convert.ToInt32(uid));
                connection.Open();
                command2.ExecuteNonQuery();
                connection.Close();
                Form.ActiveForm.Visible = false;
                forms.frmPasswordCode passwordCode = new forms.frmPasswordCode();
                passwordCode.Show();
            }

        }
        

        public void codeEnter(TextBox code, TextBox password)
        {
            
           
            MySqlCommand command = new MySqlCommand("select * from lostpassword where code=@code", connection);
            command.Parameters.AddWithValue("@code", code.Text);
            connection.Open();
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            { 
                Form.ActiveForm.Visible = false;
            }
            else
            {
                MessageBox.Show("Hatalı Kod");
            }
            connection.Close();
        }

        public void updatePassword(TextBox password, TextBox code)
        {
            int result = 0;
            string uid = "";
            MySqlCommand command3 = new MySqlCommand("select * from lostpassword where code=@code", connection);
            command3.Parameters.AddWithValue("@code", code.Text);
            connection.Open();
            MySqlDataReader dr = command3.ExecuteReader();
            if (dr.Read())
            {
                uid = dr["userID"].ToString();
                result = 1;
            }
            else
            {
                MessageBox.Show("Hatalı Kod");
            }
            connection.Close();
            if (result == 1)
            {
                Cryptology cryptology = new Cryptology();
                string encryptedText = cryptology.Encryption(password.Text);
                MySqlCommand command = new MySqlCommand("UPDATE users SET password = @password where id = @id", connection);
                command.Parameters.AddWithValue("@password", encryptedText);
                command.Parameters.AddWithValue("@id", uid);

                MySqlCommand command2 = new MySqlCommand("delete from lostpassword where userID = @uid", connection);
                command2.Parameters.AddWithValue("@uid", uid);

                connection.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Şifreniz Değiştirildi.");
                Form.ActiveForm.Visible = false;

            }

        }
    }
}
