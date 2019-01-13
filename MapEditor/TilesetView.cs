﻿using System;
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

            base.OnPaint(e);
        }

        private void TilesetView_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripCursorPosition.Text = e.Location.ToString();
        }

        private void TilesetView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = e.Location;
        }

        private void TilesetView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpLocation = e.Location;

//Calculate the dimensions of the desired tile as per the users down and up click

            Rectangle cropRect = new Rectangle(Math.Min(mouseDownLocation.X, mouseUpLocation.X), 
                Math.Min(mouseDownLocation.Y, mouseUpLocation.Y),
                Math.Abs(mouseDownLocation.X - mouseUpLocation.X),
                Math.Abs(mouseDownLocation.Y - mouseUpLocation.Y));

            //GetTile cropRect use Origin + size
             
            Stamp(currentTileset.GetTile(cropRect));


        }

        private void Stamp(Bitmap stamp)
        {
            //Stamp = 

            mapView.Stamp(stamp);
        }

    }
}
