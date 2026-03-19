using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public class OneTimeBindingViewModel : ObservableObject
    {
        private string initialValue = "Это сообщение устанавливается один раз";

        public string InitialValue
        {
            get => initialValue;
            set => SetProperty(ref initialValue, value);
        }
    }
}
