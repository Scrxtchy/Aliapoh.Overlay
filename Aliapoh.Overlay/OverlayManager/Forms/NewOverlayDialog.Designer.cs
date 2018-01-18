namespace Aliapoh.Overlay.OverlayManager
{
    partial class NewOverlayDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOverlayDialog));
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OverlayURL = new System.Windows.Forms.TextBox();
            this.FramerateLabel = new System.Windows.Forms.Label();
            this.URLLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.OverlayName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FramePerSecondLabel = new System.Windows.Forms.Label();
            this.OverlayFramerate = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayFramerate)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(278, 90);
            this.OkButton.Margin = new System.Windows.Forms.Padding(0);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(109, 24);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.CheckValidateOverlayName);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(397, 90);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(109, 24);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.OverlayURL, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.FramerateLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.URLLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OverlayName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 73);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // OverlayURL
            // 
            this.OverlayURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayURL.Location = new System.Drawing.Point(120, 24);
            this.OverlayURL.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayURL.Name = "OverlayURL";
            this.OverlayURL.Size = new System.Drawing.Size(377, 23);
            this.OverlayURL.TabIndex = 6;
            // 
            // FramerateLabel
            // 
            this.FramerateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FramerateLabel.Location = new System.Drawing.Point(0, 48);
            this.FramerateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FramerateLabel.Name = "FramerateLabel";
            this.FramerateLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.FramerateLabel.Size = new System.Drawing.Size(120, 24);
            this.FramerateLabel.TabIndex = 4;
            this.FramerateLabel.Text = "Framerate";
            this.FramerateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // URLLabel
            // 
            this.URLLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.URLLabel.Location = new System.Drawing.Point(0, 24);
            this.URLLabel.Margin = new System.Windows.Forms.Padding(0);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.URLLabel.Size = new System.Drawing.Size(120, 24);
            this.URLLabel.TabIndex = 2;
            this.URLLabel.Text = "URL";
            this.URLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.NameLabel.Size = new System.Drawing.Size(120, 24);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverlayName
            // 
            this.OverlayName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayName.Location = new System.Drawing.Point(120, 0);
            this.OverlayName.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayName.Name = "OverlayName";
            this.OverlayName.Size = new System.Drawing.Size(377, 23);
            this.OverlayName.TabIndex = 5;
            this.OverlayName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OverlayName_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.FramePerSecondLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.OverlayFramerate, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(120, 48);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(377, 24);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // FramePerSecondLabel
            // 
            this.FramePerSecondLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FramePerSecondLabel.Location = new System.Drawing.Point(100, 0);
            this.FramePerSecondLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FramePerSecondLabel.Name = "FramePerSecondLabel";
            this.FramePerSecondLabel.Size = new System.Drawing.Size(277, 24);
            this.FramePerSecondLabel.TabIndex = 5;
            this.FramePerSecondLabel.Text = "fps";
            this.FramePerSecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OverlayFramerate
            // 
            this.OverlayFramerate.Location = new System.Drawing.Point(0, 0);
            this.OverlayFramerate.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayFramerate.Maximum = new decimal(new int[] {
            144,
            0,
            0,
            0});
            this.OverlayFramerate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.OverlayFramerate.Name = "OverlayFramerate";
            this.OverlayFramerate.Size = new System.Drawing.Size(100, 23);
            this.OverlayFramerate.TabIndex = 0;
            this.OverlayFramerate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NewOverlayDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(515, 123);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewOverlayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Overlay";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverlayFramerate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label FramerateLabel;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.TextBox OverlayName;
        private System.Windows.Forms.TextBox OverlayURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label FramePerSecondLabel;
        private System.Windows.Forms.NumericUpDown OverlayFramerate;
    }
}