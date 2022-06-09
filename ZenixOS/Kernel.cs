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
using static ZenixOS.src.UI.ArcUI.LockscreenClock;

using Mouse = Cosmos.System.MouseManager;
using ZenixOS.src.UI.ArcUI;

namespace ZenixOS
{
    public class Kernel : Sys.Kernel
    {
        public static Color PenClearColor = Color.Black;

        public static Canvas canvas;

        public static bool IsLocked = true;
        private static bool IsWake = false;
        
        public static string Input;
        private static string LockScreenPressSpace = "Press space to resume from sleep";

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

            LockscreenClock.Numbers.Add('0', Zero);
            LockscreenClock.Numbers.Add('1', One);
            LockscreenClock.Numbers.Add('2', Two);
            LockscreenClock.Numbers.Add('3', Three);
            LockscreenClock.Numbers.Add('4', Four);
            LockscreenClock.Numbers.Add('5', Five);
            LockscreenClock.Numbers.Add('6', Six);
            LockscreenClock.Numbers.Add('7', Seven);
            LockscreenClock.Numbers.Add('8', Eight);
            LockscreenClock.Numbers.Add('9', Nine);
            LockscreenClock.Numbers.Add(':', Colon);

            System.Threading.Thread.Sleep(1000);
        }

        protected override void Run()
        {            
            canvas.Clear(PenClearColor);

            if (Cosmos.System.KeyboardManager.TryReadKey(out var Key))
            {
                Input += Key.KeyChar;
            }
            else
            {
                Input = "";
            }

            if (!IsLocked)
            {
                
            }
            else
            {
                if (IsWake)
                {
                    LockScreen.DrawLockScreen(Wallpaper1);
                }
                else if (!IsWake)
                {
                    canvas.DrawImage(Sleep, canvas.Mode.Columns / 2 - (int)Sleep.Width / 2, 40);
                    canvas.DrawImage(SleepMenuShutdownButton, 1860, 1020);
                    ASC16.DrawACSIIString(canvas, new Pen(Color.FromArgb(200, 200, 200)), "P", 1873, 1060);

                    DrawClock(30, 1080 - 119 - 30);
                    // ASC16.DrawACSIIString(canvas, new Pen(Color.White), Input, 0, 0);
                    ASC16.DrawACSIIString(canvas, new Pen(Color.FromArgb(80, 80, 80)), LockScreenPressSpace, canvas.Mode.Columns / 2 - (LockScreenPressSpace.Length * 8) / 2, 1050);
                    if (Input == " ")
                    {
                        IsWake = true;
                    }
                    if (Input == "p")
                    {
                        Sys.Power.Shutdown();
                    }
                }
            }

            canvas.Display();
            Cosmos.Core.Memory.Heap.Collect();
        }
    }
}
