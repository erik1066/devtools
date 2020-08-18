using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtAction.Text.StartsWith("Plain"))
                {
                    output.Text = Base64Encode(input.Text);
                }
                else
                {
                    output.Text = Base64Decode(input.Text);
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
