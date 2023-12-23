
using System.Windows;
using WpfAppTask.ViewsModels;


namespace WpfAppTask
{
   
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}