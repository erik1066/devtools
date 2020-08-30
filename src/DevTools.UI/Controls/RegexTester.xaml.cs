using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace DevTools.UI.Controls
{
    /// <summary>
    /// Interaction logic for RegexTester.xaml
    /// </summary>
    public partial class RegexTester : UserControl
    {
        public RegexTester()
        {
            InitializeComponent();
        }

        private void DoRegexTest()
        {
            try
            {
                var rx = new Regex(regularExpression.Text, RegexOptions.Compiled);
                var match = rx.Match(sourceText.Text);

                output.Text = match.Value;
            }
            catch
            {
                output.Text = string.Empty;
            }
        }

        private void regularExpression_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoRegexTest();
        }

        private void sourceText_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoRegexTest();
        }
    }
}
