using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.ViewModels.Astrology
{
    internal class SignInViewModel : BaseViewModel
    {
        #region Fields

        private DateTime? _birthDate;
        private int _age = -1;
        private string _zodiacWestern = "None";
        private string _zodiacChinese = "None";

        #region Commands

        private RelayCommand<object> _evaluateAgeCommand;

        #endregion

        #endregion

        #region Properties

        public DateTime? BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string ZodiacWestern
        {
            get => _zodiacWestern;
            set
            {
                _zodiacWestern = value;
                OnPropertyChanged();
            }
        }
        
        public string ZodiacChinese
        {
            get => _zodiacChinese;
            set
            {
                _zodiacChinese = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> EvaluateAgeCommand
        {
            get
            {
                return _evaluateAgeCommand ?? (_evaluateAgeCommand = new RelayCommand<object>(
                           EvaluateImpl, o => CanExecuteCommand()));
            }
        }

        #endregion

        #endregion

        private async void EvaluateImpl(object obj)
        {
            LoaderManager.Instance.ShowLoader();

            await Task.Run(() => Thread.Sleep(2000));
            
            int age = await Task.Run(() => BirthDate != null 
                ? CalculateAge(BirthDate.Value) : -1);
            
            string zodiacWestern = await Task.Run(() => BirthDate != null 
                ? WesternZodiac(BirthDate.Value.Month, BirthDate.Value.Day) : "None");
            
            string zodiacChinese = await Task.Run(() => BirthDate != null 
                ? ChineseZodiac(BirthDate.Value.Year) : "None");

            LoaderManager.Instance.HideLoader();

            if (age > 135 || age < 0)
            {
                Age = -1;
                ZodiacWestern = "None";
                ZodiacChinese = "None";
                
                MessageBox.Show("Invalid Birth Date");
                
                return;
            }
            
            Age = age;
            ZodiacWestern = zodiacWestern;
            ZodiacChinese = zodiacChinese;

            if (BirthDate?.Month == DateTime.Today.Month && BirthDate?.Day == DateTime.Today.Day)
            {
                MessageBox.Show("Happy Birthday! " +
                                "You look only one year older than last year!");
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            // In case of leap year
            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }

        private string WesternZodiac(int month, int day)
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

        private string ChineseZodiac(int year)
        {
            string[] signs = {"Rat", "Ox", "Tiger", "Rabbit", 
                "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"};
            
            return signs[(year - 4) % 12];
        }

        private bool CanExecuteCommand()
        {
            return BirthDate != null;
        }
    }
}