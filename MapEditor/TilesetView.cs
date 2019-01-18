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

        private Point mouseDownLocation;
        private Point mouseUpLocation;

        private MapView mapView;

        private Bitmap stamp;

        private Grid grid = new Grid();


        public TilesetView(MapView mapView)
        {
            InitializeComponent();
            this.mapView = mapView;

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
            e.Graphics.DrawImage(currentTileset.AllTiles, 0,0);

            grid.Width = this.Width;
            grid.Height = this.Height;

            Point startPosition = new Point(0, 0);
            grid.Draw(e.Graphics, startPosition);

            base.OnPaint(e);
        }

        private void TilesetView_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripCursorPosition.Text = e.Location.ToString();
        }

        private void TilesetView_MouseDown(object sender, MouseEventArgs e)
        {
            Point snappedLocation = new Point();
            snappedLocation.X = e.Location.X - (e.Location.X % grid.Size);
            snappedLocation.Y = e.Location.Y - (e.Location.Y % grid.Size);

            mouseDownLocation = snappedLocation;

            Rectangle cropRect = new Rectangle();

            cropRect.X = snappedLocation.X;
            cropRect.Y = snappedLocation.Y;
            cropRect.Width = grid.Size;
            cropRect.Height = grid.Size;

            Tile tile = new Tile(currentTileset.GetTile(cropRect));
            mapView.UpdateCurrentTile(tile); 
        }

       

    

    }
}
