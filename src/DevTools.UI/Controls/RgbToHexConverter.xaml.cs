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
using System.Xml;

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
            string hex = Common.ConvertRgbToHex(rStr, gStr, bStr);

            if (!string.IsNullOrEmpty(hex))
            {
                colorSwatch.Background = new SolidColorBrush(Color.FromRgb(byte.Parse(rStr), byte.Parse(gStr), byte.Parse(bStr)));
                return hex;
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
