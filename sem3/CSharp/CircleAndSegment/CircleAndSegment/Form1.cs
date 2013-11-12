using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircleAndSegment;


namespace CircleAndSegment
{
    public partial class Shell : Form
    {
        Create picture = new Create();

        public Shell()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture.CreateRandom();

            pictureBox1.Refresh();

            if (picture.Intersect()) label1.Text = "Intersect";
            else label1.Text = "Disjoint";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(pictureBox1.BackColor);
            picture.Draw(e.Graphics);
        }
    }
}
