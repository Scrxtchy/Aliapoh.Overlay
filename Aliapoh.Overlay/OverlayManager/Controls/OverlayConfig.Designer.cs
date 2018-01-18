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
            this.siteURL = new System.Windows.Forms.TextBox();
            this.justPaddingLabel1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.justPaddingLabel2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.overlayWidth = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.overlayHeight = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.overlayX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.overlayY = new System.Windows.Forms.NumericUpDown();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.overlayEnableBeforeLogLineRead = new System.Windows.Forms.CheckBox();
            this.EnableBeforeLogLineReadLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.overlayName = new System.Windows.Forms.TextBox();
            this.overlayNameChange = new System.Windows.Forms.Button();
            this.OverlayNameLabel = new System.Windows.Forms.Label();
            this.HotkeyTypeLabel = new System.Windows.Forms.Label();
            this.GlobalHotkeyLabel = new System.Windows.Forms.Label();
            this.overlayGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.overlayUpdateRate = new System.Windows.Forms.NumericUpDown();
            this.EnableGlobalHotkeyLabel = new System.Windows.Forms.Label();
            this.DataUpdateRateLabel = new System.Windows.Forms.Label();
            this.MaxframelateLabel = new System.Windows.Forms.Label();
            this.overlayLock = new System.Windows.Forms.CheckBox();
            this.overlayClickthru = new System.Windows.Forms.CheckBox();
            this.ClickthruLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.overlayShow = new System.Windows.Forms.CheckBox();
            this.LockOverlayLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxframelateDescLabel = new System.Windows.Forms.Label();
            this.overlayFramerate = new System.Windows.Forms.NumericUpDown();
            this.overlayGlobalHotkeyInput = new System.Windows.Forms.TextBox();
            this.overlayGlobalHotkeyType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlayWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayHeight)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlayX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayY)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlayUpdateRate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlayFramerate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.justPaddingLabel1);
            this.panel1.Controls.Add(this.button1);
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
            this.panel2.Controls.Add(this.siteURL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(46, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(509, 29);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.TextboxPadderClicked);
            // 
            // siteURL
            // 
            this.siteURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.siteURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siteURL.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.siteURL.Location = new System.Drawing.Point(5, 5);
            this.siteURL.Name = "siteURL";
            this.siteURL.Size = new System.Drawing.Size(497, 18);
            this.siteURL.TabIndex = 0;
            this.siteURL.Text = "about:blank";
            // 
            // justPaddingLabel1
            // 
            this.justPaddingLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.justPaddingLabel1.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.justPaddingLabel1.Location = new System.Drawing.Point(555, 0);
            this.justPaddingLabel1.Name = "justPaddingLabel1";
            this.justPaddingLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.justPaddingLabel1.Size = new System.Drawing.Size(2, 29);
            this.justPaddingLabel1.TabIndex = 3;
            this.justPaddingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(557, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.justPaddingLabel2.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.justPaddingLabel2.Location = new System.Drawing.Point(0, 29);
            this.justPaddingLabel2.Name = "justPaddingLabel2";
            this.justPaddingLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.justPaddingLabel2.Size = new System.Drawing.Size(600, 2);
            this.justPaddingLabel2.TabIndex = 1;
            this.justPaddingLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.SizeLabel, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.PositionLabel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.overlayEnableBeforeLogLineRead, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.EnableBeforeLogLineReadLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OverlayNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.HotkeyTypeLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.GlobalHotkeyLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.overlayGlobalHotkey, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.EnableGlobalHotkeyLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.DataUpdateRateLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.MaxframelateLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.overlayLock, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.overlayClickthru, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ClickthruLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.overlayShow, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LockOverlayLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.overlayGlobalHotkeyInput, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.overlayGlobalHotkeyType, 1, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 369);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 7;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.overlayWidth, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.WidthLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.HeightLabel, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.label23, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.overlayHeight, 4, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(200, 264);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(400, 24);
            this.tableLayoutPanel6.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(150, 0);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label20.Size = new System.Drawing.Size(30, 24);
            this.label20.TabIndex = 17;
            this.label20.Text = "px";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayWidth
            // 
            this.overlayWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayWidth.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.overlayWidth.Location = new System.Drawing.Point(50, 0);
            this.overlayWidth.Margin = new System.Windows.Forms.Padding(0);
            this.overlayWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.overlayWidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.overlayWidth.Name = "overlayWidth";
            this.overlayWidth.Size = new System.Drawing.Size(100, 23);
            this.overlayWidth.TabIndex = 16;
            this.overlayWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.overlayWidth.ValueChanged += new System.EventHandler(this.OverlayWidth_ValueChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.label23.Location = new System.Drawing.Point(330, 0);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 24);
            this.label23.TabIndex = 19;
            this.label23.Text = "px";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayHeight
            // 
            this.overlayHeight.Location = new System.Drawing.Point(230, 0);
            this.overlayHeight.Margin = new System.Windows.Forms.Padding(0);
            this.overlayHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.overlayHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.overlayHeight.Name = "overlayHeight";
            this.overlayHeight.Size = new System.Drawing.Size(100, 23);
            this.overlayHeight.TabIndex = 20;
            this.overlayHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.overlayHeight.ValueChanged += new System.EventHandler(this.OverlayHeight_ValueChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 7;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.overlayX, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label18, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label19, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.overlayY, 4, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(200, 240);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(400, 24);
            this.tableLayoutPanel5.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(150, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.label17.Size = new System.Drawing.Size(30, 24);
            this.label17.TabIndex = 17;
            this.label17.Text = "px";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayX
            // 
            this.overlayX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayX.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.overlayX.Location = new System.Drawing.Point(50, 0);
            this.overlayX.Margin = new System.Windows.Forms.Padding(0);
            this.overlayX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.overlayX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.overlayX.Name = "overlayX";
            this.overlayX.Size = new System.Drawing.Size(100, 23);
            this.overlayX.TabIndex = 16;
            this.overlayX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.overlayX.ValueChanged += new System.EventHandler(this.OverlayX_ValueChanged);
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.label19.Location = new System.Drawing.Point(330, 0);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 24);
            this.label19.TabIndex = 19;
            this.label19.Text = "px";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayY
            // 
            this.overlayY.Location = new System.Drawing.Point(230, 0);
            this.overlayY.Margin = new System.Windows.Forms.Padding(0);
            this.overlayY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.overlayY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.overlayY.Name = "overlayY";
            this.overlayY.Size = new System.Drawing.Size(100, 23);
            this.overlayY.TabIndex = 20;
            this.overlayY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.overlayY.ValueChanged += new System.EventHandler(this.OverlayY_ValueChanged);
            // 
            // SizeLabel
            // 
            this.SizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.PositionLabel.Location = new System.Drawing.Point(0, 240);
            this.PositionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.PositionLabel.Size = new System.Drawing.Size(200, 24);
            this.PositionLabel.TabIndex = 26;
            this.PositionLabel.Text = "Position";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // overlayEnableBeforeLogLineRead
            // 
            this.overlayEnableBeforeLogLineRead.AutoSize = true;
            this.overlayEnableBeforeLogLineRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayEnableBeforeLogLineRead.Location = new System.Drawing.Point(203, 219);
            this.overlayEnableBeforeLogLineRead.Name = "overlayEnableBeforeLogLineRead";
            this.overlayEnableBeforeLogLineRead.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.overlayEnableBeforeLogLineRead.Size = new System.Drawing.Size(394, 18);
            this.overlayEnableBeforeLogLineRead.TabIndex = 25;
            this.overlayEnableBeforeLogLineRead.UseVisualStyleBackColor = true;
            // 
            // EnableBeforeLogLineReadLabel
            // 
            this.EnableBeforeLogLineReadLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableBeforeLogLineReadLabel.Location = new System.Drawing.Point(0, 216);
            this.EnableBeforeLogLineReadLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EnableBeforeLogLineReadLabel.Name = "EnableBeforeLogLineReadLabel";
            this.EnableBeforeLogLineReadLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.EnableBeforeLogLineReadLabel.Size = new System.Drawing.Size(200, 24);
            this.EnableBeforeLogLineReadLabel.TabIndex = 24;
            this.EnableBeforeLogLineReadLabel.Text = "Enable beforeLogLineRead";
            this.EnableBeforeLogLineReadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.Controls.Add(this.overlayName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.overlayNameChange, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(200, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(400, 24);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // overlayName
            // 
            this.overlayName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayName.Location = new System.Drawing.Point(0, 0);
            this.overlayName.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.overlayName.Name = "overlayName";
            this.overlayName.Size = new System.Drawing.Size(375, 23);
            this.overlayName.TabIndex = 20;
            // 
            // overlayNameChange
            // 
            this.overlayNameChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("overlayNameChange.BackgroundImage")));
            this.overlayNameChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.overlayNameChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overlayNameChange.Location = new System.Drawing.Point(376, 0);
            this.overlayNameChange.Margin = new System.Windows.Forms.Padding(0);
            this.overlayNameChange.Name = "overlayNameChange";
            this.overlayNameChange.Size = new System.Drawing.Size(24, 23);
            this.overlayNameChange.TabIndex = 0;
            this.overlayNameChange.UseVisualStyleBackColor = true;
            this.overlayNameChange.Click += new System.EventHandler(this.OverlayNameChange_Click);
            // 
            // OverlayNameLabel
            // 
            this.OverlayNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlayNameLabel.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.GlobalHotkeyLabel.Location = new System.Drawing.Point(0, 168);
            this.GlobalHotkeyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.GlobalHotkeyLabel.Name = "GlobalHotkeyLabel";
            this.GlobalHotkeyLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.GlobalHotkeyLabel.Size = new System.Drawing.Size(200, 24);
            this.GlobalHotkeyLabel.TabIndex = 18;
            this.GlobalHotkeyLabel.Text = "Global hotkey";
            this.GlobalHotkeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // overlayGlobalHotkey
            // 
            this.overlayGlobalHotkey.AutoSize = true;
            this.overlayGlobalHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayGlobalHotkey.Location = new System.Drawing.Point(203, 147);
            this.overlayGlobalHotkey.Name = "overlayGlobalHotkey";
            this.overlayGlobalHotkey.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.overlayGlobalHotkey.Size = new System.Drawing.Size(394, 18);
            this.overlayGlobalHotkey.TabIndex = 17;
            this.overlayGlobalHotkey.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.overlayUpdateRate, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(200, 120);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(400, 24);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(80, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(320, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "ms";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayUpdateRate
            // 
            this.overlayUpdateRate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.overlayUpdateRate.Location = new System.Drawing.Point(0, 0);
            this.overlayUpdateRate.Margin = new System.Windows.Forms.Padding(0);
            this.overlayUpdateRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.overlayUpdateRate.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.overlayUpdateRate.Name = "overlayUpdateRate";
            this.overlayUpdateRate.Size = new System.Drawing.Size(80, 23);
            this.overlayUpdateRate.TabIndex = 0;
            this.overlayUpdateRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // EnableGlobalHotkeyLabel
            // 
            this.EnableGlobalHotkeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.MaxframelateLabel.Location = new System.Drawing.Point(0, 96);
            this.MaxframelateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MaxframelateLabel.Name = "MaxframelateLabel";
            this.MaxframelateLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.MaxframelateLabel.Size = new System.Drawing.Size(200, 24);
            this.MaxframelateLabel.TabIndex = 10;
            this.MaxframelateLabel.Text = "Max framerate";
            this.MaxframelateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // overlayLock
            // 
            this.overlayLock.AutoSize = true;
            this.overlayLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayLock.Location = new System.Drawing.Point(203, 75);
            this.overlayLock.Name = "overlayLock";
            this.overlayLock.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.overlayLock.Size = new System.Drawing.Size(394, 18);
            this.overlayLock.TabIndex = 9;
            this.overlayLock.UseVisualStyleBackColor = true;
            this.overlayLock.CheckedChanged += new System.EventHandler(this.OverlayLock_CheckedChanged);
            // 
            // overlayClickthru
            // 
            this.overlayClickthru.AutoSize = true;
            this.overlayClickthru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayClickthru.Location = new System.Drawing.Point(203, 51);
            this.overlayClickthru.Name = "overlayClickthru";
            this.overlayClickthru.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.overlayClickthru.Size = new System.Drawing.Size(394, 18);
            this.overlayClickthru.TabIndex = 4;
            this.overlayClickthru.UseVisualStyleBackColor = true;
            this.overlayClickthru.CheckedChanged += new System.EventHandler(this.OverlayClickthru_CheckedChanged);
            // 
            // ClickthruLabel
            // 
            this.ClickthruLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClickthruLabel.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ClickthruLabel.Location = new System.Drawing.Point(0, 48);
            this.ClickthruLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ClickthruLabel.Name = "ClickthruLabel";
            this.ClickthruLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.ClickthruLabel.Size = new System.Drawing.Size(200, 24);
            this.ClickthruLabel.TabIndex = 3;
            this.ClickthruLabel.Text = "Clickthru";
            this.ClickthruLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(0, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Show Overlay";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // overlayShow
            // 
            this.overlayShow.AutoSize = true;
            this.overlayShow.Checked = true;
            this.overlayShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayShow.Location = new System.Drawing.Point(203, 27);
            this.overlayShow.Name = "overlayShow";
            this.overlayShow.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.overlayShow.Size = new System.Drawing.Size(394, 18);
            this.overlayShow.TabIndex = 2;
            this.overlayShow.UseVisualStyleBackColor = true;
            this.overlayShow.CheckedChanged += new System.EventHandler(this.OverlayShow_CheckedChanged);
            // 
            // LockOverlayLabel
            // 
            this.LockOverlayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LockOverlayLabel.Location = new System.Drawing.Point(0, 72);
            this.LockOverlayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LockOverlayLabel.Name = "LockOverlayLabel";
            this.LockOverlayLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.LockOverlayLabel.Size = new System.Drawing.Size(200, 24);
            this.LockOverlayLabel.TabIndex = 5;
            this.LockOverlayLabel.Text = "Lock Overlay";
            this.LockOverlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.MaxframelateDescLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.overlayFramerate, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(200, 96);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 24);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // MaxframelateDescLabel
            // 
            this.MaxframelateDescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxframelateDescLabel.Location = new System.Drawing.Point(80, 0);
            this.MaxframelateDescLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MaxframelateDescLabel.Name = "MaxframelateDescLabel";
            this.MaxframelateDescLabel.Size = new System.Drawing.Size(320, 24);
            this.MaxframelateDescLabel.TabIndex = 6;
            this.MaxframelateDescLabel.Text = "fps (※ This value required restart)";
            this.MaxframelateDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlayFramerate
            // 
            this.overlayFramerate.Location = new System.Drawing.Point(0, 0);
            this.overlayFramerate.Margin = new System.Windows.Forms.Padding(0);
            this.overlayFramerate.Maximum = new decimal(new int[] {
            144,
            0,
            0,
            0});
            this.overlayFramerate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.overlayFramerate.Name = "overlayFramerate";
            this.overlayFramerate.Size = new System.Drawing.Size(80, 23);
            this.overlayFramerate.TabIndex = 0;
            this.overlayFramerate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.overlayFramerate.ValueChanged += new System.EventHandler(this.OverlayFramerate_ValueChanged);
            // 
            // overlayGlobalHotkeyInput
            // 
            this.overlayGlobalHotkeyInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayGlobalHotkeyInput.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.overlayGlobalHotkeyInput.Location = new System.Drawing.Point(200, 168);
            this.overlayGlobalHotkeyInput.Margin = new System.Windows.Forms.Padding(0);
            this.overlayGlobalHotkeyInput.Name = "overlayGlobalHotkeyInput";
            this.overlayGlobalHotkeyInput.Size = new System.Drawing.Size(400, 23);
            this.overlayGlobalHotkeyInput.TabIndex = 19;
            this.overlayGlobalHotkeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OverlayGlobalHotkeyInput_KeyDown);
            this.overlayGlobalHotkeyInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OverlayGlobalHotkeyInput_KeyPress);
            this.overlayGlobalHotkeyInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OverlayGlobalHotkeyInput_KeyUp);
            // 
            // overlayGlobalHotkeyType
            // 
            this.overlayGlobalHotkeyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayGlobalHotkeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.overlayGlobalHotkeyType.FormattingEnabled = true;
            this.overlayGlobalHotkeyType.Location = new System.Drawing.Point(200, 192);
            this.overlayGlobalHotkeyType.Margin = new System.Windows.Forms.Padding(0);
            this.overlayGlobalHotkeyType.Name = "overlayGlobalHotkeyType";
            this.overlayGlobalHotkeyType.Size = new System.Drawing.Size(400, 24);
            this.overlayGlobalHotkeyType.TabIndex = 21;
            // 
            // OverlayConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.justPaddingLabel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OverlayConfig";
            this.Size = new System.Drawing.Size(600, 400);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overlayWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayHeight)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overlayX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayY)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overlayUpdateRate)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overlayFramerate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label justPaddingLabel1;
        private System.Windows.Forms.Label justPaddingLabel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox overlayShow;
        private System.Windows.Forms.CheckBox overlayClickthru;
        private System.Windows.Forms.Label ClickthruLabel;
        private System.Windows.Forms.Label LockOverlayLabel;
        private System.Windows.Forms.Label EnableGlobalHotkeyLabel;
        private System.Windows.Forms.Label DataUpdateRateLabel;
        private System.Windows.Forms.Label MaxframelateLabel;
        private System.Windows.Forms.CheckBox overlayLock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label MaxframelateDescLabel;
        private System.Windows.Forms.NumericUpDown overlayFramerate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown overlayUpdateRate;
        private System.Windows.Forms.CheckBox overlayGlobalHotkey;
        private System.Windows.Forms.Label GlobalHotkeyLabel;
        private System.Windows.Forms.TextBox overlayGlobalHotkeyInput;
        private System.Windows.Forms.Label HotkeyTypeLabel;
        private System.Windows.Forms.ComboBox overlayGlobalHotkeyType;
        private System.Windows.Forms.Label OverlayNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button overlayNameChange;
        private System.Windows.Forms.TextBox overlayName;
        private System.Windows.Forms.Label EnableBeforeLogLineReadLabel;
        private System.Windows.Forms.CheckBox overlayEnableBeforeLogLineRead;
        public System.Windows.Forms.TextBox siteURL;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown overlayX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown overlayY;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown overlayWidth;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown overlayHeight;
    }
}
