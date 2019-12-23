using IEEE_802._3_以太网帧封装.MyForm;
using IEEE_802._3_以太网帧封装.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 使用自己的字体
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            unsafe
            {

                fixed (byte* pFontData = Resources.consola)
                {
                    privateFonts.AddMemoryFont((IntPtr)pFontData, Resources.consola.Length);
                }
            }

            Font font = new Font(privateFonts.Families[0], 12);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
