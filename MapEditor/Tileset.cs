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
        public Image image { get; }

        public Tileset(string path)
        {
            this.path = path;
            image = Image.FromFile(path);
        }

    }
}
