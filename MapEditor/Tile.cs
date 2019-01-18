using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public class Tile
    {
        private Bitmap bitmap;
        public Point Position { get; set; }

        public Tile(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bitmap, Position);
        }
    }
}
