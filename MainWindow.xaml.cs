using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl => ContentCtrl;
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.DataGrid);
        }
    }
}
