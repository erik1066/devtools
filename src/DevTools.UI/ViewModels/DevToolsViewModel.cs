namespace DevTools.UI
{
    public sealed class DevToolsViewModel : ObservableObject
    {
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
