using MakeScreenshot;
using System;
using System.Windows.Forms;

namespace MakeScreenshotGUI
{
    class IconTray
    {
        NotifyIcon ni;
#if DEBUG
        static MenuItem[] menuList = new MenuItem[] { new MenuItem("Test"), new MenuItem("FullScreen"), new MenuItem("ActiveScreen"), new MenuItem("ClipScreen"), new MenuItem("Settings"), new MenuItem("Exit")};
#else
        static MenuItem[] menuList = new MenuItem[] { new MenuItem("FullScreen"), new MenuItem("ActiveScreen"), new MenuItem("ClipScreen"), new MenuItem("Settings"), new MenuItem("Exit")};
#endif
        ContextMenu clickMenu = new ContextMenu(menuList);

        public void Start()
        {
            ni = new NotifyIcon
            {
                Icon = Properties.Resources.Icon,
                Visible = true,
                ContextMenu = clickMenu
            };


#if DEBUG
            menuList[0].Click += new EventHandler(MenuTest_Click);
            menuList[1].Click += new EventHandler(MenuFullScreen_Click);
            menuList[2].Click += new EventHandler(MenuActiveScreen_Click);
            menuList[3].Click += new EventHandler(MenuClipScreen_Click);
            menuList[4].Click += new EventHandler(MenuSettings_Click);
            menuList[5].Click += new EventHandler(MenuExit_Click);
#else
            menuList[0].Click += new EventHandler(MenuFullScreen_Click);
            menuList[1].Click += new EventHandler(MenuActiveScreen_Click);
            menuList[2].Click += new EventHandler(MenuClipScreen_Click);
            menuList[3].Click += new EventHandler(MenuSettings_Click);
            menuList[4].Click += new EventHandler(MenuExit_Click);
#endif
        }

        public void Delete()
        {
            ni.Visible = false;
            ni.Dispose();
        }

        private void MenuFullScreen_Click(object sender, EventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private void MenuActiveScreen_Click(object sender, EventArgs e)
        {
            Screenshot.TakeActiveScreen();
        }

        private void MenuClipScreen_Click(object sender, EventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private void MenuTest_Click(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.Show();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
