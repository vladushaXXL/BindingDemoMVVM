using System.Windows;
using BindingDemoMVVM.ViewModels;

namespace BindingDemoMVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
