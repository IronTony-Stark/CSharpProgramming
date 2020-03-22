using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models
{
    [Serializable]
    public class User : INotifyPropertyChanged, IComparable<User>
    {
        #region Fields

        private static int _idGlobal;

        private readonly int _id;
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

        public static int IdGlobal
        {
            get => _idGlobal;
            set => _idGlobal = value;
        }

        public int Id => _id;

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            private set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            private set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            private set
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
            if (!AstrologyViewModel.EmailIsValid(email))
                throw new InvalidEmailException("Invalid Email Address");

            _id = _idGlobal++;
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate ?? DateTime.Today;

            _age = AstrologyViewModel.CalculateAge(BirthDate);
            if (Age < 0) throw new UserNotBornException($"User hasn't been born yet. Age: {Age}");
            if (Age > 135) throw new UserTooOldException($"User is too old. Age: {Age}");

            _isAdult = Age > 17;
            _isBirthday = BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day;
            _sunSign = AstrologyViewModel.WesternZodiac(BirthDate.Day, BirthDate.Month);
            _chineseSign = AstrologyViewModel.ChineseZodiac(BirthDate.Year);
        }

        public object this[string propertyName]
        {
            get
            {
                try
                {
                    Type myType = typeof(User);
                    PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                    return myPropInfo.GetValue(this, null);
                }
                catch (Exception e)
                {
                    throw new PropertyNotFoundException($"Property {propertyName} cannot be found", e);
                }
            }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;

        private protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(User other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return _id.CompareTo(other._id);
        }
    }
}