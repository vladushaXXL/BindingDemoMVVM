using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public partial class DefaultBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string  inputText;

        [ObservableProperty]
        private string outputText = "Пример текста";
    }
}