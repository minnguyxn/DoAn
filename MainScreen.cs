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
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            Information information = new Information();
            information.TopLevel = false;
            information.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(information);
            FormBorderStyle = FormBorderStyle.None;
            information.Show();
        }

        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            ChangePass changePass = new ChangePass();
            changePass.TopLevel = false;
            changePass.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(changePass);
            FormBorderStyle = FormBorderStyle.None;
            changePass.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
