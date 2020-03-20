using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology
{
    internal class UsersViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<User> _users = new ObservableCollection<User>();
        private User _selectedUser;

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
            set => _users = value;
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set => _selectedUser = value;
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

        internal UsersViewModel()
        {
            GenerateUsers(50);
        }

        private void AddUserImpl(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.PersonOperation);
        }

        private void UpdateUserImpl(object obj)
        {
            AstrologyViewModel.UserToUpdate = SelectedUser;
            NavigationManager.Instance.Navigate(ViewType.PersonOperation);
        }

        private void DeleteUserImpl(object obj)
        {
            Users.Remove(SelectedUser);
        }

        private async void GenerateUsers(int num)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < num; i++)
                {
                    _users.Add(GenerateRandomUser());
                }
            });
        }

        private User GenerateRandomUser()
        {
            string[] names =
            {
                "Tony", "Max", "Noah", "William", "James", "Mason", "Daniel", "Aria", "David", "Levi", "Ryan",
                "Emma", "Rain", "Kira", "Violet", "Aria", "Mia", "Lily", "Natalie", "Bella", "Lucy", "Caroline"
            };

            string[] surnames =
            {
                "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis",
                "Wilson", "Anderson", "Taylor", "Wang", "Devi", "Li",
            };

            string[] emails =
            {
                "@gmail.com", "@urk.net", "@mail.ru", "@outlook.com"
            };

            string name = Utilities.RandomItem(names);
            string surname = Utilities.RandomItem(surnames);
            string email = Utilities.RandomString(Utilities.Random.Next(10) + 5)
                           + Utilities.RandomItem(emails);
            DateTime randomDate = Utilities.RandomDateTime(new DateTime(1950, 1, 1), DateTime.Today);

            return new User(name, surname, email, randomDate);
        }
    }
}