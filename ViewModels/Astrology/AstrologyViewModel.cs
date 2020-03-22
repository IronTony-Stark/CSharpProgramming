using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.DataStorage;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology
{
    internal class AstrologyViewModel : BaseViewModel
    {
        #region Fields

        private IRepository _repository;

        private User _user;
        private readonly User _userDefault;

        private string _nameTemp;
        private string _surnameTemp;
        private string _emailTemp;
        private DateTime? _birthDateTemp;

        #region Congratz

        private readonly string[] _congratz =
        {
            "Happy birthday, {0}! May your Facebook, " +
            "Instagram and Twitter walls be filled with messages from people you never talk to!",

            "Forget about the past, you can’t change it. Forget about the future, you can’t " +
            "predict it. Forget about the present, I didn't get you one. Happy birthday, {0}!",

            "On your birthday, I thought of giving you the cutest gift in the world. " +
            "But then I realized that is not possible, " +
            "because you yourself are the cutest gift in the world. Anyway, happy birthday, {0}!",

            "Happy birthday, {0}! The emergency department is on speed dial just in case you have " +
            "an unexpected asthma attack blowing the candles. Just saying... I mean just kidding",

            "Happy birthday, {0}! I made a list about the words of wisdom I wanted to give you " +
            "for your birthday. It’s still blank. Maybe next year",

            "Oh yeah! You’re getting closer to the age when the government sends you money " +
            "every month. Happy Birthday, {0}!",

            "Congratulations, {0}! You only look one year older than you did on your last birthday.",

            "Brace yourself, {0}! An explosion of Facebook, Twitter and Instagram notifications " +
            "is coming. Happy Birthday!",

            "Happy Birthday, {0}! May your day be full of happiness, laughter, love, and of " +
            "course the most important thing—wine!!",
        };

        #endregion

        #region Commands

        private RelayCommand<object> _commitCommand;
        private RelayCommand<object> _finishCommand;

        #endregion

        #endregion

        #region Properties

        private IRepository Repository => _repository;

        public User User
        {
            get => _user;
            private set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        private User UserDefault => _userDefault;

        public string NameTemp
        {
            get => _nameTemp;
            set
            {
                _nameTemp = value;
                OnPropertyChanged();
            }
        }

        public string SurnameTemp
        {
            get => _surnameTemp;
            set
            {
                _surnameTemp = value;
                OnPropertyChanged();
            }
        }

        public string EmailTemp
        {
            get => _emailTemp;
            set
            {
                _emailTemp = value;
                OnPropertyChanged();
            }
        }

        public DateTime? BirthDateTemp
        {
            get => _birthDateTemp;
            set
            {
                _birthDateTemp = value;
                OnPropertyChanged();
            }
        }

        private string[] Congratz => _congratz;

        #region Commands

        public RelayCommand<object> CommitCommand => _commitCommand ?? (_commitCommand =
            new RelayCommand<object>(CommitImpl,
                o => CommitCanExecuteCommand()));

        public RelayCommand<object> FinishCommand =>
            _finishCommand ?? (_finishCommand = new RelayCommand<object>(FinishImpl));

        #endregion

        #endregion

        #region Constructors

        internal AstrologyViewModel(IRepository repository)
        {
            _repository = repository;
            _user = new User("Anonym", "Anonym");
            _userDefault = _user;
        }

        #endregion

        #region CommandsImpls

        private async void CommitImpl(object obj)
        {
            LoaderManager.Instance.ShowLoader();

            try
            {
                await Task.Run(() => { User = new User(NameTemp, SurnameTemp, EmailTemp, BirthDateTemp); });
            }
            catch (Exception e)
            {
                User = UserDefault;
                LoaderManager.Instance.HideLoader();

                MessageBox.Show(e.Message);

                return;
            }

            if (StationManager.SelectedUser != null)
                Repository.UpdateUser(StationManager.SelectedUser, User);
            else
                Repository.AddUser(User);

            StationManager.SelectedUser = User;

            LoaderManager.Instance.HideLoader();

            if (!User.IsBirthday) return;
            string congratulation = Congratz[new Random().Next(Congratz.Length)];
            MessageBox.Show(string.Format(congratulation, User.Name));
        }

        private static void FinishImpl(object obj)
        {
            StationManager.SelectedUser = null;
            NavigationManager.Instance.Navigate(ViewType.DataGrid);
        }

        #endregion

        internal static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            // In case of leap year
            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }

        internal static string WesternZodiac(int day, int month)
        {
            string sign;

            switch (month)
            {
                case 1:
                    sign = day <= 19 ? "Capricorn" : "Aquarius";
                    break;
                case 2:
                    sign = day <= 18 ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    sign = day <= 20 ? "Pisces" : "Aries";
                    break;
                case 4:
                    sign = day <= 19 ? "Aries" : "Taurus";
                    break;
                case 5:
                    sign = day <= 20 ? "Taurus" : "Gemini";
                    break;
                case 6:
                    sign = day <= 20 ? "Gemini" : "Cancer";
                    break;
                case 7:
                    sign = day <= 22 ? "Cancer" : "Leo";
                    break;
                case 8:
                    sign = day <= 22 ? "Leo" : "Virgo";
                    break;
                case 9:
                    sign = day <= 22 ? "Virgo" : "Libra";
                    break;
                case 10:
                    sign = day <= 22 ? "Libra" : "Scorpio";
                    break;
                case 11:
                    sign = day <= 21 ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                    sign = day <= 21 ? "Sagittarius" : "Capricorn";
                    break;
                default:
                    throw new ArgumentException("Month is invalid");
            }

            return sign;
        }

        internal static string ChineseZodiac(int year)
        {
            string[] signs =
            {
                "Rat", "Ox", "Tiger", "Rabbit",
                "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
            };

            return signs[(year - 4) % 12];
        }

        internal static bool EmailIsValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private bool CommitCanExecuteCommand()
        {
            return !string.IsNullOrEmpty(_nameTemp) && !string.IsNullOrEmpty(_surnameTemp)
                                                    && !string.IsNullOrEmpty(_emailTemp)
                                                    && _birthDateTemp != null;
        }
    }
}