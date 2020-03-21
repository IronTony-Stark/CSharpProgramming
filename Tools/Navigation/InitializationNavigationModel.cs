using System;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner) { }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.DataGrid:
                    ViewsDictionary.Add(viewType, new UsersControl());
                    break;
                case ViewType.PersonOperation:
                    ViewsDictionary.Add(viewType, new AstrologyControl());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}