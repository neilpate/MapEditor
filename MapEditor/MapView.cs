using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class MapView : Form
    {
        private Bitmap stamp;
        private Grid grid = new Grid();
        private Point stampLocation = new Point();


        public MapView()
        {
            InitializeComponent();
        }

        public void Stamp(Bitmap stamp)
        {
            this.stamp = stamp;

            Invalidate();
        }

      
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            if (stamp != null)
                g.DrawImage(stamp, stampLocation);

            grid.Width = this.Width;
            grid.Height = this.Height;

            Point startPosition = new Point(0, toolStrip1.Height);

            grid.Draw(g, startPosition);

            base.OnPaint(e);
        }

        private void toolStripButtonGridVisible_Click(object sender, EventArgs e)
        {
            //Button will toggle by itself as the CheckOnClick property has been set
            //Add that we need to do is toggle the grid variable
            grid.Visible = !grid.Visible;

            Invalidate();

        }


        //This seems like a rubbish way to handle the menu!
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grid.Size = 16;
            Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            grid.Size = 32;
            Invalidate();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            grid.Size = 64;
            Invalidate();

        }

        private void MapView_MouseMove(object sender, MouseEventArgs e)
        {
            statusStripMousePositionLabel.Text = e.Location.ToString();
        }

        private void MapView_MouseDown(object sender, MouseEventArgs e)
        {
            stampLocation = e.Location;
        }
    }
}
