using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        private Point cellLocation = new Point();

        public Map map = new Map();


        public MapView()
        {
            InitializeComponent();
            DoubleBuffered = true;

            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
        }

        public void Stamp(Bitmap stamp)
        {
            this.stamp = stamp;

            Invalidate();
        }

        public void AddCurrentTile ()
        {
            if (currentTile != null)
            {
                Tile tileToAdd = new Tile(currentTile.Bitmap);
                tileToAdd.Position = stampLocation;
                map.AddTile(tileToAdd);

            }

        }

      
        protected override void OnPaint(PaintEventArgs e)
        {
            Console.WriteLine("Entered OnPaint");
            pictureBoxMap.Invalidate();
            base.OnPaint(e);

        }

        private void toolStripButtonGridVisible_Click(object sender, EventArgs e)
        {
            //Button will toggle by itself as the CheckOnClick property has been set
            //Add that we need to do is toggle the grid variable
            grid.Visible = !grid.Visible;

            Invalidate();
            Update();

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

        

       public void UpdateCurrentTile(Tile tile)
        {
            currentTile = tile;

            this.Cursor = new Cursor(tile.Bitmap.GetHicon());

        }


        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image |*.png";
            sfd.Title = "Select file to save";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                map.Save(sfd.FileName);
            }
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            statusStripMousePositionLabel.Text = e.Location.ToString();
            cellLocation.X = e.Location.X - (e.Location.X % grid.Size);
            cellLocation.Y = e.Location.Y - (e.Location.Y % grid.Size);
            toolStripStatusSnappedPosition.Text = cellLocation.ToString();

            //If the user is still holding the button then stamp if the cell changes 
            if (mouseButtonPressed)

                if (inMapBounds(cellLocation))

                if ((e.Location.X != cellLocation.X) || (e.Location.Y != cellLocation.Y))
                {
                    stampLocation = cellLocation;
                    AddCurrentTile();
                    pictureBoxMap.Invalidate();
                }


        }

        //Stamp the tile onto the current cell position
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            mouseButtonPressed = true;
            if ( inMapBounds(stampLocation) )
            {
                stampLocation = cellLocation;
                AddCurrentTile();
                Invalidate();
            }

        }

        private bool inMapBounds(Point point)
        {
            if ((point.X <= map.Size) && (point.Y <= map.Size))
                return true;
            else
                return false;
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            mouseButtonPressed = false;
        }

        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            map.Paint(g);

            grid.Width = map.Size;
            grid.Height = map.Size;

            Point startPosition = new Point(0, 0);

            grid.Draw(g, startPosition);

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mapOptionsDialog = new MapOptionsDialog(map);

            mapOptionsDialog.ShowDialog();

            grid.Size = mapOptionsDialog.GridSize;

            this.Refresh();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "map files (*.map)|*.map";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                map.Name = Path.GetFileName(saveFileDialog.FileName);
                var formatter = new BinaryFormatter();
                var stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, map);
                stream.Close();

                this.Text = map.Name;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(map.Name, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, map);
            stream.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "map files (*.map)|*.map";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var formatter = new BinaryFormatter();
                var stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

                Map mapNew = (Map)formatter.Deserialize(stream);
                map = mapNew;
                stream.Close();

                this.Text = map.Name;
                this.Refresh();

            }


          }

        
    }
}
