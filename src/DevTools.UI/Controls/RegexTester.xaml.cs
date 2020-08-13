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
            var rx = new Regex(regularExpression.Text, RegexOptions.Compiled);
            var match = rx.Match(sourceText.Text);

            output.Text = match.Value;
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
