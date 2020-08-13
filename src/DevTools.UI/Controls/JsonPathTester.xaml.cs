using Newtonsoft.Json.Linq;
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
            string payload = jsonPathSourceDocument.Text;
            string jsonPath = jsonPathExpression.Text;

            if (string.IsNullOrEmpty(payload)) return;
            if (string.IsNullOrEmpty(jsonPath)) return;

            JObject sourceJson = JObject.Parse(payload);

            try
            {
                JToken token = sourceJson.SelectToken(jsonPath);
                string jsonResult = token.ToString();

                jsonPathOutput.Text = jsonResult;
            }
            catch (Exception)
            {
                jsonPathOutput.Text = string.Empty;
            }
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
