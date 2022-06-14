using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data.SQLite;
namespace DoAn
{
    public partial class Reset : Form
    {
        public string userX = string.Empty;
        public string EmailX = string.Empty;
        public string PasswordX = string.Empty;
        private static Random random = new Random();
        public Reset()
        {
            InitializeComponent();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection _con = new SQLiteConnection();
            string _strConnect = "Data Source=MyDatabase.db;Version=3;";
            _con.ConnectionString = _strConnect;
            _con.Open(); // mở kết nối
                         // Tìm xem đã có user trùng tên đăng nhập chưa?
            string FinduserSql = "SELECT * FROM users WHERE username= ?";
            // Thực thi câu lệnh
            SQLiteCommand cmd1 = new SQLiteCommand(FinduserSql, _con);
            cmd1.Parameters.Add("$username", DbType.String).Value = Tuser.Text;
            SQLiteDataReader rdr = cmd1.ExecuteReader();

            if (rdr.HasRows) // có user tồn tại
            {
                while (rdr.Read())
                {
                    userX = rdr.GetString(1);
                    EmailX = rdr.GetString(5);
                }
            }
            if (Tuser.Text != userX)
            {
                label7.Visible = true;
            } else
            {
                PasswordX = RandomString(8);
                string fromText = "admin.carental@gmail.com";
                string toText = EmailX;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromText);
                    mail.To.Add(EmailX);
                    mail.Subject = "Reset Password";
                    mail.Body = "New password for " + userX + "is : " + PasswordX;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;

                        smtp.Credentials = new NetworkCredential("19521848@gm.uit.edu.vn", "1029996133");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        SQLiteConnection _con1 = new SQLiteConnection();
                        string _strConnect1 = "Data Source=MyDatabase.db;Version=3;";
                        _con1.ConnectionString = _strConnect1;
                        _con1.Open(); // mở kết nối
                                      // Tìm xem đã có user trùng tên đăng nhập chưa?
                        string FinduserSql1 = "UPDATE users SET password = ? WHERE username = ?";
                        // Thực thi câu lệnh
                        SQLiteCommand cmd11 = new SQLiteCommand(FinduserSql1, _con1);
                        cmd11.Parameters.Add("$password", DbType.String).Value = PasswordX;
                        cmd11.Parameters.Add("$username", DbType.String).Value = userX;
                        SQLiteDataReader rdr1 = cmd11.ExecuteReader();
                        MessageBox.Show("Reset Password Successed");
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }

            }
        }
    }
}
