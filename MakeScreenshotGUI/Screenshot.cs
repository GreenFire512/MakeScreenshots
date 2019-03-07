using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MakeScreenshotGUI
{
    class Screenshot
    {
        static Bitmap bitsource;

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

        public static Bitmap GetBitmap(Size size, int top, int left)
        {;
            bitsource = new Bitmap(size.Width, size.Height);
            Graphics graph = Graphics.FromImage(bitsource);
            graph.CopyFromScreen(left, top, 0, 0, size);
            return bitsource;
        }

        public static void TakeFullScreen()
        {
            Size size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Save(GetBitmap(size, 0, 0), Settings.dir);
        }

        public static void TakeActiveScreen()
        {
            Rect rect = new Rect();
            GetWindowRect(GetForegroundWindow(), ref rect);
            Size size = new Size(rect.Right - rect.Left - 14, rect.Bottom - rect.Top - 7);
            Save(GetBitmap(size, rect.Top, rect.Left + 7), Settings.dir);
        }

        private static void Save(Bitmap img, string path)
        {
            path = (Directory.Exists(path)) ? path : Application.StartupPath;
            DateTime date = DateTime.Now;

            switch (Settings.pic_format)
            {
                case ".jpg":
                    img.Save(path + "\\" + date.ToString("yyyymmdd-Hmmss") + ".jpg", ImageFormat.Jpeg);
                    break;
                case ".png":
                default:
                    img.Save(path + "\\" + date.ToString("yyyymmdd-Hmmss") + ".png", ImageFormat.Png);
                    break;
            }
            img.Dispose();
        }

        public static void TakeClipScreen() {
            Size size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            ScreenClip windows = new ScreenClip(Screenshot.GetBitmap(size, 0, 0));
            windows.Show();
        }

        public static void TakeClipScreen(Bitmap bitmap, System.Windows.Point p1, System.Windows.Point p2)
        {
            Size size = new Size((int)(p2.X - p1.X), (int)(p2.Y - p1.Y));
            Bitmap img = ResizeBitmap(GetBitmap(size, (int)p1.X, (int)p1.Y), size.Width, size.Height);
            Save(img, Settings.dir);
        }

        private static Bitmap ResizeBitmap(Bitmap source, int sizex, int sizey)
        {
            Bitmap result = new Bitmap(sizex, sizey);
            Graphics graph = Graphics.FromImage(result);
            graph.DrawImage(source, new Rectangle(0, 0, sizex, sizey), 0, 0, sizex, sizey, GraphicsUnit.Pixel);
            return result;
        }
    }

}
