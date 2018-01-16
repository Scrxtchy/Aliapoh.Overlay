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
            this.overlayTabControl1 = new Aliapoh.Overlay.OverlayTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.overlayTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // overlayTabControl1
            // 
            this.overlayTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.overlayTabControl1.Controls.Add(this.tabPage1);
            this.overlayTabControl1.Controls.Add(this.tabPage2);
            this.overlayTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayTabControl1.ItemSize = new System.Drawing.Size(48, 240);
            this.overlayTabControl1.Location = new System.Drawing.Point(0, 0);
            this.overlayTabControl1.Multiline = true;
            this.overlayTabControl1.Name = "overlayTabControl1";
            this.overlayTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.overlayTabControl1.SelectedIndex = 0;
            this.overlayTabControl1.Size = new System.Drawing.Size(800, 600);
            this.overlayTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.overlayTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(240, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(558, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(240, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(558, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OverlayController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.overlayTabControl1);
            this.Name = "OverlayController";
            this.Size = new System.Drawing.Size(800, 600);
            this.overlayTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OverlayTabControl overlayTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
