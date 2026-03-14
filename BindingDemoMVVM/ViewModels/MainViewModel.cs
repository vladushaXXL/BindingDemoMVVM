using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            DefaultBindingViewModel = new DefaultBindingViewModel();
            TwoWayBindingViewModel = new TwoWayBindingViewModel();
            OneWayBindingViewModel = new OneWayBindingViewModel();
            OneTimeBindingViewModel = new OneTimeBindingViewModel();
        }

        public DefaultBindingViewModel DefaultBindingViewModel { get; }

        public TwoWayBindingViewModel TwoWayBindingViewModel { get; }

        public OneWayBindingViewModel OneWayBindingViewModel { get; }

        public OneTimeBindingViewModel OneTimeBindingViewModel { get; }
    }
}