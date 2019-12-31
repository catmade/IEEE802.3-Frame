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
            IEEE_802._3_以太网帧封装.FrameItem.Frame frame2 = new IEEE_802._3_以太网帧封装.FrameItem.Frame();
            IEEE_802._3_以太网帧封装.FrameItem.Data data2 = new IEEE_802._3_以太网帧封装.FrameItem.Data();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac3 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac4 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            IEEE_802._3_以太网帧封装.FrameItem.Frame frame1 = new IEEE_802._3_以太网帧封装.FrameItem.Frame();
            IEEE_802._3_以太网帧封装.FrameItem.Data data1 = new IEEE_802._3_以太网帧封装.FrameItem.Data();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac1 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            IEEE_802._3_以太网帧封装.FrameItem.MAC mac2 = new IEEE_802._3_以太网帧封装.FrameItem.MAC();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabDrawCRCPage = new System.Windows.Forms.TabPage();
            this.drawCRC1 = new IEEE_802._3_以太网帧封装.MyUserContorl.DrawCRC();
            this.tabReceiverPage = new System.Windows.Forms.TabPage();
            this.lbCheckResult = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.receiverPanel = new IEEE_802._3_以太网帧封装.FramePanel();
            this.tabSenderPage = new System.Windows.Forms.TabPage();
            this.btnGenRandomData = new System.Windows.Forms.Button();
            this.btnCompleteData = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.senderPanel = new IEEE_802._3_以太网帧封装.FramePanel();
            this.btnSetCRCGP = new System.Windows.Forms.Button();
            this.lbCRCGP = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabDrawCRCPage.SuspendLayout();
            this.tabReceiverPage.SuspendLayout();
            this.tabSenderPage.SuspendLayout();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // tabDrawCRCPage
            // 
            this.tabDrawCRCPage.Controls.Add(this.drawCRC1);
            this.tabDrawCRCPage.Location = new System.Drawing.Point(4, 22);
            this.tabDrawCRCPage.Name = "tabDrawCRCPage";
            this.tabDrawCRCPage.Size = new System.Drawing.Size(625, 437);
            this.tabDrawCRCPage.TabIndex = 2;
            this.tabDrawCRCPage.Text = "循环冗余校验计算过程";
            // 
            // drawCRC1
            // 
            this.drawCRC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawCRC1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawCRC1.Location = new System.Drawing.Point(0, 0);
            this.drawCRC1.Name = "drawCRC1";
            this.drawCRC1.Size = new System.Drawing.Size(625, 437);
            this.drawCRC1.SplitterDistance = 350;
            this.drawCRC1.SplitterWidth = 5;
            this.drawCRC1.TabIndex = 0;
            // 
            // tabReceiverPage
            // 
            this.tabReceiverPage.BackColor = System.Drawing.SystemColors.Control;
            this.tabReceiverPage.Controls.Add(this.lbCheckResult);
            this.tabReceiverPage.Controls.Add(this.btnCheck);
            this.tabReceiverPage.Controls.Add(this.receiverPanel);
            this.tabReceiverPage.Location = new System.Drawing.Point(4, 22);
            this.tabReceiverPage.Name = "tabReceiverPage";
            this.tabReceiverPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceiverPage.Size = new System.Drawing.Size(625, 437);
            this.tabReceiverPage.TabIndex = 1;
            this.tabReceiverPage.Text = "接收者";
            // 
            // lbCheckResult
            // 
            this.lbCheckResult.AutoSize = true;
            this.lbCheckResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCheckResult.Location = new System.Drawing.Point(31, 339);
            this.lbCheckResult.Name = "lbCheckResult";
            this.lbCheckResult.Size = new System.Drawing.Size(48, 16);
            this.lbCheckResult.TabIndex = 2;
            this.lbCheckResult.Text = "     ";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCheck.Location = new System.Drawing.Point(528, 342);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(87, 32);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "检测数据";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // receiverPanel
            // 
            frame2.Data = data2;
            frame2.DestinationMac = mac3;
            frame2.FCS = null;
            frame2.Length = null;
            frame2.SourceMac = mac4;
            this.receiverPanel.Frame = frame2;
            this.receiverPanel.Location = new System.Drawing.Point(8, 6);
            this.receiverPanel.Name = "receiverPanel";
            this.receiverPanel.PanelMode = IEEE_802._3_以太网帧封装.Mode.DisplayData;
            this.receiverPanel.Size = new System.Drawing.Size(620, 330);
            this.receiverPanel.TabIndex = 0;
            // 
            // tabSenderPage
            // 
            this.tabSenderPage.BackColor = System.Drawing.SystemColors.Control;
            this.tabSenderPage.Controls.Add(this.btnGenRandomData);
            this.tabSenderPage.Controls.Add(this.btnCompleteData);
            this.tabSenderPage.Controls.Add(this.btnSend);
            this.tabSenderPage.Controls.Add(this.senderPanel);
            this.tabSenderPage.Controls.Add(this.btnSetCRCGP);
            this.tabSenderPage.Controls.Add(this.lbCRCGP);
            this.tabSenderPage.Location = new System.Drawing.Point(4, 22);
            this.tabSenderPage.Name = "tabSenderPage";
            this.tabSenderPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSenderPage.Size = new System.Drawing.Size(684, 437);
            this.tabSenderPage.TabIndex = 0;
            this.tabSenderPage.Text = "发送者";
            // 
            // btnGenRandomData
            // 
            this.btnGenRandomData.Location = new System.Drawing.Point(312, 334);
            this.btnGenRandomData.Name = "btnGenRandomData";
            this.btnGenRandomData.Size = new System.Drawing.Size(107, 33);
            this.btnGenRandomData.TabIndex = 11;
            this.btnGenRandomData.Text = "生成随机数据";
            this.btnGenRandomData.UseVisualStyleBackColor = true;
            this.btnGenRandomData.Click += new System.EventHandler(this.btnGenRandomData_Click);
            // 
            // btnCompleteData
            // 
            this.btnCompleteData.Location = new System.Drawing.Point(425, 334);
            this.btnCompleteData.Name = "btnCompleteData";
            this.btnCompleteData.Size = new System.Drawing.Size(107, 33);
            this.btnCompleteData.TabIndex = 11;
            this.btnCompleteData.Text = "计算校验字段";
            this.btnCompleteData.UseVisualStyleBackColor = true;
            this.btnCompleteData.Click += new System.EventHandler(this.btnCompleteData_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(538, 334);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 33);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送数据";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // senderPanel
            // 
            frame1.Data = data1;
            frame1.DestinationMac = mac1;
            frame1.FCS = null;
            frame1.Length = null;
            frame1.SourceMac = mac2;
            this.senderPanel.Frame = frame1;
            this.senderPanel.Location = new System.Drawing.Point(8, 6);
            this.senderPanel.Name = "senderPanel";
            this.senderPanel.PanelMode = IEEE_802._3_以太网帧封装.Mode.InputData;
            this.senderPanel.Size = new System.Drawing.Size(621, 330);
            this.senderPanel.TabIndex = 9;
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
            // lbCRCGP
            // 
            this.lbCRCGP.AutoSize = true;
            this.lbCRCGP.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCRCGP.Location = new System.Drawing.Point(16, 384);
            this.lbCRCGP.Name = "lbCRCGP";
            this.lbCRCGP.Size = new System.Drawing.Size(72, 19);
            this.lbCRCGP.TabIndex = 7;
            this.lbCRCGP.Text = "P(X) = ";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabSenderPage);
            this.tab.Controls.Add(this.tabReceiverPage);
            this.tab.Controls.Add(this.tabDrawCRCPage);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(633, 463);
            this.tab.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 463);
            this.Controls.Add(this.tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IEEE 802.3 以太网帧封装演示";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabDrawCRCPage.ResumeLayout(false);
            this.tabReceiverPage.ResumeLayout(false);
            this.tabReceiverPage.PerformLayout();
            this.tabSenderPage.ResumeLayout(false);
            this.tabSenderPage.PerformLayout();
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabSenderPage;
        private System.Windows.Forms.Button btnCompleteData;
        private System.Windows.Forms.Button btnSend;
        private FramePanel senderPanel;
        private System.Windows.Forms.Button btnSetCRCGP;
        private System.Windows.Forms.Label lbCRCGP;
        private System.Windows.Forms.TabPage tabReceiverPage;
        private System.Windows.Forms.Button btnCheck;
        private FramePanel receiverPanel;
        private System.Windows.Forms.TabPage tabDrawCRCPage;
        private MyUserContorl.DrawCRC drawCRC1;
        private System.Windows.Forms.Button btnGenRandomData;
        private System.Windows.Forms.Label lbCheckResult;
    }
}

