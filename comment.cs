using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DoAn
{
    public partial class comment : UserControl
    {
        public comment(string _name, string avatar, string comment)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            name.Text = _name;
            img.Image = (Image)(new Bitmap(Image.FromFile(path + "\\source_csharp\\" + avatar)));
            content.Text = comment;
        }
    }
}
