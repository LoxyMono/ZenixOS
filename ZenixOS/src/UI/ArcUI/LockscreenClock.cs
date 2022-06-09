using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Cosmos.System.Graphics;

using RTC = Cosmos.HAL.RTC;

using static ZenixOS.Kernel;

namespace ZenixOS.src.UI.ArcUI
{
    class LockscreenClock
    {
        private static int placement;

        public static Dictionary<char, Bitmap> Numbers = new Dictionary<char, Bitmap>();

        private static string ClockString = "";

        public static void DrawClock(int x, int y)
        {
            PenClearColor = Color.FromArgb(0, 0, 0);

            ClockString = $"{RTC.Hour}:{RTC.Minute}";

            DrawClockString(x, y, ClockString, false);
        }

        private static void DrawClockString(int x, int y, string str, bool centered)
        {
            placement = 0;
            foreach (char ch in str)
            {
                if (!centered)
                {
                    canvas.DrawImage(Numbers[ch], x + 20 + placement * 96, y);
                }
                else
                {
                    canvas.DrawImage(Numbers[ch], x + 20 + placement * 96 - 282, y);
                }
                placement++;
            }
        }
    }
}
