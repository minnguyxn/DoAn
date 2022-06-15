using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class MainScreen : Form
    {
        private string cuser;
        public MainScreen(string current_user)
        {
            InitializeComponent();
            cuser = current_user;
            label1.Text = "Hello, " + cuser;
            main_posts posts = new main_posts(panel6.Size,cuser, "renderall");
            posts.TopLevel = false;
            posts.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(posts);
   
            posts.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            Information information = new Information(cuser);
            information.TopLevel = false;
            information.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(information);
            FormBorderStyle = FormBorderStyle.None;
            information.Show();
        }

        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            ChangePass changePass = new ChangePass(cuser);
            changePass.TopLevel = false;
            changePass.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(changePass);
            FormBorderStyle = FormBorderStyle.None;
            changePass.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            CreatePost createpost = new CreatePost(cuser);
            createpost.TopLevel = false;
            createpost.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(createpost);
            FormBorderStyle = FormBorderStyle.None;
            createpost.Show();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            main_posts posts = new main_posts(panel6.Size, cuser, "mypost");
            posts.TopLevel = false;
            posts.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(posts);
            FormBorderStyle = FormBorderStyle.None;
            posts.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            main_posts posts = new main_posts(panel6.Size, cuser, "renderall");
            posts.TopLevel = false;
            posts.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(posts);

            posts.Show();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            Chart chart = new Chart(cuser);
            chart.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(chart);

            chart.Show();
            
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            main_posts posts = new main_posts(panel6.Size, cuser, "rentedpost");
            posts.TopLevel = false;
            posts.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(posts);
            FormBorderStyle = FormBorderStyle.None;
            posts.Show();
        }
    }
}
