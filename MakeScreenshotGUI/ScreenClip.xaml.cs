using MakeScreenshot;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MakeScreenshotGUI
{
    /// <summary>
    /// Логика взаимодействия для ScreenClip.xaml
    /// </summary>
    public partial class ScreenClip : Window
    {
        System.Windows.Point p1;
        System.Windows.Point p2;

        public ScreenClip(Bitmap img)
        {
            InitializeComponent();
            using (MemoryStream memory = new MemoryStream())
            {
                img.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                PictureBox.Source = bitmapimage;
            }
        }

        private void Button_Close (object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MouseLeftButton_Down(object sender, MouseButtonEventArgs e)
        {
            p1 = e.GetPosition(this);
            //SelectImg();
        }

        private void MouseLeftButton_Up(object sender, MouseButtonEventArgs e)
        {
            p2 = e.GetPosition(this);
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapImage buf = PictureBox.Source as BitmapImage;
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(buf));
                enc.Save(outStream);
                Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                Screenshot.TakeClipScreen(bitmap, p1, p2);
            }
            Close();
            //SelectImg();
        }

        private void SelectImg()
        {
            while (true)
            {
                Graphics g;
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapImage buf = PictureBox.Source as BitmapImage;
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(buf));
                    enc.Save(outStream);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                    g = Graphics.FromImage(bitmap);
                }

                Pen PenStyle = new Pen(Color.Red, 1);
                g.DrawRectangle(PenStyle, (int)p1.X, (int)p1.Y, 10, 10);
            }
        }
    }
}
