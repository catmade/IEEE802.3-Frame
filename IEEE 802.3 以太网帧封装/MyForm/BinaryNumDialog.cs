using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装.MyForm
{
    public partial class BinaryNumDialog : Form
    {
        public BinaryNumDialog()
        {
            InitializeComponent();
            InitTableLayoutPanel();
            InitLabel();
        }

        /// <summary>
        /// 每列的宽度
        /// </summary>
        private static int ColumnWidth = 20;

        /// <summary>
        /// 每行的高度
        /// </summary>
        private static int RowHeight = 30;

        /// <summary>
        /// 每行显示的比特数
        /// </summary>
        private static int ByteNumOfRow = 2;

        /// <summary>
        /// 总共显示多少bit
        /// </summary>
        private static int TotalByte = 8;

        /// <summary>
        /// 共显示多少行
        /// 其中一行用来显示bit，紧接着的下一行显示下标
        /// </summary>
        private static int RowCount = TotalByte / ByteNumOfRow * 2;

        /// <summary>
        /// 表格布局中，需要有多少列
        /// 其中每 4 个bit一组，每组中间用一列间隔开
        /// 所以为了放下n个bit，共需要 n * 8 列来放数据，n * 2 - 1 来分隔每4个bit
        /// 化简可得到：n * 10 - 1
        /// </summary>
        private static int ColumnCount = ByteNumOfRow * 10 - 1;

        /// <summary>
        /// 所有的用来选择输入的label
        /// </summary>
        private static Label[] lbInputs = new Label[TotalByte * 8];

        /// <summary>
        /// 所有用来标记下标的label
        /// </summary>
        private static Label[] lbIndexs = new Label[TotalByte * 8];

        private void InitLabel()
        {
            int inputIndex = lbInputs.Length - 1;
            int indexIndex = lbIndexs.Length - 1;

            bool putAsInputLabel;
            bool putAsIndexLabel;
            bool putAsDivisionLabel;

            for (int row = 0; row < tabPanel.RowCount; row++)
            { 
                // 偶数行用来控制输入
                for (int column = 0; column < tabPanel.ColumnCount; column++)
                {
                    putAsDivisionLabel = (column % 5 == 4);
                    if (putAsDivisionLabel)
                    {
                        continue;
                    }

                    putAsInputLabel = row % 2 != 1;
                    if (putAsInputLabel)
                    {
                        lbInputs[inputIndex] = new Label();
                        SetInputLabelStyle(ref lbInputs[inputIndex], inputIndex);
                        tabPanel.Controls.Add(lbInputs[inputIndex], column, row);
                        inputIndex--;
                        continue;
                    }

                    putAsIndexLabel = row % 2 == 1;
                    if (putAsIndexLabel)
                    {
                        lbIndexs[indexIndex] = new Label();
                        SetIndexLabelStyle(ref lbIndexs[indexIndex], indexIndex);
                        tabPanel.Controls.Add(lbIndexs[indexIndex], column, row);
                        indexIndex--;
                        continue;
                    }
                }
            }
        }

        private void SetInputLabelStyle(ref Label lable, int index)
        {
            lable.AutoSize = true;
            lable.Dock = System.Windows.Forms.DockStyle.Fill;
            lable.Font = new System.Drawing.Font("Consolas", 18F);
            lable.Location = new System.Drawing.Point(0, 0);
            lable.Margin = new System.Windows.Forms.Padding(0);
            lable.Size = new System.Drawing.Size(20, 40);
            lable.Text = "0";
            lable.MouseClick += Lable_MouseClick;
            lable.MouseEnter += Lable_MouseEnter;
            lable.MouseLeave += Lable_MouseLeave;
            lable.Tag = index;
        }

        private void Lable_MouseLeave(object sender, EventArgs e)
        {
            var label = sender as Label;
            lbInputs[int.Parse(label.Tag.ToString())].ForeColor = Label.DefaultForeColor;
        }

        private void Lable_MouseEnter(object sender, EventArgs e)
        {
            var label = sender as Label;
            lbInputs[int.Parse(label.Tag.ToString())].ForeColor = Color.DodgerBlue;
        }

        private void SetIndexLabelStyle(ref Label lable, int index)
        {
            lable.AutoSize = true;
            lable.Dock = System.Windows.Forms.DockStyle.Fill;
            lable.Font = new System.Drawing.Font("Consolas", 8F);
            lable.Location = new System.Drawing.Point(0, 0);
            lable.Margin = new System.Windows.Forms.Padding(0);
            lable.Size = new System.Drawing.Size(20, 40);
            lable.Text = index.ToString().PadLeft(2);
        }

        private void Lable_MouseClick(object sender, MouseEventArgs e)
        {
            var label = sender as Label;
            if ("0".Equals(label.Text))
            {
                lbInputs[int.Parse(label.Tag.ToString())].Text = "1";
            }
            else
            {
                lbInputs[int.Parse(label.Tag.ToString())].Text = "0";
            }
        }

        private void InitTableLayoutPanel()
        {
            this.tabPanel.RowStyles.Clear();
            this.tabPanel.ColumnStyles.Clear();

            this.tabPanel.RowCount = RowCount;
            // 添加行
            for (int i = 0; i < RowCount; i++)
            {
                // 偶数行的字体比奇数行的字体大，行高要高一些
                if (i % 2 == 0)
                {
                    this.tabPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, RowHeight));
                } 
                else
                {
                    this.tabPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, RowHeight / 2));
                }
            }

            this.tabPanel.ColumnCount = ColumnCount;
            // 添加列
            for (int i = 0; i < ColumnCount; i++)
            {
                // 每 4 列为一组，中间有分割，所以对应位置的列宽度要小一些
                if (i % 5 == 4)
                {
                    this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, ColumnWidth / 2));
                }
                else
                {
                    this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, ColumnWidth));
                }
            }

            this.tabPanel.Width = this.tabPanel.ColumnCount * ColumnWidth;
            this.tabPanel.Height = this.tabPanel.RowCount * RowHeight;
        }

        /// <summary>
        /// 数据
        /// Bytes[2]Bytes[1]Bytes[0]，高字节向低字节
        /// </summary>
        public byte[] Bytes { get; private set; } = new byte[TotalByte];

        /// <summary>
        /// 数值的大小
        /// </summary>
        public long Num {
            get {
                long num = 0;
                for (int i = 0; i < Bytes.Length; i++)
                {
                    num += Bytes[i] * (long)Math.Pow(2, i * 8);
                }
                return num;
            } 
        }

        /// <summary>
        /// 数值为 1 的位置下标
        /// </summary>
        public int[] OneIndexs
        {
            get
            {
                List<int> result = new List<int>();

                for (int i = lbInputs.Length - 1; i >= 0; i--)
                {
                    if ("1".Equals(lbInputs[i].Text))
                    {
                        result.Add(i);
                    }
                }

                return result.ToArray();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = lbInputs.Length - 1; i >= 0; i--)
            {
                builder.Append(lbInputs[i].Text);
            }

            string str = builder.ToString();
            for (int i = 0; i < Bytes.Length; i++)
            {
                string str1 = str.Substring(i * 8, 8);
                Bytes[Bytes.Length - 1 - i] = Convert.ToByte(str1, 2);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
