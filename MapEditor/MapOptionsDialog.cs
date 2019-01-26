using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class MapOptionsDialog : Form
    {
        private Map map;

        public int GridSize
        {
            get {return (int) gridSize.Value; }
        }

        public MapOptionsDialog(Map map)
        {
            InitializeComponent();

            this.map = map;
            gridSize.Value = 32;
            mapSize.Value = map.Size;

        }

        private void mapSize_ValueChanged(object sender, EventArgs e)
        {
            map.Size = (int) ((NumericUpDown)sender).Value;
        }

       
    }
}
