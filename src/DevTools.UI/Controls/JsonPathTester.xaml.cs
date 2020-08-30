using System.Windows;
using System.Windows.Controls;

namespace DevTools.UI.Controls
{
    /// <summary>
    /// Interaction logic for JsonPathTester.xaml
    /// </summary>
    public partial class JsonPathTester : UserControl
    {
        public JsonPathTester()
        {
            InitializeComponent();
        }

        private void DoPathTest()
        {
            string jsonDocument = jsonPathSourceDocument.Text;
            string jsonPath = jsonPathExpression.Text;

            if (string.IsNullOrEmpty(jsonDocument)) return;
            if (string.IsNullOrEmpty(jsonPath)) return;

            jsonPathOutput.Text = Common.JsonPathTest(jsonDocument, jsonPath);
        }

        private void jsonPathExpression_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoPathTest();
        }

        private void jsonPathSourceDocument_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoPathTest();
        }

        private void btnJsonPathClearAll_Click(object sender, RoutedEventArgs e)
        {
            jsonPathSourceDocument.Clear();
        }

        private void btnJsonPathCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(jsonPathSourceDocument.Text);
        }

        private void btnJsonPathPaste_Click(object sender, RoutedEventArgs e)
        {
            jsonPathSourceDocument.Text = Clipboard.GetText();
        }
    }
}
