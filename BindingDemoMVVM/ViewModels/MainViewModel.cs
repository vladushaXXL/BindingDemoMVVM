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
        private DictionaryLocalizationService.LanguageOption selectedLanguage;

        public MainViewModel()
        {
            selectedLanguage = DictionaryLocalizationService.Instance.CurrentLanguage;
            showGreetingCommand = new RelayCommand(ShowGreetingMessage);
        }

        public DictionaryLocalizationService LocalizationService => DictionaryLocalizationService.Instance;

        public DefaultBindingViewModel DefaultBindingViewModel { get; } = new();

        public TwoWayBindingViewModel TwoWayBindingViewModel { get; } = new();

        public OneTimeBindingViewModel OneTimeBindingViewModel { get; } = new();

        public OneWayBindingViewModel OneWayBindingViewModel { get; } = new();

        public DictionaryLocalizationService.LanguageOption SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                if (SetProperty(ref selectedLanguage, value))
                {
                    DictionaryLocalizationService.Instance.CurrentLanguage = value;
                }
            }
        }

        public ICommand ShowGreetingCommand => showGreetingCommand;

        private void ShowGreetingMessage()
        {
            var userName = string.IsNullOrWhiteSpace(TwoWayBindingViewModel.UserName)
                ? LocalizationService.GetString("FallbackUserName")
                : TwoWayBindingViewModel.UserName;

            var message = string.Format(LocalizationService.GetString("GreetingMessageFormat"), userName);
            MessageBox.Show(message, LocalizationService.GetString("GreetingTitle"), MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
