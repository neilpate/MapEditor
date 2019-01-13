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
        Bitmap stamp;
        private int gridSize = 32;
        private bool gridVisible = true;

        public MapView()
        {
            InitializeComponent();
            // stamp = new Image();
        }

        public void Stamp(Bitmap stamp)
        {
            this.stamp = stamp;

            Invalidate();
        }

        private void DrawGrid(Graphics g)
        {
            Pen gridPen = new Pen(Color.Gray);
            int width = this.Size.Width;
            int height = this.Size.Height;

            Point startPoint = new Point();
            Point endPoint = new Point();

            //Draw horizontal lines
            //Step through y values
            //Need to account for the toolstrip
            int startY = toolStrip1.Height;
            for (int y = startY; y < height; y += gridSize)
            {
                startPoint.X = 0;
                startPoint.Y = y;

                endPoint.X = width;
                endPoint.Y = y;

                g.DrawLine(gridPen, startPoint, endPoint);
            }


            //Draw vertical lines
            //Step through x values
            for (int x = 0; x < width; x += gridSize)
            {
                startPoint.X = x;
                startPoint.Y = startY;

                endPoint.X = x;
                endPoint.Y = height;

                g.DrawLine(gridPen, startPoint, endPoint);
            }

            gridPen.Dispose();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (stamp != null)
                e.Graphics.DrawImage(stamp, 0, 0);

            if (gridVisible)
                DrawGrid(e.Graphics);

            base.OnPaint(e);
        }

        private void toolStripButtonGridVisible_Click(object sender, EventArgs e)
        {
            //Button will toggle by itself as the CheckOnClick property has been set
            //Add that we need to do is toggle the grid variable
            gridVisible = !gridVisible;

            Invalidate();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            gridSize = 16;
            Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            gridSize = 32;
            Invalidate();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            gridSize = 64;
            Invalidate();

        }
    }
}
