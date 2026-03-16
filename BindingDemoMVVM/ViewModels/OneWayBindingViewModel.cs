using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Threading;

namespace BindingDemoMVVM.ViewModels
{
    public partial class OneWayBindingViewModel : ObservableObject
    {
        private DispatcherTimer timer;

        [ObservableProperty]
        private int progressValue = 25;

        [ObservableProperty]
        private string currentTime;

        public OneWayBindingViewModel()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            };

            timer.Start();
        }
    }
}