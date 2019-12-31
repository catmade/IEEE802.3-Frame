using IEEE_802._3_以太网帧封装.FrameItem;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); 
            lbCRCGP.Text = Frame.GenPol.ToString();
        }

        /// <summary>
        /// 生成随机数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenRandomData_Click(object sender, EventArgs e)
        {
            this.senderPanel.GenAllRandom();
        }

        #region 设置生成多项式

        private static BinaryNumInputDialog binaryNumDialog = new BinaryNumInputDialog();

        private void btnSetCRCGP_Click(object sender, EventArgs e)
        {
            // 显示弹窗并获取数据
            if (binaryNumDialog.ShowDialog(this) == DialogResult.OK)
            {
                Frame.GenPol = CRCGeneratingPolynomial.Parse(binaryNumDialog.IndexsOfOne);
                lbCRCGP.Text = Frame.GenPol.ToString();
            }
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
            this.receiverPanel.Frame = this.senderPanel.Frame;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var format = this.receiverPanel.Frame.CalcCRC();            // 正确的数据
            var real = this.receiverPanel.Frame.FrameCheckSequence;     // 实际接收到的数据
            bool equal = 
                format[0] == real[0]
                && format[0] == real[0]
                && format[0] == real[0]
                && format[0] == real[0];

            if (!equal)
            {
                MessageBox.Show("数据出现错误", "检测结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompleteData_Click(object sender, EventArgs e)
        {
            this.senderPanel.CalcFCS();
        }

        private void lbCRCGP_Click(object sender, EventArgs e)
        {

        }
    }
}
