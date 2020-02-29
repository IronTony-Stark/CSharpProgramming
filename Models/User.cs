using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models
{
    internal class User : INotifyPropertyChanged
    {
        #region Fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        
        private readonly int _age;
        private readonly bool _isAdult;
        private readonly bool _isBirthday;
        private readonly string _sunSign;
        private readonly string _chineseSign;

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public int Age => _age;
        public bool IsAdult => _isAdult;
        public bool IsBirthday => _isBirthday;
        public string SunSign => _sunSign;
        public string ChineseSign => _chineseSign;

        #endregion

        internal User(string name, string surname, string email = "default@mail.com", DateTime? birthDate = null)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate ?? DateTime.Today;

            _age = AstrologyViewModel.CalculateAge(BirthDate);
            _isAdult = Age > 17;
            _isBirthday = BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day;
            _sunSign = AstrologyViewModel.WesternZodiac(BirthDate.Day, BirthDate.Month);
            _chineseSign = AstrologyViewModel.ChineseZodiac(BirthDate.Year);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}