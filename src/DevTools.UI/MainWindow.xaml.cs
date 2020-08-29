using System.Windows;

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
            fileEncryptorView.Visibility = Visibility.Collapsed;
            guidGeneratorView.Visibility = Visibility.Collapsed;
        }

        private void rgbConverter_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Visible;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
            fileEncryptorView.Visibility = Visibility.Collapsed;
            guidGeneratorView.Visibility = Visibility.Collapsed;
        }

        private void base64converter_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Visible;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
            fileEncryptorView.Visibility = Visibility.Collapsed;
            guidGeneratorView.Visibility = Visibility.Collapsed;
        }

        private void regexTester_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Visible;
            hasherView.Visibility = Visibility.Collapsed;
            fileEncryptorView.Visibility = Visibility.Collapsed;
            guidGeneratorView.Visibility = Visibility.Collapsed;
        }

        private void hasher_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Visible;
            fileEncryptorView.Visibility = Visibility.Collapsed;
            guidGeneratorView.Visibility = Visibility.Collapsed;
        }

        private void fileEncryptor_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
            fileEncryptorView.Visibility = Visibility.Visible;
            guidGeneratorView.Visibility = Visibility.Collapsed;
        }

        private void guidGenerator_Selected(object sender, RoutedEventArgs e)
        {
            if (jsonPathTesterView == null) return;
            jsonPathTesterView.Visibility = Visibility.Collapsed;
            rgbConverterView.Visibility = Visibility.Collapsed;
            base64ConverterView.Visibility = Visibility.Collapsed;
            regexTesterView.Visibility = Visibility.Collapsed;
            hasherView.Visibility = Visibility.Collapsed;
            fileEncryptorView.Visibility = Visibility.Collapsed;
            guidGeneratorView.Visibility = Visibility.Visible;
        }
    }
}
