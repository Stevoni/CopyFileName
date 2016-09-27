namespace CopyFileUtility
{
    partial class frmMain
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
            this.lvPaths = new System.Windows.Forms.ListView();
            this.colOutputType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvPaths
            // 
            this.lvPaths.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOutputType,
            this.colOutput});
            this.lvPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPaths.FullRowSelect = true;
            this.lvPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvPaths.HoverSelection = true;
            this.lvPaths.Location = new System.Drawing.Point(0, 0);
            this.lvPaths.Name = "lvPaths";
            this.lvPaths.Size = new System.Drawing.Size(459, 117);
            this.lvPaths.TabIndex = 0;
            this.lvPaths.UseCompatibleStateImageBehavior = false;
            this.lvPaths.View = System.Windows.Forms.View.Details;
            this.lvPaths.ItemActivate += new System.EventHandler(this.lvPaths_ItemActivate);
            // 
            // colOutputType
            // 
            this.colOutputType.Text = "Output Type";
            // 
            // colOutput
            // 
            this.colOutput.Text = "Output";
            this.colOutput.Width = 120;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 117);
            this.Controls.Add(this.lvPaths);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Copy File Utility";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPaths;
        private System.Windows.Forms.ColumnHeader colOutputType;
        private System.Windows.Forms.ColumnHeader colOutput;
    }
}

