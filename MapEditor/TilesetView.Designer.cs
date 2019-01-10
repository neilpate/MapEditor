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
            this.labelInfo = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCursorPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(13, 15);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(40, 13);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "{{info}}";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCursorPosition});
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
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxTileset.Location = new System.Drawing.Point(0, 31);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(594, 377);
            this.pictureBoxTileset.TabIndex = 2;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseMove);
            // 
            // TilesetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxTileset);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelInfo);
            this.Name = "TilesetView";
            this.Size = new System.Drawing.Size(594, 430);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCursorPosition;
        private System.Windows.Forms.PictureBox pictureBoxTileset;
    }
}
