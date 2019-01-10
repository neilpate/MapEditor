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
        public TilesetView()
        {
            InitializeComponent();
        }

        public void SetInfo(string name)
        {
            labelInfo.Text = name;
        }

        public void SetImage(Image image)
        {
            pictureBoxTileset.Image = image;
        }

        private void pictureBoxTileset_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripCursorPosition.Text = e.Location.ToString();
        }
    }
}
