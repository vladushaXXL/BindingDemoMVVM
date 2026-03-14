using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public partial class OneTimeBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string message = "Это сообщение устанавливается один раз";
    }
}