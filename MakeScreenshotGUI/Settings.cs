using System;
using System.IO;

namespace MakeScreenshotGUI
{
    public static class Settings
    {
        private readonly static string fileName = "settings.ini";

        public static string dir;
        public static string pic_format;
        public static string full_screen_key;
        public static string active_screen_key;
        public static string region_screen_key;


        private static void SaveToFile()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(dir);
                file.WriteLine(pic_format);
                file.WriteLine(full_screen_key);
                file.WriteLine(active_screen_key);
                file.WriteLine(region_screen_key);
                file.Close();
            }
        }

        public static void Open()
        {
            FileInfo fileSettings = new FileInfo(fileName);
            if (fileSettings.Exists)
            {
                using (StreamReader fileread = new StreamReader(fileName))
                {
                    dir = fileread.ReadLine();
                    pic_format = fileread.ReadLine();
                    full_screen_key = fileread.ReadLine();
                    active_screen_key = fileread.ReadLine();
                    region_screen_key = fileread.ReadLine();
                    fileread.Close();
                }
            }
        }

        public static void Save(string dir, string pic_format, string full_screen_key, string active_screen_key, string region_screen_key)
        {
            Settings.dir = dir;
            Settings.pic_format = pic_format;
            Settings.full_screen_key = full_screen_key;
            Settings.active_screen_key = active_screen_key;
            Settings.region_screen_key = region_screen_key;
            SaveToFile();
        }
    }
}
