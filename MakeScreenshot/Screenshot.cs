using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MakeScreenshot
{
    class Screenshot
    {
        Bitmap bitpic;

        // Список окон
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        //
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }



        public void TakeFullScreen()
        {
            bitpic = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Graphics graph = Graphics.FromImage(bitpic);
            graph.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            Save();
        }

        public void TakeActiveScreen()
        {
            IntPtr handle = GetForegroundWindow();
            Rect rct = new Rect();
            GetWindowRect(handle, ref rct);
            Size size = new Size(rct.Right - rct.Left - 14, rct.Bottom - rct.Top - 7);

            bitpic = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
            Graphics graph = Graphics.FromImage(bitpic);
            graph.CopyFromScreen(rct.Left + 7, rct.Top, 00, 0, size);
            Save();
        }

        private void Save()
        {
            bitpic.Save("screen_0.png", ImageFormat.Png);
        }

    }

}
