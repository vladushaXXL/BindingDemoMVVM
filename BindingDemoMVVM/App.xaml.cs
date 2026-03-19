using BindingDemoMVVM.Services;
using System.Windows;

namespace BindingDemoMVVM
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DictionaryLocalizationService.Instance.Initialize();
        }
    }
}
