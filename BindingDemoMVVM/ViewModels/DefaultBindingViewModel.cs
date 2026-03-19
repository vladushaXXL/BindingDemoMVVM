using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public class DefaultBindingViewModel : ObservableObject
    {
        private string text = "Пример текста";
        private int number = 42;
        private bool flag = true;
        private double value = 0.5;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public int Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }

        public bool Flag
        {
            get => flag;
            set => SetProperty(ref flag, value);
        }

        public double Value
        {
            get => this.value;
            set => SetProperty(ref this.value, value);
        }
    }
}
