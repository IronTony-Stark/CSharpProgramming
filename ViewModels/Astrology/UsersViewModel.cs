using System.Collections.ObjectModel;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology
{
    internal class UsersViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<User> _users = StationManager.DataStorage.Users;

        #region Commands

        private RelayCommand<object> _addUserCommand;
        private RelayCommand<object> _updateUserCommand;
        private RelayCommand<object> _deleteUserCommand;

        #endregion

        #endregion

        #region Properties

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public static User SelectedUser
        {
            get => StationManager.SelectedUser;
            set => StationManager.SelectedUser = value;
        }

        #region Commands

        public RelayCommand<object> AddUserCommand =>
            _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(AddUserImpl));

        public RelayCommand<object> UpdateUserCommand =>
            _updateUserCommand ?? (_updateUserCommand = new RelayCommand<object>(UpdateUserImpl));

        public RelayCommand<object> DeleteUserCommand =>
            _deleteUserCommand ?? (_deleteUserCommand = new RelayCommand<object>(DeleteUserImpl));

        #endregion

        #endregion

        #region CommandsImpls

        private void AddUserImpl(object obj)
        {
            StationManager.SelectedUser = null;
            NavigationManager.Instance.Navigate(ViewType.PersonOperation);
        }

        private void UpdateUserImpl(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.PersonOperation);
        }

        private void DeleteUserImpl(object obj)
        {
            StationManager.DataStorage.RemoveUser(StationManager.SelectedUser);
            StationManager.DataStorage.Save();
            StationManager.SelectedUser = null;
        }

        #endregion
    }
}