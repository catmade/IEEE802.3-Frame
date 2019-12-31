using IEEE_802._3_以太网帧封装.FrameItem;
using System;
using System.Text;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装
{
    public partial class FramePanel : UserControl
    {
        public FramePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 面板模式
        /// </summary>
        private Mode mode = Mode.InputData;

        public Mode PanelMode
        {
            get { return mode; }
            set
            {
                mode = value;
                if (mode == Mode.InputData)
                {
                    this.tbFCS.ReadOnly = true;
                    this.tbDataLength.ReadOnly = true;
                }
            }
        }

        #region 供使用者调用的方法
        /// <summary>
        /// 以太网帧
        /// </summary>
        private Frame frame = new Frame();

        /// <summary>
        /// 以太网帧
        /// </summary>
        public Frame Frame
        {
            get { return frame; }
            set
            {
                frame = value;
                if (PanelMode == Mode.DisplayData)
                {
                    this.tbDestinationAddr.Text = frame.DestinationMac.ToString();
                    this.tbSourceAddr.Text = frame.SourceMac.ToString();
                    this.tbDataLength.Text = frame.Length.ToString();
                    this.tbDataHex.Text = frame.Data.ToString();
                    this.tbFCS.Text = frame.FCS.ToString();
                }
            }
        }

        /// <summary>
        /// 将校验字段数据清空
        /// </summary>
        public void ClearFCS()
        {
            this.tbFCS.Text = "";
            this.Frame.FCS = null;
        }
        #endregion

        #region 工具方法
        /// <summary>
        /// 将byte数组转换成十六进制字符串，并用空格分隔，如：0000 1111 => 0F
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static string ByteArrayToHexStr(params byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in bytes)
            {
                builder.Append(item.ToString("X").PadLeft(2, '0')).Append(' ');
            }
            return builder.ToString();
        }

        private static Random random = new Random();

        public void CalcFCS()
        {
            string errorMessage;
            FCS fcs;
            FCS.TryParse(this.Frame.CalcCRC(), out errorMessage, out fcs);
            this.Frame.FCS = fcs;
            this.tbFCS.Text = fcs.ToString();
        }

        #region 生成随机数据
        public void GenAllRandom()
        {
            GenRandomData();
            GenRandomMac();
        }

        public void GenRandomMac()
        {
            var mac = MAC.GetRandomMac();
            this.Frame.SourceMac = mac;
            this.tbSourceAddr.Text = mac.ToString();

            mac = MAC.GetRandomMac();
            this.Frame.DestinationMac = mac;
            this.tbDestinationAddr.Text = mac.ToString();
        }

        public void GenRandomData()
        {
            GenRandomData(random.Next(Data.MinLength, Data.MaxLength));
        }

        public void GenRandomData(int length)
        {
            var data = Data.GetRandomData(length);
            this.Frame.Data = data;
            this.tbDataHex.Text = data.ToString();
        }
        #endregion

        #endregion

        #region 检查 MAC 地址字符串是否合法
        private void tbDestinationAddr_TextChanged(object sender, EventArgs e)
        {
            if (mode == Mode.InputData)
            {
                ClearFCS();
            }

            TextBox tb = sender as TextBox;
            string errorMessage;
            MAC mac;
            errorProvider1.SetError(tb, "");
            this.Frame.DestinationMac = null;

            if (!MAC.TryParse(tb.Text, out errorMessage, out mac))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.DestinationMac = mac;
            }
        }

        private void tbSourceAddr_TextChanged(object sender, EventArgs e)
        {
            if (mode == Mode.InputData)
            {
                ClearFCS();
            }

            TextBox tb = sender as TextBox;
            string errorMessage;
            MAC mac;
            errorProvider1.SetError(tb, "");
            this.Frame.SourceMac = null;

            if (!MAC.TryParse(tb.Text, out errorMessage, out mac))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.SourceMac = mac;
            }
        }
        #endregion

        #region 检查数据部分是否合法
        private void tbDataHex_TextChanged(object sender, EventArgs e)
        {
            if(mode == Mode.InputData)
            {
                ClearFCS();
            }

            TextBox tb = sender as TextBox;
            string errorMessage;
            Data data;
            errorProvider1.SetError(tb, "");
            this.Frame.Data = null;

            if (!Data.TryParse(tb.Text, out errorMessage, out data))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.Data = data;

                if (mode == Mode.InputData)
                {
                    Length len = new Length();
                    Length.TryParse(this.Frame.Data.Length, out errorMessage, out len);
                    this.Frame.Length = len;
                    this.tbDataLength.Text = this.Frame.Length.ToString();
                }
            }
        }

        #endregion

        private void tbFCS_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string errorMessage;
            FCS fcs;
            errorProvider1.SetError(tb, "");
            this.Frame.FCS = null;

            if (!FCS.TryParse(tb.Text, out errorMessage, out fcs))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.FCS = fcs;
            }
        }

        private void tbDataLength_TextChanged(object sender, EventArgs e)
        {
            if (mode == Mode.InputData)
            {
                ClearFCS();
            }

            TextBox tb = sender as TextBox;
            string errorMessage;
            Length length;
            errorProvider1.SetError(tb, "");
            this.Frame.Length = null;

            if (!Length.TryParse(tb.Text, out errorMessage, out length))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.Length = length;
            }
        }
    }

    public enum Mode
    {
        /// <summary>
        /// 输入数据的模式，会根据数据长度的变化自动设置长度字段的值
        /// </summary>
        InputData,

        /// <summary>
        /// 显示数据的模式，仅将数据显示出来，不会检查长度字段的值是否正确
        /// </summary>
        DisplayData
    }
}
