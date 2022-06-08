using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.HAL.Drivers.PCI.Video;

using static ZenixOS.ExternalCommand;
using static ZenixOS.src.Boot;

using Mouse = Cosmos.System.MouseManager;

namespace ZenixOS
{
    public class Kernel : Sys.Kernel
    {
        public static Color PenClearColor = Color.Black;

        public static Canvas canvas;

        [ManifestResourceStream(ResourceName = "ZenixOS.src.Cursor.bmp")] public static byte[] cursor;

        public static Bitmap Cursor = null;

        protected override void BeforeRun()
        {
            Console.Clear();
            OK("Zenix booted, initialize canvas...");
            
            canvas = new SVGAIICanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));

            Mouse.ScreenWidth = (uint)canvas.Mode.Columns;
            Mouse.ScreenHeight = (uint)canvas.Mode.Rows;
            
            foreach (Mode aMode in canvas.AvailableModes)
            {
                mDebugger.Send(aMode.ToString());
            }

            src.Boot.LoadFiles();

            src.UI.LockscreenClock.Numbers.Add('0', Zero);
            src.UI.LockscreenClock.Numbers.Add('1', One);
            src.UI.LockscreenClock.Numbers.Add('2', Two);
            src.UI.LockscreenClock.Numbers.Add('3', Three);
            src.UI.LockscreenClock.Numbers.Add('4', Four);
            src.UI.LockscreenClock.Numbers.Add('5', Five);
            src.UI.LockscreenClock.Numbers.Add('6', Six);
            src.UI.LockscreenClock.Numbers.Add('7', Seven);
            src.UI.LockscreenClock.Numbers.Add('8', Eight);
            src.UI.LockscreenClock.Numbers.Add('9', Nine);
            src.UI.LockscreenClock.Numbers.Add(':', Colon);
        }

        protected override void Run()
        {
            canvas.Clear(PenClearColor);

            src.UI.LockscreenClock.DrawClock(0, 0);

            canvas.Display();

            Cosmos.Core.Memory.Heap.Collect();
        }
    }
}
