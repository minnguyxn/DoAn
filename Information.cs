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
    public partial class Information : Form
    {
        private string curuser;
        public string path;
        public Information(string cuser)
        {
            string path = Directory.GetCurrentDirectory();
            InitializeComponent();
            curuser = cuser;
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
               // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
               // _con.ConnectionString = _strConnect;
               _con.Open();
                string InsertSql = "SELECT * FROM users WHERE username= ?";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    name.Text = rdr.GetString(3);
                    adress.Text = rdr.GetString(8);
                    phone.Text = rdr.GetString(9);
                    email.Text = rdr.GetString(5);
                    //path = rdr.GetString(7);
                    try
                    {

                        bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path + "\\source_csharp\\" + rdr.GetString(7))));
                    }
                    catch
                    {
                        bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path + "\\source_csharp\\avatar.jpg")));
                    }
                }
                _con.Close();
            }


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            nameC.Visible = true;
            adressC.Visible = true;
            phoneC.Visible = true;
            EmailC.Visible = true;
            edit.Visible = false;
            change.Visible = true;
            nameC.Text = name.Text;
            adressC.Text = adress.Text;
            phoneC.Text = phone.Text;
            EmailC.Text= email.Text;
        }

        private void change_Click(object sender, EventArgs e)
        {
            edit.Visible = true;
            change.Visible = false;
            nameC.Visible = false;
            adressC.Visible = false;
            phoneC.Visible = false;
            EmailC.Visible = false;
            //SQLiteConnection _con = new SQLiteConnection();
            //string _strConnect = "Data Source=MyDatabase.db;Version=3;";
            //_con.ConnectionString = _strConnect;
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                _con.Open();
                string InsertSql = "UPDATE users SET fullname = ?, email = ?, phone = ?, address = ? WHERE username = ? ";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$fullname", DbType.String).Value = nameC.Text;
                cmd.Parameters.Add("$email", DbType.String).Value = EmailC.Text;
                cmd.Parameters.Add("$phone", DbType.String).Value = phoneC.Text;
                cmd.Parameters.Add("$address", DbType.String).Value = adressC.Text;
                cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                name.Text = nameC.Text;
                email.Text = EmailC.Text;
                phone.Text = phoneC.Text;
                adress.Text = adressC.Text;
                rdr.Close();
                _con.Close();
            }

            MessageBox.Show("Your infomation has been updated");

        }

       

        private void nameC_TextChanged(object sender, EventArgs e)
        {

        }

        private void adressC_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            
            //path = path.Replace(@"\",@"\\");
            //SQLiteConnection _con = new SQLiteConnection();
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                OpenFileDialog x = new OpenFileDialog();
                x.Filter = "Image Files|*.jpg";
                string path_ = Directory.GetCurrentDirectory() + "\\source_csharp\\";
                string filename = "";
                if (x.ShowDialog() == DialogResult.OK)
                {
                    //newpath = x.FileName;
                    bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(x.FileName)));
                    
                    File.Copy(x.FileName, Path.Combine(path_, curuser + Path.GetExtension(x.FileName)), true);
                    filename = curuser + Path.GetExtension(x.FileName);
                }
                //string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                //_con.ConnectionString = _strConnect;
                _con.Open();
                string InsertSql = "UPDATE users SET avatar = ? WHERE username = ? ";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);

                cmd.Parameters.Add("$avatar", DbType.String).Value = curuser + Path.GetExtension(filename);
                cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                _con.Close();
            }
            //_con.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
