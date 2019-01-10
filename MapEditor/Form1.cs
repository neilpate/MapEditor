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
        List<string> tileSets;
        private TilesetView tilesetView;

        public Form1()
        {
            InitializeComponent();
            updateTilesets();
            treeViewTilesets.AfterSelect += OnSelectedTilesetChanged;
            tilesetView = new TilesetView() { Dock = DockStyle.Fill };

        }

        private void OnSelectedTilesetChanged(object sender, TreeViewEventArgs e)
        {
            var selectedEpisode = treeViewTilesets.SelectedNode.Tag as string;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(tilesetView);
            tilesetView.SetInfo(selectedEpisode);
        //    Image image = 


          //  tilesetView.SetImage = 
        }

        void updateTilesets()
        {
            DirectoryInfo d = new DirectoryInfo(@"c:\temp\tilesets");

            FileInfo[] files = d.GetFiles();
            foreach (var file in files)
            {
                TreeNode node = new TreeNode(file.Name) { Tag = file.Name };
                treeViewTilesets.Nodes.Add(node);
            }
        }
    }
}
