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
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            nameC.Visible = true;
            adressC.Visible = true;
            phoneC.Visible = true;
            EmailC.Visible = true;
            edit.Visible = false;
            change.Visible = true;
        }

        private void change_Click(object sender, EventArgs e)
        {
            edit.Visible = true;
            change.Visible = false;
            nameC.Visible = false;
            adressC.Visible = false;
            phoneC.Visible = false;
            EmailC.Visible = false;
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                string path = x.FileName;
                bunifuPictureBox1.Image = (Image)(new Bitmap(Image.FromFile(path)));
            }
            
        }
    }
}
