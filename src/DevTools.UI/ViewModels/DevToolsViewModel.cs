namespace DevTools.UI
{
    public sealed class DevToolsViewModel : ObservableObject
    {
        private JsonTransformerViewModel _jsonTransformerVm = new JsonTransformerViewModel();

        public JsonTransformerViewModel JsonTransformerViewModel
        {
            get { return _jsonTransformerVm; }
            private set
            {
                _jsonTransformerVm = value;
                RaisePropertyChanged(nameof(JsonTransformerViewModel));
            }
        }

        private FileEncryptorViewModel _fileEncryptorVm = new FileEncryptorViewModel();

        public FileEncryptorViewModel FileEncryptorViewModel
        {
            get { return _fileEncryptorVm; }
            private set
            {
                _fileEncryptorVm = value;
                RaisePropertyChanged(nameof(FileEncryptorViewModel));
            }
        }

        private GuidGeneratorViewModel _guidGeneratorVm = new GuidGeneratorViewModel();

        public GuidGeneratorViewModel GuidGeneratorViewModel
        {
            get { return _guidGeneratorVm; }
            private set
            {
                _guidGeneratorVm = value;
                RaisePropertyChanged(nameof(GuidGeneratorViewModel));
            }
        }
    }
}
