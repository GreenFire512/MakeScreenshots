using MakeScreenshotGUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;

namespace MakeScreenshot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            foreach(ListBoxItem item in PicFormatBox.Items)
            {
                if (item.Content.ToString() == Settings.pic_format)
                    PicFormatBox.SelectedValue = item;
            }
        }

        private void SavePicFormat(object sender, RoutedEventArgs e)
        {
            Settings.pic_format = ((ComboBoxItem)PicFormatBox.SelectedItem).Content.ToString();
        }

        private void ButtonFullScreen_Click(object sender, RoutedEventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private void ButtonActiveScreen_Click(object sender, RoutedEventArgs e)
        {
            Screenshot.TakeActiveScreen();
        }

        private void ButtonClipScreen_Click(object sender, RoutedEventArgs e)
        {
            TakeClipShot();
        }

        private void TakeClipShot()
        {
            System.Drawing.Size size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            ScreenClip windows = new ScreenClip(Screenshot.GetBitmap(size, 0, 0));
            windows.Show();
        }

        private void DirSave_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dir = new FolderBrowserDialog())
            {
                dir.SelectedPath = Settings.dir;
                dir.ShowDialog();
            }
        }
    }
}
