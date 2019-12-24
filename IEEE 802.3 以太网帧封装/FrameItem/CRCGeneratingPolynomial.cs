using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// 循环冗余检验 ( Cyclic Redundancy Check )
    /// </summary>
    public class CRCGeneratingPolynomial
    {
        public int Length { get; set; }

        /// <summary>
        /// 指数
        /// </summary>
        public LinkedList<int> Coefficients { get; set; }

        /// <summary>
        /// 自定义优先级链表，采用前插法，数值小的排在后面
        /// </summary>
        /// <param name="n">数</param>
        /// <returns></returns>
        private LinkedListNode<int> Add(int n)
        {
            // 如果长度为0，直接插入
            if(Coefficients.Count == 0)
            {
                return Coefficients.AddFirst(n);
            }

            // 找到合适的位置插入，合适的位置为：比 n 大的数后、比 n 小的数前
            var temp = Coefficients.First;
            for (int i = 0; i < Coefficients.Count; i++)
            {
                if(temp.Value < n)
                {
                    return Coefficients.AddBefore(temp, n);
                }
                temp = temp.Next;
            }

            // 如果没有比 n 小的，说明 n 最小，则直接插在最后
            return Coefficients.AddLast(n);
        }


        private static Regex regex = new Regex("([0-9]{1}(\\s+))*([0-9]{1})");


        //public static bool CanParse(string str, int length, out string errorMessage)
        //{
        //    errorMessage = null;
        //    bool canParse = regex.IsMatch(str);

        //    if (!canParse)
        //    {
        //        errorMessage = "请将指数用空格分割开，而且结尾不要有空白符";
        //    }

        //    int n = int.
        //}

        //public static bool TryParse(string str, int length,out string errorMessage, out CRCGeneratingPolynomial result)
        //{

        //}
    }

}
