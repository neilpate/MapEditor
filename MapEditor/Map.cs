using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapEditor
{
    public class Map
    {
        List<Tile> tiles = new List<Tile>();
        public int Size { get; set; }

        public Map()
        {
            Size = 320;
        }

        public void AddTile(Tile newTile)
        {
            tiles.Add(newTile);
        }

        public void Paint(Graphics g)
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw(g);

            }
        }

        public void Save(string filename)
        {
            using (FileStream fs = File.Create(filename))
            {
                Bitmap bitmap = new Bitmap(1000, 1000);

                Graphics g = Graphics.FromImage(bitmap);

                Paint(g);

                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);

               

            }

        }
    }
}
