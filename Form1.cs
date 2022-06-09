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
    public partial class Form1 : Form
    {
        private string current_user;
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string username = Tuser.Text;
            string password = Tpass.Text;
            // khởi tạo connect
            //SQLiteConnection _con = new SQLiteConnection();
            //string _strConnect = "Data Source=MyDatabase.db;Version=3;";
            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //_con.ConnectionString = _strConnect;
                _con.Open(); // mở kết nối
                             // câu lệnh insert user
                string InsertSql = "SELECT * FROM users WHERE username= ? AND password=?";
                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$username", DbType.String).Value = username;
                cmd.Parameters.Add("$password", DbType.String).Value = password;

                SQLiteDataReader rdr = cmd.ExecuteReader();
                //_con.Close(); // đóng kết nối

                if (rdr.HasRows)
                {
                    // set biến current_user
                    panel0.Controls.Clear();
                    current_user = username;
                    MainScreen mainscreen = new MainScreen(current_user);
                    mainscreen.TopLevel = false;
                    mainscreen.Dock = DockStyle.Fill;
                    this.panel0.Controls.Add(mainscreen);
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    mainscreen.Show();
                }
                else
                {
                    FalseLabel.Visible = true;
                    Tuser.Text = "";
                    Tpass.Text = "";
                }

                _con.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Register register = new Register();
            register.TopLevel = false;
            register.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(register);
            //FormBorderStyle = FormBorderStyle.None;
            register.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Forgotten forgotten = new Forgotten();
            forgotten.TopLevel = false;
            forgotten.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(forgotten);
            //FormBorderStyle = FormBorderStyle.None;
            forgotten.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
