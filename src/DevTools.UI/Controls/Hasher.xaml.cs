using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Hasher.xaml
    /// </summary>
    public partial class Hasher : UserControl
    {
        public Hasher()
        {
            InitializeComponent();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoHashing();
        }

        private void DoHashing()
        {
            var comboBoxItem = cmbHashAlgorithm.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null && comboBoxItem.Content != null)
            {
                string algorithm = comboBoxItem.Content.ToString();

                switch (algorithm)
                {
                    case "SHA-1":
                        hashedOutput.Text = SHA1Hash(input.Text);
                        break;
                    case "SHA-2 (512)":
                        hashedOutput.Text = SHA512Hash(input.Text);
                        break;
                }
            }
        }

        static string SHA1Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        static string SHA512Hash(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            using (var alg = SHA512.Create())
            {
                alg.ComputeHash(data);
                return BitConverter.ToString(alg.Hash);
            }
        }

        private void cmbHashAlgorithm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoHashing();
        }
    }
}
