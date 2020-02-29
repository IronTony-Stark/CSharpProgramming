using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology
{
    public partial class AstrologyControl : UserControl
    {
        public AstrologyControl()
        {
            InitializeComponent();
            DataContext = new AstrologyViewModel();
        }
    }
}
