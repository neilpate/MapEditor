namespace MapEditor
{
    partial class TilesetView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCursorPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelectedTileset = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCursorPosition,
            this.toolStripStatusLabelSelectedTileset});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCursorPosition
            // 
            this.toolStripCursorPosition.Name = "toolStripCursorPosition";
            this.toolStripCursorPosition.Size = new System.Drawing.Size(37, 17);
            this.toolStripCursorPosition.Text = "{{x,y}}";
            // 
            // toolStripStatusLabelSelectedTileset
            // 
            this.toolStripStatusLabelSelectedTileset.Name = "toolStripStatusLabelSelectedTileset";
            this.toolStripStatusLabelSelectedTileset.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelSelectedTileset.Text = "{{selectedTileset}}";
            // 
            // TilesetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "TilesetView";
            this.Size = new System.Drawing.Size(594, 430);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TilesetView_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TilesetView_MouseUp);

            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TilesetView_MouseMove);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCursorPosition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelectedTileset;
    }
}
