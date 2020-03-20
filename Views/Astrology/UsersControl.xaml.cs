using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology
{
    public partial class AstrologyPeopleControl : UserControl, INavigatable
    {
        public AstrologyPeopleControl()
        {
            InitializeComponent();
            DataContext = new AstrologyPeopleViewModel();
        }
    }
}