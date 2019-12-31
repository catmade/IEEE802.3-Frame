using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// 以太网帧
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// 生成多项式
        /// </summary>
        public static CRCGeneratingPolynomial GenPol =
            CRCGeneratingPolynomial.Parse(new int[] { 32, 26, 23, 22, 26, 12, 11, 12, 8, 7, 5, 4, 2, 1, 0 });

        /// <summary>
        /// 前导码
        /// </summary>
        public static byte[] Preamble = { 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA };

        /// <summary>
        /// 帧前定界符
        /// </summary>
        public static byte SFD = 0xAB;

        /// <summary>
        /// 目的 MAC 地址
        /// </summary>
        public MAC DestinationMac { get; set; }

        /// <summary>
        /// 源 MAC 地址
        /// </summary>
        public MAC SourceMac { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public byte[] Length { get; set; }

        /// <summary>
        /// 数据部分
        /// </summary>
        public Data Data { get; set; }

        /// <summary>
        /// 帧检验序列
        /// </summary>
        public byte[] FrameCheckSequence { get; set; }

        /// <summary>
        /// 根据数据再次计算循环冗余码
        /// </summary>
        /// <returns></returns>
        public byte[] CalcCRC()
        {
            return GenPol.CalcCRC(DestinationMac, SourceMac, Length, Data);
        }

        /// <summary>
        /// 获取检验结果
        /// </summary>
        /// <returns></returns>
        public byte[] CheckCRC()
        {
            return GenPol.CalcCRC(DestinationMac, SourceMac, Length, Data, FrameCheckSequence);
        }
    }
}
