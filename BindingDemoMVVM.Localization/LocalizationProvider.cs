using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace BindingDemoMVVM.Localization
{
    public sealed class LocalizationProvider : INotifyPropertyChanged
    {
        private readonly IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> translations;
        private readonly IReadOnlyList<LanguageOption> supportedLanguages;
        private LanguageOption currentLanguage;

        private LocalizationProvider()
        {
            supportedLanguages = new[]
            {
                new LanguageOption("ru", "Русский"),
                new LanguageOption("en", "English")
            };

            currentLanguage = supportedLanguages[0];

            translations = new Dictionary<string, IReadOnlyDictionary<string, string>>(StringComparer.OrdinalIgnoreCase)
            {
                ["ru"] = CreateRussianTranslations(),
                ["en"] = CreateEnglishTranslations()
            };
        }

        public static LocalizationProvider Instance { get; } = new LocalizationProvider();

        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged(nameof(CurrentLanguage));
                OnPropertyChanged(Binding.IndexerName);
            }
        }

        public string this[string key] => GetString(key);

        public string GetString(string key)
        {
            if (translations.TryGetValue(currentLanguage.Code, out var current)
                && current.TryGetValue(key, out var value))
            {
                return value;
            }

            if (translations.TryGetValue("ru", out var fallback)
                && fallback.TryGetValue(key, out value))
            {
                return value;
            }

            return "[" + key + "]";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static IReadOnlyDictionary<string, string> CreateRussianTranslations()
        {
            return new Dictionary<string, string>
            {
                ["WindowTitle"] = "Демонстрация привязок WPF",
                ["LanguageLabel"] = "Язык:",
                ["ShowMessageButton"] = "Показать сообщение",
                ["TabDefaultBinding"] = "Привязка по умолчанию",
                ["TabTwoWayBinding"] = "Двухсторонняя привязка",
                ["TabOneTimeBinding"] = "Одноразовая привязка",
                ["TabOneWayBinding"] = "Односторонняя привязка",
                ["TabTriggers"] = "Триггеры",
                ["Default_Title"] = "Привязка по умолчанию (Mode не указан)",
                ["Default_Description"] = "Для TextBox по умолчанию TwoWay, для TextBlock, Slider и CheckBox используется OneWay.",
                ["Default_TextLabel"] = "Текст:",
                ["Default_NumberLabel"] = "Число:",
                ["Default_FlagLabel"] = "Флаг:",
                ["Default_FlagContent"] = "Включено",
                ["Default_SliderLabel"] = "Слайдер:",
                ["TwoWay_Title"] = "Двухсторонняя привязка (TwoWay)",
                ["TwoWay_NameLabel"] = "Имя (TextBox, TwoWay):",
                ["TwoWay_MirrorLabel"] = "То же значение UserName (TextBlock, OneWay - только чтение):",
                ["TwoWay_AgeLabel"] = "Возраст (Slider):",
                ["TwoWay_AgeValuePrefix"] = "Возраст:",
                ["TwoWay_AgeValueSuffix"] = "лет",
                ["TwoWay_IsActiveLabel"] = "Активен (IsActive)",
                ["TwoWay_IsActiveValuePrefix"] = "IsActive =",
                ["OneTime_Title"] = "Одноразовая привязка (OneTime)",
                ["OneTime_Description"] = "Значение передается только при загрузке. Изменения в ViewModel после загрузки не отображаются.",
                ["OneTime_InputLabel"] = "TextBox привязан к InitialValue с Mode=OneTime:",
                ["OneTime_Note"] = "При вводе в TextBox значение в UI не обновляется из ViewModel. Изменение InitialValue после загрузки тоже не попадет на экран.",
                ["OneWay_Title"] = "Односторонняя привязка (OneWay)",
                ["OneWay_Description"] = "CurrentTime обновляется по таймеру раз в секунду. UI получает обновления только от источника.",
                ["OneWay_CurrentTimeLabel"] = "Текущее время:",
                ["Triggers_Title"] = "Триггеры",
                ["Triggers_PropertyTriggerDescription"] = "1. PropertyTrigger - кнопка меняет цвет при наведении (IsMouseOver):",
                ["Triggers_HoverButton"] = "Наведи курсор",
                ["Triggers_DataTriggerDescription"] = "2. DataTrigger - текст меняется при условии (CheckBox IsChecked):",
                ["Triggers_EnableCondition"] = "Включить условие",
                ["Triggers_ConditionOff"] = "Условие выключено",
                ["Triggers_ConditionOn"] = "Условие включено!",
                ["Triggers_Note"] = "(Текст и стиль зависят от состояния CheckBox)",
                ["Triggers_EventTriggerDescription"] = "3. EventTrigger - анимация при нажатии кнопки (Click):",
                ["Triggers_AnimatedButton"] = "Нажми для анимации",
                ["GreetingTitle"] = "Сообщение",
                ["GreetingMessageFormat"] = "Здравствуйте, {0}! Язык приложения успешно переключен.",
                ["FallbackUserName"] = "пользователь"
            };
        }

        private static IReadOnlyDictionary<string, string> CreateEnglishTranslations()
        {
            return new Dictionary<string, string>
            {
                ["WindowTitle"] = "WPF Binding Demo",
                ["LanguageLabel"] = "Language:",
                ["ShowMessageButton"] = "Show message",
                ["TabDefaultBinding"] = "Default binding",
                ["TabTwoWayBinding"] = "Two-way binding",
                ["TabOneTimeBinding"] = "One-time binding",
                ["TabOneWayBinding"] = "One-way binding",
                ["TabTriggers"] = "Triggers",
                ["Default_Title"] = "Default binding (Mode is not specified)",
                ["Default_Description"] = "For TextBox the default mode is TwoWay, while TextBlock, Slider and CheckBox use OneWay.",
                ["Default_TextLabel"] = "Text:",
                ["Default_NumberLabel"] = "Number:",
                ["Default_FlagLabel"] = "Flag:",
                ["Default_FlagContent"] = "Enabled",
                ["Default_SliderLabel"] = "Slider:",
                ["TwoWay_Title"] = "Two-way binding (TwoWay)",
                ["TwoWay_NameLabel"] = "Name (TextBox, TwoWay):",
                ["TwoWay_MirrorLabel"] = "The same UserName value (TextBlock, OneWay - read only):",
                ["TwoWay_AgeLabel"] = "Age (Slider):",
                ["TwoWay_AgeValuePrefix"] = "Age:",
                ["TwoWay_AgeValueSuffix"] = "years",
                ["TwoWay_IsActiveLabel"] = "Active (IsActive)",
                ["TwoWay_IsActiveValuePrefix"] = "IsActive =",
                ["OneTime_Title"] = "One-time binding (OneTime)",
                ["OneTime_Description"] = "The value is passed only when the view is loaded. Changes in the ViewModel are not reflected afterwards.",
                ["OneTime_InputLabel"] = "TextBox is bound to InitialValue with Mode=OneTime:",
                ["OneTime_Note"] = "Typing in the TextBox does not refresh the UI from the ViewModel. Changing InitialValue after loading also will not appear on the screen.",
                ["OneWay_Title"] = "One-way binding (OneWay)",
                ["OneWay_Description"] = "CurrentTime is updated by a timer every second. The UI receives updates only from the source.",
                ["OneWay_CurrentTimeLabel"] = "Current time:",
                ["Triggers_Title"] = "Triggers",
                ["Triggers_PropertyTriggerDescription"] = "1. PropertyTrigger - the button changes color on mouse hover (IsMouseOver):",
                ["Triggers_HoverButton"] = "Hover over me",
                ["Triggers_DataTriggerDescription"] = "2. DataTrigger - the text changes when a condition is met (CheckBox IsChecked):",
                ["Triggers_EnableCondition"] = "Enable condition",
                ["Triggers_ConditionOff"] = "Condition is off",
                ["Triggers_ConditionOn"] = "Condition is on!",
                ["Triggers_Note"] = "(The text and style depend on the CheckBox state)",
                ["Triggers_EventTriggerDescription"] = "3. EventTrigger - animation when the button is clicked:",
                ["Triggers_AnimatedButton"] = "Click for animation",
                ["GreetingTitle"] = "Message",
                ["GreetingMessageFormat"] = "Hello, {0}! The application language has been switched successfully.",
                ["FallbackUserName"] = "user"
            };
        }
    }
}
