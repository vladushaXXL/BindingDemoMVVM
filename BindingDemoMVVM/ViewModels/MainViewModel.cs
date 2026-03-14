namespace BindingDemoMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            TwoWayBindingViewModel = new TwoWayBindingViewModel();
            OneTimeBindingViewModel = new OneTimeBindingViewModel();
            OneWayBindingViewModel = new OneWayBindingViewModel();
            DefaultBindingViewModel = new DefaultBindingViewModel();
        }

        public TwoWayBindingViewModel TwoWayBindingViewModel { get; }
        public OneTimeBindingViewModel OneTimeBindingViewModel { get; }
        public OneWayBindingViewModel OneWayBindingViewModel { get; }
        public DefaultBindingViewModel DefaultBindingViewModel { get; }
    }
}