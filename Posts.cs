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
    public partial class main_posts : Form
    {
        private string curuser = string.Empty;
        public main_posts(Size e,string _curuser,string type)
        {
            InitializeComponent();
            panel3.Size = e;
            curuser = _curuser;
            if (type == "mypost")
            {
                Mypost();
            }
            else if (type == "rentedpost")
            {
                load_rented_posts();
            }
            else
            {
                load_posts();
            }
        }

        private void Posts_Load(object sender, EventArgs e)
        {

        }

        public void load_posts()
        {
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = "SELECT * FROM posts JOIN users ON posts.createduser = users.username";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                //cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                DataTable dtt = new DataTable();
                SQLiteDataAdapter rdr = new SQLiteDataAdapter(cmd);
                rdr.Fill(dtt);
                foreach(DataRow dr in dtt.Rows)
                {
                    string fullname = dr["fullname"].ToString();//string.Empty;
                    string phone = dr["phone"].ToString();
                    string email = dr["email"].ToString();
                    string price = dr["price"].ToString();
                    string avatar = dr["avatar"].ToString();
                    string content = dr["content"].ToString();
                    string createdate = dr["createdate"].ToString();
                    string createduser = dr["createduser"].ToString();

                    string status = dr["status"].ToString();
                    string adress = string.Empty; 
                  
                    //string InsertSql1 = "SELECT * FROM users WHERE username= ?";
                    // Thực thi câu lệnh
                    //SQLiteCommand cmd1 = new SQLiteCommand(InsertSql1, _con);
                    //cmd.Parameters.Add("$username", DbType.String).Value = dr["createduser"];
                    //SQLiteDataReader rdr1 = cmd.ExecuteReader();
                    //while (rdr1.Read())
                    //{
                    //    fullname = rdr1.GetString(3);
                    //    adress = rdr1.GetString(8);
                    //    phone = rdr1.GetString(9);
                    //    email = rdr1.GetString(5);
                    //}
                    //rdr1.Close();
                    _post post = new _post("renderall",fullname, phone, email,dr["id"].ToString(),curuser,price,avatar,content,createdate, status, createduser);
                    flowLayoutPanel1.Controls.Add(post);

                }
                
                _con.Close();
            }
            //for (int i = 0; i <= 5; i++)
            //{
            //    _post post = new _post();

            //    flowLayoutPanel1.Controls.Add(post);
            //}
        }


        public void load_rented_posts()
        {
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = "SELECT * FROM posts JOIN users ON posts.createduser = users.username WHERE star = ?";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$star", DbType.String).Value = curuser;
                DataTable dtt = new DataTable();
                SQLiteDataAdapter rdr = new SQLiteDataAdapter(cmd);
                rdr.Fill(dtt);
                foreach (DataRow dr in dtt.Rows)
                {
                    string fullname = dr["fullname"].ToString();//string.Empty;
                    string phone = dr["phone"].ToString();
                    string email = dr["email"].ToString();
                    string price = dr["price"].ToString();
                    string avatar = dr["avatar"].ToString();
                    string content = dr["content"].ToString();
                    string createdate = dr["createdate"].ToString();
                    string createduser = dr["createduser"].ToString();

                    string status = dr["status"].ToString();
                    string adress = string.Empty;

                    //string InsertSql1 = "SELECT * FROM users WHERE username= ?";
                    // Thực thi câu lệnh
                    //SQLiteCommand cmd1 = new SQLiteCommand(InsertSql1, _con);
                    //cmd.Parameters.Add("$username", DbType.String).Value = dr["createduser"];
                    //SQLiteDataReader rdr1 = cmd.ExecuteReader();
                    //while (rdr1.Read())
                    //{
                    //    fullname = rdr1.GetString(3);
                    //    adress = rdr1.GetString(8);
                    //    phone = rdr1.GetString(9);
                    //    email = rdr1.GetString(5);
                    //}
                    //rdr1.Close();
                    _post post = new _post("renderall", fullname, phone, email, dr["id"].ToString(), curuser, price, avatar, content, createdate, status, createduser);
                    flowLayoutPanel1.Controls.Add(post);

                }

                _con.Close();
            }
            //for (int i = 0; i <= 5; i++)
            //{
            //    _post post = new _post();

            //    flowLayoutPanel1.Controls.Add(post);
            //}
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
  
        private void Mypost()
        {
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = "SELECT * FROM posts JOIN users ON posts.createduser = users.username where posts.createduser = ? ";

                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$createduser", DbType.String).Value = curuser;
                DataTable dtt = new DataTable();
                SQLiteDataAdapter rdr = new SQLiteDataAdapter(cmd);
                rdr.Fill(dtt);
                foreach (DataRow dr in dtt.Rows)
                {
                    string fullname = dr["fullname"].ToString();//string.Empty;
                    string phone = dr["phone"].ToString();
                    string email = dr["email"].ToString();
                    string price = dr["price"].ToString();
                    string avatar = dr["avatar"].ToString();
                    string content = dr["content"].ToString();
                    string createdate = dr["createdate"].ToString();
                    string createduser = dr["createduser"].ToString();
                    string status = dr["status"].ToString();
                    string adress = string.Empty;

                    //string InsertSql1 = "SELECT * FROM users WHERE username= ?";
                    // Thực thi câu lệnh
                    //SQLiteCommand cmd1 = new SQLiteCommand(InsertSql1, _con);
                    //cmd.Parameters.Add("$username", DbType.String).Value = dr["createduser"];
                    //SQLiteDataReader rdr1 = cmd.ExecuteReader();
                    //while (rdr1.Read())
                    //{
                    //    fullname = rdr1.GetString(3);
                    //    adress = rdr1.GetString(8);
                    //    phone = rdr1.GetString(9);
                    //    email = rdr1.GetString(5);
                    //}
                    //rdr1.Close();
                    _post post = new _post("rendermypost",fullname, phone, email, dr["id"].ToString(), curuser, price, avatar, content, createdate, status, createduser);
                    flowLayoutPanel1.Controls.Add(post);

                }

                _con.Close();
            }
        }
    }
}
