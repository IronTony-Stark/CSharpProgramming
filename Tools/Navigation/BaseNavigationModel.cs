using System.Collections.Generic;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        #region Fields

        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        #endregion

        #region Properties

        private IContentOwner ContentOwner => _contentOwner;

        protected Dictionary<ViewType, INavigatable> ViewsDictionary => _viewsDictionary;

        #endregion
        
        protected abstract void InitializeView(ViewType viewType);
        
        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        public void Navigate(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }
    }
}