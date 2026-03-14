namespace BindingDemoMVVM.ViewModels
{
    /// <summary>
    /// ViewModel для демонстрации двухсторонней привязки.
    /// </summary>
    public class TwoWayBindingViewModel : ViewModelBase
    {
        private string _userName = "Пользователь";
        private int _age = 25;
        private bool _isActive = true;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
