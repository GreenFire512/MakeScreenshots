using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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
            DirTextBox.Text = ProgramSettings.GetDirSave();
            foreach (ListBoxItem item in PicFormatBox.Items)
            {
                if (item.Content.ToString() == ProgramSettings.GetPicFormat())
                    PicFormatBox.SelectedValue = item;
            }
        }

        private void SaveSettings()
        {
            ;
        }

        private void Button_ChangeDir(object sender, RoutedEventArgs e)
        {
            DirTextBox.Text = ProgramSettings.ChooseDirFolder();
        }

        private void CloseWidnow(object sender, CancelEventArgs e)
        {
            ;
        }

        private void SavePicFormat(object sender, RoutedEventArgs e)
        {
            ProgramSettings.SaveFormat(((ComboBoxItem)PicFormatBox.SelectedItem).Content.ToString());
        }

        private void Fullscr_alt_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Fullscr_shift_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Fullscr_ctrl_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Fullscrkey_changed(object sender, SelectionChangedEventArgs e)
        {
            SaveSettings();
        }

        private void Active_alt_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Active_shift_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Active_ctrl_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Acrivescrkey_changed(object sender, SelectionChangedEventArgs e)
        {
            SaveSettings();
        }

        private void Region_alt_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Region_shift_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Region_ctrl_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Regionscrkey_changed(object sender, SelectionChangedEventArgs e)
        {
            SaveSettings();
        }

        private void PicFormat_changed(object sender, SelectionChangedEventArgs e)
        {
            SaveSettings();
        }
    }
}
