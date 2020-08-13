using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevTools.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void jsonPath_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Visible;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
        }

        private void rgbConverter_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Visible;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
        }

        private void base64converter_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Visible;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
        }

        private void regexTester_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Visible;
            hasherView.Visibility = Visibility.Collapsed;
        }

        private void hasher_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Visible;
        }
    }
}
