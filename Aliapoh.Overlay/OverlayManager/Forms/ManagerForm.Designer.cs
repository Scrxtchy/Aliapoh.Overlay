namespace Aliapoh.Overlays.OverlayManager
{
    partial class ManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.overlayController1 = new Aliapoh.Overlays.OverlayManager.OverlayController();
            this.SuspendLayout();
            // 
            // overlayController1
            // 
            this.overlayController1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayController1.Location = new System.Drawing.Point(0, 0);
            this.overlayController1.Name = "overlayController1";
            this.overlayController1.Size = new System.Drawing.Size(884, 501);
            this.overlayController1.TabIndex = 0;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 501);
            this.Controls.Add(this.overlayController1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Name = "OverlayManager";
            this.Text = ":: Aliapoh Overlay Manager ::";
            this.ResumeLayout(false);
        }

        #endregion

        public OverlayController overlayController1;
    }
}