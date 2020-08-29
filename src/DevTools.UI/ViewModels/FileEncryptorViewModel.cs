using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DevTools.UI
{
    public sealed class FileEncryptorViewModel : ObservableObject
    {
        #region Properties
        private string _outcome = string.Empty;
        public string Outcome
        {
            get { return _outcome; }
            set
            {
                _outcome = value;
                RaisePropertyChanged(nameof(Outcome));
            }
        }

        private string _inputFilePath = string.Empty;
        public string InputFilePath
        {
            get { return _inputFilePath; }
            set
            {
                _inputFilePath = value;
                RaisePropertyChanged(nameof(InputFilePath));
            }
        }

        private string _outputFilePath = string.Empty;
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            set
            {
                _outputFilePath = value;
                RaisePropertyChanged(nameof(OutputFilePath));
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private string _salt = string.Empty;
        public string Salt
        {
            get { return _salt; }
            set
            {
                _salt = value;
                RaisePropertyChanged(nameof(Salt));
            }
        }

        private string _iv = string.Empty;
        public string InitVector
        {
            get { return _iv; }
            set
            {
                _iv = value;
                RaisePropertyChanged(nameof(InitVector));
            }
        }

        private int _iterations = 1_000_000;
        public int Iterations
        {
            get { return _iterations; }
            set
            {
                _iterations = value;
                RaisePropertyChanged(nameof(Iterations));
            }
        }

        private bool _isProcessing = false;
        public bool IsProcessing
        {
            get { return _isProcessing; }
            set
            {
                _isProcessing = value;
                RaisePropertyChanged(nameof(IsProcessing));
            }
        }

        private CryptoOperation _operation = CryptoOperation.Idle;
        public CryptoOperation Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                RaisePropertyChanged(nameof(Operation));
            }
        }

        private string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        private double _progress = 100.0;
        public double Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                RaisePropertyChanged(nameof(Progress));
            }
        }
        #endregion // Properties

        #region Commands
        public ICommand EncryptCommand { get { return new RelayCommand(EncryptCommandExecute, CanExecuteEncryptCommand); } }
        private void EncryptCommandExecute()
        {
            string inputFilePath = InputFilePath;
            string outputFilePath = OutputFilePath;
            string password = Password;
            string initVector = InitVector;
            string salt = Salt;

            if (System.IO.File.Exists(outputFilePath))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Output file {outputFilePath} already exists. Do you wish to overwrite this file?", "Overwrite Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult != MessageBoxResult.Yes)
                {
                    return;
                }
            }

            try
            {
                Progress = 0.0;
                Outcome = string.Empty;
                IsProcessing = false;

                Task.Factory.StartNew(
                    () =>
                    {
                        IsProcessing = true;
                        Operation = CryptoOperation.Encrpyting;
                        Status = "Encrypting...";

                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        sw.Start();

                        Common.EncryptFile(inputFilePath, outputFilePath, password, initVector, salt, 1_000_000, UpdateProgress);
                        OutputFilePath = outputFilePath;

                        IsProcessing = false;
                        Outcome = "Success!";

                        sw.Stop();
                        Operation = CryptoOperation.Idle;
                        Status = $"Encrypted successfully in {sw.Elapsed.TotalSeconds.ToString("N1")} seconds";
                        CommandManager.InvalidateRequerySuggested();
                    });
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private bool CanExecuteEncryptCommand() => !IsProcessing;

        public ICommand DecryptCommand { get { return new RelayCommand(DecryptCommandExecute, CanExecuteDecryptCommand); } }
        private void DecryptCommandExecute()
        {
            string inputFilePath = InputFilePath;
            string outputFilePath = OutputFilePath;
            string password = Password;
            string initVector = InitVector;
            string salt = Salt;

            if (System.IO.File.Exists(outputFilePath))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Output file {outputFilePath} already exists. Do you wish to overwrite this file?", "Overwrite Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult != MessageBoxResult.Yes)
                {
                    return;
                }
            }

            try
            {
                Progress = 0.0;
                Outcome = string.Empty;
                IsProcessing = false;

                Task.Factory.StartNew(
                    () =>
                    {
                        IsProcessing = true;
                        Operation = CryptoOperation.Decrypting;
                        Status = "Decrypting...";

                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        sw.Start();

                        Common.DecryptFile(inputFilePath, outputFilePath, password, initVector, salt, 1_000_000, UpdateProgress);
                        OutputFilePath = outputFilePath;

                        IsProcessing = false;
                        Outcome = "Success!";

                        sw.Stop();
                        Operation = CryptoOperation.Idle;
                        Status = $"Decrypted successfully in {sw.Elapsed.TotalSeconds.ToString("N1")} seconds";
                        CommandManager.InvalidateRequerySuggested();
                    });
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private bool CanExecuteDecryptCommand() => !IsProcessing;
        #endregion // Commands

        private void UpdateProgress(double progress)
        {
            Status = $"{Operation} ({Progress.ToString("N0")}%)...";
            Progress = progress;
        }

        public enum CryptoOperation
        {
            Encrpyting,
            Decrypting,
            Idle
        }
    }
}
