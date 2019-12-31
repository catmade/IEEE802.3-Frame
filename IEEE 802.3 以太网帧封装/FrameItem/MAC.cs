using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// MAC 地址
    /// </summary>
    public class MAC
    {
        /// <summary>
        /// MAC 地址
        /// </summary>
        private byte[] mac { get; set; }

        public byte[] Bytes { get { return mac; } }

        /// <summary>
        /// MAC 地址格式，用空格分隔
        /// </summary>
        private static Regex regex = new Regex("^([A-Fa-f0-9]{2} ){5}[A-Fa-f0-9]{2}$");

        public MAC()
        {
            this.mac = new byte[6];
        }

        /// <summary>
        /// 判断字符串是否可以被解析
        /// </summary>
        /// <param name="str">被检测字符串</param>
        /// <param name="errorMessage">错误信息（如果格式不正确的话）</param>
        /// <returns></returns>
        public static bool CanParse(string str, out string errorMessage)
        {
            errorMessage = "";
            bool result = regex.IsMatch(str);
            if (!result)
            {
                errorMessage = "MAC 地址格式错误，正确的例子如：1C D0 03 5B 22 95（大小写均可以）";
            }
            return result;
        }

        /// <summary>
        /// 尝试将字符串格式的解析为 MAC 格式
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="errorMessage">如果解析出错，会返回错误信息</param>
        /// <param name="result">如果解析出错，result=null</param>
        /// <returns>是否解析成功</returns>
        public static bool TryParse(string str, out string errorMessage, out MAC result)
        {
            result = null;
            bool canParse = CanParse(str, out errorMessage);

            if (canParse)
            {
                result = new MAC();
                var hexs = str.Split(' ');
                for (int i = 0; i < 6; i++)
                {
                    result.mac[i] = Convert.ToByte(hexs[i], 16);
                }
            }

            return canParse;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this.mac)
            {
                builder.Append(item.ToString("X").PadLeft(2, '0')).Append(' ');
            }
            return builder.ToString().Substring(0, builder.Length - 1);
        }

        /// <summary>
        /// 生成随机MAC地址
        /// </summary>
        /// <returns></returns>
        public static MAC GetRandomMac()
        {
            var result = new MAC();
            Random random = new Random();
            random.NextBytes(result.mac);
            return result;
        }
    }
}
