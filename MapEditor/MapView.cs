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
    public partial class MapView : Form
    {
        Bitmap stamp;

        public MapView()
        {
            InitializeComponent();
           // stamp = new Image();
        }

        public void Stamp(Bitmap stamp)
        {
            this.stamp = stamp;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try {
                e.Graphics.DrawImage(stamp, 0, 0);

            }
            catch
            {

            }
            base.OnPaint(e);
        }
    }
}
