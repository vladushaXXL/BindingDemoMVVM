using BindingDemoMVVM.Commands;
using BindingDemoMVVM.Localization;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BindingDemoMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly RelayCommand showGreetingCommand;
        private LanguageOption selectedLanguage;

        public MainViewModel()
        {
            selectedLanguage = LocalizationProvider.Instance.CurrentLanguage;
            showGreetingCommand = new RelayCommand(ShowGreetingMessage);
        }

        public LocalizationProvider LocalizationProvider => LocalizationProvider.Instance;

        public DefaultBindingViewModel DefaultBindingViewModel { get; } = new();

        public TwoWayBindingViewModel TwoWayBindingViewModel { get; } = new();

        public OneTimeBindingViewModel OneTimeBindingViewModel { get; } = new();

        public OneWayBindingViewModel OneWayBindingViewModel { get; } = new();

        public LanguageOption SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                if (SetProperty(ref selectedLanguage, value))
                {
                    LocalizationProvider.Instance.CurrentLanguage = value;
                }
            }
        }

        public ICommand ShowGreetingCommand => showGreetingCommand;

        private void ShowGreetingMessage()
        {
            var userName = string.IsNullOrWhiteSpace(TwoWayBindingViewModel.UserName)
                ? LocalizationProvider.GetString("FallbackUserName")
                : TwoWayBindingViewModel.UserName;

            var message = string.Format(LocalizationProvider.GetString("GreetingMessageFormat"), userName);
            MessageBox.Show(
                message,
                LocalizationProvider.GetString("GreetingTitle"),
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
