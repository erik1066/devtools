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
                    return string.Empty;
                }
            }
            else
            {
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
    }
}
