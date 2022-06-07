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
    public partial class Forgotten : Form
    {
        public Forgotten()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tuser.Text != "user")
            {
                label7.Visible = true;
                label6.Visible = false;
                label8.Visible = false;
            } else
            {
                if (pass2.Text != "pass2")
                {
                    label7.Visible = false;
                    label6.Visible = false;
                    label8.Visible = true;
                } else
                {
                    if (pass.Text != rpass.Text)
                    {
                        label7.Visible = false;
                        label6.Visible = true;
                        label8.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Reset Password Successed");
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
