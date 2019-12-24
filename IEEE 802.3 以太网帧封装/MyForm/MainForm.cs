using IEEE_802._3_以太网帧封装.FrameItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装.MyForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 检测MAC地址合法性
        private void tbDestinationMac_TextChanged(object sender, EventArgs e)
        {
            CheckMac(sender, e);
        }

        private void tbSourceMac_TextChanged(object sender, EventArgs e)
        {
            CheckMac(sender, e);
        }

        private void CheckMac(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string errorMessage;
            errorProvider1.SetError(tb, "");
            if (!MAC.CanParse(tb.Text, out errorMessage))
            {
                errorProvider1.SetError((Control)sender, errorMessage);
            }
        }
        #endregion

        private void tbDataHex_TextChanged(object sender, EventArgs e)
        {
            string errorMessage;
            errorProvider1.SetError(tbDataHex, "");
            if (!Data.CanParse(tbDataHex.Text, out errorMessage))
            {
                errorProvider1.SetError(tbDataHex, errorMessage);
            }
        }

        private void btnGenRandomData_Click(object sender, EventArgs e)
        {
            this.tbDataHex.Text = Data.GetRandomData(100).ToString();
        }

        private void tabpInput_MouseClick(object sender, MouseEventArgs e)
        {

        }

        #region 设置生成多项式

        private static BinaryNumDialog binaryNumDialog = new BinaryNumDialog();

        private void btnSetCRCGP_Click(object sender, EventArgs e)
        {
            // 显示弹窗并获取数据
            if (binaryNumDialog.ShowDialog(this) == DialogResult.OK)
            {
                lbCRCGP.Text = GenRCGP(binaryNumDialog.OneIndexs);
            }
        }

        private string GenRCGP(int[] indexs) 
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("P(X) = ");

            for (int i = 0; i < indexs.Length; i++)
            {
                builder.Append('x').Append(ConvertNumToSuperscript(indexs[i])).Append(" + ");
            }

            return builder.ToString().Substring(0, builder.Length - 3);
        }

        /// <summary>
        /// 上标符号
        /// </summary>
        private static char[] eops = {'⁰','¹','²','³','⁴','⁵','⁶','⁷','⁸','⁹' };
        /// <summary>
        /// 将数字转为上标字符串
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string ConvertNumToSuperscript(int n)
        {
            var strs = n.ToString().ToCharArray();
            var result = "";
            for (int i = 0; i < strs.Length; i++)
            {
                result += eops[strs[i] - '0'];
            }
            return result;
        }


        #endregion
    }
}
