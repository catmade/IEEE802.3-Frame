using System;
using System.Text;
using System.Text.RegularExpressions;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// 帧的数据部分
    /// </summary>
    public class Data
    {
        private byte[] data { get; set; }

        public byte[] Bytes { get { return data; } }

        /// <summary>
        /// 数据的字节数
        /// </summary>
        public int Length
        {
            get { return data.Length; }
        }

        /// <summary>
        /// 数据长度最小值（字节）
        /// </summary>
        public static int MinLength = 64;

        /// <summary>
        /// 数据长度最大值（字节）
        /// </summary>
        public static int MaxLength = 1500;

        /// <summary>
        /// 限定数据格式为
        /// a1 b1 11 25
        /// 这样的格式
        /// </summary>
        private static Regex regex = new Regex("^([A-Fa-f0-9]{2}[\\s+])*([A-Fa-f0-9]{2})$");

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
                errorMessage = "数据格式错误，数据用十六进制表示，每个字节的数据用空格分割开，如：0a 11 b4";
            }

            return result;
        }

        /// <summary>
        /// 尝试将字符串格式的解析为 Data 格式
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="errorMessage">如果解析出错，会返回错误信息</param>
        /// <param name="result">如果解析出错，result=null</param>
        /// <returns>是否解析成功</returns>
        public static bool TryParse(string str, out string errorMessage, out Data result)
        {
            result = null;
            bool canParse = CanParse(str, out errorMessage);

            if (canParse)
            {
                result = new Data();
                var hexs = Regex.Split(str, "\\s+");
                result.data = new byte[hexs.Length];
                for (int i = 0; i < result.data.Length; i++)
                {
                    result.data[i] = Convert.ToByte(hexs[i], 16);
                }
            }

            return canParse;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this.data)
            {
                builder.Append(item.ToString("X").PadLeft(2, '0')).Append(' ');
            }
            return builder.ToString().Substring(0, builder.Length - 1);
        }

        /// <summary>
        /// 生成指定长度的随机数据
        /// </summary>
        /// <param name="countOfByte"></param>
        /// <returns></returns>
        public static Data GetRandomData(int countOfByte)
        {
            var result = new Data();
            result.data = new byte[countOfByte];
            Random random = new Random();
            random.NextBytes(result.data);

            return result;
        }
    }
}
