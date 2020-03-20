using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers
{
    internal class NavigationManager
    {
        #region Fields

        private static readonly object Locker = new object();
        private INavigationModel _navigationModel;
        private static NavigationManager _instance;

        #endregion

        #region Properties

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigationManager());
                }
            }
        }

        #endregion

        private NavigationManager() { }

        internal void Initialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ViewType viewType)
        {
            _navigationModel.Navigate(viewType);
        }
    }
}