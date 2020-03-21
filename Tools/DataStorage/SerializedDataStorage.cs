using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Managers;


namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly ObservableCollection<User> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<ObservableCollection<User>>(FileFolderHelper.StorageFilePath);
                User.IdGlobal = _users.Last().Id;
            }
            catch (FileNotFoundException)
            {
                _users = new ObservableCollection<User>();
                GenerateUsers(50);
                Save();
            }
        }
        
        public ObservableCollection<User> Users => _users;

        public List<User> UsersList => _users.ToList();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }

        public void Save()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }

        private void GenerateUsers(int num)
        {
            for (int i = 0; i < num; i++)
                AddUser(GenerateRandomUser());
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