using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MapEditor
{
    public partial class MapView : Form
    {
        private Bitmap stamp;
        private Grid grid = new Grid();
        private Point stampLocation = new Point();
        private Tile currentTile;
        private bool mouseButtonPressed;
        private Point snappedLocation = new Point();

        public Map map = new Map();


        public MapView()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void Stamp(Bitmap stamp)
        {
            this.stamp = stamp;

            Invalidate();
        }

        public void AddCurrentTile ()
        {
            Tile tileToAdd = new Tile(currentTile.Bitmap);
            tileToAdd.Position = stampLocation;
            map.AddTile(tileToAdd);

        }

      
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            map.Paint(g);


            grid.Width = this.Width;
            grid.Height = this.Height;

            Point startPosition = new Point(0, toolStrip1.Height+menuStrip1.Height);

            grid.Draw(g, startPosition);

            base.OnPaint(e);

       //     ResumeLayout();
        }

        private void toolStripButtonGridVisible_Click(object sender, EventArgs e)
        {
            //Button will toggle by itself as the CheckOnClick property has been set
            //Add that we need to do is toggle the grid variable
            grid.Visible = !grid.Visible;

            Invalidate();

        }


        //This seems like a rubbish way to handle the menu!
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grid.Size = 16;
            Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            grid.Size = 32;
            Invalidate();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            grid.Size = 64;
            Invalidate();

        }

        private void MapView_MouseMove(object sender, MouseEventArgs e)
        {
            statusStripMousePositionLabel.Text = e.Location.ToString();
            snappedLocation.X = e.Location.X - (e.Location.X % grid.Size);
            snappedLocation.Y = e.Location.Y - ((e.Location.Y - menuStrip1.Height - toolStrip1.Height) % grid.Size);
            toolStripStatusSnappedPosition.Text = snappedLocation.ToString();

            //If the user is still holding the button then stamp if the cell changes 
            if (mouseButtonPressed)

                if ((e.Location.X != snappedLocation.X) || (e.Location.Y != snappedLocation.Y))
                {
                    stampLocation = snappedLocation;
                    AddCurrentTile();
                    Invalidate();
                }
                

        }

        private void MapView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseButtonPressed = true;
           
            stampLocation = snappedLocation;
           
            AddCurrentTile();

            Invalidate();
        }

       public void UpdateCurrentTile(Tile tile)
        {
            currentTile = tile;

            this.Cursor = new Cursor(tile.Bitmap.GetHicon());

        }

        private void MapView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseButtonPressed = false;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image |*.png";
            sfd.Title = "Select file to save";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                FileStream fs = (FileStream)sfd.OpenFile();

                Bitmap bitmap = new Bitmap(1000, 1000);

                Graphics g = Graphics.FromImage(bitmap);

                map.Paint(g);

                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);

                //bitmap.


            }
        }
    }
}
