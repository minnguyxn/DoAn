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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void change_Click(object sender, EventArgs e)
        {
            //bunifuButton1.Visible = true;
            //change.Visible = false;
            if (current.Text == "pass")
            {
                if (newpass.Text == renewpass.Text)
                {
                    label5.Visible = true;
                    FalseLabel.Visible = false;
                    label6.Visible = false;
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
