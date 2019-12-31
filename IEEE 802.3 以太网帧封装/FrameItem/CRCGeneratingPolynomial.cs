using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// 循环冗余检验 ( Cyclic Redundancy Check )
    /// </summary>
    public class CRCGeneratingPolynomial
    {
        private int[] indexsOfOne;

        private string binaryString
        {
            get
            {
                var maxIndex = indexsOfOne[0];  // 最大的下标
                char[] strs = new char[maxIndex + 1];

                // 将所有位都标记为 0
                for (int i = 0; i < strs.Length; i++)
                {
                    strs[i] = '0';
                }

                // 将部分位修改为 1
                foreach (var i in indexsOfOne)
                {
                    strs[strs.Length - i - 1] = '1';
                }

                return new string(strs);
            }
        }

        /// <summary>
        /// 计算循环冗余码
        /// </summary>
        /// <param name="destinationMac"></param>
        /// <param name="sourceMac"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] CalcCRC(MAC destinationMac, MAC sourceMac, byte[] length, Data data)
        {
            // 后面填充 4 个 0 字节数据
            return CalcCRC(destinationMac, sourceMac, length, data, new byte[] { 0, 0, 0, 0 });
        }

        /// <summary>
        /// 计算循环冗余码
        /// </summary>
        /// <param name="destinationMac"></param>
        /// <param name="sourceMac"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <param name="fcs"></param>
        /// <returns></returns>
        public byte[] CalcCRC(MAC destinationMac, MAC sourceMac, byte[] length, Data data, byte[] fcs)
        {
            List<byte> list = new List<byte>();

            list.AddRange(destinationMac.Bytes);
            list.AddRange(sourceMac.Bytes);
            list.AddRange(length);
            list.AddRange(data.Bytes);
            list.AddRange(fcs);

            return CalcCRC(list.ToArray());
        }

        /// <summary>
        /// 计算循环冗余码
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private byte[] CalcCRC(byte[] items)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(Convert.ToString(item, 2).PadLeft(8, '0'));
            }

            return CalcCRC(builder.ToString());
        }

        /// <summary>
        /// 计算循环冗余码
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private byte[] CalcCRC(string v)
        {
            var data = new Queue<char>(v.ToArray());

            // 除数
            char[] divisor = binaryString.ToArray();

            // 商
            Queue<char> S = new Queue<char>();

            // 每次取 width 个字符进行异或运算
            int width = divisor.Length;

            // 被除数
            Queue<char> str = new Queue<char>();
            // 获取前 width - 1 个字符，填入到str中
            for (int i = 0; i < width - 1; i++)
            {
                str.Enqueue(data.Dequeue());
            }

            char[] temp;

            // delete. just for debug
            int cursor = -1;
            string strDivisor = new string(divisor);
            string str0 = "00000000000000000000000000000000";
            int totalWidth = divisor.Length + 1 + v.Length;
            // delete

            StringBuilder process = new StringBuilder();

            while (data.Count != 0)
            {
                cursor++;
                str.Enqueue(data.Dequeue());

                if (str.First() == '0')
                {
                    S.Enqueue('0');
                    str.Dequeue();

                    process.Append(LongChar(width + 1 + cursor, ' '))
                    .AppendLine(str0);
                    //.AppendLine(LongChar(totalWidth - width - 1 - cursor - 32, '|'));
                }
                else
                {
                    S.Enqueue('1');
                    process.Append(LongChar(width + 1 + cursor, ' '))
                    .AppendLine(strDivisor);
                    //.AppendLine(LongChar(toktalWidth - width - 1 - cursor - 32, '|'));

                    temp = str.ToArray();
                    str.Clear();

                    for (int i = 1; i < temp.Length; i++)
                    {
                        str.Enqueue(temp[i] == divisor[i] ? '0' : '1');
                    }

                }

                process.Append(LongChar(width + 1 + cursor, ' '))
                    .AppendLine(new string(str.ToArray()));
                    //.AppendLine(LongChar(totalWidth - width - 1 - cursor - 32, '|'));

            }

            File.WriteAllText("C://Users//Seven//Desktop//计算过程.txt",
                new StringBuilder()
                .AppendLine(LongChar(width + 1, ' ') + new string(S.ToArray()))
                .AppendLine(new string(divisor.ToArray()) + '|' + v)
                .AppendLine(process.ToString())
                .ToString());

            var result = new byte[4];
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 32 - str.Count; i++)
            {
                builder.Append('0');
            }
            while (str.Count != 0)
            {
                builder.Append(str.Dequeue());
            }

            for (int i = 0; i < 4; i++)
            {
                result[3 - i] = Convert.ToByte(builder.ToString().Substring(i * 8, 8), 2);
            }

            return result;
        }

        public static CRCGeneratingPolynomial Parse(int[] indexsOfOne)
        {
            var result = new CRCGeneratingPolynomial();
            result.indexsOfOne = indexsOfOne;

            return result;
        }

        public string LongChar(int length, char c)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(c);
            }
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("P(X) = ");

            for (int i = 0; i < indexsOfOne.Length; i++)
            {
                builder.Append('x').Append(ConvertNumToSuperscript(indexsOfOne[i])).Append(" + ");
            }

            return builder.ToString().Substring(0, builder.Length - 3);
        }

        #region 获取指定数字对应的上标字符串，即："123" -> "¹²³"
        /// <summary>
        /// 上标符号
        /// </summary>
        private static char[] eops = { '⁰', '¹', '²', '³', '⁴', '⁵', '⁶', '⁷', '⁸', '⁹' };

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
