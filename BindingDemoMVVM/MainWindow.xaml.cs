using BindingDemoMVVM.ViewModels;
using System.Windows;

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