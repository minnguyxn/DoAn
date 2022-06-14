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
using System.Globalization;
namespace DoAn
{
    public partial class Chart : UserControl
    {
        public string cuser = string.Empty;
        public Chart(string currentUser)
        {
            cuser = currentUser;
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {

        }
        public class PostStatistic
        {
            private string time;

            private int numberOfPost;

            public string Time
            {
                get { return time; }

                set { time = value; }
            }
            public int NumberOfPost
            {
                get { return numberOfPost; }

                set { numberOfPost = value; }
            }

            public PostStatistic(string time_, int numberOfPost_)
            {
                this.time = time_;

                this.numberOfPost = numberOfPost_;
            }
        }

        private void createChart()
        {
            string timestatistic = comboBox2.Text;
            int much = 3;
            if(timestatistic == "Weekly")
            {
                much = 7;
            }
            else if (timestatistic == "Last10day")
            {
                much = 10;
            }
            string typestatistic = comboBox1.Text;
            int type = 0; 
            if (timestatistic == "My rented posts")
            {
                type = 1;
            }
            BindingList<PostStatistic> dataSource = new BindingList<PostStatistic>();

            using (SQLiteConnection _con = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))
            {
                //SQLiteConnection _con = new SQLiteConnection();
                // string _strConnect = "Data Source=MyDatabase.db;Version=3;";
                // _con.ConnectionString = _strConnect;
                _con.Open();

                string InsertSql = string.Empty;
                if (type == 0)
                {
                    InsertSql = "SELECT * FROM posts WHERE createduser = ?";
                }
                else  InsertSql = "SELECT * FROM posts WHERE star = ?";

                // Thực thi câu lệnh
                SQLiteCommand cmd = new SQLiteCommand(InsertSql, _con);
                cmd.Parameters.Add("$createduser", DbType.String).Value = cuser;
                //cmd.Parameters.Add("$username", DbType.String).Value = curuser;
                DataTable dtt = new DataTable();
                SQLiteDataAdapter rdr = new SQLiteDataAdapter(cmd);
                rdr.Fill(dtt);

                for (int i = 0; i <= much; i++)
                {
                    int count = 0;
                    DateTime newdate;
                    string label = string.Empty;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        string datetimestring = dr["createdate"].ToString();
                        
                        DateTime.TryParse(datetimestring, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out newdate);
                        
                        DateTime comparedStart = DateTime.Now.AddDays(i*-1).Date;
                        DateTime comparedEnd = DateTime.Now.AddDays(i * -1 +1).Date;


                        if (newdate < comparedEnd && newdate > comparedStart)
                        {
                            count++;
                        }
                        string[] date_Extract = comparedEnd.ToString().Split(' ');
                        label = date_Extract[0];
                        //flowLayoutPanel1.Controls.Add(cmt);
                    }
                    //dataSource.Add(new PostStatistic(newdate.Date.ToString(), count));
                    //string[] date_Extract = newdate.ToString().Split(' ');
                    chart1.Series["NumberOfPost"].Points.AddXY(label, count);
                }
                chart1.Titles.Add("Post Statistic");


                _con.Close();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            createChart();
        }
    }
}
