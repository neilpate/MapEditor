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
        public Bitmap Bitmap { get; }           //this is a bit of a bodge
        public Point Position { get; set; }

        public Tile(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
        }
        
        public void Draw(Graphics g)
        {
            g.DrawImage(Bitmap, Position);
        }

    }
}
