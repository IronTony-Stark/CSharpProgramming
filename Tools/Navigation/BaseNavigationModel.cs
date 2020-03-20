using System.Collections.Generic;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        #region Fields

        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;
        private bool isInitialized = false;

        #endregion

        #region Properties

        private IContentOwner ContentOwner => _contentOwner;

        protected Dictionary<ViewType, INavigatable> ViewsDictionary => _viewsDictionary;

        public bool IsInitialized { get; set; }

        #endregion
        
        protected abstract void InitializeViews();
        
        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        public void Navigate(ViewType viewType)
        {
            if (!isInitialized)
            {
                InitializeViews();
                isInitialized = true;
            }

            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }
    }
}