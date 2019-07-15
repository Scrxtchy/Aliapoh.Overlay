namespace Aliapoh.Overlay.OverlayManager
{
    partial class OverlayController
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayController));
            this.OpenBackgroundDialog = new System.Windows.Forms.OpenFileDialog();
            this.ScreenshotSavePathSelectDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LogTabPage = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ClearLogsButton = new System.Windows.Forms.Button();
            this.MarginLabel1 = new System.Windows.Forms.Label();
            this.CopyAllLogsButton = new System.Windows.Forms.Button();
            this.PluginsTabPage = new System.Windows.Forms.TabPage();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.ScreenShotSettingGroupbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ScreenshotSavePathTextBox = new System.Windows.Forms.TextBox();
            this.ScreenshotSavePathSelectButton = new System.Windows.Forms.Button();
            this.MarginLabel = new System.Windows.Forms.Label();
            this.AutoClippingLabel = new System.Windows.Forms.Label();
            this.FillModeLabel = new System.Windows.Forms.Label();
            this.BackgroundImageLabel = new System.Windows.Forms.Label();
            this.SavePathLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ScreenshotMargin = new System.Windows.Forms.NumericUpDown();
            this.AutoClippingCheckBox = new System.Windows.Forms.CheckBox();
            this.ScreenshotBackgroundFillModeComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ScreenshotBackgroundSelectButton = new System.Windows.Forms.Button();
            this.ScreenshotBackgroundImagePathTextBox = new System.Windows.Forms.TextBox();
            this.ProgramOptionGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.AutoHideCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoHideByProcLabel = new System.Windows.Forms.Label();
            this.DetectProcessLabel = new System.Windows.Forms.Label();
            this.VersionAutoCheckLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LatestVersionLabel = new System.Windows.Forms.Label();
            this.VersionAutoCheckCheckBox = new System.Windows.Forms.CheckBox();
            this.DetectProcessNameTextBox = new System.Windows.Forms.TextBox();
            this.OverlaysTabPage = new System.Windows.Forms.TabPage();
            this.overlayManageTabControl1 = new Aliapoh.Overlay.OverlayManageTabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ScreenShotButton = new System.Windows.Forms.Button();
            this.MarginLabel2 = new System.Windows.Forms.Label();
            this.OpenDevToolButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.OverlayTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.overlayAddButton = new System.Windows.Forms.Button();
            this.OverlayControlTabPage = new Aliapoh.Overlay.OverlayTabControl();
            this.LogTabPage.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            this.ScreenShotSettingGroupbox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenshotMargin)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.ProgramOptionGroupBox.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.OverlaysTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.OverlayControlTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenBackgroundDialog
            // 
            this.OpenBackgroundDialog.FileName = "openFileDialog1";
            // 
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.LogTextBox);
            this.LogTabPage.Controls.Add(this.panel5);
            this.LogTabPage.Location = new System.Drawing.Point(2, 34);
            this.LogTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.Size = new System.Drawing.Size(796, 444);
            this.LogTabPage.TabIndex = 1;
            this.LogTabPage.Text = "LogEntry";
            this.LogTabPage.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.Color.White;
            this.LogTextBox.Location = new System.Drawing.Point(0, 32);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(796, 412);
            this.LogTextBox.TabIndex = 1;
            this.LogTextBox.Text = "";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.ClearLogsButton);
            this.panel5.Controls.Add(this.MarginLabel1);
            this.panel5.Controls.Add(this.CopyAllLogsButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(796, 32);
            this.panel5.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(211, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Auto scroll";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ClearLogsButton
            // 
            this.ClearLogsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClearLogsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.ClearLogsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearLogsButton.Location = new System.Drawing.Point(104, 2);
            this.ClearLogsButton.Name = "ClearLogsButton";
            this.ClearLogsButton.Size = new System.Drawing.Size(100, 28);
            this.ClearLogsButton.TabIndex = 2;
            this.ClearLogsButton.Text = "Clear Logs";
            this.ClearLogsButton.UseVisualStyleBackColor = true;
            this.ClearLogsButton.Click += new System.EventHandler(this.ClearLogsButton_Click);
            // 
            // MarginLabel1
            // 
            this.MarginLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.MarginLabel1.Location = new System.Drawing.Point(102, 2);
            this.MarginLabel1.Name = "MarginLabel1";
            this.MarginLabel1.Size = new System.Drawing.Size(2, 28);
            this.MarginLabel1.TabIndex = 1;
            // 
            // CopyAllLogsButton
            // 
            this.CopyAllLogsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CopyAllLogsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.CopyAllLogsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyAllLogsButton.Location = new System.Drawing.Point(2, 2);
            this.CopyAllLogsButton.Name = "CopyAllLogsButton";
            this.CopyAllLogsButton.Size = new System.Drawing.Size(100, 28);
            this.CopyAllLogsButton.TabIndex = 0;
            this.CopyAllLogsButton.Text = "Copy All Logs";
            this.CopyAllLogsButton.UseVisualStyleBackColor = true;
            // 
            // PluginsTabPage
            // 
            this.PluginsTabPage.Location = new System.Drawing.Point(2, 34);
            this.PluginsTabPage.Name = "PluginsTabPage";
            this.PluginsTabPage.Size = new System.Drawing.Size(796, 444);
            this.PluginsTabPage.TabIndex = 4;
            this.PluginsTabPage.Text = "Plugins";
            this.PluginsTabPage.UseVisualStyleBackColor = true;
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.ScreenShotSettingGroupbox);
            this.SettingsTabPage.Controls.Add(this.ProgramOptionGroupBox);
            this.SettingsTabPage.Location = new System.Drawing.Point(2, 34);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(10, 2, 10, 10);
            this.SettingsTabPage.Size = new System.Drawing.Size(796, 444);
            this.SettingsTabPage.TabIndex = 2;
            this.SettingsTabPage.Text = "Settings";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // ScreenShotSettingGroupbox
            // 
            this.ScreenShotSettingGroupbox.Controls.Add(this.tableLayoutPanel1);
            this.ScreenShotSettingGroupbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScreenShotSettingGroupbox.Enabled = false;
            this.ScreenShotSettingGroupbox.Location = new System.Drawing.Point(10, 128);
            this.ScreenShotSettingGroupbox.Margin = new System.Windows.Forms.Padding(10);
            this.ScreenShotSettingGroupbox.Name = "ScreenShotSettingGroupbox";
            this.ScreenShotSettingGroupbox.Padding = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.ScreenShotSettingGroupbox.Size = new System.Drawing.Size(776, 152);
            this.ScreenShotSettingGroupbox.TabIndex = 0;
            this.ScreenShotSettingGroupbox.TabStop = false;
            this.ScreenShotSettingGroupbox.Text = "Screenshot Options";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.MarginLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.AutoClippingLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.FillModeLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BackgroundImageLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SavePathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.AutoClippingCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ScreenshotBackgroundFillModeComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Controls.Add(this.ScreenshotSavePathTextBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ScreenshotSavePathSelectButton, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(180, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(583, 24);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // ScreenshotSavePathTextBox
            // 
            this.ScreenshotSavePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotSavePathTextBox.Location = new System.Drawing.Point(0, 0);
            this.ScreenshotSavePathTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ScreenshotSavePathTextBox.Name = "ScreenshotSavePathTextBox";
            this.ScreenshotSavePathTextBox.Size = new System.Drawing.Size(543, 23);
            this.ScreenshotSavePathTextBox.TabIndex = 0;
            this.ScreenshotSavePathTextBox.TextChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // ScreenshotSavePathSelectButton
            // 
            this.ScreenshotSavePathSelectButton.BackColor = System.Drawing.Color.Gainsboro;
            this.ScreenshotSavePathSelectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotSavePathSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ScreenshotSavePathSelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScreenshotSavePathSelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ScreenshotSavePathSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenshotSavePathSelectButton.Location = new System.Drawing.Point(544, 0);
            this.ScreenshotSavePathSelectButton.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.ScreenshotSavePathSelectButton.Name = "ScreenshotSavePathSelectButton";
            this.ScreenshotSavePathSelectButton.Size = new System.Drawing.Size(39, 23);
            this.ScreenshotSavePathSelectButton.TabIndex = 1;
            this.ScreenshotSavePathSelectButton.Text = "…";
            this.ScreenshotSavePathSelectButton.UseVisualStyleBackColor = false;
            // 
            // MarginLabel
            // 
            this.MarginLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarginLabel.Location = new System.Drawing.Point(0, 96);
            this.MarginLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MarginLabel.Name = "MarginLabel";
            this.MarginLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.MarginLabel.Size = new System.Drawing.Size(180, 27);
            this.MarginLabel.TabIndex = 8;
            this.MarginLabel.Text = "Margin";
            this.MarginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AutoClippingLabel
            // 
            this.AutoClippingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoClippingLabel.Location = new System.Drawing.Point(0, 72);
            this.AutoClippingLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AutoClippingLabel.Name = "AutoClippingLabel";
            this.AutoClippingLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AutoClippingLabel.Size = new System.Drawing.Size(180, 24);
            this.AutoClippingLabel.TabIndex = 6;
            this.AutoClippingLabel.Text = "Auto Clipping";
            this.AutoClippingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FillModeLabel
            // 
            this.FillModeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillModeLabel.Location = new System.Drawing.Point(0, 48);
            this.FillModeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FillModeLabel.Name = "FillModeLabel";
            this.FillModeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.FillModeLabel.Size = new System.Drawing.Size(180, 24);
            this.FillModeLabel.TabIndex = 4;
            this.FillModeLabel.Text = "Fill Mode";
            this.FillModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BackgroundImageLabel
            // 
            this.BackgroundImageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundImageLabel.Location = new System.Drawing.Point(0, 24);
            this.BackgroundImageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundImageLabel.Name = "BackgroundImageLabel";
            this.BackgroundImageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.BackgroundImageLabel.Size = new System.Drawing.Size(180, 24);
            this.BackgroundImageLabel.TabIndex = 2;
            this.BackgroundImageLabel.Text = "Background";
            this.BackgroundImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SavePathLabel
            // 
            this.SavePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SavePathLabel.Location = new System.Drawing.Point(0, 0);
            this.SavePathLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SavePathLabel.Name = "SavePathLabel";
            this.SavePathLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.SavePathLabel.Size = new System.Drawing.Size(180, 24);
            this.SavePathLabel.TabIndex = 0;
            this.SavePathLabel.Text = "Save Path";
            this.SavePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.68243F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.31757F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ScreenshotMargin, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(180, 96);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(583, 27);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(79, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(504, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "px";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScreenshotMargin
            // 
            this.ScreenshotMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotMargin.Location = new System.Drawing.Point(0, 2);
            this.ScreenshotMargin.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.ScreenshotMargin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScreenshotMargin.Name = "ScreenshotMargin";
            this.ScreenshotMargin.Size = new System.Drawing.Size(77, 23);
            this.ScreenshotMargin.TabIndex = 0;
            this.ScreenshotMargin.ValueChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // AutoClippingCheckBox
            // 
            this.AutoClippingCheckBox.AutoSize = true;
            this.AutoClippingCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoClippingCheckBox.Location = new System.Drawing.Point(184, 76);
            this.AutoClippingCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoClippingCheckBox.Name = "AutoClippingCheckBox";
            this.AutoClippingCheckBox.Size = new System.Drawing.Size(575, 16);
            this.AutoClippingCheckBox.TabIndex = 10;
            this.AutoClippingCheckBox.UseVisualStyleBackColor = true;
            this.AutoClippingCheckBox.CheckedChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // ScreenshotBackgroundFillModeComboBox
            // 
            this.ScreenshotBackgroundFillModeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotBackgroundFillModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenshotBackgroundFillModeComboBox.FormattingEnabled = true;
            this.ScreenshotBackgroundFillModeComboBox.Location = new System.Drawing.Point(180, 48);
            this.ScreenshotBackgroundFillModeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.ScreenshotBackgroundFillModeComboBox.Name = "ScreenshotBackgroundFillModeComboBox";
            this.ScreenshotBackgroundFillModeComboBox.Size = new System.Drawing.Size(583, 23);
            this.ScreenshotBackgroundFillModeComboBox.TabIndex = 11;
            this.ScreenshotBackgroundFillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Controls.Add(this.ScreenshotBackgroundSelectButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ScreenshotBackgroundImagePathTextBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(180, 24);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(583, 24);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // ScreenshotBackgroundSelectButton
            // 
            this.ScreenshotBackgroundSelectButton.BackColor = System.Drawing.Color.Gainsboro;
            this.ScreenshotBackgroundSelectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotBackgroundSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ScreenshotBackgroundSelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScreenshotBackgroundSelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ScreenshotBackgroundSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenshotBackgroundSelectButton.Location = new System.Drawing.Point(544, 0);
            this.ScreenshotBackgroundSelectButton.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.ScreenshotBackgroundSelectButton.Name = "ScreenshotBackgroundSelectButton";
            this.ScreenshotBackgroundSelectButton.Size = new System.Drawing.Size(39, 23);
            this.ScreenshotBackgroundSelectButton.TabIndex = 2;
            this.ScreenshotBackgroundSelectButton.Text = "…";
            this.ScreenshotBackgroundSelectButton.UseVisualStyleBackColor = false;
            // 
            // ScreenshotBackgroundImagePathTextBox
            // 
            this.ScreenshotBackgroundImagePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotBackgroundImagePathTextBox.Location = new System.Drawing.Point(0, 0);
            this.ScreenshotBackgroundImagePathTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ScreenshotBackgroundImagePathTextBox.Name = "ScreenshotBackgroundImagePathTextBox";
            this.ScreenshotBackgroundImagePathTextBox.Size = new System.Drawing.Size(543, 23);
            this.ScreenshotBackgroundImagePathTextBox.TabIndex = 1;
            this.ScreenshotBackgroundImagePathTextBox.TextChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // ProgramOptionGroupBox
            // 
            this.ProgramOptionGroupBox.Controls.Add(this.tableLayoutPanel5);
            this.ProgramOptionGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProgramOptionGroupBox.Location = new System.Drawing.Point(10, 2);
            this.ProgramOptionGroupBox.Name = "ProgramOptionGroupBox";
            this.ProgramOptionGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.ProgramOptionGroupBox.Size = new System.Drawing.Size(776, 126);
            this.ProgramOptionGroupBox.TabIndex = 1;
            this.ProgramOptionGroupBox.TabStop = false;
            this.ProgramOptionGroupBox.Text = "Program Options";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.AutoHideCheckBox, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.AutoHideByProcLabel, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.DetectProcessLabel, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.VersionAutoCheckLabel, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.LatestVersionLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.VersionAutoCheckCheckBox, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.DetectProcessNameTextBox, 1, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(763, 97);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // AutoHideCheckBox
            // 
            this.AutoHideCheckBox.AutoSize = true;
            this.AutoHideCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoHideCheckBox.Location = new System.Drawing.Point(184, 76);
            this.AutoHideCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoHideCheckBox.Name = "AutoHideCheckBox";
            this.AutoHideCheckBox.Size = new System.Drawing.Size(575, 16);
            this.AutoHideCheckBox.TabIndex = 8;
            this.AutoHideCheckBox.UseVisualStyleBackColor = true;
            this.AutoHideCheckBox.CheckedChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // AutoHideByProcLabel
            // 
            this.AutoHideByProcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoHideByProcLabel.Location = new System.Drawing.Point(0, 72);
            this.AutoHideByProcLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AutoHideByProcLabel.Name = "AutoHideByProcLabel";
            this.AutoHideByProcLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AutoHideByProcLabel.Size = new System.Drawing.Size(180, 24);
            this.AutoHideByProcLabel.TabIndex = 7;
            this.AutoHideByProcLabel.Text = "Autohide (by Process)";
            this.AutoHideByProcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DetectProcessLabel
            // 
            this.DetectProcessLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetectProcessLabel.Location = new System.Drawing.Point(0, 48);
            this.DetectProcessLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DetectProcessLabel.Name = "DetectProcessLabel";
            this.DetectProcessLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.DetectProcessLabel.Size = new System.Drawing.Size(180, 24);
            this.DetectProcessLabel.TabIndex = 5;
            this.DetectProcessLabel.Text = "Detect Process";
            this.DetectProcessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VersionAutoCheckLabel
            // 
            this.VersionAutoCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionAutoCheckLabel.Location = new System.Drawing.Point(0, 24);
            this.VersionAutoCheckLabel.Margin = new System.Windows.Forms.Padding(0);
            this.VersionAutoCheckLabel.Name = "VersionAutoCheckLabel";
            this.VersionAutoCheckLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.VersionAutoCheckLabel.Size = new System.Drawing.Size(180, 24);
            this.VersionAutoCheckLabel.TabIndex = 3;
            this.VersionAutoCheckLabel.Text = "Version Auto Check";
            this.VersionAutoCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(180, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label4.Size = new System.Drawing.Size(583, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "1.0.0.0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LatestVersionLabel
            // 
            this.LatestVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LatestVersionLabel.Location = new System.Drawing.Point(0, 0);
            this.LatestVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LatestVersionLabel.Name = "LatestVersionLabel";
            this.LatestVersionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.LatestVersionLabel.Size = new System.Drawing.Size(180, 24);
            this.LatestVersionLabel.TabIndex = 1;
            this.LatestVersionLabel.Text = "Latest Version";
            this.LatestVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VersionAutoCheckCheckBox
            // 
            this.VersionAutoCheckCheckBox.AutoSize = true;
            this.VersionAutoCheckCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionAutoCheckCheckBox.Location = new System.Drawing.Point(184, 28);
            this.VersionAutoCheckCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.VersionAutoCheckCheckBox.Name = "VersionAutoCheckCheckBox";
            this.VersionAutoCheckCheckBox.Size = new System.Drawing.Size(575, 16);
            this.VersionAutoCheckCheckBox.TabIndex = 4;
            this.VersionAutoCheckCheckBox.UseVisualStyleBackColor = true;
            this.VersionAutoCheckCheckBox.CheckedChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // DetectProcessNameTextBox
            // 
            this.DetectProcessNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetectProcessNameTextBox.Location = new System.Drawing.Point(180, 48);
            this.DetectProcessNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.DetectProcessNameTextBox.Name = "DetectProcessNameTextBox";
            this.DetectProcessNameTextBox.Size = new System.Drawing.Size(583, 23);
            this.DetectProcessNameTextBox.TabIndex = 6;
            this.DetectProcessNameTextBox.Text = "ffxiv.exe, ffxiv_dx11.exe";
            this.DetectProcessNameTextBox.TextChanged += new System.EventHandler(this.SettingChangeSaver);
            // 
            // OverlaysTabPage
            // 
            this.OverlaysTabPage.Controls.Add(this.overlayManageTabControl1);
            this.OverlaysTabPage.Controls.Add(this.panel2);
            this.OverlaysTabPage.Location = new System.Drawing.Point(2, 34);
            this.OverlaysTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.OverlaysTabPage.Name = "OverlaysTabPage";
            this.OverlaysTabPage.Size = new System.Drawing.Size(796, 444);
            this.OverlaysTabPage.TabIndex = 0;
            this.OverlaysTabPage.Text = "Overlays";
            this.OverlaysTabPage.UseVisualStyleBackColor = true;
            // 
            // overlayManageTabControl1
            // 
            this.overlayManageTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.overlayManageTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayManageTabControl1.ItemSize = new System.Drawing.Size(48, 220);
            this.overlayManageTabControl1.Location = new System.Drawing.Point(0, 32);
            this.overlayManageTabControl1.Multiline = true;
            this.overlayManageTabControl1.Name = "overlayManageTabControl1";
            this.overlayManageTabControl1.Padding = new System.Drawing.Point(32, 32);
            this.overlayManageTabControl1.SelectedIndex = 0;
            this.overlayManageTabControl1.Size = new System.Drawing.Size(796, 412);
            this.overlayManageTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.overlayManageTabControl1.TabIndex = 1;
            this.overlayManageTabControl1.SelectedIndexChanged += new System.EventHandler(this.OverlayManageTabControl1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.panel2.Size = new System.Drawing.Size(796, 32);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.ScreenShotButton);
            this.panel4.Controls.Add(this.MarginLabel2);
            this.panel4.Controls.Add(this.OpenDevToolButton);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.OverlayTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(222, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(572, 30);
            this.panel4.TabIndex = 3;
            // 
            // ScreenShotButton
            // 
            this.ScreenShotButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScreenShotButton.BackgroundImage")));
            this.ScreenShotButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ScreenShotButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScreenShotButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ScreenShotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenShotButton.Location = new System.Drawing.Point(446, 0);
            this.ScreenShotButton.Margin = new System.Windows.Forms.Padding(0);
            this.ScreenShotButton.Name = "ScreenShotButton";
            this.ScreenShotButton.Size = new System.Drawing.Size(30, 30);
            this.ScreenShotButton.TabIndex = 7;
            this.ScreenShotButton.UseVisualStyleBackColor = true;
            // 
            // MarginLabel2
            // 
            this.MarginLabel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.MarginLabel2.Location = new System.Drawing.Point(476, 0);
            this.MarginLabel2.Name = "MarginLabel2";
            this.MarginLabel2.Size = new System.Drawing.Size(2, 30);
            this.MarginLabel2.TabIndex = 6;
            // 
            // OpenDevToolButton
            // 
            this.OpenDevToolButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenDevToolButton.BackgroundImage")));
            this.OpenDevToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenDevToolButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.OpenDevToolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OpenDevToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenDevToolButton.Location = new System.Drawing.Point(478, 0);
            this.OpenDevToolButton.Margin = new System.Windows.Forms.Padding(0);
            this.OpenDevToolButton.Name = "OpenDevToolButton";
            this.OpenDevToolButton.Size = new System.Drawing.Size(30, 30);
            this.OpenDevToolButton.TabIndex = 9;
            this.OpenDevToolButton.UseVisualStyleBackColor = true;
            this.OpenDevToolButton.Click += new System.EventHandler(this.OpenDevToolButton_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(508, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 30);
            this.label3.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(510, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ReloadSelectedOverlayButtonClicked);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(540, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(2, 30);
            this.label13.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(542, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CloseSelectedOverlayButtonClicked);
            // 
            // OverlayTitle
            // 
            this.OverlayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayTitle.Location = new System.Drawing.Point(0, 0);
            this.OverlayTitle.Name = "OverlayTitle";
            this.OverlayTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.OverlayTitle.Size = new System.Drawing.Size(572, 30);
            this.OverlayTitle.TabIndex = 3;
            this.OverlayTitle.Text = "Please Select Overlay";
            this.OverlayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.overlayAddButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(220, 30);
            this.panel3.TabIndex = 2;
            // 
            // overlayAddButton
            // 
            this.overlayAddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("overlayAddButton.BackgroundImage")));
            this.overlayAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.overlayAddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.overlayAddButton.FlatAppearance.BorderSize = 0;
            this.overlayAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overlayAddButton.Location = new System.Drawing.Point(2, 2);
            this.overlayAddButton.Margin = new System.Windows.Forms.Padding(0);
            this.overlayAddButton.Name = "overlayAddButton";
            this.overlayAddButton.Size = new System.Drawing.Size(26, 26);
            this.overlayAddButton.TabIndex = 0;
            this.overlayAddButton.UseVisualStyleBackColor = true;
            this.overlayAddButton.Click += new System.EventHandler(this.OverlayAddButton_Click);
            // 
            // OverlayControlTabPage
            // 
            this.OverlayControlTabPage.Controls.Add(this.OverlaysTabPage);
            this.OverlayControlTabPage.Controls.Add(this.SettingsTabPage);
            this.OverlayControlTabPage.Controls.Add(this.PluginsTabPage);
            this.OverlayControlTabPage.Controls.Add(this.LogTabPage);
            this.OverlayControlTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayControlTabPage.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.OverlayControlTabPage.ItemSize = new System.Drawing.Size(10, 32);
            this.OverlayControlTabPage.Location = new System.Drawing.Point(0, 0);
            this.OverlayControlTabPage.Multiline = true;
            this.OverlayControlTabPage.Name = "OverlayControlTabPage";
            this.OverlayControlTabPage.Padding = new System.Drawing.Point(18, 0);
            this.OverlayControlTabPage.SelectedIndex = 0;
            this.OverlayControlTabPage.Size = new System.Drawing.Size(800, 480);
            this.OverlayControlTabPage.TabIndex = 0;
            // 
            // OverlayController
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.OverlayControlTabPage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "OverlayController";
            this.Size = new System.Drawing.Size(800, 480);
            this.Load += new System.EventHandler(this.OverlayController_Load);
            this.LogTabPage.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.SettingsTabPage.ResumeLayout(false);
            this.ScreenShotSettingGroupbox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenshotMargin)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ProgramOptionGroupBox.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.OverlaysTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.OverlayControlTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenBackgroundDialog;
        private System.Windows.Forms.FolderBrowserDialog ScreenshotSavePathSelectDialog;
        private System.Windows.Forms.TabPage LogTabPage;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button ClearLogsButton;
        private System.Windows.Forms.Label MarginLabel1;
        private System.Windows.Forms.Button CopyAllLogsButton;
        private System.Windows.Forms.TabPage PluginsTabPage;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.GroupBox ScreenShotSettingGroupbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox ScreenshotSavePathTextBox;
        private System.Windows.Forms.Button ScreenshotSavePathSelectButton;
        private System.Windows.Forms.Label MarginLabel;
        private System.Windows.Forms.Label AutoClippingLabel;
        private System.Windows.Forms.Label FillModeLabel;
        private System.Windows.Forms.Label BackgroundImageLabel;
        private System.Windows.Forms.Label SavePathLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ScreenshotMargin;
        private System.Windows.Forms.CheckBox AutoClippingCheckBox;
        private System.Windows.Forms.ComboBox ScreenshotBackgroundFillModeComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button ScreenshotBackgroundSelectButton;
        private System.Windows.Forms.TextBox ScreenshotBackgroundImagePathTextBox;
        private System.Windows.Forms.GroupBox ProgramOptionGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox AutoHideCheckBox;
        private System.Windows.Forms.Label AutoHideByProcLabel;
        private System.Windows.Forms.Label DetectProcessLabel;
        private System.Windows.Forms.Label VersionAutoCheckLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LatestVersionLabel;
        private System.Windows.Forms.CheckBox VersionAutoCheckCheckBox;
        private System.Windows.Forms.TextBox DetectProcessNameTextBox;
        private System.Windows.Forms.TabPage OverlaysTabPage;
        public OverlayManageTabControl overlayManageTabControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ScreenShotButton;
        private System.Windows.Forms.Label MarginLabel2;
        private System.Windows.Forms.Button OpenDevToolButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label OverlayTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button overlayAddButton;
        public OverlayTabControl OverlayControlTabPage;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
