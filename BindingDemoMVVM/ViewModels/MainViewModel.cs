using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingDemoMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string _textValue;

        public string TextValue
        {
            get => _textValue;
            set
            {
                _textValue = value;
                OnPropertyChanged();
            }
        }

        private int _sliderValue;

        public int SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}