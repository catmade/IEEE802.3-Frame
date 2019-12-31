using IEEE_802._3_以太网帧封装.FrameItem;
using System;
using System.Drawing;
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
            this.senderPanel.ClearFCS();
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
                this.senderPanel.ClearFCS();
            }
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!this.senderPanel.Frame.IsIntegrated)
            {
                MessageBox.Show("帧数据不完整，发送失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tab.SelectedIndex = 1;
            this.receiverPanel.Frame = this.senderPanel.Frame.Clone() as Frame;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.receiverPanel.Frame.NoError)
            {
                this.lbCheckResult.Text = "数据没有错误";
                this.lbCheckResult.ForeColor = Color.Green;
                MessageBox.Show("数据没有错误", "检测结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.lbCheckResult.Text = "数据出现错误";
                this.lbCheckResult.ForeColor = Color.Red;
                MessageBox.Show("数据出现错误", "检测结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCompleteData_Click(object sender, EventArgs e)
        {
            if (!this.senderPanel.Frame.CanCalcCRC)
            {
                MessageBox.Show("帧数据不完整，无法进行计算", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.senderPanel.CalcFCS();
        }
    }
}
