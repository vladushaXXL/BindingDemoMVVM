using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BindingDemoMVVM.Services
{
    public sealed class DictionaryLocalizationService
    {
        public sealed class LanguageOption
        {
            public LanguageOption(string code, string displayName)
            {
                Code = code;
                DisplayName = displayName;
            }

            public string Code { get; }

            public string DisplayName { get; }
        }

        private readonly IReadOnlyList<LanguageOption> supportedLanguages;
        private LanguageOption currentLanguage;

        private DictionaryLocalizationService()
        {
            supportedLanguages = new[]
            {
                new LanguageOption("ru", "Русский"),
                new LanguageOption("en", "English")
            };

            currentLanguage = supportedLanguages[0];
        }

        public static DictionaryLocalizationService Instance { get; } = new DictionaryLocalizationService();

        public IReadOnlyList<LanguageOption> SupportedLanguages => supportedLanguages;

        public LanguageOption CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                if (value == null || string.Equals(currentLanguage.Code, value.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                currentLanguage = value;
                ApplyLanguage(value.Code);
            }
        }

        public void Initialize()
        {
            ApplyLanguage(currentLanguage.Code);
        }

        public string GetString(string key)
        {
            var resource = Application.Current.TryFindResource(key);
            return resource as string ?? "[" + key + "]";
        }

        private void ApplyLanguage(string code)
        {
            var resourceDictionary = new ResourceDictionary
            {
                Source = new Uri($"/BindingDemoMVVM;component/Resources/Strings.{code}.xaml", UriKind.Relative)
            };

            var dictionaries = Application.Current.Resources.MergedDictionaries;
            var existing = dictionaries.FirstOrDefault(d =>
                d.Source != null &&
                d.Source.OriginalString.IndexOf("Resources/Strings.", StringComparison.OrdinalIgnoreCase) >= 0);

            if (existing != null)
            {
                dictionaries.Remove(existing);
            }

            dictionaries.Add(resourceDictionary);
        }
    }
}
