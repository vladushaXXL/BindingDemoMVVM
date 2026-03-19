using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Threading;

namespace BindingDemoMVVM.ViewModels
{
    public class OneWayBindingViewModel : ObservableObject
    {
        private readonly DispatcherTimer timer;
        private string currentTime = string.Empty;

        public string CurrentTime
        {
            get => currentTime;
            set => SetProperty(ref currentTime, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneWayBindingViewModel"/> class.
        /// </summary>
        public OneWayBindingViewModel()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            };

            timer.Start();
        }
    }
}
