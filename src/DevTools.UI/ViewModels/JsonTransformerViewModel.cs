using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevTools;
using JUST;

namespace DevTools.UI
{
    public sealed class JsonTransformerViewModel : ObservableObject
    {
        #region Properties
        private static JsonTransformer _jsonTransformer = new JsonTransformer();

        private string _transformJson = string.Empty;
        public string TransformJson
        {
            get { return _transformJson; }
            set
            {
                _transformJson = value;
                RaisePropertyChanged(nameof(TransformJson));
            }
        }

        private string _inputJson = string.Empty;
        public string InputJson
        {
            get { return _inputJson; }
            set
            {
                _inputJson = value;
                RaisePropertyChanged(nameof(InputJson));
            }
        }

        private string _outputJson = string.Empty;
        public string OutputJson
        {
            get { return _outputJson; }
            set
            {
                _outputJson = value;
                RaisePropertyChanged(nameof(OutputJson));
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
        #endregion // Properties

        #region Commands
        public ICommand TransformCommand { get { return new RelayCommand(TransformCommandExecute, CanExecuteTransformCommand); } }
        private void TransformCommandExecute()
        {
            try
            {
                Status = "Transforming...";
                IsProcessing = false;

                Task.Factory.StartNew(
                    () =>
                    {
                        IsProcessing = true;
                        Status = "Transforming...";

                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        sw.Start();

                        OutputJson = _jsonTransformer.Transform(TransformJson, InputJson);

                        sw.Stop();
                        Status = $"Transformed successfully in {sw.Elapsed.TotalSeconds.ToString("N1")} seconds";
                        CommandManager.InvalidateRequerySuggested();
                    });
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private bool CanExecuteTransformCommand() => true;//!IsProcessing;
        #endregion // Commands
    }
}
