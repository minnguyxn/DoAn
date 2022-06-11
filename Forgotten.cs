using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace DoAn
{
    public partial class Forgotten : Form
    {
        public string userX;
        public string pass2X;
        public Forgotten()
        {
            InitializeComponent();
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
                    pass2X = rdr.GetString(6);
                }
            }
            if (Tuser.Text != userX)      // check user có tồn tại không
            {
                label7.Visible = true;
                label6.Visible = false;
                label8.Visible = false;
            } else
            {
                if (pass2.Text != pass2X)    // check pass 2 đúng chưa
                {
                    label7.Visible = false;
                    label6.Visible = false;
                    label8.Visible = true;
                } else
                {
                    if (pass.Text != rpass.Text)   // check re-password
                    {
                        label7.Visible = false;
                        label6.Visible = true;
                        label8.Visible = false;
                    }
                    else
                    {
                        SQLiteConnection _con1 = new SQLiteConnection();
                        string _strConnect1 = "Data Source=MyDatabase.db;Version=3;";
                        _con1.ConnectionString = _strConnect1;
                        _con1.Open(); // mở kết nối
                                     // Tìm xem đã có user trùng tên đăng nhập chưa?
                        string FinduserSql1 = "UPDATE users SET password = ? WHERE username = ?";
                        // Thực thi câu lệnh
                        SQLiteCommand cmd11 = new SQLiteCommand(FinduserSql1, _con1);
                        cmd11.Parameters.Add("$password", DbType.String).Value = pass.Text;
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
