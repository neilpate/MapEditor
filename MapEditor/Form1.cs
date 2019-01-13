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


namespace MapEditor
{
    public partial class Form1 : Form
    {
        private TilesetView tilesetView;

        public Form1()
        {
            InitializeComponent();

            MapView mapView = new MapView();

            updateTilesets();
            treeViewTilesets.AfterSelect += OnSelectedTilesetChanged;
            tilesetView = new TilesetView(mapView) { Dock = DockStyle.Fill };

            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(tilesetView);


            mapView.Show();


        }

        private void OnSelectedTilesetChanged(object sender, TreeViewEventArgs e)
        {
            var selectedTileset = treeViewTilesets.SelectedNode.Tag as string;

            tilesetView.SetInfo(selectedTileset);
          


        }

        void updateTilesets()
        {
            DirectoryInfo d = new DirectoryInfo(@"tilesets");

            FileInfo[] files = d.GetFiles();
            foreach (var file in files)
            {
                if (file.Extension == ".png")
                {
                    TreeNode node = new TreeNode(file.Name) { Tag = file.Name };
                    treeViewTilesets.Nodes.Add(node);

                }
            }
        }
    }
}
