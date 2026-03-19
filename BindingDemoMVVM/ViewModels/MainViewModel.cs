using BindingDemoMVVM.Commands;
using BindingDemoMVVM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BindingDemoMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly RelayCommand showGreetingCommand;
        private LocalizationManager.LanguageOption selectedLanguage;

        public MainViewModel()
        {
            selectedLanguage = LocalizationManager.CurrentLanguage;
            showGreetingCommand = new RelayCommand(ShowGreetingMessage);
        }

        public LocalizationManager LocalizationManager => LocalizationManager.Instance;

        public DefaultBindingViewModel DefaultBindingViewModel { get; } = new();

        public TwoWayBindingViewModel TwoWayBindingViewModel { get; } = new();

        public OneTimeBindingViewModel OneTimeBindingViewModel { get; } = new();

        public OneWayBindingViewModel OneWayBindingViewModel { get; } = new();

        public LocalizationManager.LanguageOption SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                if (SetProperty(ref selectedLanguage, value))
                {
                    LocalizationManager.CurrentLanguage = value;
                }
            }
        }

        public ICommand ShowGreetingCommand => showGreetingCommand;

        private void ShowGreetingMessage()
        {
            var userName = string.IsNullOrWhiteSpace(TwoWayBindingViewModel.UserName)
                ? LocalizationManager["FallbackUserName"]
                : TwoWayBindingViewModel.UserName;

            var message = string.Format(LocalizationManager["GreetingMessageFormat"], userName);
            MessageBox.Show(message, LocalizationManager["GreetingTitle"], MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
