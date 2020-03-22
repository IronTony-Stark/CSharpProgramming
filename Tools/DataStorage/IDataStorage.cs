using System.Collections.Generic;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.DataStorage
{
    internal interface IDataStorage
    {
        // ObservableCollection<User> UsersView { get; set; }
        
        List<User> Users { get; }
        
        void AddUser(User user);
        
        void RemoveUser(User user);

        void Save();
    }
}
