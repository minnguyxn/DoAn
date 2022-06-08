using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace DoAn
{
     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public SQLiteConnection _con = new SQLiteConnection();
        public void createConection()
        {
            string _strConnect = "Data Source=MyDatabase.db;Version=3;";
            _con.ConnectionString = _strConnect;
            _con.Open();
        }
        public void closeConnection()
        {
            _con.Close();
        }

        public void createUsersTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS users (id nvarchar(50) NOT NULL PRIMARY KEY,username nvarchar(50),password nvarchar(50), fullname nvarchar(50), displayname varchar(15), email varchar(30),pass2 nvarchar(50),avatar text , address nvarchar(100), phone varchar(11))";
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void createPostsTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS posts (id nvarchar(50) NOT NULL PRIMARY KEY, name nvarchar(50), content text , description text , typecar nvarchar(30), price nvarchar(30),createdate nvarchar(50),createduser nvarchar(50), comments text , location text , status nvarchar(30), numberliked nvarchar(30), star nvarchar(30))";
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void createCommentsTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS comments (id nvarchar(50) NOT NULL PRIMARY KEY,idpost nvarchar(50),iduser nvarchar(50), comment text )";
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }
        public void createLikesTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS likes (id nvarchar(50) NOT NULL PRIMARY KEY,idpost nvarchar(50),iduser nvarchar(50) )";
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }


        [STAThread]
        static void Main()
        {
            //SQLiteConnection.CreateFile("MyDatabase.db");
            //Program p = new Program();
            //p.createUsersTable();
            //p.createPostsTable();
            //p.createCommentsTable();
            //p.createLikesTable();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
