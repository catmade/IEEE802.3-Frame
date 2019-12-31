namespace IEEE_802._3_以太网帧封装.MyForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            IEEE_802._3_以太网帧封装.FrameItem.Frame frame1 = new IEEE_802._3_以太网帧封装.FrameItem.Frame();
            IEEE_802._3_以太网帧封装.FrameItem.Data data1 = new IEEE_802._3_以太网帧封装.FrameItem.Data();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac1 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac2 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            IEEE_802._3_以太网帧封装.FrameItem.Frame frame2 = new IEEE_802._3_以太网帧封装.FrameItem.Frame();
            IEEE_802._3_以太网帧封装.FrameItem.Data data2 = new IEEE_802._3_以太网帧封装.FrameItem.Data();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac3 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac4 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnGenRandomData = new System.Windows.Forms.Button();
            this.lbCRCGP = new System.Windows.Forms.Label();
            this.btnSetCRCGP = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabSenderPage = new System.Windows.Forms.TabPage();
            this.btnCompleteData = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tabReceiverPage = new System.Windows.Forms.TabPage();
            this.btnCheck = new System.Windows.Forms.Button();
            this.senderPanel = new IEEE_802._3_以太网帧封装.FramePanel();
            this.receiverPanel = new IEEE_802._3_以太网帧封装.FramePanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tab.SuspendLayout();
            this.tabSenderPage.SuspendLayout();
            this.tabReceiverPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnGenRandomData
            // 
            this.btnGenRandomData.Location = new System.Drawing.Point(411, 384);
            this.btnGenRandomData.Name = "btnGenRandomData";
            this.btnGenRandomData.Size = new System.Drawing.Size(93, 23);
            this.btnGenRandomData.TabIndex = 4;
            this.btnGenRandomData.Text = "生成随机数据";
            this.btnGenRandomData.UseVisualStyleBackColor = true;
            this.btnGenRandomData.Click += new System.EventHandler(this.btnGenRandomData_Click);
            // 
            // lbCRCGP
            // 
            this.lbCRCGP.AutoSize = true;
            this.lbCRCGP.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCRCGP.Location = new System.Drawing.Point(136, 339);
            this.lbCRCGP.Name = "lbCRCGP";
            this.lbCRCGP.Size = new System.Drawing.Size(72, 19);
            this.lbCRCGP.TabIndex = 7;
            this.lbCRCGP.Text = "P(X) = ";
            this.lbCRCGP.Click += new System.EventHandler(this.lbCRCGP_Click);
            // 
            // btnSetCRCGP
            // 
            this.btnSetCRCGP.Location = new System.Drawing.Point(20, 332);
            this.btnSetCRCGP.Name = "btnSetCRCGP";
            this.btnSetCRCGP.Size = new System.Drawing.Size(110, 37);
            this.btnSetCRCGP.TabIndex = 8;
            this.btnSetCRCGP.Text = "设置生成多项式";
            this.btnSetCRCGP.UseVisualStyleBackColor = true;
            this.btnSetCRCGP.Click += new System.EventHandler(this.btnSetCRCGP_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabSenderPage);
            this.tab.Controls.Add(this.tabReceiverPage);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(692, 463);
            this.tab.TabIndex = 9;
            // 
            // tabSenderPage
            // 
            this.tabSenderPage.BackColor = System.Drawing.SystemColors.Info;
            this.tabSenderPage.Controls.Add(this.btnCompleteData);
            this.tabSenderPage.Controls.Add(this.btnSend);
            this.tabSenderPage.Controls.Add(this.senderPanel);
            this.tabSenderPage.Controls.Add(this.btnSetCRCGP);
            this.tabSenderPage.Controls.Add(this.btnGenRandomData);
            this.tabSenderPage.Controls.Add(this.lbCRCGP);
            this.tabSenderPage.Location = new System.Drawing.Point(4, 22);
            this.tabSenderPage.Name = "tabSenderPage";
            this.tabSenderPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSenderPage.Size = new System.Drawing.Size(684, 437);
            this.tabSenderPage.TabIndex = 0;
            this.tabSenderPage.Text = "发送者";
            // 
            // btnCompleteData
            // 
            this.btnCompleteData.Location = new System.Drawing.Point(20, 384);
            this.btnCompleteData.Name = "btnCompleteData";
            this.btnCompleteData.Size = new System.Drawing.Size(130, 23);
            this.btnCompleteData.TabIndex = 11;
            this.btnCompleteData.Text = "纠正数据格式";
            this.btnCompleteData.UseVisualStyleBackColor = true;
            this.btnCompleteData.Click += new System.EventHandler(this.btnCompleteData_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(543, 384);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送数据";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tabReceiverPage
            // 
            this.tabReceiverPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabReceiverPage.Controls.Add(this.btnCheck);
            this.tabReceiverPage.Controls.Add(this.receiverPanel);
            this.tabReceiverPage.Location = new System.Drawing.Point(4, 22);
            this.tabReceiverPage.Name = "tabReceiverPage";
            this.tabReceiverPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceiverPage.Size = new System.Drawing.Size(684, 437);
            this.tabReceiverPage.TabIndex = 1;
            this.tabReceiverPage.Text = "接收者";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(530, 342);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "检查数据";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // senderPanel
            // 
            frame1.Data = data1;
            frame1.DestinationMac = mac1;
            frame1.FrameCheckSequence = null;
            frame1.Length = null;
            frame1.SourceMac = mac2;
            this.senderPanel.Frame = frame1;
            this.senderPanel.Location = new System.Drawing.Point(8, 6);
            this.senderPanel.Name = "senderPanel";
            this.senderPanel.PanelMode = IEEE_802._3_以太网帧封装.Mode.Silence;
            this.senderPanel.Size = new System.Drawing.Size(610, 330);
            this.senderPanel.TabIndex = 9;
            // 
            // receiverPanel
            // 
            frame2.Data = data2;
            frame2.DestinationMac = mac3;
            frame2.FrameCheckSequence = null;
            frame2.Length = null;
            frame2.SourceMac = mac4;
            this.receiverPanel.Frame = frame2;
            this.receiverPanel.Location = new System.Drawing.Point(8, 6);
            this.receiverPanel.Name = "receiverPanel";
            this.receiverPanel.PanelMode = IEEE_802._3_以太网帧封装.Mode.Check;
            this.receiverPanel.Size = new System.Drawing.Size(610, 330);
            this.receiverPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 463);
            this.Controls.Add(this.tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IEEE 802.3 以太网帧封装演示";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabSenderPage.ResumeLayout(false);
            this.tabSenderPage.PerformLayout();
            this.tabReceiverPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnGenRandomData;
        private System.Windows.Forms.Label lbCRCGP;
        private System.Windows.Forms.Button btnSetCRCGP;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabSenderPage;
        private System.Windows.Forms.TabPage tabReceiverPage;
        private FramePanel senderPanel;
        private FramePanel receiverPanel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCompleteData;
    }
}

