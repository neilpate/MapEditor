namespace MapEditor
{
    partial class MapOptionsDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mapSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSize
            // 
            this.gridSize.Location = new System.Drawing.Point(65, 7);
            this.gridSize.Name = "gridSize";
            this.gridSize.Size = new System.Drawing.Size(63, 20);
            this.gridSize.TabIndex = 0;
            this.gridSize.Value = new decimal(new int[] {
            123,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grid size";
            // 
            // mapSize
            // 
            this.mapSize.Location = new System.Drawing.Point(65, 33);
            this.mapSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mapSize.Name = "mapSize";
            this.mapSize.Size = new System.Drawing.Size(63, 20);
            this.mapSize.TabIndex = 2;
            this.mapSize.Value = new decimal(new int[] {
            123,
            0,
            0,
            131072});
            this.mapSize.ValueChanged += new System.EventHandler(this.mapSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "pixels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "pixels";
            // 
            // MapOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 288);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mapSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridSize);
            this.Name = "MapOptionsDialog";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.gridSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown gridSize;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown mapSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}