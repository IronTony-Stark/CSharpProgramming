using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        
        private ObservableCollection<User> _users = new ObservableCollection<User>(StationManager.DataStorage.Users);
        
        private string _sortBy;
        private string _filterBy;
        private string _filterOperation;
        private string _filterValue;

        #region Commands

        private RelayCommand<object> _addUserCommand;
        private RelayCommand<object> _updateUserCommand;
        private RelayCommand<object> _deleteUserCommand;
        private RelayCommand<object> _applyFilterCommand;

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

        public string SortBy
        {
            get => _sortBy;
            set
            {
                string previous = _sortBy;
                _sortBy = value;

                if (previous != _sortBy)
                {
                    Sort(SortBy);
                }
            }
        }

        public string FilterBy
        {
            get => _filterBy;
            set => _filterBy = value;
        }

        public string FilterOperation
        {
            get => _filterOperation;
            set => _filterOperation = value;
        }

        public string FilterValue
        {
            get => _filterValue;
            set => _filterValue = value;
        }

        #region Commands

        public RelayCommand<object> AddUserCommand =>
            _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(AddUserImpl));

        public RelayCommand<object> UpdateUserCommand =>
            _updateUserCommand ?? (_updateUserCommand = new RelayCommand<object>(UpdateUserImpl));

        public RelayCommand<object> DeleteUserCommand =>
            _deleteUserCommand ?? (_deleteUserCommand = new RelayCommand<object>(DeleteUserImpl));

        public RelayCommand<object> ApplyFilterCommand =>
            _applyFilterCommand ??
            (_applyFilterCommand = new RelayCommand<object>(ApplyFilterImpl, ApplyFilterCanExecute));

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
            User toDelete = StationManager.SelectedUser;
            
            Users.Remove(toDelete);
            StationManager.DataStorage.RemoveUser(toDelete);
            StationManager.DataStorage.Save();
            
            StationManager.SelectedUser = null;
        }

        private static List<User> FilteredUsers<T>(IEnumerable<User> users,
            string propGetter, Func<T, T, bool> keyFunc, T key)
            where T : IComparable<T>
        {
            return users.Where(u => keyFunc((T) u[propGetter], key)).ToList();
        }

        private void ApplyFilterImpl(object obj)
        {
            try
            {
                List<User> filtered;
                
                switch (FilterBy)
                {
                    case "Name":
                    case "Surname":
                    case "Email":
                    case "SunSign":
                    case "ChineseSign":
                        filtered = FilteredUsers(StationManager.DataStorage.Users,
                            FilterBy,
                            LambdaComparisonOperators.GetFunctionByName<string>(FilterOperation),
                            FilterValue);
                        break;
                    case "Id":
                    case "Age":
                        filtered = FilteredUsers(StationManager.DataStorage.Users,
                            FilterBy,
                            LambdaComparisonOperators.GetFunctionByName<int>(FilterOperation),
                            int.Parse(FilterValue));
                        break;
                    case "BirthDate":
                        filtered = FilteredUsers(StationManager.DataStorage.Users,
                            FilterBy,
                            LambdaComparisonOperators.GetFunctionByName<DateTime>(FilterOperation),
                            DateTime.Parse(FilterValue));
                        break;
                    case "IsBirthday":
                    case "Adult":
                        filtered = FilteredUsers(StationManager.DataStorage.Users,
                            FilterBy,
                            LambdaComparisonOperators.GetFunctionByName<bool>(FilterOperation),
                            bool.Parse(FilterValue));
                        break;
                    default:
                        throw new ArgumentException("Filter By Unknown Element");
                }
                
                Users = new ObservableCollection<User>(filtered);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool ApplyFilterCanExecute(object obj)
        {
            return !string.IsNullOrEmpty(FilterValue);
        }

        #endregion

        private void Sort(string sortBy)
        {
            switch (sortBy)
            {
                case "Id":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.Id));
                    break;
                case "Name":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.Name));
                    break;
                case "Surname":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.Surname));
                    break;
                case "Email":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.Email));
                    break;
                case "Birth Date":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.BirthDate));
                    break;
                case "Age":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.Age));
                    break;
                case "Adult":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.IsAdult));
                    break;
                case "Birthday Today":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.IsBirthday));
                    break;
                case "Sun Sign":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.SunSign));
                    break;
                case "Chinese Sign":
                    Users = new ObservableCollection<User>(Users.OrderBy(i => i.ChineseSign));
                    break;
                default:
                    throw new ArgumentException("Sort By Unknown Property");
            }
        }
    }
}