using System.Windows;

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

            Settings.Open();
            Input.Init();
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            icon.Delete();            
        }
    }
}
