using System;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
        }

        protected override void InitializeViews()
        {
            UsersControl usersControl = new UsersControl();
            ViewsDictionary.Add(ViewType.DataGrid, usersControl);
            ViewsDictionary.Add(ViewType.PersonOperation, new AstrologyControl(usersControl.DataContext));
        }
    }
}