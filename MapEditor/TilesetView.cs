using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class TilesetView : UserControl
    {

        Dictionary<string, Tileset> tileSets = new Dictionary<string, Tileset>();
        private string selectedTileset;
        private Tileset currentTileset;


        public TilesetView()
        {
            InitializeComponent();
        }

        public void SetInfo(string selectedTileset)
        {

            this.selectedTileset = selectedTileset;
            toolStripStatusLabelSelectedTileset.Text = selectedTileset;

            if (!tileSets.TryGetValue(selectedTileset, out currentTileset))
            {
                currentTileset = new Tileset($@"tilesets\{selectedTileset}");
                tileSets.Add(selectedTileset, currentTileset);
            }

            this.Invalidate();
        }





        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(currentTileset.image, 0,0);

            base.OnPaint(e);
        }

        private void TilesetView_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripCursorPosition.Text = e.Location.ToString();
        }

    }
}
