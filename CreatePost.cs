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
    public partial class CreatePost : Form
    {
        private string curuser;
        private string postid;
        private string img_filename;
        public string path;
        public CreatePost(string cuser)
        {
            InitializeComponent();
            curuser = cuser;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            string path_ = Directory.GetCurrentDirectory() + "\\source_csharp\\";
            string filename = "";
            string IDOfPost = Guid.NewGuid().ToString();
            postid = IDOfPost;
            if (x.ShowDialog() == DialogResult.OK)
            {
                path = x.FileName;
                post_img.Image = (Image)(new Bitmap(Image.FromFile(path)));
                File.Copy(x.FileName, Path.Combine(path_, IDOfPost + Path.GetExtension(x.FileName)), true);
                filename = postid + Path.GetExtension(x.FileName);

            }
            img_filename = filename;

        //    string IDofCurentUser = "";

        //    SQLiteConnection _con = new SQLiteConnection();
        //    string _strConnect = "Data Source=MyDatabase.db;Version=3;";
        //    _con.ConnectionString = _strConnect;
        //    _con.Open();
        //    string querySql = "SELECT * FROM users WHERE username= ?";
        //    // Thực thi câu lệnh
        //    SQLiteCommand cmd = new SQLiteCommand(querySql, _con);
        //    cmd.Parameters.Add("$username", DbType.String).Value = curuser;
        //    SQLiteDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        IDofCurentUser = rdr.GetString(0);
        //        //bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path + "//source_cscharp//" + rdr.GetString(7))));
        //    }

        //    string NameOfPost = post_name.Text;
        //    string ContentOfPost = post_content.Text;
        //    string DesOfPost = post_description.Text;
        //    string TypecarOfPost = post_typecar.Text;
        //    string PriceOfPost = post_price.Text;
        //    string CreatedDateOfPost = DateTime.Now.ToString();
        //    string CreatedUserOfPost = IDofCurentUser;
        //    string commentsOfPost = "test";
        //    string LocationOfPost = post_location.Text;
        //    string StatusOfPost = "available";
        //    string NumberLikeOfPost = "0";
        //    string StarOfPost = "0";

        //    string InsertSql = @"INSERT INTO posts (id,name, content, description, typecar, price, createdate, createduser, comments, location, status, numberliked, star) values ($id,$name, $content, $description, $typecar, $price, $createdate, $createduser, $comments, $location, $status, $numberliked, $star)";
        //    // Thực thi câu lệnh
        //    SQLiteCommand Icmd = new SQLiteCommand(InsertSql, _con);
        //    cmd.Parameters.Add("$id", DbType.String).Value = IDOfPost;
        //    cmd.Parameters.Add("$name", DbType.String).Value = NameOfPost;
        //    cmd.Parameters.Add("$content", DbType.String).Value = ContentOfPost;
        //    cmd.Parameters.Add("$description", DbType.String).Value = DesOfPost;
        //    cmd.Parameters.Add("$typecar", DbType.String).Value = TypecarOfPost;
        //    cmd.Parameters.Add("$price", DbType.String).Value = PriceOfPost;
        //    cmd.Parameters.Add("$createdate", DbType.String).Value = CreatedDateOfPost;
        //    cmd.Parameters.Add("$createduser", DbType.String).Value = CreatedUserOfPost;
        //    cmd.Parameters.Add("$comments", DbType.String).Value = commentsOfPost;
        //    cmd.Parameters.Add("$location", DbType.String).Value = LocationOfPost;
        //    cmd.Parameters.Add("$status", DbType.String).Value = StatusOfPost;
        //    cmd.Parameters.Add("$numberliked", DbType.String).Value = NumberLikeOfPost;
        //    cmd.Parameters.Add("$star", DbType.String).Value = StarOfPost;


        //    Icmd.ExecuteNonQuery();

        //    MessageBox.Show("Create post Successed");
           

        //    _con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string IDofCurentUser = "";

            //SQLiteConnection _con = new SQLiteConnection();
            //string _strConnect = "Data Source=MyDatabase.db;Version=3;";
            //_con.ConnectionString = _strConnect;
            //_con.Open();
            //string querySql = "SELECT * FROM users WHERE username= ?";
            //// Thực thi câu lệnh
            //SQLiteCommand cmd = new SQLiteCommand(querySql, _con);
            //cmd.Parameters.Add("$username", DbType.String).Value = curuser;
            //SQLiteDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    IDofCurentUser = rdr.GetString(0);
            //    //bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path + "//source_cscharp//" + rdr.GetString(7))));
            //}
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                _con.Open();

                string NameOfPost = post_name.Text;
                string ContentOfPost = post_content.Text;
                string DesOfPost = post_description.Text;
                string TypecarOfPost = post_typecar.Text;
                string PriceOfPost = post_price.Text;
                string CreatedDateOfPost = DateTime.Now.ToString();
                string CreatedUserOfPost = curuser;
                string commentsOfPost = "test";
                string LocationOfPost = post_location.Text;
                string StatusOfPost = "available";
                string NumberLikeOfPost = "0";
                string StarOfPost = "0";

                string InsertSql = @"INSERT INTO posts (id,name, content, description, typecar, price, createdate, createduser, comments, location, status, numberliked, star) values ($id,$name, $content, $description, $typecar, $price, $createdate, $createduser, $comments, $location, $status, $numberliked, $star)";
                // Thực thi câu lệnh
                using (SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con))
                {

                    //SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                    cmd.Parameters.Add("$id", DbType.String).Value = postid;
                    cmd.Parameters.Add("$name", DbType.String).Value = NameOfPost;
                    cmd.Parameters.Add("$content", DbType.String).Value = ContentOfPost;
                    cmd.Parameters.Add("$description", DbType.String).Value = DesOfPost;
                    cmd.Parameters.Add("$typecar", DbType.String).Value = TypecarOfPost;
                    cmd.Parameters.Add("$price", DbType.String).Value = PriceOfPost;
                    cmd.Parameters.Add("$createdate", DbType.String).Value = CreatedDateOfPost;
                    cmd.Parameters.Add("$createduser", DbType.String).Value = CreatedUserOfPost;
                    cmd.Parameters.Add("$comments", DbType.String).Value = commentsOfPost;
                    cmd.Parameters.Add("$location", DbType.String).Value = LocationOfPost;
                    cmd.Parameters.Add("$status", DbType.String).Value = StatusOfPost;
                    cmd.Parameters.Add("$numberliked", DbType.String).Value = NumberLikeOfPost;
                    cmd.Parameters.Add("$star", DbType.String).Value = StarOfPost;


                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Create post Successed");


                _con.Close();
            }
        }
    }
}
