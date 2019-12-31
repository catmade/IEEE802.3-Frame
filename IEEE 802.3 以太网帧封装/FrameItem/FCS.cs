using System;
using System.Text;
using System.Text.RegularExpressions;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    public class FCS
    {
        private byte[] bytes;

        public byte[] Bytes { get { return bytes; } }

        private static Regex regex = new Regex("^([0-9a-fA-F0]{2}[ ]){3}[0-9a-fA-F0]{2}$");

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
                errorMessage = "长度字段格式错误，应当为 4 字节，正确的例子如：3c 21 1C D0（大小写均可以）";
            }
            return result;
        }

        /// <summary>
        /// 尝试将字符串格式的解析为 FCS 格式
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="errorMessage">如果解析出错，会返回错误信息</param>
        /// <param name="result">如果解析出错，result=null</param>
        /// <returns>是否解析成功</returns>
        public static bool TryParse(string str, out string errorMessage, out FCS result)
        {
            result = null;
            bool canParse = CanParse(str, out errorMessage);

            if (canParse)
            {
                result = new FCS();
                result.bytes = new byte[4];

                var hexs = str.Split(' ');
                result.bytes[0] = Convert.ToByte(hexs[0], 16);
                result.bytes[1] = Convert.ToByte(hexs[1], 16);
                result.bytes[2] = Convert.ToByte(hexs[2], 16);
                result.bytes[3] = Convert.ToByte(hexs[3], 16);
            }

            return canParse;
        }

        public static bool TryParse(byte[] bytes, out string errorMessage, out FCS result)
        {
            result = null;
            errorMessage = "";
            bool canParse = bytes.Length == 4;

            if (!canParse)
            {
                errorMessage = "数据长度错误";
            }
            else
            {
                result = new FCS();
                result.bytes = bytes;
            }

            return canParse;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this.bytes)
            {
                builder.Append(item.ToString("X").PadLeft(2, '0')).Append(' ');
            }
            return builder.ToString().Substring(0, builder.Length - 1);
        }
    }
}
