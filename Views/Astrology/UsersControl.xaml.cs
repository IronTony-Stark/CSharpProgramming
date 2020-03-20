using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology
{
    public partial class UsersControl : UserControl, INavigatable
    {
        public UsersControl()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
        }
    }
}