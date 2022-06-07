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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tuser.Text == "user")
            {
                label7.Visible = true;
                label6.Visible = false;
            }
            else
            {
                if (pass.Text != rpass.Text)
                {
                    label6.Visible=true;
                    label7.Visible=false;
                } else
                {
                    MessageBox.Show("Sign Up Successed");
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }
    }
}
