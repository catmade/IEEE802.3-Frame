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
    class Frame
    {
        /// <summary>
        /// 目的 MAC 地址
        /// </summary>
        private MAC DestinationMac { get; set; }

        /// <summary>
        /// 源 MAC 地址
        /// </summary>
        private MAC SourceMac { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        private Type Type { get; set; }

        /// <summary>
        /// 数据部分
        /// </summary>
        private Data Data { get; set; }

        /// <summary>
        /// 帧检验序列
        /// </summary>
        private byte[] FrameCheckSequence { get; set; }

    }
}
