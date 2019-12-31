using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEEE_802._3_以太网帧封装.FrameItem;
using System.Text.RegularExpressions;

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
        private Mode mode = Mode.Set;

        public Mode PanelMode
        {
            get { return mode; }
            set { mode = value; }
        }

        #region 属性
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
                if (PanelMode == Mode.Check)
                {
                    this.tbDestinationAddr.Text = frame.DestinationMac.ToString();
                    this.tbSourceAddr.Text = frame.SourceMac.ToString();
                    this.tbDataLength.Text = ByteArrayToHexStr(frame.Length);
                    this.tbDataHex.Text = frame.Data.ToString();
                    this.tbFCS.Text = ByteArrayToHexStr(frame.FrameCheckSequence);
                }
            }
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
            if(bytes == null || bytes.Length == 0)
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
            this.Frame.FrameCheckSequence = this.Frame.CalcCRC();
            this.tbFCS.Text = ByteArrayToHexStr(this.Frame.FrameCheckSequence);
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
            // TODO
            //GenRandomData(random.Next(Data.MinLength, Data.MaxLength));
            GenRandomData(5);
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
            TextBox tb = sender as TextBox;
            string errorMessage;
            MAC mac;
            errorProvider1.SetError(tb, "");

            if (!MAC.TryParse(tb.Text, out errorMessage, out mac))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.DestinationMac = mac;
                if (PanelMode == Mode.Set)
                {
                    // 重新计算FCS
                    this.Frame.FrameCheckSequence = this.Frame.CalcCRC();
                    this.tbFCS.Text = ByteArrayToHexStr(this.Frame.FrameCheckSequence);
                }
            }
        }

        private void tbSourceAddr_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string errorMessage;
            MAC mac;
            errorProvider1.SetError(tb, "");

            if (!MAC.TryParse(tb.Text, out errorMessage, out mac))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.SourceMac = mac;
                if (PanelMode == Mode.Set)
                {
                    // 重新计算FCS
                    this.Frame.FrameCheckSequence = this.Frame.CalcCRC();
                    this.tbFCS.Text = ByteArrayToHexStr(this.Frame.FrameCheckSequence);
                }
            }
        }
        #endregion

        #region 检查数据部分是否合法
        private void tbDataHex_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string errorMessage;
            Data data;
            errorProvider1.SetError(tb, "");

            if (!Data.TryParse(tb.Text, out errorMessage, out data))
            {
                errorProvider1.SetError(tb, errorMessage);
            }
            else
            {
                this.Frame.Data = data;

                // 设置长度字段
                byte[] bytes = new byte[2];
                int length = this.Frame.Data.Length;
                bytes[0] = Convert.ToByte(length / 256);
                bytes[1] = Convert.ToByte(length % 256);
                this.Frame.Length = bytes;
                this.tbDataLength.Text = ByteArrayToHexStr(this.Frame.Length);

                if (PanelMode == Mode.Set)
                {
                    // 重新计算FCS
                    this.Frame.FrameCheckSequence = this.Frame.CalcCRC();
                    this.tbFCS.Text = ByteArrayToHexStr(this.Frame.FrameCheckSequence);
                }
            }
        }

        #endregion
    }

    public enum Mode
    {
        /// <summary>
        /// 设置以太网帧的模式，会实时更新FCS，如果实时更新，对性能要求比较高
        /// </summary>
        Set,

        /// <summary>
        /// 设置以太网帧的模式，不会实时更新FCS
        /// </summary>
        Silence,

        /// <summary>
        /// 检查以太网帧的模式
        /// </summary>
        Check
    }
}
