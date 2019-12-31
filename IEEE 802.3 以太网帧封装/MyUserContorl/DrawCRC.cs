using IEEE_802._3_以太网帧封装.FrameItem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装.MyUserContorl
{
    public partial class DrawCRC : UserControl
    {
        public DrawCRC()
        {
            InitializeComponent();
            // 禁止编译器对跨线程访问做检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private static Regex regex = new Regex("^[0-1]+$");
        /// <summary>
        /// 生成多项式（除数）
        /// </summary>
        private char[] Divisor
        {
            get
            {
                if (!regex.IsMatch(this.tbGenPol.Text))
                {
                    MessageBox.Show("生成多项式格式错误，应当为二进制字符串", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return this.tbGenPol.Text.ToArray();
            }
        }

        /// <summary>
        /// 待处理数据（被除数）
        /// </summary>
        private char[] Data
        {
            get
            {
                if (!regex.IsMatch(this.tbData.Text))
                {
                    MessageBox.Show("数据格式错误，应当为二进制字符串", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return this.tbData.Text.ToArray();
            }
        }

        /// <summary>
        /// 每一步之间的毫秒数
        /// </summary>
        private int MilliSecondsTimeout
        {
            get
            {
                return int.Parse(this.tbTimeOut.Text);
            }
        }

        #region 允许调用者自定义的属性
        /// <summary>
        /// 获取或设置拆分器的位置以像素为单位，从左边缘或上边缘的SplitContainer.
        /// </summary>
        public int SplitterDistance
        {
            get
            {
                return this.splitContainer1.SplitterDistance;
            }
            set
            {
                this.splitContainer1.SplitterDistance = value;
            }
        }

        /// <summary>
        /// 获取或设置拆分器的宽度(以像素为单位)
        /// </summary>
        public int SplitterWidth
        {
            get
            {
                return this.splitContainer1.SplitterWidth;
            }
            set
            {
                this.splitContainer1.SplitterWidth = value;
            }
        }

        #endregion

        private static BinaryNumInputDialog binaryDialog = new BinaryNumInputDialog();

        #region 按钮的监听事件
        private void btnSetCRCGP_Click(object sender, EventArgs e)
        {
            if (binaryDialog.ShowDialog() == DialogResult.OK)
            {
                this.tbGenPol.Text = binaryDialog.BinaryString;
                this.lbCRCGP.Text = CRCGeneratingPolynomial.Parse(binaryDialog.IndexsOfOne).ToString();
            }
        }

        private void btnSetData_Click(object sender, EventArgs e)
        {
            if (binaryDialog.ShowDialog() == DialogResult.OK)
            {
                this.tbData.Text = binaryDialog.BinaryString;
            }
        }

        /// <summary>
        /// 用来通知进程结束
        /// </summary>
        private static CancellationTokenSource cts = new CancellationTokenSource();

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.tbResult.Text = "";
            cts.Cancel();
            cts = new CancellationTokenSource();
            Task.Run(() => CalcCRC(Func.Check, cts.Token));
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            this.tbResult.Text = "";
            cts.Cancel();
            cts = new CancellationTokenSource();
            Task.Run(() => CalcCRC(Func.Calc, cts.Token));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
        #endregion

        #region 计算CRC

        /// <summary>
        /// 计算CRC
        /// <paramref name="func">操作</paramref>
        /// </summary>
        private void CalcCRC(Func func, CancellationToken token)
        {
            var sourceData = Data;                  // 原始数据的拷贝
            char[] divisor = Divisor;               // 除数

            #region 判断是否继续执行
            if (sourceData == null || divisor == null)
            {
                return;
            }

            // 检验数据时，数据长度不能小于生成多项式的长度
            if (func == Func.Check && sourceData.Length < divisor.Length)
            {
                MessageBox.Show("数据长度不能小于生成多项式的长度", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            if (func == Func.Calc)
            {
                // 在后面补 0
                sourceData = (new string(sourceData) + "".PadRight(Divisor.Length - 1, '0')).ToArray();
            }

            var data = new Queue<char>(sourceData); // 被除数
            Queue<char> S = new Queue<char>();      // 商
            int width = divisor.Length;             // 每次取 width 个字符进行异或运算

            Queue<char> str = new Queue<char>();    // 每次取的长度为 width 的部分被除数
            // 获取前 width - 1 个字符，填入到str中
            for (int i = 0; i < width - 1; i++)
            {
                str.Enqueue(data.Dequeue());
            }

            int cursor = -1;                                // 只是为了显示计算过程用
            StringBuilder process = new StringBuilder();    // 只是为了显示计算过程用

            char[] temp;
            while (data.Count != 0)
            {
                cursor++;
                str.Enqueue(data.Dequeue());

                if (str.First() == '0')
                {
                    S.Enqueue('0');
                    str.Dequeue();
                }
                else
                {
                    S.Enqueue('1');

                    process.Append("".PadLeft(width + 1 + cursor, ' '))
                        .Append(new string(divisor))
                        .AppendLine("".PadLeft(sourceData.Length - width - cursor, '|'));      // 只是为了显示计算过程用

                    temp = str.ToArray();
                    str.Clear();

                    for (int i = 1; i < temp.Length; i++)
                    {
                        str.Enqueue(temp[i] == divisor[i] ? '0' : '1');
                    }

                }

                #region 只是为了显示计算过程用
                char next = data.Count == 0 ? ' ' : data.First();
                process.Append(
                    new string(str.ToArray()).PadLeft(
                        width + 2 + cursor + str.Count, ' ') + next
                    );
                if (data.Count != 0)
                {
                    process.AppendLine("".PadLeft(sourceData.Length - width - 1 - cursor, '|')); ;              // 只是为了显示计算过程用
                }

                this.tbProcess.Text = new StringBuilder()
                .AppendLine(new string(S.ToArray()).PadLeft(width + 1 + S.Count, ' '))
                .AppendLine(new string(divisor.ToArray()) + '|' + new string(sourceData))
                .AppendLine(process.ToString())
                .ToString();        // 只是为了显示计算过程用

                #endregion

                Thread.Sleep(MilliSecondsTimeout);
                if (token.IsCancellationRequested)
                {   // 收到终止信号后，线程终止
                    return;
                }
            }


            this.tbResult.Text = new string(str.ToArray());

            lbError.Text = "";
            if (func == Func.Check)
            {
                // 判断结果
                bool hasError = false;
                foreach (var item in str.ToArray())
                {
                    if (item != '0')
                    {
                        hasError = true;
                        break;
                    }
                }
                if (hasError)
                {
                    lbError.ForeColor = Color.Red;
                    lbError.Text = "出现错误";
                }
                else
                {
                    lbError.ForeColor = Color.Green;
                    lbError.Text = "没有错误";
                }
            }
        }
        #endregion

    }


    enum Func
    {
        Check,
        Calc
    }

}
