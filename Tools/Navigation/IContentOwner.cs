using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}