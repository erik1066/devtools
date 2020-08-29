using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DevTools.UI
{
    public sealed class GuidGeneratorViewModel : ObservableObject
    {
        private const int MAX_GUIDS = 2_000_000;

        #region Properties
        private string _numberOfGuids = "1";
        public string NumberOfGuids
        {
            get { return _numberOfGuids; }
            set
            {
                _numberOfGuids = value;
                RaisePropertyChanged(nameof(NumberOfGuids));
            }
        }

        private bool _uppercase = false;
        public bool Uppercase
        {
            get { return _uppercase; }
            set
            {
                _uppercase = value;
                RaisePropertyChanged(nameof(Uppercase));
            }
        }

        private bool _braces = false;
        public bool Braces
        {
            get { return _braces; }
            set
            {
                _braces = value;
                RaisePropertyChanged(nameof(Braces));
            }
        }

        private bool _hyphens = true;
        public bool Hyphens
        {
            get { return _hyphens; }
            set
            {
                _hyphens = value;
                RaisePropertyChanged(nameof(Hyphens));
            }
        }

        private bool _base64Encode = false;
        public bool Base64Encode
        {
            get { return _base64Encode; }
            set
            {
                _base64Encode = value;
                RaisePropertyChanged(nameof(Base64Encode));
            }
        }

        private bool _rfc7515 = false;
        public bool Rfc7515
        {
            get { return _rfc7515; }
            set
            {
                _rfc7515 = value;
                RaisePropertyChanged(nameof(Rfc7515));
            }
        }

        private bool _urlencode = false;
        public bool Urlencode
        {
            get { return _urlencode; }
            set
            {
                _urlencode = value;
                RaisePropertyChanged(nameof(Urlencode));
            }
        }

        private string _output = string.Empty;
        public string Output
        {
            get { return _output; }
            set
            {
                _output = value;
                RaisePropertyChanged(nameof(Output));
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

        private double _progress = 0.0;
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
        public ICommand GenerateCommand { get { return new RelayCommand(GenerateCommandExecute, CanExecuteGenerateCommand); } }
        private void GenerateCommandExecute()
        {
            bool success = int.TryParse(NumberOfGuids, out int maxGuids);

            if (!success)
            {
                // TODO: Validate input
                Output = string.Empty;
                return;
            }
            else if (maxGuids > MAX_GUIDS)
            {
                // TODO: Validate input

                MessageBoxResult result = System.Windows.MessageBox.Show("Invalid number of GUIDs specified. Use a value less than or equal to " + MAX_GUIDS + ".", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            StringBuilder sb = new StringBuilder(maxGuids * 38);
            IsProcessing = true;
            Progress = 0.0;
            Output = string.Empty;

            Task.Factory.StartNew(
                () =>
                {
                    for (int i = 0; i < maxGuids; i++)
                    {
                        string guid = System.Guid.NewGuid().ToString();

                        if (Uppercase)
                        {
                            guid = guid.ToUpper();
                        }
                        if (!Hyphens)
                        {
                            guid = guid.Replace("-", string.Empty);
                        }
                        if (Braces)
                        {
                            guid = "{" + guid + "}";
                        }
                        if (Base64Encode)
                        {
                            guid = Common.Base64Encode(guid);
                        }
                        if (Base64Encode && Rfc7515)
                        {
                            guid = guid.Split('=')[0]; // Remove any trailing '='s
                            guid = guid.Replace('+', '-'); // 62nd char of encoding
                            guid = guid.Replace('/', '_'); // 63rd char of encoding
                        }
                        if (Urlencode)
                        {
                            guid = WebUtility.UrlEncode(guid);
                        }

                        sb.Append(guid);
                        sb.Append(Environment.NewLine);

                        Progress = ((double)i / (double)maxGuids) * 100.0;
                    }

                    Output = sb.ToString();
                    IsProcessing = false;
                    Progress = 0.0;
                });
        }
        private bool CanExecuteGenerateCommand() => true;
        #endregion // Commands
    }
}
