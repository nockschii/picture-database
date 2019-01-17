using System.Windows;
using PicDB.ViewModel;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel m = new MainWindowViewModel();
            DataContext = m;
        }
    }
}
