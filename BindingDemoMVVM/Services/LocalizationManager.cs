using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace BindingDemoMVVM.Services
{
    public sealed class LocalizationManager : INotifyPropertyChanged
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("BindingDemoMVVM.Resources.Localization", Assembly.GetExecutingAssembly());

        private static readonly LocalizationManager instance = new LocalizationManager();
        private LanguageOption currentLanguage;

        private LocalizationManager()
        {
            SupportedLanguages = new ObservableCollection<LanguageOption>
            {
                new LanguageOption("ru", "Русский"),
                new LanguageOption("en", "English")
            };

            currentLanguage = SupportedLanguages[0];
        }

        public static LocalizationManager Instance => instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<LanguageOption> SupportedLanguages { get; }

        public LanguageOption CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                if (value == null || Equals(currentLanguage, value))
                {
                    return;
                }

                currentLanguage = value;
                var culture = new CultureInfo(value.CultureCode);
                CultureInfo.CurrentUICulture = culture;
                CultureInfo.CurrentCulture = culture;

                OnPropertyChanged(nameof(CurrentLanguage));
                OnPropertyChanged("Item[]");
            }
        }

        public string this[string key] => ResourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? key;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public sealed class LanguageOption
        {
            public LanguageOption(string cultureCode, string displayName)
            {
                CultureCode = cultureCode;
                DisplayName = displayName;
            }

            public string CultureCode { get; }

            public string DisplayName { get; }
        }
    }
}
