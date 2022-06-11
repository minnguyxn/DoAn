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
    public partial class main_posts : Form
    {
        public main_posts(Size e)
        {
            InitializeComponent();
            panel3.Size = e;
            load_posts();
        }

        private void Posts_Load(object sender, EventArgs e)
        {

        }

        public void load_posts()
        {
            for(int i = 0;i <= 5;i++)
            {
               _post post = new _post();
              
                flowLayoutPanel1.Controls.Add(post);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
