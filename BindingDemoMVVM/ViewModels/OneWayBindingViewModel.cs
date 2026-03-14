using System;
using System.Windows.Threading;

namespace BindingDemoMVVM.ViewModels
{
    /// <summary>
    /// ViewModel для демонстрации односторонней привязки (OneWay).
    /// CurrentTime обновляется по таймеру.
    /// </summary>
    public class OneWayBindingViewModel : ViewModelBase, IDisposable
    {
        private string _currentTime;
        private readonly DispatcherTimer _timer;

        public OneWayBindingViewModel()
        {
            _currentTime = DateTime.Now.ToString("HH:mm:ss");
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) => CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            _timer.Start();
        }

        public string CurrentTime
        {
            get => _currentTime;
            set => SetProperty(ref _currentTime, value);
        }

        public void Dispose()
        {
            _timer?.Stop();
        }
    }
}
