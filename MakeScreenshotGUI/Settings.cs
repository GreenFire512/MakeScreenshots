using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace MakeScreenshotGUI
{
    public static class Settings
    {
        private readonly static string fileName = "settings.ini";

        public static string dir;
        public static string pic_format;
        public static Key full_screen_key;
        public static Key active_screen_key;
        public static Key region_screen_key;
        public static ModifierKeys full_screen_modifired_key;
        public static ModifierKeys active_screen_modifired_key;
        public static ModifierKeys region_screen_modifired_key;




        private static void SaveToFile()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(dir);
                file.WriteLine(pic_format);
                file.WriteLine(Convert.ToInt32(full_screen_modifired_key) + " " + Convert.ToInt32(full_screen_key));
                file.WriteLine(Convert.ToInt32(active_screen_modifired_key) + " " + Convert.ToInt32(active_screen_key));
                file.WriteLine(Convert.ToInt32(region_screen_modifired_key) + " " + Convert.ToInt32(region_screen_key));
                file.Close();
            }
        }

        public static void DefaultSettings()
        {
            dir = Application.StartupPath;
            pic_format = ".png";
            full_screen_modifired_key = ModifierKeys.None;
            full_screen_key = Key.PrintScreen;
            active_screen_modifired_key = ModifierKeys.Alt;
            active_screen_key = Key.PrintScreen;
            region_screen_modifired_key = ModifierKeys.Shift;
            region_screen_key = Key.PrintScreen;
            SaveToFile();
        }

        public static void Open()
        {
            FileInfo fileSettings = new FileInfo(fileName);
            if (fileSettings.Exists)
            {
                using (StreamReader fileread = new StreamReader(fileName))
                {
                    string tmp;
                    dir = fileread.ReadLine();
                    pic_format = fileread.ReadLine();
                    tmp = fileread.ReadLine();
                    full_screen_modifired_key = (ModifierKeys) Convert.ToInt32(tmp.Substring(0, 1));
                    full_screen_key = (Key) Convert.ToInt32(tmp.Substring(2));

                    tmp = fileread.ReadLine();
                    active_screen_modifired_key = (ModifierKeys)Convert.ToInt32(tmp.Substring(0, 1));
                    active_screen_key = (Key)Convert.ToInt32(tmp.Substring(2));

                    tmp = fileread.ReadLine();
                    region_screen_modifired_key = (ModifierKeys)Convert.ToInt32(tmp.Substring(0, 1));
                    region_screen_key = (Key)Convert.ToInt32(tmp.Substring(2));

                    fileread.Close();
                }
            }
            // Load Default Settings
            else
            {
                DefaultSettings();
            }
        }

        public static void Save()
        {
            SaveToFile();
        }
    }
}
