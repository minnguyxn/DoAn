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
    public partial class ChangePass : Form
    {
        public string curuser;
        public string passC;
        public ChangePass(string cuser)
        {
            InitializeComponent();
            curuser = cuser;
            SQLiteConnection _con = new SQLiteConnection();
            string _strConnect = "Data Source=MyDatabase.db;Version=3;";
            _con.ConnectionString = _strConnect;
            _con.Open();
            string InsertSql = "SELECT * FROM users WHERE username= ?";
            // Thực thi câu lệnh
            SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
            cmd.Parameters.Add("$username", DbType.String).Value = curuser;
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                passC = rdr.GetString(2);
            }
            _con.Close();

        }

        private void change_Click(object sender, EventArgs e)
        {
            //bunifuButton1.Visible = true;
            //change.Visible = false;
            if (current.Text == passC)
            {
                if (newpass.Text == renewpass.Text)
                {
                    label5.Visible = true;
                    FalseLabel.Visible = false;
                    label6.Visible = false;
                    SQLiteConnection _con = new SQLiteConnection();
                    string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                    _con.ConnectionString = _strConnect;
                    _con.Open();
                    string InsertSql = "UPDATE users SET password = ? WHERE username = ? ";
                    // Thực thi câu lệnh
                    SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);

                    cmd.Parameters.Add("$password", DbType.String).Value = newpass.Text;
                    cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    _con.Close();

                }
                else
                {
                    label5.Visible = false;
                    FalseLabel.Visible = false;
                    label6.Visible = true;
                }
            }
            else
            {
                label5.Visible = false;
                FalseLabel.Visible = true;
                label6.Visible = false;
            }
        }
    }
}
