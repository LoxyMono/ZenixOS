using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Cosmos.System.Graphics;

using RTC = Cosmos.HAL.RTC;

using static ZenixOS.Kernel;

namespace ZenixOS.src.UI
{
    class LockscreenClock
    {
        public static Dictionary<char, Bitmap> Numbers = new Dictionary<char, Bitmap>();

        private static string ClockString = "";

        public static void DrawClock(int x, int y)
        {
            PenClearColor = Color.FromArgb(20, 20, 20);

            ClockString = $"{RTC.Hour}:{RTC.Minute}";

            DrawClockString(x, y, ClockString);
        }

        private static void DrawClockString(int x, int y, string str)
        {
            int placement = 0;
            foreach (char ch in str)
            {
                canvas.DrawImage(Numbers[ch], x + 10 + (placement * 84), y);
                placement++;
            }
        }
    }
}
