using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology
{
    public partial class SignInControl : UserControl
    {
        internal SignInControl()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
