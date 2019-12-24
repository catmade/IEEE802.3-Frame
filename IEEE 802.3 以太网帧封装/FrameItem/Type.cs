using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEE_802._3_以太网帧封装.FrameItem
{
    /// <summary>
    /// 帧类型
    /// </summary>
    public enum Type
    {
        IPMessage = 0x0800,

        NovellIPX = 0x8137
    }
}
