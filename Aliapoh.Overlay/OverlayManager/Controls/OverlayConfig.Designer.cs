namespace Aliapoh.Overlay
{
    partial class OverlayConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayConfig));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SiteURL = new System.Windows.Forms.TextBox();
            this.justPaddingLabel1 = new System.Windows.Forms.Label();
            this.HTMLFileSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.justPaddingLabel2 = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SubTableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.OverlayWidth = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.OverlayHeight = new System.Windows.Forms.NumericUpDown();
            this.SubTableLayout3 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.OverlayX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.OverlayY = new System.Windows.Forms.NumericUpDown();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.OverlayEnableBeforeLogLineRead = new System.Windows.Forms.CheckBox();
            this.EnableBeforeLogLineReadLabel = new System.Windows.Forms.Label();
            this.SubTableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.OverlayName = new System.Windows.Forms.TextBox();
            this.OverlayNameChangeButton = new System.Windows.Forms.Button();
            this.OverlayNameLabel = new System.Windows.Forms.Label();
            this.HotkeyTypeLabel = new System.Windows.Forms.Label();
            this.GlobalHotkeyLabel = new System.Windows.Forms.Label();
            this.OverlayGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.SubTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.OverlayUpdaterate = new System.Windows.Forms.NumericUpDown();
            this.EnableGlobalHotkeyLabel = new System.Windows.Forms.Label();
            this.DataUpdateRateLabel = new System.Windows.Forms.Label();
            this.MaxframelateLabel = new System.Windows.Forms.Label();
            this.OverlayLock = new System.Windows.Forms.CheckBox();
            this.OverlayClickthru = new System.Windows.Forms.CheckBox();
            this.ClickthruLabel = new System.Windows.Forms.Label();
            this.ShowOverlayLabel = new System.Windows.Forms.Label();
            this.OverlayShow = new System.Windows.Forms.CheckBox();
            this.LockOverlayLabel = new System.Windows.Forms.Label();
            this.SubTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxframelateDescLabel = new System.Windows.Forms.Label();
            this.OverlayFramerate = new System.Windows.Forms.NumericUpDown();
            this.OverlayGlobalHotkeyInput = new System.Windows.Forms.TextBox();
            this.overlayGlobalHotkeyType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SubTableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayHeight)).BeginInit();
            this.SubTableLayout3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayY)).BeginInit();
            this.SubTableLayoutPanel5.SuspendLayout();
            this.SubTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayUpdaterate)).BeginInit();
            this.SubTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayFramerate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.justPaddingLabel1);
            this.panel1.Controls.Add(this.HTMLFileSelectButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 29);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.SiteURL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(46, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(509, 29);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.TextboxPadderClicked);
            // 
            // SiteURL
            // 
            this.SiteURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SiteURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SiteURL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SiteURL.Location = new System.Drawing.Point(5, 5);
            this.SiteURL.Name = "SiteURL";
            this.SiteURL.Size = new System.Drawing.Size(497, 18);
            this.SiteURL.TabIndex = 0;
            this.SiteURL.Text = "about:blank";
            // 
            // justPaddingLabel1
            // 
            this.justPaddingLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.justPaddingLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.justPaddingLabel1.Location = new System.Drawing.Point(555, 0);
            this.justPaddingLabel1.Name = "justPaddingLabel1";
            this.justPaddingLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.justPaddingLabel1.Size = new System.Drawing.Size(2, 29);
            this.justPaddingLabel1.TabIndex = 3;
            this.justPaddingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HTMLFileSelectButton
            // 
            this.HTMLFileSelectButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.HTMLFileSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HTMLFileSelectButton.Location = new System.Drawing.Point(557, 0);
            this.HTMLFileSelectButton.Name = "HTMLFileSelectButton";
            this.HTMLFileSelectButton.Size = new System.Drawing.Size(43, 29);
            this.HTMLFileSelectButton.TabIndex = 2;
            this.HTMLFileSelectButton.Text = "…";
            this.HTMLFileSelectButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(46, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // justPaddingLabel2
            // 
            this.justPaddingLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.justPaddingLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.justPaddingLabel2.Location = new System.Drawing.Point(0, 29);
            this.justPaddingLabel2.Name = "justPaddingLabel2";
            this.justPaddingLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.justPaddingLabel2.Size = new System.Drawing.Size(600, 2);
            this.justPaddingLabel2.TabIndex = 1;
            this.justPaddingLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.SubTableLayoutPanel4, 1, 11);
            this.MainTableLayoutPanel.Controls.Add(this.SubTableLayout3, 1, 10);
            this.MainTableLayoutPanel.Controls.Add(this.SizeLabel, 0, 11);
            this.MainTableLayoutPanel.Controls.Add(this.PositionLabel, 0, 10);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayEnableBeforeLogLineRead, 1, 9);
            this.MainTableLayoutPanel.Controls.Add(this.EnableBeforeLogLineReadLabel, 0, 9);
            this.MainTableLayoutPanel.Controls.Add(this.SubTableLayoutPanel5, 1, 0);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayNameLabel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.HotkeyTypeLabel, 0, 8);
            this.MainTableLayoutPanel.Controls.Add(this.GlobalHotkeyLabel, 0, 7);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayGlobalHotkey, 1, 6);
            this.MainTableLayoutPanel.Controls.Add(this.SubTableLayoutPanel2, 1, 5);
            this.MainTableLayoutPanel.Controls.Add(this.EnableGlobalHotkeyLabel, 0, 6);
            this.MainTableLayoutPanel.Controls.Add(this.DataUpdateRateLabel, 0, 5);
            this.MainTableLayoutPanel.Controls.Add(this.MaxframelateLabel, 0, 4);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayLock, 1, 3);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayClickthru, 1, 2);
            this.MainTableLayoutPanel.Controls.Add(this.ClickthruLabel, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.ShowOverlayLabel, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayShow, 1, 1);
            this.MainTableLayoutPanel.Controls.Add(this.LockOverlayLabel, 0, 3);
            this.MainTableLayoutPanel.Controls.Add(this.SubTableLayoutPanel1, 1, 4);
            this.MainTableLayoutPanel.Controls.Add(this.OverlayGlobalHotkeyInput, 1, 7);
            this.MainTableLayoutPanel.Controls.Add(this.overlayGlobalHotkeyType, 1, 8);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 31);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 13;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(600, 369);
            this.MainTableLayoutPanel.TabIndex = 2;
            // 
            // SubTableLayoutPanel4
            // 
            this.SubTableLayoutPanel4.ColumnCount = 7;
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SubTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SubTableLayoutPanel4.Controls.Add(this.label20, 0, 0);
            this.SubTableLayoutPanel4.Controls.Add(this.OverlayWidth, 0, 0);
            this.SubTableLayoutPanel4.Controls.Add(this.WidthLabel, 0, 0);
            this.SubTableLayoutPanel4.Controls.Add(this.HeightLabel, 3, 0);
            this.SubTableLayoutPanel4.Controls.Add(this.label23, 5, 0);
            this.SubTableLayoutPanel4.Controls.Add(this.OverlayHeight, 4, 0);
            this.SubTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubTableLayoutPanel4.Location = new System.Drawing.Point(200, 264);
            this.SubTableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.SubTableLayoutPanel4.Name = "SubTableLayoutPanel4";
            this.SubTableLayoutPanel4.RowCount = 1;
            this.SubTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel4.Size = new System.Drawing.Size(400, 24);
            this.SubTableLayoutPanel4.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(150, 0);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label20.Size = new System.Drawing.Size(30, 24);
            this.label20.TabIndex = 17;
            this.label20.Text = "px";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OverlayWidth
            // 
            this.OverlayWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayWidth.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.OverlayWidth.Location = new System.Drawing.Point(50, 0);
            this.OverlayWidth.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.OverlayWidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.OverlayWidth.Name = "OverlayWidth";
            this.OverlayWidth.Size = new System.Drawing.Size(100, 23);
            this.OverlayWidth.TabIndex = 16;
            this.OverlayWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.OverlayWidth.ValueChanged += new System.EventHandler(this.OverlayWidth_ValueChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WidthLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WidthLabel.Location = new System.Drawing.Point(0, 0);
            this.WidthLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(50, 24);
            this.WidthLabel.TabIndex = 15;
            this.WidthLabel.Text = "Width";
            this.WidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HeightLabel
            // 
            this.HeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeightLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HeightLabel.Location = new System.Drawing.Point(180, 0);
            this.HeightLabel.Margin = new System.Windows.Forms.Padding(0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(50, 24);
            this.HeightLabel.TabIndex = 18;
            this.HeightLabel.Text = "Height";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(330, 0);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 24);
            this.label23.TabIndex = 19;
            this.label23.Text = "px";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OverlayHeight
            // 
            this.OverlayHeight.Location = new System.Drawing.Point(230, 0);
            this.OverlayHeight.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.OverlayHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.OverlayHeight.Name = "OverlayHeight";
            this.OverlayHeight.Size = new System.Drawing.Size(100, 23);
            this.OverlayHeight.TabIndex = 20;
            this.OverlayHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.OverlayHeight.ValueChanged += new System.EventHandler(this.OverlayHeight_ValueChanged);
            // 
            // SubTableLayout3
            // 
            this.SubTableLayout3.ColumnCount = 7;
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SubTableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SubTableLayout3.Controls.Add(this.label17, 0, 0);
            this.SubTableLayout3.Controls.Add(this.OverlayX, 0, 0);
            this.SubTableLayout3.Controls.Add(this.label16, 0, 0);
            this.SubTableLayout3.Controls.Add(this.label18, 3, 0);
            this.SubTableLayout3.Controls.Add(this.label19, 5, 0);
            this.SubTableLayout3.Controls.Add(this.OverlayY, 4, 0);
            this.SubTableLayout3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubTableLayout3.Location = new System.Drawing.Point(200, 240);
            this.SubTableLayout3.Margin = new System.Windows.Forms.Padding(0);
            this.SubTableLayout3.Name = "SubTableLayout3";
            this.SubTableLayout3.RowCount = 1;
            this.SubTableLayout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayout3.Size = new System.Drawing.Size(400, 24);
            this.SubTableLayout3.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(150, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label17.Size = new System.Drawing.Size(30, 24);
            this.label17.TabIndex = 17;
            this.label17.Text = "px";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OverlayX
            // 
            this.OverlayX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayX.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.OverlayX.Location = new System.Drawing.Point(50, 0);
            this.OverlayX.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.OverlayX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.OverlayX.Name = "OverlayX";
            this.OverlayX.Size = new System.Drawing.Size(100, 23);
            this.OverlayX.TabIndex = 16;
            this.OverlayX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.OverlayX.ValueChanged += new System.EventHandler(this.OverlayX_ValueChanged);
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 24);
            this.label16.TabIndex = 15;
            this.label16.Text = "X";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(180, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 24);
            this.label18.TabIndex = 18;
            this.label18.Text = "Y";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(330, 0);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 24);
            this.label19.TabIndex = 19;
            this.label19.Text = "px";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OverlayY
            // 
            this.OverlayY.Location = new System.Drawing.Point(230, 0);
            this.OverlayY.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.OverlayY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.OverlayY.Name = "OverlayY";
            this.OverlayY.Size = new System.Drawing.Size(100, 23);
            this.OverlayY.TabIndex = 20;
            this.OverlayY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.OverlayY.ValueChanged += new System.EventHandler(this.OverlayY_ValueChanged);
            // 
            // SizeLabel
            // 
            this.SizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SizeLabel.Location = new System.Drawing.Point(0, 264);
            this.SizeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SizeLabel.Size = new System.Drawing.Size(200, 24);
            this.SizeLabel.TabIndex = 27;
            this.SizeLabel.Text = "Size";
            this.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PositionLabel
            // 
            this.PositionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PositionLabel.Location = new System.Drawing.Point(0, 240);
            this.PositionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.PositionLabel.Size = new System.Drawing.Size(200, 24);
            this.PositionLabel.TabIndex = 26;
            this.PositionLabel.Text = "Position";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverlayEnableBeforeLogLineRead
            // 
            this.OverlayEnableBeforeLogLineRead.AutoSize = true;
            this.OverlayEnableBeforeLogLineRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayEnableBeforeLogLineRead.Location = new System.Drawing.Point(203, 219);
            this.OverlayEnableBeforeLogLineRead.Name = "OverlayEnableBeforeLogLineRead";
            this.OverlayEnableBeforeLogLineRead.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OverlayEnableBeforeLogLineRead.Size = new System.Drawing.Size(394, 18);
            this.OverlayEnableBeforeLogLineRead.TabIndex = 25;
            this.OverlayEnableBeforeLogLineRead.UseVisualStyleBackColor = true;
            this.OverlayEnableBeforeLogLineRead.CheckedChanged += new System.EventHandler(this.OverlayEnableBeforeLogLineRead_CheckedChanged);
            // 
            // EnableBeforeLogLineReadLabel
            // 
            this.EnableBeforeLogLineReadLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableBeforeLogLineReadLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EnableBeforeLogLineReadLabel.Location = new System.Drawing.Point(0, 216);
            this.EnableBeforeLogLineReadLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EnableBeforeLogLineReadLabel.Name = "EnableBeforeLogLineReadLabel";
            this.EnableBeforeLogLineReadLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.EnableBeforeLogLineReadLabel.Size = new System.Drawing.Size(200, 24);
            this.EnableBeforeLogLineReadLabel.TabIndex = 24;
            this.EnableBeforeLogLineReadLabel.Text = "Enable beforeLogLineRead";
            this.EnableBeforeLogLineReadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubTableLayoutPanel5
            // 
            this.SubTableLayoutPanel5.ColumnCount = 2;
            this.SubTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.SubTableLayoutPanel5.Controls.Add(this.OverlayName, 0, 0);
            this.SubTableLayoutPanel5.Controls.Add(this.OverlayNameChangeButton, 1, 0);
            this.SubTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubTableLayoutPanel5.Location = new System.Drawing.Point(200, 0);
            this.SubTableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.SubTableLayoutPanel5.Name = "SubTableLayoutPanel5";
            this.SubTableLayoutPanel5.RowCount = 1;
            this.SubTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel5.Size = new System.Drawing.Size(400, 24);
            this.SubTableLayoutPanel5.TabIndex = 23;
            // 
            // OverlayName
            // 
            this.OverlayName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayName.Location = new System.Drawing.Point(0, 0);
            this.OverlayName.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.OverlayName.Name = "OverlayName";
            this.OverlayName.Size = new System.Drawing.Size(375, 23);
            this.OverlayName.TabIndex = 20;
            // 
            // OverlayNameChangeButton
            // 
            this.OverlayNameChangeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OverlayNameChangeButton.BackgroundImage")));
            this.OverlayNameChangeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OverlayNameChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverlayNameChangeButton.Location = new System.Drawing.Point(376, 0);
            this.OverlayNameChangeButton.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayNameChangeButton.Name = "OverlayNameChangeButton";
            this.OverlayNameChangeButton.Size = new System.Drawing.Size(24, 23);
            this.OverlayNameChangeButton.TabIndex = 0;
            this.OverlayNameChangeButton.UseVisualStyleBackColor = true;
            this.OverlayNameChangeButton.Click += new System.EventHandler(this.OverlayNameChange_Click);
            // 
            // OverlayNameLabel
            // 
            this.OverlayNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayNameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OverlayNameLabel.Location = new System.Drawing.Point(0, 0);
            this.OverlayNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayNameLabel.Name = "OverlayNameLabel";
            this.OverlayNameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.OverlayNameLabel.Size = new System.Drawing.Size(200, 24);
            this.OverlayNameLabel.TabIndex = 22;
            this.OverlayNameLabel.Text = "Overlay name";
            this.OverlayNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HotkeyTypeLabel
            // 
            this.HotkeyTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotkeyTypeLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HotkeyTypeLabel.Location = new System.Drawing.Point(0, 192);
            this.HotkeyTypeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.HotkeyTypeLabel.Name = "HotkeyTypeLabel";
            this.HotkeyTypeLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.HotkeyTypeLabel.Size = new System.Drawing.Size(200, 24);
            this.HotkeyTypeLabel.TabIndex = 20;
            this.HotkeyTypeLabel.Text = "Hotkey Type";
            this.HotkeyTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GlobalHotkeyLabel
            // 
            this.GlobalHotkeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GlobalHotkeyLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GlobalHotkeyLabel.Location = new System.Drawing.Point(0, 168);
            this.GlobalHotkeyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.GlobalHotkeyLabel.Name = "GlobalHotkeyLabel";
            this.GlobalHotkeyLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.GlobalHotkeyLabel.Size = new System.Drawing.Size(200, 24);
            this.GlobalHotkeyLabel.TabIndex = 18;
            this.GlobalHotkeyLabel.Text = "Global hotkey";
            this.GlobalHotkeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverlayGlobalHotkey
            // 
            this.OverlayGlobalHotkey.AutoSize = true;
            this.OverlayGlobalHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayGlobalHotkey.Location = new System.Drawing.Point(203, 147);
            this.OverlayGlobalHotkey.Name = "OverlayGlobalHotkey";
            this.OverlayGlobalHotkey.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OverlayGlobalHotkey.Size = new System.Drawing.Size(394, 18);
            this.OverlayGlobalHotkey.TabIndex = 17;
            this.OverlayGlobalHotkey.UseVisualStyleBackColor = true;
            this.OverlayGlobalHotkey.CheckedChanged += new System.EventHandler(this.OverlayGlobalHotkey_CheckedChanged);
            // 
            // SubTableLayoutPanel2
            // 
            this.SubTableLayoutPanel2.ColumnCount = 2;
            this.SubTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.SubTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel2.Controls.Add(this.label9, 1, 0);
            this.SubTableLayoutPanel2.Controls.Add(this.OverlayUpdaterate, 0, 0);
            this.SubTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubTableLayoutPanel2.Location = new System.Drawing.Point(200, 120);
            this.SubTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.SubTableLayoutPanel2.Name = "SubTableLayoutPanel2";
            this.SubTableLayoutPanel2.RowCount = 1;
            this.SubTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel2.Size = new System.Drawing.Size(400, 24);
            this.SubTableLayoutPanel2.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(80, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(320, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "ms";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OverlayUpdaterate
            // 
            this.OverlayUpdaterate.Enabled = false;
            this.OverlayUpdaterate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.OverlayUpdaterate.Location = new System.Drawing.Point(0, 0);
            this.OverlayUpdaterate.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayUpdaterate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.OverlayUpdaterate.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.OverlayUpdaterate.Name = "OverlayUpdaterate";
            this.OverlayUpdaterate.Size = new System.Drawing.Size(80, 23);
            this.OverlayUpdaterate.TabIndex = 0;
            this.OverlayUpdaterate.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // EnableGlobalHotkeyLabel
            // 
            this.EnableGlobalHotkeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableGlobalHotkeyLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EnableGlobalHotkeyLabel.Location = new System.Drawing.Point(0, 144);
            this.EnableGlobalHotkeyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EnableGlobalHotkeyLabel.Name = "EnableGlobalHotkeyLabel";
            this.EnableGlobalHotkeyLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.EnableGlobalHotkeyLabel.Size = new System.Drawing.Size(200, 24);
            this.EnableGlobalHotkeyLabel.TabIndex = 14;
            this.EnableGlobalHotkeyLabel.Text = "Enable global hotkey";
            this.EnableGlobalHotkeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataUpdateRateLabel
            // 
            this.DataUpdateRateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataUpdateRateLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DataUpdateRateLabel.Location = new System.Drawing.Point(0, 120);
            this.DataUpdateRateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DataUpdateRateLabel.Name = "DataUpdateRateLabel";
            this.DataUpdateRateLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.DataUpdateRateLabel.Size = new System.Drawing.Size(200, 24);
            this.DataUpdateRateLabel.TabIndex = 12;
            this.DataUpdateRateLabel.Text = "Data update rate";
            this.DataUpdateRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MaxframelateLabel
            // 
            this.MaxframelateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxframelateLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaxframelateLabel.Location = new System.Drawing.Point(0, 96);
            this.MaxframelateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MaxframelateLabel.Name = "MaxframelateLabel";
            this.MaxframelateLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MaxframelateLabel.Size = new System.Drawing.Size(200, 24);
            this.MaxframelateLabel.TabIndex = 10;
            this.MaxframelateLabel.Text = "Max framerate";
            this.MaxframelateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverlayLock
            // 
            this.OverlayLock.AutoSize = true;
            this.OverlayLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayLock.Location = new System.Drawing.Point(203, 75);
            this.OverlayLock.Name = "OverlayLock";
            this.OverlayLock.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OverlayLock.Size = new System.Drawing.Size(394, 18);
            this.OverlayLock.TabIndex = 9;
            this.OverlayLock.UseVisualStyleBackColor = true;
            this.OverlayLock.CheckedChanged += new System.EventHandler(this.OverlayLock_CheckedChanged);
            // 
            // OverlayClickthru
            // 
            this.OverlayClickthru.AutoSize = true;
            this.OverlayClickthru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayClickthru.Location = new System.Drawing.Point(203, 51);
            this.OverlayClickthru.Name = "OverlayClickthru";
            this.OverlayClickthru.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OverlayClickthru.Size = new System.Drawing.Size(394, 18);
            this.OverlayClickthru.TabIndex = 4;
            this.OverlayClickthru.UseVisualStyleBackColor = true;
            this.OverlayClickthru.CheckedChanged += new System.EventHandler(this.OverlayClickthru_CheckedChanged);
            // 
            // ClickthruLabel
            // 
            this.ClickthruLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClickthruLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ClickthruLabel.Location = new System.Drawing.Point(0, 48);
            this.ClickthruLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ClickthruLabel.Name = "ClickthruLabel";
            this.ClickthruLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.ClickthruLabel.Size = new System.Drawing.Size(200, 24);
            this.ClickthruLabel.TabIndex = 3;
            this.ClickthruLabel.Text = "Clickthru";
            this.ClickthruLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ShowOverlayLabel
            // 
            this.ShowOverlayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowOverlayLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ShowOverlayLabel.Location = new System.Drawing.Point(0, 24);
            this.ShowOverlayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ShowOverlayLabel.Name = "ShowOverlayLabel";
            this.ShowOverlayLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.ShowOverlayLabel.Size = new System.Drawing.Size(200, 24);
            this.ShowOverlayLabel.TabIndex = 1;
            this.ShowOverlayLabel.Text = "Show Overlay";
            this.ShowOverlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OverlayShow
            // 
            this.OverlayShow.AutoSize = true;
            this.OverlayShow.Checked = true;
            this.OverlayShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OverlayShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayShow.Location = new System.Drawing.Point(203, 27);
            this.OverlayShow.Name = "OverlayShow";
            this.OverlayShow.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OverlayShow.Size = new System.Drawing.Size(394, 18);
            this.OverlayShow.TabIndex = 2;
            this.OverlayShow.UseVisualStyleBackColor = true;
            this.OverlayShow.CheckedChanged += new System.EventHandler(this.OverlayShow_CheckedChanged);
            // 
            // LockOverlayLabel
            // 
            this.LockOverlayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LockOverlayLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LockOverlayLabel.Location = new System.Drawing.Point(0, 72);
            this.LockOverlayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LockOverlayLabel.Name = "LockOverlayLabel";
            this.LockOverlayLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.LockOverlayLabel.Size = new System.Drawing.Size(200, 24);
            this.LockOverlayLabel.TabIndex = 5;
            this.LockOverlayLabel.Text = "Lock Overlay";
            this.LockOverlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubTableLayoutPanel1
            // 
            this.SubTableLayoutPanel1.ColumnCount = 2;
            this.SubTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.SubTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel1.Controls.Add(this.MaxframelateDescLabel, 1, 0);
            this.SubTableLayoutPanel1.Controls.Add(this.OverlayFramerate, 0, 0);
            this.SubTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubTableLayoutPanel1.Location = new System.Drawing.Point(200, 96);
            this.SubTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.SubTableLayoutPanel1.Name = "SubTableLayoutPanel1";
            this.SubTableLayoutPanel1.RowCount = 1;
            this.SubTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubTableLayoutPanel1.Size = new System.Drawing.Size(400, 24);
            this.SubTableLayoutPanel1.TabIndex = 15;
            // 
            // MaxframelateDescLabel
            // 
            this.MaxframelateDescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxframelateDescLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaxframelateDescLabel.Location = new System.Drawing.Point(80, 0);
            this.MaxframelateDescLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MaxframelateDescLabel.Name = "MaxframelateDescLabel";
            this.MaxframelateDescLabel.Size = new System.Drawing.Size(320, 24);
            this.MaxframelateDescLabel.TabIndex = 6;
            this.MaxframelateDescLabel.Text = "fps (※ This value required restart)";
            this.MaxframelateDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.OverlayFramerate.Size = new System.Drawing.Size(80, 23);
            this.OverlayFramerate.TabIndex = 0;
            this.OverlayFramerate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.OverlayFramerate.ValueChanged += new System.EventHandler(this.OverlayFramerate_ValueChanged);
            // 
            // OverlayGlobalHotkeyInput
            // 
            this.OverlayGlobalHotkeyInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayGlobalHotkeyInput.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.OverlayGlobalHotkeyInput.Location = new System.Drawing.Point(200, 168);
            this.OverlayGlobalHotkeyInput.Margin = new System.Windows.Forms.Padding(0);
            this.OverlayGlobalHotkeyInput.Name = "OverlayGlobalHotkeyInput";
            this.OverlayGlobalHotkeyInput.Size = new System.Drawing.Size(400, 23);
            this.OverlayGlobalHotkeyInput.TabIndex = 19;
            this.OverlayGlobalHotkeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OverlayGlobalHotkeyInput_KeyDown);
            this.OverlayGlobalHotkeyInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OverlayGlobalHotkeyInput_KeyPress);
            this.OverlayGlobalHotkeyInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OverlayGlobalHotkeyInput_KeyUp);
            // 
            // overlayGlobalHotkeyType
            // 
            this.overlayGlobalHotkeyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayGlobalHotkeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.overlayGlobalHotkeyType.FormattingEnabled = true;
            this.overlayGlobalHotkeyType.Location = new System.Drawing.Point(200, 192);
            this.overlayGlobalHotkeyType.Margin = new System.Windows.Forms.Padding(0);
            this.overlayGlobalHotkeyType.Name = "overlayGlobalHotkeyType";
            this.overlayGlobalHotkeyType.Size = new System.Drawing.Size(400, 23);
            this.overlayGlobalHotkeyType.TabIndex = 21;
            // 
            // OverlayConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.justPaddingLabel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OverlayConfig";
            this.Size = new System.Drawing.Size(600, 400);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.SubTableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverlayWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayHeight)).EndInit();
            this.SubTableLayout3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverlayX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayY)).EndInit();
            this.SubTableLayoutPanel5.ResumeLayout(false);
            this.SubTableLayoutPanel5.PerformLayout();
            this.SubTableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverlayUpdaterate)).EndInit();
            this.SubTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverlayFramerate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button HTMLFileSelectButton;
        private System.Windows.Forms.Label justPaddingLabel1;
        private System.Windows.Forms.Label justPaddingLabel2;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Label ShowOverlayLabel;
        private System.Windows.Forms.CheckBox OverlayShow;
        private System.Windows.Forms.CheckBox OverlayClickthru;
        private System.Windows.Forms.Label ClickthruLabel;
        private System.Windows.Forms.Label LockOverlayLabel;
        private System.Windows.Forms.Label EnableGlobalHotkeyLabel;
        private System.Windows.Forms.Label DataUpdateRateLabel;
        private System.Windows.Forms.Label MaxframelateLabel;
        private System.Windows.Forms.CheckBox OverlayLock;
        private System.Windows.Forms.TableLayoutPanel SubTableLayoutPanel1;
        private System.Windows.Forms.Label MaxframelateDescLabel;
        private System.Windows.Forms.NumericUpDown OverlayFramerate;
        private System.Windows.Forms.TableLayoutPanel SubTableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown OverlayUpdaterate;
        private System.Windows.Forms.CheckBox OverlayGlobalHotkey;
        private System.Windows.Forms.Label GlobalHotkeyLabel;
        private System.Windows.Forms.TextBox OverlayGlobalHotkeyInput;
        private System.Windows.Forms.Label HotkeyTypeLabel;
        private System.Windows.Forms.ComboBox overlayGlobalHotkeyType;
        private System.Windows.Forms.Label OverlayNameLabel;
        private System.Windows.Forms.TableLayoutPanel SubTableLayoutPanel5;
        private System.Windows.Forms.Button OverlayNameChangeButton;
        private System.Windows.Forms.TextBox OverlayName;
        private System.Windows.Forms.Label EnableBeforeLogLineReadLabel;
        public System.Windows.Forms.TextBox SiteURL;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TableLayoutPanel SubTableLayout3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown OverlayX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown OverlayY;
        private System.Windows.Forms.TableLayoutPanel SubTableLayoutPanel4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown OverlayWidth;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown OverlayHeight;
        public System.Windows.Forms.CheckBox OverlayEnableBeforeLogLineRead;
    }
}
