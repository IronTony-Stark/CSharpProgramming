using System.Collections.Generic;
using System.Collections.ObjectModel;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.DataStorage
{
    internal interface IDataStorage
    {
        ObservableCollection<User> Users { get; }
        
        List<User> UsersList { get; }
        
        void AddUser(User user);
        
        void RemoveUser(User user);

        void Save();
    }
}
