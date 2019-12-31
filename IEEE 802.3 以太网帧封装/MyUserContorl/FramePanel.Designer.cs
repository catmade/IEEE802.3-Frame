namespace IEEE_802._3_以太网帧封装
{
    partial class FramePanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbSourceAddr = new System.Windows.Forms.TextBox();
            this.tbDestinationAddr = new System.Windows.Forms.TextBox();
            this.lbDestinationAddr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSFD = new System.Windows.Forms.Label();
            this.tbPreamble = new System.Windows.Forms.TextBox();
            this.lbPreamble = new System.Windows.Forms.Label();
            this.tbSFD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbDataLength = new System.Windows.Forms.TextBox();
            this.tbFCS = new System.Windows.Forms.TextBox();
            this.tbDataHex = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.Controls.Add(this.tbSourceAddr, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbDestinationAddr, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDestinationAddr, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSFD, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbPreamble, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPreamble, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSFD, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 51);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbSourceAddr
            // 
            this.tbSourceAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSourceAddr.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbSourceAddr, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbSourceAddr, -15);
            this.tbSourceAddr.Location = new System.Drawing.Point(426, 24);
            this.tbSourceAddr.Margin = new System.Windows.Forms.Padding(0);
            this.tbSourceAddr.MaxLength = 17;
            this.tbSourceAddr.Name = "tbSourceAddr";
            this.tbSourceAddr.Size = new System.Drawing.Size(169, 26);
            this.tbSourceAddr.TabIndex = 1;
            this.tbSourceAddr.TextChanged += new System.EventHandler(this.tbSourceAddr_TextChanged);
            // 
            // tbDestinationAddr
            // 
            this.tbDestinationAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDestinationAddr.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbDestinationAddr, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbDestinationAddr, -15);
            this.tbDestinationAddr.Location = new System.Drawing.Point(266, 24);
            this.tbDestinationAddr.Margin = new System.Windows.Forms.Padding(0);
            this.tbDestinationAddr.MaxLength = 17;
            this.tbDestinationAddr.Name = "tbDestinationAddr";
            this.tbDestinationAddr.Size = new System.Drawing.Size(159, 26);
            this.tbDestinationAddr.TabIndex = 1;
            this.tbDestinationAddr.TextChanged += new System.EventHandler(this.tbDestinationAddr_TextChanged);
            // 
            // lbDestinationAddr
            // 
            this.lbDestinationAddr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDestinationAddr.AutoSize = true;
            this.lbDestinationAddr.Location = new System.Drawing.Point(319, 6);
            this.lbDestinationAddr.Name = "lbDestinationAddr";
            this.lbDestinationAddr.Size = new System.Drawing.Size(53, 12);
            this.lbDestinationAddr.TabIndex = 2;
            this.lbDestinationAddr.Text = "目的地址";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "源地址";
            // 
            // lbSFD
            // 
            this.lbSFD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSFD.AutoSize = true;
            this.lbSFD.Location = new System.Drawing.Point(196, 6);
            this.lbSFD.Name = "lbSFD";
            this.lbSFD.Size = new System.Drawing.Size(65, 12);
            this.lbSFD.TabIndex = 1;
            this.lbSFD.Text = "帧前定界符";
            // 
            // tbPreamble
            // 
            this.tbPreamble.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPreamble.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbPreamble, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbPreamble, -15);
            this.tbPreamble.Location = new System.Drawing.Point(1, 24);
            this.tbPreamble.Margin = new System.Windows.Forms.Padding(0);
            this.tbPreamble.MaxLength = 20;
            this.tbPreamble.Name = "tbPreamble";
            this.tbPreamble.Size = new System.Drawing.Size(190, 26);
            this.tbPreamble.TabIndex = 1;
            this.tbPreamble.Text = "AA AA AA AA AA AA AA";
            // 
            // lbPreamble
            // 
            this.lbPreamble.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPreamble.AutoSize = true;
            this.lbPreamble.Location = new System.Drawing.Point(75, 6);
            this.lbPreamble.Name = "lbPreamble";
            this.lbPreamble.Size = new System.Drawing.Size(41, 12);
            this.lbPreamble.TabIndex = 0;
            this.lbPreamble.Text = "前导码";
            // 
            // tbSFD
            // 
            this.tbSFD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSFD.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbSFD, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbSFD, -15);
            this.tbSFD.Location = new System.Drawing.Point(192, 24);
            this.tbSFD.Margin = new System.Windows.Forms.Padding(0);
            this.tbSFD.MaxLength = 2;
            this.tbSFD.Name = "tbSFD";
            this.tbSFD.Size = new System.Drawing.Size(73, 26);
            this.tbSFD.TabIndex = 1;
            this.tbSFD.Text = "AB";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(512, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "校验字段";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "数据";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "数据长度";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.tbDataLength, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbFCS, 2, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 99);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(596, 51);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tbDataLength
            // 
            this.tbDataLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDataLength.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbDataLength, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbDataLength, -15);
            this.tbDataLength.Location = new System.Drawing.Point(1, 24);
            this.tbDataLength.Margin = new System.Windows.Forms.Padding(0);
            this.tbDataLength.MaxLength = 5;
            this.tbDataLength.Name = "tbDataLength";
            this.tbDataLength.Size = new System.Drawing.Size(62, 26);
            this.tbDataLength.TabIndex = 1;
            this.tbDataLength.Text = "00 00";
            // 
            // tbFCS
            // 
            this.tbFCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFCS.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbFCS, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbFCS, -15);
            this.tbFCS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbFCS.Location = new System.Drawing.Point(479, 24);
            this.tbFCS.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tbFCS.MaxLength = 11;
            this.tbFCS.Name = "tbFCS";
            this.tbFCS.Size = new System.Drawing.Size(116, 26);
            this.tbFCS.TabIndex = 1;
            // 
            // tbDataHex
            // 
            this.tbDataHex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDataHex.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tbDataHex, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.errorProvider1.SetIconPadding(this.tbDataHex, -15);
            this.tbDataHex.Location = new System.Drawing.Point(10, 179);
            this.tbDataHex.Multiline = true;
            this.tbDataHex.Name = "tbDataHex";
            this.tbDataHex.Size = new System.Drawing.Size(587, 135);
            this.tbDataHex.TabIndex = 1;
            this.tbDataHex.TextChanged += new System.EventHandler(this.tbDataHex_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FramePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbDataHex);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FramePanel";
            this.Size = new System.Drawing.Size(610, 330);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPreamble;
        private System.Windows.Forms.Label lbSFD;
        private System.Windows.Forms.Label lbDestinationAddr;
        private System.Windows.Forms.TextBox tbPreamble;
        private System.Windows.Forms.TextBox tbSourceAddr;
        private System.Windows.Forms.TextBox tbDestinationAddr;
        private System.Windows.Forms.TextBox tbSFD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbDataLength;
        private System.Windows.Forms.TextBox tbFCS;
        private System.Windows.Forms.TextBox tbDataHex;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
