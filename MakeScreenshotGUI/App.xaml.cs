using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using NHotkey.Wpf;
using System.Windows.Input;
using NHotkey;

namespace MakeScreenshotGUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        IconTray icon;

        private void App_StartUp(object sender, StartupEventArgs e)
        {
            icon = new IconTray();
            icon.Start();

            HotkeyManager.Current.AddOrReplace("FullScreen", Key.PrintScreen, ModifierKeys.None, FullScreen);
            HotkeyManager.Current.AddOrReplace("ActiveWindow", Key.PrintScreen, ModifierKeys.Alt, ActiveWindow);
            HotkeyManager.Current.AddOrReplace("ClipScreen", Key.PrintScreen, ModifierKeys.Shift, ClipScreen);

            Settings.Open();
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            icon.Dispose();
        }

        private void FullScreen(object sender, HotkeyEventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private void ActiveWindow(object sender, HotkeyEventArgs e)
        {
            Screenshot.TakeActiveScreen();
        }

        private void ClipScreen(object sender, HotkeyEventArgs e)
        {
            Screenshot.TakeClipScreen();
        }
    }
}
