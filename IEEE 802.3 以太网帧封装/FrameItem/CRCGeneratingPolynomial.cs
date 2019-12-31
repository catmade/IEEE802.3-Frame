using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
        /// <param name="items"></param>
        /// <returns></returns>
        public byte[] CalcCRC(byte[] items)
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
            var data = new Queue<char>(v.ToArray());    // 被除数
            char[] divisor = binaryString.ToArray();    // 除数
            Queue<char> S = new Queue<char>();          // 商
            int width = divisor.Length;                 // 每次取 width 个字符进行异或运算
            Queue<char> str = new Queue<char>();        // 每次取的长度为 width 的部分被除数

            // 获取前 width - 1 个字符，填入到str中
            for (int i = 0; i < width - 1; i++)
            {
                str.Enqueue(data.Dequeue());
            }

            while (data.Count != 0)
            {
                str.Enqueue(data.Dequeue());

                if (str.First() == '0')
                {
                    S.Enqueue('0');
                    str.Dequeue();
                }
                else
                {
                    S.Enqueue('1');

                    var temp = str.ToArray();
                    str.Clear();

                    for (int i = 1; i < temp.Length; i++)
                    {
                        str.Enqueue(temp[i] == divisor[i] ? '0' : '1');
                    }
                }
            }

            var res = new string(str.ToArray()).PadLeft(32, '0');

            Debug.WriteLine("被除数" + v);
            Debug.WriteLine("商    " + res);
            Debug.WriteLine("\n");

            var result = new byte[4];
            // 将字符串格式化为byte
            for (int i = 0; i < 4; i++)
            {
                result[i] = Convert.ToByte(res.Substring(i * 8, 8), 2);
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
