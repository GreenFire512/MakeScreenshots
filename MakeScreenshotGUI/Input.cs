using NHotkey;
using NHotkey.Wpf;
using System;
using System.Windows;
using System.Windows.Input;

namespace MakeScreenshotGUI
{
    static class Input
    {
        #region Private
        private static void FullScreen(object sender, HotkeyEventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private static void ActiveWindow(object sender, HotkeyEventArgs e)
        {
            Screenshot.TakeActiveScreen();
        }

        private static void ClipScreen(object sender, HotkeyEventArgs e)
        {
            Screenshot.TakeClipScreen();
        }
        #endregion

        #region Public
        public static void Init()
        {
            ValidateSettings();

            HotkeyManager.Current.AddOrReplace("FullScreen", Settings.full_screen_key, Settings.full_screen_modifired_key, FullScreen);
            HotkeyManager.Current.AddOrReplace("ActiveWindow", Settings.active_screen_key, Settings.active_screen_modifired_key, ActiveWindow);
            HotkeyManager.Current.AddOrReplace("ClipScreen", Settings.region_screen_key, Settings.region_screen_modifired_key, ClipScreen);
        }

        public static void ChangeKeyFullScreen()
        {
            HotkeyManager.Current.AddOrReplace("FullScreen", Settings.full_screen_key, Settings.full_screen_modifired_key, FullScreen);
        }

        public static void ChangeKeyActiveScreen()
        {
         
            HotkeyManager.Current.AddOrReplace("ActiveWindow", Settings.active_screen_key, Settings.active_screen_modifired_key, ActiveWindow);

        }

        public static void ChangeKeyRegionScreen()
        {
            HotkeyManager.Current.AddOrReplace("ClipScreen", Settings.region_screen_key, Settings.region_screen_modifired_key, ClipScreen);
        }

        public static void ChangeAllKey()
        {
            ChangeKeyFullScreen();
            ChangeKeyActiveScreen();
            ChangeKeyRegionScreen();
        }

        private static void ValidateSettings()
        {
            if (
                (Settings.full_screen_modifired_key == Settings.active_screen_modifired_key) ||
                (Settings.full_screen_modifired_key == Settings.region_screen_modifired_key) ||
                (Settings.active_screen_modifired_key == Settings.region_screen_modifired_key)
                )
            {
                Settings.DefaultSettings();
                MessageBoxResult result = System.Windows.MessageBox.Show("Settings Error. Load default settings");
            }
        }
    }
    #endregion
}
