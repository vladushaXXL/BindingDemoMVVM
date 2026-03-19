using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingDemoMVVM.ViewModels
{
    public class TwoWayBindingViewModel : ObservableObject
    {
        private string userName = "Студент";
        private int age = 20;
        private bool isActive = true;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public int Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }
    }
}
