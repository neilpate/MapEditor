using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public class Map
    {
        List<Tile> tiles = new List<Tile>();

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

    }
}
