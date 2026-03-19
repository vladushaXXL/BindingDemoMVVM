using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public DefaultBindingViewModel DefaultBindingViewModel { get; } = new();
        public TwoWayBindingViewModel TwoWayBindingViewModel { get; } = new();
        public OneTimeBindingViewModel OneTimeBindingViewModel { get; } = new();
        public OneWayBindingViewModel OneWayBindingViewModel { get; } = new();
    }
}
