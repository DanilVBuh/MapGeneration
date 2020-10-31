namespace MapGeneration
{
    partial class MapForm
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
            this.components = new System.ComponentModel.Container();
            this.mapTimer = new System.Windows.Forms.Timer(this.components);
            this.mapPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mapTimer
            // 
            this.mapTimer.Enabled = true;
            this.mapTimer.Interval = 10;
            this.mapTimer.Tick += new System.EventHandler(this.mapTimer_Tick);
            // 
            // mapPanel
            // 
            this.mapPanel.AutoSize = true;
            this.mapPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Enabled = false;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(620, 620);
            this.mapPanel.TabIndex = 1;
            this.mapPanel.Visible = false;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(620, 620);
            this.Controls.Add(this.mapPanel);
            this.DoubleBuffered = true;
            this.Name = "MapForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer mapTimer;
        private System.Windows.Forms.Panel mapPanel;
    }
}

