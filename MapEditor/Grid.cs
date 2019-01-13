using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapEditor
{
    class Grid
    {
        public int Size { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen = new Pen(Color.Gray);

        public Grid()
        {
            Size = 32;     
        }

        public void Draw(Graphics g)
        {

            Point startPoint = new Point();
            Point endPoint = new Point();

            //Draw horizontal lines
            //Step through y values
            //Need to account for the toolstrip
            int startY = 20; // toolStrip1.Height;
            for (int y = startY; y < Height; y += Size)
            {
                startPoint.X = 0;
                startPoint.Y = y;

                endPoint.X = Width;
                endPoint.Y = y;

                g.DrawLine(pen, startPoint, endPoint);
            }


            //Draw vertical lines
            //Step through x values
            for (int x = 0; x < Width; x += Size)
            {
                startPoint.X = x;
                startPoint.Y = startY;

                endPoint.X = x;
                endPoint.Y = Height;

                g.DrawLine(pen, startPoint, endPoint);
            }

        }

    }
}
