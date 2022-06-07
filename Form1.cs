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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Tuser.Text == "user" && Tpass.Text == "pass")
            {
                panel0.Controls.Clear();
                MainScreen mainscreen = new MainScreen();
                mainscreen.TopLevel = false;
                mainscreen.Dock = DockStyle.Fill;
                this.panel0.Controls.Add(mainscreen);
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                mainscreen.Show();
            } else
            {
                FalseLabel.Visible = true;
                Tuser.Text = "";
                Tpass.Text = "";
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
    }
}
