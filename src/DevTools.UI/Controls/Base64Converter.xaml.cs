using System;
using System.Windows;
using System.Windows.Controls;

namespace DevTools.UI.Controls
{
    /// <summary>
    /// Interaction logic for Base64Converter.xaml
    /// </summary>
    public partial class Base64Converter : UserControl
    {
        public Base64Converter()
        {
            InitializeComponent();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtAction.Text.StartsWith("Plain"))
                {
                    output.Text = Common.Base64Encode(input.Text);
                }
                else
                {
                    output.Text = Common.Base64Decode(input.Text);
                }
            }
            catch (Exception ex)
            {
                output.Text = $"{ex.GetType().ToString()} : {ex.Message}";
            }
        }

        private void btnDirectionality_IsCheckedChanged(ModernWpf.Controls.ToggleSplitButton sender, ModernWpf.Controls.ToggleSplitButtonIsCheckedChangedEventArgs args)
        {

        }

        private void sourceButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedBullet = (Button)sender;
            string text = clickedBullet.Content.ToString();

            if (text.StartsWith("Base"))
            {
                txtAction.Text = text;
            }
            else if (text.StartsWith("Plain"))
            {
                txtAction.Text = text;
            }

            btnDirectionality.IsChecked = true;
            btnDirectionality.Flyout.Hide();
        }
    }
}
