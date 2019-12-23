using IEEE_802._3_以太网帧封装.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEEE_802._3_以太网帧封装.MyForm
{
    public partial class DrawCRCForm : Form
    {
        public DrawCRCForm()
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            DrawSubject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawProcess();
        }

        //private Font drawFont = new Font("Consolas", 16);

        private SolidBrush drawBrush = new SolidBrush(Color.Black);


        Graphics g ; //创建画板

        /// <summary>
        /// 绘制题目
        /// </summary>
        private void DrawSubject()
        {
            this.Show();    // 将画板显示出来

            Pen p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为的画笔
            g.DrawLine(p, GetLTPointOfList(1), GetRBPointOfList(1));//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            //g.DrawString("123456", drawFont, drawBrush, 0, itemHeight * 2);

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
            g.DrawString("123456", font, drawBrush, 0, itemHeight * 2);

        }

        /// <summary>
        /// 绘制解题步骤
        /// </summary>
        private void DrawProcess()
        {

        }

        private static int itemHeight = 30;
        private static int itemWeight = 1500;

        /// <summary>
        /// 获取第n行的左上（Left Top）角的坐标
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Point GetLTPointOfList(int n)
        {
            return new Point(0, itemHeight * n);
        }

        /// <summary>
        /// 获取第n行的右下（Right Bottom）角的坐标
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Point GetRBPointOfList(int n)
        {
            return new Point(itemWeight, itemHeight * n);
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
