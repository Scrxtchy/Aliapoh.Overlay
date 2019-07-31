namespace Aliapoh.Overlays.OverlayManager
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
            this.NewOverlayCancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FramerateLabel = new System.Windows.Forms.Label();
            this.URLLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.OverlayFramerate = new System.Windows.Forms.NumericUpDown();
            this.FramePerSecondLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.OverlayName = new System.Windows.Forms.TextBox();
            this.OverlayURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayFramerate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(287, 435);
            this.OkButton.Margin = new System.Windows.Forms.Padding(0);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(109, 24);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.CheckValidateOverlayName);
            // 
            // NewOverlayCancelButton
            // 
            this.NewOverlayCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewOverlayCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.NewOverlayCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewOverlayCancelButton.Location = new System.Drawing.Point(406, 435);
            this.NewOverlayCancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewOverlayCancelButton.Name = "NewOverlayCancelButton";
            this.NewOverlayCancelButton.Size = new System.Drawing.Size(109, 24);
            this.NewOverlayCancelButton.TabIndex = 5;
            this.NewOverlayCancelButton.Text = "Cancel";
            this.NewOverlayCancelButton.UseVisualStyleBackColor = true;
            this.NewOverlayCancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // tableLayoutPanel1
            // 
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
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 80);
            this.tableLayoutPanel1.TabIndex = 6;
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
            // FramePerSecondLabel
            // 
            this.FramePerSecondLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FramePerSecondLabel.Location = new System.Drawing.Point(100, 0);
            this.FramePerSecondLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FramePerSecondLabel.Name = "FramePerSecondLabel";
            this.FramePerSecondLabel.Size = new System.Drawing.Size(286, 24);
            this.FramePerSecondLabel.TabIndex = 5;
            this.FramePerSecondLabel.Text = "fps";
            this.FramePerSecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 24);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // OverlayName
            // 
            this.OverlayName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayName.Location = new System.Drawing.Point(120, 0);
            this.OverlayName.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayName.Name = "OverlayName";
            this.OverlayName.Size = new System.Drawing.Size(386, 23);
            this.OverlayName.TabIndex = 5;
            this.OverlayName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OverlayName_KeyPress);
            // 
            // OverlayURL
            // 
            this.OverlayURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayURL.Location = new System.Drawing.Point(120, 24);
            this.OverlayURL.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayURL.Name = "OverlayURL";
            this.OverlayURL.Size = new System.Drawing.Size(386, 23);
            this.OverlayURL.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Plugin";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(9, 116);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(506, 310);
            this.checkedListBox1.TabIndex = 8;
            // 
            // NewOverlayDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(524, 468);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.NewOverlayCancelButton);
            this.Controls.Add(this.OkButton);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 507);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 507);
            this.Name = "NewOverlayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Overlay";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayFramerate)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button NewOverlayCancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label FramerateLabel;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.TextBox OverlayURL;
        private System.Windows.Forms.TextBox OverlayName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label FramePerSecondLabel;
        private System.Windows.Forms.NumericUpDown OverlayFramerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}