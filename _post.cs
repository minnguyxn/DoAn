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
using System.IO;
namespace DoAn
{
    public partial class _post : UserControl
    {
       string _id = string.Empty;
        string curuser = string.Empty;
        private string path = Directory.GetCurrentDirectory();
        public _post(string typerender,string a, string b, string c, string idpost, string _curuser,string price,string avatar,
            string content,string createdate,string status, string createduser)
        {
            //_id = a;
            InitializeComponent();
            label1.Text = a;
            label2.Text = b;
            label3.Text = c;
            label4.Text = price;
            label5.Text = createdate;
            richTextBox1.Text = content;
            bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path + "\\source_csharp\\" + avatar)));
            pictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path + "\\source_csharp\\" + idpost + ".jpg")));
            _id = idpost;
            curuser = _curuser;
            bunifuButton2.Text = status == "available" ? "Available" : status == "pending" ? "pending" : "rented";
            bunifuButton2.Enabled = status == "available";
            bunifuButton2.BackColor = status == "available" ? Color.Blue : status == "pending" ? Color.Yellow : Color.Green;

            bunifuButton1.Visible = _curuser == createduser;
            bunifuButton3.Visible = _curuser == createduser;
            if (typerender == "renderall")
            {
                bunifuButton1.Visible = false;
                bunifuButton3.Visible = false;
            }    

            load_comments();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void load_comments()
        {
            flowLayoutPanel1.Controls.Clear();
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = "SELECT * FROM comments JOIN users ON comments.iduser = users.username WHERE idpost = ?";

                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$idpost", DbType.String).Value = _id;
                //cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                DataTable dtt = new DataTable();
                SQLiteDataAdapter rdr = new SQLiteDataAdapter(cmd);
                rdr.Fill(dtt);
                foreach (DataRow dr in dtt.Rows)
                {
                    string fullname = dr["fullname"].ToString();
                    string phone = string.Empty;
                    string email = string.Empty;
                    string adress = string.Empty;
                    string avatar = dr["avatar"].ToString();


                    comment cmt = new comment(fullname,avatar,dr["comment"].ToString());
                    flowLayoutPanel1.Controls.Add(cmt);

                }

                _con.Close();
            }
            //for (int i = 0; i <= 5; i++)
            //{
            //    _post post = new _post();

            //    flowLayoutPanel1.Controls.Add(post);
            //}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            string cmt = cmt_textbox.Text;
            string id_cmt = Guid.NewGuid().ToString();
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = @"INSERT INTO comments (id,idpost, iduser, comment) values ($id,$idpost, $iduser, $comment)";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$id", DbType.String).Value = id_cmt;
                cmd.Parameters.Add("$idpost", DbType.String).Value = _id;
                cmd.Parameters.Add("$iduser", DbType.String).Value = curuser;
                cmd.Parameters.Add("$comment", DbType.String).Value = cmt;
                cmd.ExecuteNonQuery();

                _con.Close();

                load_comments();
            }
        }

        private void Thuebai()
        {
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = @"UPDATE posts SET status = 'pending', star = ? WHERE id = ? ";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$star", DbType.String).Value = curuser;
                cmd.Parameters.Add("id", DbType.String).Value = _id;

                cmd.ExecuteNonQuery();
                _con.Close();
                MessageBox.Show("Rental request successfully");
            }
        }
        private void Duyetbai()
        {
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = @"UPDATE posts SET status = 'rented'  WHERE id = ? ";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("id", DbType.String).Value = _id;

                //cmd.Parameters.Add("$star", DbType.String).Value = curuser;
                cmd.ExecuteNonQuery();
                _con.Close();
                MessageBox.Show("Cho thuê thành công");

            }
        }

        private void Khongduyet()
        {
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = @"UPDATE posts SET status = 'available', star = 'null WHERE id = ? ";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("id", DbType.String).Value = _id;

                //cmd.Parameters.Add("$star", DbType.String).Value = curuser;
                cmd.ExecuteNonQuery();
                _con.Close();
                MessageBox.Show("Rental request was cancel");

            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Duyetbai();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Thuebai();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Khongduyet();
        }
    }
}
