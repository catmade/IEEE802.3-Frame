using System;
using System.Collections.Generic;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// 以太网帧
    /// </summary>
    public class Frame : ICloneable
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
        public Length Length { get; set; }

        /// <summary>
        /// 数据部分
        /// </summary>
        public Data Data { get; set; }

        /// <summary>
        /// 帧检验序列 FrameCheckSequence
        /// </summary>
        public FCS FCS { get; set; }

        /// <summary>
        /// 根据待检验数据（源地址、目的地址、长度、数据）计算循环冗余码
        /// </summary>
        /// <returns></returns>
        public byte[] CalcCRC()
        {
            List<byte> list = new List<byte>();
            list.AddRange(DestinationMac.Bytes);
            list.AddRange(SourceMac.Bytes);
            list.AddRange(Length.Bytes);
            list.AddRange(Data.Bytes);
            list.AddRange(new byte[] { 0, 0, 0, 0 });
            return GenPol.CalcCRC(list.ToArray());
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 数据是否出错
        /// </summary>
        public bool NoError
        {
            get
            {
                if (!IsIntegrated)
                {
                    return false;
                }

                List<byte> list = new List<byte>();
                list.AddRange(DestinationMac.Bytes);
                list.AddRange(SourceMac.Bytes);
                list.AddRange(Length.Bytes);
                list.AddRange(Data.Bytes);
                list.AddRange(FCS.Bytes);

                var format = GenPol.CalcCRC(list.ToArray());

                return format[0] == 0x0
                    && format[0] == 0x0
                    && format[0] == 0x0
                    && format[0] == 0x0;
            }
        }

        /// <summary>
        /// 帧是否完整
        /// </summary>
        public bool IsIntegrated
        {
            get
            {
                return GenPol != null &&
                    Preamble != null &&
                    DestinationMac != null &&
                    SourceMac != null &&
                    Length != null &&
                    Data != null &&
                    FCS != null;
            }
        }

        public bool CanCalcCRC
        {
            get
            {
                return GenPol != null &&
                    Preamble != null &&
                    DestinationMac != null &&
                    SourceMac != null &&
                    Length != null &&
                    Data != null;
            }
        }
    }
}
