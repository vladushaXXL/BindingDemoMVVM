using BindingDemoMVVM.Commands;
using BindingDemoMVVM.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BindingDemoMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly LocalizationManager localizationManager = LocalizationManager.Instance;
        private readonly RelayCommand showGreetingCommand;
        private string userName;
        private LocalizationManager.LanguageOption selectedLanguage;

        public MainViewModel()
        {
            selectedLanguage = localizationManager.CurrentLanguage;
            showGreetingCommand = new RelayCommand(ShowGreetingMessage, CanShowGreetingMessage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LocalizationManager LocalizationManager => localizationManager;

        public string UserName
        {
            get => userName;
            set
            {
                if (SetField(ref userName, value))
                {
                    showGreetingCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public LocalizationManager.LanguageOption SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                if (SetField(ref selectedLanguage, value))
                {
                    localizationManager.CurrentLanguage = value;
                }
            }
        }

        public ICommand ShowGreetingCommand => showGreetingCommand;

        private bool CanShowGreetingMessage()
        {
            return !string.IsNullOrWhiteSpace(UserName);
        }

        private void ShowGreetingMessage()
        {
            var message = string.Format(localizationManager["GreetingMessageFormat"], UserName);
            MessageBox.Show(message, localizationManager["GreetingTitle"], MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
