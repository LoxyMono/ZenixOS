using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Cosmos.System.Graphics;

using static ZenixOS.Kernel;

namespace ZenixOS.src.UI.ArcUI
{
    class LockScreen
    {
        public static void DrawLockScreen(Bitmap LockImage)
        {
            if (LockImage.Width < canvas.Mode.Columns || LockImage.Height < canvas.Mode.Rows || LockImage.Width > canvas.Mode.Columns || LockImage.Height > canvas.Mode.Rows)
            {
                canvas.DrawImage(LockImage, 0, 0, 1920, 1080);
            }
            else
            {
                canvas.DrawImage(LockImage, 0, 0);
            }
        }
    }
}
