using System.Windows;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
