namespace BindingDemoMVVM.ViewModels
{
    /// <summary>
    /// ViewModel для демонстрации одноразовой привязки (OneTime).
    /// Значение передаётся только при загрузке.
    /// </summary>
    public class OneTimeBindingViewModel : ViewModelBase
    {
        private string _initialValue = "Начальное значение (загружается один раз)";

        public string InitialValue
        {
            get => _initialValue;
            set => SetProperty(ref _initialValue, value);
        }
    }
}
