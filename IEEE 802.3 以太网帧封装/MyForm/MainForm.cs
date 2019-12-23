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
    }
}
