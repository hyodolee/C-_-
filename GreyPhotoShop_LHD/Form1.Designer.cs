namespace GreyPhotoShop_LHD
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기GreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장GreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화소점처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.동일영상ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.밝게하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이진화2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이진화3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파라볼라캡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파라볼라컵ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기하학처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상미러링상하ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상축소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상확대포워딩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상확대백워딩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상이동ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상회전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영상이동마우스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_paper = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_lable = new System.Windows.Forms.ToolStripStatusLabel();
            this.밝게어둡게키보드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_paper)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.화소점처리ToolStripMenuItem,
            this.기하학처리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(357, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기GreyToolStripMenuItem,
            this.저장GreyToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기GreyToolStripMenuItem
            // 
            this.열기GreyToolStripMenuItem.Name = "열기GreyToolStripMenuItem";
            this.열기GreyToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.열기GreyToolStripMenuItem.Text = "열기(Grey)";
            this.열기GreyToolStripMenuItem.Click += new System.EventHandler(this.열기GreyToolStripMenuItem_Click);
            // 
            // 저장GreyToolStripMenuItem
            // 
            this.저장GreyToolStripMenuItem.Name = "저장GreyToolStripMenuItem";
            this.저장GreyToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.저장GreyToolStripMenuItem.Text = "저장(Grey)";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 화소점처리ToolStripMenuItem
            // 
            this.화소점처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.동일영상ToolStripMenuItem,
            this.밝게하기ToolStripMenuItem,
            this.이진화2ToolStripMenuItem,
            this.이진화3ToolStripMenuItem,
            this.파라볼라캡ToolStripMenuItem,
            this.파라볼라컵ToolStripMenuItem,
            this.밝게어둡게키보드ToolStripMenuItem});
            this.화소점처리ToolStripMenuItem.Name = "화소점처리ToolStripMenuItem";
            this.화소점처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.화소점처리ToolStripMenuItem.Text = "화소점 처리";
            // 
            // 동일영상ToolStripMenuItem
            // 
            this.동일영상ToolStripMenuItem.Name = "동일영상ToolStripMenuItem";
            this.동일영상ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.동일영상ToolStripMenuItem.Text = "동일 영상";
            this.동일영상ToolStripMenuItem.Click += new System.EventHandler(this.동일영상ToolStripMenuItem_Click);
            // 
            // 밝게하기ToolStripMenuItem
            // 
            this.밝게하기ToolStripMenuItem.Name = "밝게하기ToolStripMenuItem";
            this.밝게하기ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.밝게하기ToolStripMenuItem.Text = "밝게 하기";
            this.밝게하기ToolStripMenuItem.Click += new System.EventHandler(this.밝게하기ToolStripMenuItem_Click);
            // 
            // 이진화2ToolStripMenuItem
            // 
            this.이진화2ToolStripMenuItem.Name = "이진화2ToolStripMenuItem";
            this.이진화2ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.이진화2ToolStripMenuItem.Text = "이진화2";
            this.이진화2ToolStripMenuItem.Click += new System.EventHandler(this.이진화2ToolStripMenuItem_Click);
            // 
            // 이진화3ToolStripMenuItem
            // 
            this.이진화3ToolStripMenuItem.Name = "이진화3ToolStripMenuItem";
            this.이진화3ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.이진화3ToolStripMenuItem.Text = "이진화3";
            this.이진화3ToolStripMenuItem.Click += new System.EventHandler(this.이진화3ToolStripMenuItem_Click);
            // 
            // 파라볼라캡ToolStripMenuItem
            // 
            this.파라볼라캡ToolStripMenuItem.Name = "파라볼라캡ToolStripMenuItem";
            this.파라볼라캡ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.파라볼라캡ToolStripMenuItem.Text = "파라볼라(캡)";
            this.파라볼라캡ToolStripMenuItem.Click += new System.EventHandler(this.파라볼라캡ToolStripMenuItem_Click);
            // 
            // 파라볼라컵ToolStripMenuItem
            // 
            this.파라볼라컵ToolStripMenuItem.Name = "파라볼라컵ToolStripMenuItem";
            this.파라볼라컵ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.파라볼라컵ToolStripMenuItem.Text = "파라볼라(컵)";
            this.파라볼라컵ToolStripMenuItem.Click += new System.EventHandler(this.파라볼라컵ToolStripMenuItem_Click);
            // 
            // 기하학처리ToolStripMenuItem
            // 
            this.기하학처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.영상미러링상하ToolStripMenuItem,
            this.영상축소ToolStripMenuItem,
            this.영상확대포워딩ToolStripMenuItem,
            this.영상확대백워딩ToolStripMenuItem,
            this.영상이동ToolStripMenuItem,
            this.영상회전ToolStripMenuItem,
            this.영상이동마우스ToolStripMenuItem});
            this.기하학처리ToolStripMenuItem.Name = "기하학처리ToolStripMenuItem";
            this.기하학처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.기하학처리ToolStripMenuItem.Text = "기하학 처리";
            // 
            // 영상미러링상하ToolStripMenuItem
            // 
            this.영상미러링상하ToolStripMenuItem.Name = "영상미러링상하ToolStripMenuItem";
            this.영상미러링상하ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상미러링상하ToolStripMenuItem.Text = "영상 미러링(상하)";
            this.영상미러링상하ToolStripMenuItem.Click += new System.EventHandler(this.영상미러링상하ToolStripMenuItem_Click);
            // 
            // 영상축소ToolStripMenuItem
            // 
            this.영상축소ToolStripMenuItem.Name = "영상축소ToolStripMenuItem";
            this.영상축소ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상축소ToolStripMenuItem.Text = "영상 축소";
            this.영상축소ToolStripMenuItem.Click += new System.EventHandler(this.영상축소ToolStripMenuItem_Click);
            // 
            // 영상확대포워딩ToolStripMenuItem
            // 
            this.영상확대포워딩ToolStripMenuItem.Name = "영상확대포워딩ToolStripMenuItem";
            this.영상확대포워딩ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상확대포워딩ToolStripMenuItem.Text = "영상 확대(포워딩)";
            this.영상확대포워딩ToolStripMenuItem.Click += new System.EventHandler(this.영상확대포워딩ToolStripMenuItem_Click);
            // 
            // 영상확대백워딩ToolStripMenuItem
            // 
            this.영상확대백워딩ToolStripMenuItem.Name = "영상확대백워딩ToolStripMenuItem";
            this.영상확대백워딩ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상확대백워딩ToolStripMenuItem.Text = "영상 확대(백워딩)";
            this.영상확대백워딩ToolStripMenuItem.Click += new System.EventHandler(this.영상확대백워딩ToolStripMenuItem_Click);
            // 
            // 영상이동ToolStripMenuItem
            // 
            this.영상이동ToolStripMenuItem.Name = "영상이동ToolStripMenuItem";
            this.영상이동ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상이동ToolStripMenuItem.Text = "영상 이동";
            this.영상이동ToolStripMenuItem.Click += new System.EventHandler(this.영상이동ToolStripMenuItem_Click);
            // 
            // 영상회전ToolStripMenuItem
            // 
            this.영상회전ToolStripMenuItem.Name = "영상회전ToolStripMenuItem";
            this.영상회전ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상회전ToolStripMenuItem.Text = "영상 회전";
            this.영상회전ToolStripMenuItem.Click += new System.EventHandler(this.영상회전ToolStripMenuItem_Click);
            // 
            // 영상이동마우스ToolStripMenuItem
            // 
            this.영상이동마우스ToolStripMenuItem.Name = "영상이동마우스ToolStripMenuItem";
            this.영상이동마우스ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.영상이동마우스ToolStripMenuItem.Text = "영상 이동(마우스)";
            this.영상이동마우스ToolStripMenuItem.Click += new System.EventHandler(this.영상이동마우스ToolStripMenuItem_Click);
            // 
            // pb_paper
            // 
            this.pb_paper.Location = new System.Drawing.Point(0, 31);
            this.pb_paper.Name = "pb_paper";
            this.pb_paper.Size = new System.Drawing.Size(100, 50);
            this.pb_paper.TabIndex = 1;
            this.pb_paper.TabStop = false;
            this.pb_paper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pb_paper_MouseDown);
            this.pb_paper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pb_paper_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_lable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(357, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_lable
            // 
            this.tool_lable.Name = "tool_lable";
            this.tool_lable.Size = new System.Drawing.Size(72, 20);
            this.tool_lable.Text = "영상크기:";
            // 
            // 밝게어둡게키보드ToolStripMenuItem
            // 
            this.밝게어둡게키보드ToolStripMenuItem.Name = "밝게어둡게키보드ToolStripMenuItem";
            this.밝게어둡게키보드ToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.밝게어둡게키보드ToolStripMenuItem.Text = "밝게/어둡게(키보드)";
            this.밝게어둡게키보드ToolStripMenuItem.Click += new System.EventHandler(this.밝게어둡게키보드ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 372);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pb_paper);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "그레이 영상처리(이효도)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_paper)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기GreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장GreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화소점처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 동일영상ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 밝게하기ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_paper;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tool_lable;
        private System.Windows.Forms.ToolStripMenuItem 이진화2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이진화3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파라볼라캡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파라볼라컵ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기하학처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상미러링상하ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상축소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상확대포워딩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상확대백워딩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상이동ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상회전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영상이동마우스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 밝게어둡게키보드ToolStripMenuItem;
    }
}

