using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Views.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner) { }

        protected override void InitializeView()
        {
            UsersControl usersControl;
            ViewsDictionary.Add(ViewType.DataGrid, usersControl = new UsersControl());
            ViewsDictionary.Add(ViewType.PersonOperation, new AstrologyControl(usersControl));
        }
    }
}