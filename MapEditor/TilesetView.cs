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
        private MapView mapView;
        private Point snappedLocation;
        private Grid grid = new Grid();
        private Point[] points = new Point[5];

        public TilesetView(MapView mapView)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.mapView = mapView;
            snappedLocation = new Point(0, 0);

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

            Pen pen = new Pen(Color.LimeGreen)
            {
                Width = 5,
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };
            e.Graphics.DrawLines(pen, points);
            pen.Dispose();

            base.OnPaint(e);
        }

        private void TilesetView_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripCursorPosition.Text = e.Location.ToString();

            Point newSnappedLocation = new Point
            {
                X = e.Location.X - (e.Location.X % grid.Size),
                Y = e.Location.Y - (e.Location.Y % grid.Size)
            };

            //Only bother updating the selection rectangle if the mouse is over a new tile
            if ((newSnappedLocation.X != snappedLocation.X) || (newSnappedLocation.Y != snappedLocation.Y))
            {
                snappedLocation = newSnappedLocation;

                Rectangle cropRect = new Rectangle();

                newSnappedLocation.X = newSnappedLocation.X;
                newSnappedLocation.Y = newSnappedLocation.Y;

                cropRect.X = newSnappedLocation.X;
                cropRect.Y = newSnappedLocation.Y;
                cropRect.Width = grid.Size;
                cropRect.Height = grid.Size;

                points[0].X = cropRect.X;
                points[0].Y = cropRect.Y;

                points[1].X = cropRect.X + cropRect.Width;
                points[1].Y = cropRect.Y;

                points[2].X = cropRect.X + cropRect.Width;
                points[2].Y = cropRect.Y + cropRect.Height;

                points[3].X = cropRect.X;
                points[3].Y = cropRect.Y + cropRect.Height;

                points[4].X = cropRect.X;
                points[4].Y = cropRect.Y;

                Invalidate();

            }

        }

        private void TilesetView_MouseDown(object sender, MouseEventArgs e)
        {
            Point snappedLocation = new Point()
            {
                X = e.Location.X - (e.Location.X % grid.Size),
                Y = e.Location.Y - (e.Location.Y % grid.Size)
            };

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
