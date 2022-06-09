using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Cosmos.System.Graphics;

using static ZenixOS.Kernel;

namespace ZenixOS.src
{
    class Boot
    {
        // Logo and system images
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.Logo.bmp")] public static byte[] zenixlogo;

        // Numbers for the Lockscreen Clock

        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.Zero.bmp")] public static byte[] zero;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.1.bmp")] public static byte[] one;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.2.bmp")] public static byte[] two;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.3.bmp")] public static byte[] three;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.4.bmp")] public static byte[] four;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.5.bmp")] public static byte[] five;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.6.bmp")] public static byte[] six;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.7.bmp")] public static byte[] seven;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.8.bmp")] public static byte[] eight;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.9.bmp")] public static byte[] nine;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.Colon.bmp")] public static byte[] colon;

        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.Sleep.bmp")] public static byte[] sleep;
        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.SleepMenuShutdownButton.bmp")] public static byte[] sleepmenushutdownbutton;

        [ManifestResourceStream(ResourceName = "ZenixOS.src.UI.IMG.Wallpaper1.bmp")] public static byte[] wp1;

        public static Bitmap ZenixLogo = null;

        public static Bitmap Zero = null;
        public static Bitmap One = null;
        public static Bitmap Two = null;
        public static Bitmap Three = null;
        public static Bitmap Four = null;
        public static Bitmap Five = null;
        public static Bitmap Six = null;
        public static Bitmap Seven = null;
        public static Bitmap Eight = null;
        public static Bitmap Nine = null;
        public static Bitmap Colon = null;

        public static Bitmap Sleep = null;
        public static Bitmap SleepMenuShutdownButton = null;

        public static Bitmap Wallpaper1 = null;

        public static void LoadFiles()
        {
            ZenixLogo = new Bitmap(zenixlogo);
            canvas.DrawImage(ZenixLogo, canvas.Mode.Columns / 2 - (int)ZenixLogo.Width / 2, canvas.Mode.Rows / 2 - (int)ZenixLogo.Height / 2);
            canvas.Display();


            Zero = new Bitmap(zero);
            One = new Bitmap(one);
            Two = new Bitmap(two);
            Three = new Bitmap(three);
            Four = new Bitmap(four);
            Five = new Bitmap(five);
            Six = new Bitmap(six);
            Seven = new Bitmap(seven);
            Eight = new Bitmap(eight);
            Nine = new Bitmap(nine);
            Colon = new Bitmap(colon);

            Sleep = new Bitmap(sleep);
            SleepMenuShutdownButton = new Bitmap(sleepmenushutdownbutton);

            Wallpaper1 = new Bitmap(wp1);
        }
    }
}
