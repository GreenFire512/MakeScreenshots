using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeScreenshotGUI
{
    class ProgramSettings
    {
        #region Value
        private static string dirSave, picFormat, fullScrKey, activeScrKey, regionScrKey;
        private static readonly string fileName = "settings.ini";
        #endregion



        #region Private
        private static void Open()
        {
            FileInfo fileSettings = new FileInfo(fileName);
            if (fileSettings.Exists)
            {
                using (StreamReader fileread = new StreamReader(fileName))
                {
                    dirSave = fileread.ReadLine();
                    picFormat = fileread.ReadLine();
                    fullScrKey = fileread.ReadLine();
                    activeScrKey = fileread.ReadLine();
                    regionScrKey = fileread.ReadLine();
                    fileread.Close();
                }
            }
        }

        private static void SaveToFile()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(dirSave);
                file.WriteLine(picFormat);
                file.WriteLine(fullScrKey);
                file.WriteLine(activeScrKey);
                file.WriteLine(regionScrKey);
                file.Close();
            }
        }
        #endregion



        #region Public
        public static void Save(string dirSave)
        {
            ProgramSettings.dirSave = dirSave;
            SaveToFile();
        }

        public static void SaveFormat(string picFormat)
        {
            ProgramSettings.picFormat = picFormat;
            SaveToFile();
        }

        public static string GetDirSave()
        {
            Open();
            return dirSave;
        }

        public static string GetPicFormat()
        {
            Open();
            return picFormat;
        }

        public static string ChooseDirFolder()
        {
            string result;
            using (FolderBrowserDialog dir = new FolderBrowserDialog())
            {
                dir.SelectedPath = GetDirSave();
                dir.ShowDialog();
                Save(dir.SelectedPath);
                result = dir.SelectedPath;
            }
            return result;
        }

        public static int GetFullScrKey()
        {
            Open();
            return Convert.ToInt32(fullScrKey);
        } 

        public static void SaveFullScrKey(string input)
        {
            fullScrKey = input;
            SaveToFile();
        }

        public static int GetActiveScrKey()
        {
            Open();
            return Convert.ToInt32(activeScrKey);
        }

        public static void SaveActiveScrKey(string input)
        {
            activeScrKey = input;
            SaveToFile();
        }

        public static int GetRegionScrKey()
        {
            Open();
            return Convert.ToInt32(regionScrKey);
        }

        public static void SaveRegionScrKey(string input)
        {
            regionScrKey = input;
            SaveToFile();
        }
        #endregion
    }
}
