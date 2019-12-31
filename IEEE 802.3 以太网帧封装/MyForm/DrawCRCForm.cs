using IEEE_802._3_以太网帧封装.FrameItem;
using IEEE_802._3_以太网帧封装.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装.MyForm
{
    public partial class DrawCRCForm : Form
    {
        public DrawCRCForm()
        {
            InitializeComponent();
            // 禁止编译器对跨线程访问做检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 生成多项式（除数）
        /// </summary>
        private char[] Divisor
        {
            get
            {
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

        private static CancellationTokenSource cts = new CancellationTokenSource();

        private void btnCheck_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
            Task.Run(() => CalcCRC(Func.Check, cts.Token));
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
            this.tbData.Text += "".PadLeft(Divisor.Length - 1, '0');
            Task.Run(() => CalcCRC(Func.Calc, cts.Token));
        }
        #endregion


        #region 计算CRC

        /// <summary>
        /// 指示线程是否继续执行
        /// </summary>
        bool stop = false;

        /// <summary>
        /// 计算CRC
        /// <paramref name="func">操作</paramref>
        /// </summary>
        private void CalcCRC(Func func, CancellationToken token)
        {
            this.tbResult.Text = "";

            var sourceData = Data;                  // 原始数据的拷贝
            var data = new Queue<char>(sourceData);
            char[] divisor = Divisor;               // 除数
            Queue<char> S = new Queue<char>();      // 商
            int width = divisor.Length;             // 每次取 width 个字符进行异或运算

            Queue<char> str = new Queue<char>();    // 被除数
            // 获取前 width - 1 个字符，填入到str中
            for (int i = 0; i < width - 1; i++)
            {
                str.Enqueue(data.Dequeue());
            }

            int cursor = -1;    // 只是为了显示计算过程用
            StringBuilder process = new StringBuilder();        // 只是为了显示计算过程用

            char[] temp;
            while (data.Count != 0)
            {
                if (stop)
                {
                    return;
                }

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
