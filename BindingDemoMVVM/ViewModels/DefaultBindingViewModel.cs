namespace BindingDemoMVVM.ViewModels
{
    /// <summary>
    /// ViewModel для демонстрации привязки по умолчанию (без указания Mode).
    /// </summary>
    public class DefaultBindingViewModel : ViewModelBase
    {
        private string _text = "Текст по умолчанию";
        private int _number = 42;
        private bool _flag = false;
        private double _value = 0.5;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        public bool Flag
        {
            get => _flag;
            set => SetProperty(ref _flag, value);
        }

        public double Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
