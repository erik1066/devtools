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
    /// Interaction logic for RgbToHexConverter.xaml
    /// </summary>
    public partial class RgbToHexConverter : UserControl
    {
        public RgbToHexConverter()
        {
            InitializeComponent();
        }

        private string DoRgbConversion(string rStr, string gStr, string bStr)
        {
            if (int.TryParse(rStr, out int r) && int.TryParse(gStr, out int g) && int.TryParse(bStr, out int b))
            {
                if (r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255)
                {
                    colorSwatch.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
                    return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
                }
                else
                {
                    colorSwatch.Background = new SolidColorBrush(Colors.Transparent);
                    return string.Empty;
                }
            }
            else
            {
                colorSwatch.Background = new SolidColorBrush(Colors.Transparent);
                return string.Empty;
            }
        }

        private void rgbRed_TextChanged(object sender, TextChangedEventArgs e)
        {
            hex.Text = DoRgbConversion(rgbRed.Text, rgbGreen.Text, rgbBlue.Text);
        }

        private void rgbGreen_TextChanged(object sender, TextChangedEventArgs e)
        {
            hex.Text = DoRgbConversion(rgbRed.Text, rgbGreen.Text, rgbBlue.Text);
        }

        private void rgbBlue_TextChanged(object sender, TextChangedEventArgs e)
        {
            hex.Text = DoRgbConversion(rgbRed.Text, rgbGreen.Text, rgbBlue.Text);
            hexWithHash.Text = "#" + hex.Text;
        }

        private void hexInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            (string red, string green, string blue) = DoHexConversion(hexInput.Text);
            rgbRedOutput.Text = red;
            rgbGreenOutput.Text = green;
            rgbBlueOutput.Text = blue;
        }

        (string red, string green, string blue) DoHexConversion(string hex)
        {
            
            try
            {
                hex = hex.Trim().Trim('#');
                if (hex.Length == 6)
                {
                    int redValue = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    int greenValue = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    int blueValue = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                    colorSwatchHex.Background = new SolidColorBrush(Color.FromRgb((byte)redValue, (byte)greenValue, (byte)blueValue));
                    return (redValue.ToString(), greenValue.ToString(), blueValue.ToString());
                }
                else if (hex.Length == 3)
                {
                    int redValue = int.Parse(hex.Substring(0, 1) + hex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber);
                    int greenValue = int.Parse(hex.Substring(1, 1) + hex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);
                    int blueValue = int.Parse(hex.Substring(2, 1) + hex.Substring(2, 1), System.Globalization.NumberStyles.HexNumber);
                    colorSwatchHex.Background = new SolidColorBrush(Color.FromRgb((byte)redValue, (byte)greenValue, (byte)blueValue));
                    return (redValue.ToString(), greenValue.ToString(), blueValue.ToString());
                }
                else
                {
                    colorSwatchHex.Background = new SolidColorBrush(Colors.Transparent);
                    return (string.Empty, string.Empty, string.Empty);
                }
            }
            catch
            {
                colorSwatchHex.Background = new SolidColorBrush(Colors.Transparent);
                return (string.Empty, string.Empty, string.Empty);
            }
        }
    }
}
