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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbDestinationMac = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbSourceMac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDataHex = new System.Windows.Forms.TextBox();
            this.btnGenRandomData = new System.Windows.Forms.Button();
            this.tabpInput = new System.Windows.Forms.TableLayoutPanel();
            this.lbCRCGP = new System.Windows.Forms.Label();
            this.btnSetCRCGP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDestinationMac
            // 
            this.tbDestinationMac.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDestinationMac.Location = new System.Drawing.Point(3, 30);
            this.tbDestinationMac.Name = "tbDestinationMac";
            this.tbDestinationMac.Size = new System.Drawing.Size(168, 26);
            this.tbDestinationMac.TabIndex = 0;
            this.tbDestinationMac.Text = "9C-DA-3E-5B-22-95";
            this.tbDestinationMac.TextChanged += new System.EventHandler(this.tbDestinationMac_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAC destination";
            // 
            // tbSourceMac
            // 
            this.tbSourceMac.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSourceMac.Location = new System.Drawing.Point(180, 30);
            this.tbSourceMac.Name = "tbSourceMac";
            this.tbSourceMac.Size = new System.Drawing.Size(168, 26);
            this.tbSourceMac.TabIndex = 0;
            this.tbSourceMac.Text = "9C-DA-3E-5B-22-95";
            this.tbSourceMac.TextChanged += new System.EventHandler(this.tbSourceMac_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "MAC source";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbDestinationMac, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbSourceMac, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 67);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "CRC Checksum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(361, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "00 10 10 11";
            // 
            // tbDataHex
            // 
            this.tbDataHex.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataHex.Location = new System.Drawing.Point(23, 231);
            this.tbDataHex.Multiline = true;
            this.tbDataHex.Name = "tbDataHex";
            this.tbDataHex.Size = new System.Drawing.Size(765, 207);
            this.tbDataHex.TabIndex = 3;
            this.tbDataHex.TextChanged += new System.EventHandler(this.tbDataHex_TextChanged);
            // 
            // btnGenRandomData
            // 
            this.btnGenRandomData.Location = new System.Drawing.Point(23, 202);
            this.btnGenRandomData.Name = "btnGenRandomData";
            this.btnGenRandomData.Size = new System.Drawing.Size(93, 23);
            this.btnGenRandomData.TabIndex = 4;
            this.btnGenRandomData.Text = "生成随机数据";
            this.btnGenRandomData.UseVisualStyleBackColor = true;
            this.btnGenRandomData.Click += new System.EventHandler(this.btnGenRandomData_Click);
            // 
            // tabpInput
            // 
            this.tabpInput.ColumnCount = 1;
            this.tabpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabpInput.Location = new System.Drawing.Point(167, 165);
            this.tabpInput.Name = "tabpInput";
            this.tabpInput.RowCount = 2;
            this.tabpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabpInput.Size = new System.Drawing.Size(30, 60);
            this.tabpInput.TabIndex = 5;
            this.tabpInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabpInput_MouseClick);
            // 
            // lbCRCGP
            // 
            this.lbCRCGP.AutoSize = true;
            this.lbCRCGP.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCRCGP.Location = new System.Drawing.Point(150, 121);
            this.lbCRCGP.Name = "lbCRCGP";
            this.lbCRCGP.Size = new System.Drawing.Size(144, 19);
            this.lbCRCGP.TabIndex = 7;
            this.lbCRCGP.Text = "P(X) = x^3 + x³";
            // 
            // btnSetCRCGP
            // 
            this.btnSetCRCGP.Location = new System.Drawing.Point(23, 114);
            this.btnSetCRCGP.Name = "btnSetCRCGP";
            this.btnSetCRCGP.Size = new System.Drawing.Size(110, 37);
            this.btnSetCRCGP.TabIndex = 8;
            this.btnSetCRCGP.Text = "设置生成多项式";
            this.btnSetCRCGP.UseVisualStyleBackColor = true;
            this.btnSetCRCGP.Click += new System.EventHandler(this.btnSetCRCGP_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSetCRCGP);
            this.Controls.Add(this.lbCRCGP);
            this.Controls.Add(this.tabpInput);
            this.Controls.Add(this.btnGenRandomData);
            this.Controls.Add(this.tbDataHex);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "IEEE 802.3 以太网帧封装演示";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDestinationMac;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSourceMac;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbDataHex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenRandomData;
        private System.Windows.Forms.TableLayoutPanel tabpInput;
        private System.Windows.Forms.Label lbCRCGP;
        private System.Windows.Forms.Button btnSetCRCGP;
    }
}

