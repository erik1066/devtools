using System;
using System.Windows;
using System.Windows.Controls;
using DevTools;

namespace DevTools.UI.Controls
{
    /// <summary>
    /// Interaction logic for FileEncryptor.xaml
    /// </summary>
    public partial class FileEncryptor : UserControl
    {
        public FileEncryptor()
        {
            InitializeComponent();
        }

        private FileEncryptorViewModel ViewModel => ((this.DataContext) as FileEncryptorViewModel);

        private void InputFilePathSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsProcessing) return;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                CheckFileExists = true
            };

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ViewModel.InputFilePath = filename;
                ViewModel.OutputFilePath = filename + ".brv";
                ViewModel.Outcome = string.Empty;
            }
        }

        private void OutputFilePathSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsProcessing) return;
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                CheckFileExists = false,
                CreatePrompt = true
            };

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ViewModel.OutputFilePath = filename;
                ViewModel.Outcome = string.Empty;
            }
        }

        private void OutputFilePathCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OutputFilePath.Text);
        }

        private void PasswordGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsProcessing) return;
            var password = Common.GeneratePassword(24, 6);
            ViewModel.Password = password;
        }

        private void InitVectorGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsProcessing) return;
            var iv = Common.GeneratePassword(16, 8);
            ViewModel.InitVector = iv;
        }

        private void SaltGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsProcessing) return;
            var salt = Common.GeneratePassword(24, 6);
            ViewModel.Salt = salt;
        }

        private void PasswordCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ViewModel.Password);
        }

        private void SaltCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ViewModel.Salt);
        }

        private void InitVectorCopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ViewModel.InitVector);
        }
    }
}
