using MVVMSample003.ViewModels;
using System.Windows;

namespace MVVMSample003.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
