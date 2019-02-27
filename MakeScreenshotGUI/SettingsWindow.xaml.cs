using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MakeScreenshotGUI
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DirTextBox.Text = Settings.dir;
            foreach (ListBoxItem item in PicFormatBox.Items)
            {
                if (item.Content.ToString() == Settings.pic_format)
                    PicFormatBox.SelectedValue = item;
            }
        }

        private void Button_ChangeDir(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result.ToString() == "OK")
                {
                    DirTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void CloseWidnow(object sender, CancelEventArgs e)
        {
            ;
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Settings.Save(DirTextBox.Text, PicFormatBox.Text, "1", "1", "1");
            Close();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
