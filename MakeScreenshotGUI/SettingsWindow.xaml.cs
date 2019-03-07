using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System;
using System.Windows.Input;

namespace MakeScreenshotGUI
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private Key temp_full_screen_key;
        private Key temp_active_screen_key;
        private Key temp_region_screen_key;

        public SettingsWindow()
        {
            InitializeComponent();
            DirTextBox.Text = Settings.dir;
            foreach (ListBoxItem item in PicFormatBox.Items)
            {
                if (item.Content.ToString() == Settings.pic_format)
                    PicFormatBox.SelectedValue = item;
            }
            full_screen_none.IsChecked = Settings.full_screen_modifired_key == ModifierKeys.None;
            full_screen_alt.IsChecked = Settings.full_screen_modifired_key == ModifierKeys.Alt;
            full_screen_shift.IsChecked = Settings.full_screen_modifired_key == ModifierKeys.Shift;
            full_screen_ctrl.IsChecked = Settings.full_screen_modifired_key == ModifierKeys.Control;
            TextToTextBox(Settings.full_screen_key, ref textbox_full_screen, out temp_full_screen_key);

            active_screen_none.IsChecked = Settings.active_screen_modifired_key == ModifierKeys.None;
            active_screen_alt.IsChecked = Settings.active_screen_modifired_key == ModifierKeys.Alt;
            active_screen_shift.IsChecked = Settings.active_screen_modifired_key == ModifierKeys.Shift;
            active_screen_ctrl.IsChecked = Settings.active_screen_modifired_key == ModifierKeys.Control;
            TextToTextBox(Settings.active_screen_key, ref textbox_active_screen, out temp_active_screen_key);

            region_screen_none.IsChecked = Settings.region_screen_modifired_key == ModifierKeys.None;
            region_screen_alt.IsChecked = Settings.region_screen_modifired_key == ModifierKeys.Alt;
            region_screen_shift.IsChecked = Settings.region_screen_modifired_key == ModifierKeys.Shift;
            region_screen_ctrl.IsChecked = Settings.region_screen_modifired_key == ModifierKeys.Control;
            TextToTextBox(Settings.region_screen_key, ref textbox_region_screen, out temp_region_screen_key);


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
            if (
                ConvertBoolToModifierKeys(full_screen_alt.IsChecked, full_screen_shift.IsChecked, full_screen_ctrl.IsChecked) == ConvertBoolToModifierKeys(active_screen_alt.IsChecked, active_screen_shift.IsChecked, active_screen_ctrl.IsChecked) ||
                ConvertBoolToModifierKeys(full_screen_alt.IsChecked, full_screen_shift.IsChecked, full_screen_ctrl.IsChecked) == ConvertBoolToModifierKeys(region_screen_alt.IsChecked, region_screen_shift.IsChecked, region_screen_ctrl.IsChecked) ||
                ConvertBoolToModifierKeys(active_screen_alt.IsChecked, active_screen_shift.IsChecked, active_screen_ctrl.IsChecked) == ConvertBoolToModifierKeys(region_screen_alt.IsChecked, region_screen_shift.IsChecked, region_screen_ctrl.IsChecked)
                )
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Wrong settings. Can't save");
            }
            else
            {
                Settings.full_screen_modifired_key = ConvertBoolToModifierKeys(full_screen_alt.IsChecked, full_screen_shift.IsChecked, full_screen_ctrl.IsChecked);
                Settings.active_screen_modifired_key = ConvertBoolToModifierKeys(active_screen_alt.IsChecked, active_screen_shift.IsChecked, active_screen_ctrl.IsChecked);
                Settings.region_screen_modifired_key = ConvertBoolToModifierKeys(region_screen_alt.IsChecked, region_screen_shift.IsChecked, region_screen_ctrl.IsChecked);

                Settings.full_screen_key = temp_full_screen_key;
                Settings.active_screen_key = temp_active_screen_key;
                Settings.region_screen_key = temp_region_screen_key;

                Settings.dir = DirTextBox.Text;
                Settings.pic_format = PicFormatBox.Text;

                Settings.Save();
                Input.ChangeAllKey();
                Close();
            }


        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnKeyUpFullScreen(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextToTextBox(e.Key, ref textbox_full_screen, out temp_full_screen_key);
        }

        private void OnKeyUpActiveScreen(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextToTextBox(e.Key, ref textbox_active_screen, out temp_active_screen_key);
        }

        private void OnKeyUpRegionScreen(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextToTextBox(e.Key, ref textbox_region_screen, out temp_region_screen_key);
        }

        private ModifierKeys ConvertBoolToModifierKeys(bool? alt, bool? shift, bool? ctrl)
        {
            if (alt == true)
            {
                return ModifierKeys.Alt;
            }
            else if (shift == true)
            {
                return ModifierKeys.Shift;
            }
            else if (ctrl == true)
            {
                return ModifierKeys.Control;
            }
            return ModifierKeys.None;
        }

        private Key ConvertComboBoxItemToKey(System.Windows.Controls.ComboBox combo_box)
        {
            Key key;
            ComboBoxItem item;
            string content;

            item = (ComboBoxItem)combo_box.SelectedValue;
            content = (string)item.Content;
            if (Enum.TryParse(content, out key))
            {
                return key;
            }

            return Key.PrintScreen;
        }

        private int ConvertToComboBoxIndex(System.Windows.Controls.ComboBox combo_box, string key)
        {
            int index = 0;
            foreach (ComboBoxItem item in combo_box.Items)
            {
                if (key == item.Content.ToString())
                {
                    return index;
                }
                index++;
            }
            return 0;
        }

        private void TextToTextBox(Key key, ref System.Windows.Controls.TextBox textbox, out Key temp_key)
        {
            temp_key = key;
            if (key == Key.PrintScreen)
            {
                textbox.Text = "Print Screen";
            }
            else
            {
                textbox.Text = key.ToString();
            }
        }
    }
}
