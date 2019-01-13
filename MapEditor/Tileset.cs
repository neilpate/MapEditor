using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapEditor
{
    public class Tileset
    {
        string path;
        public Bitmap AllTiles { get; }
        public Bitmap Tile;


        public Tileset(string path)
        {
            this.path = path;
            AllTiles = new Bitmap(path);
        }

        //Returns the image data for the desired crop rectangle
        public Bitmap GetTile(Rectangle cropRect)
        {
            System.Drawing.Imaging.PixelFormat format = AllTiles.PixelFormat;
            return AllTiles.Clone(cropRect, format);
        }

    }
}
