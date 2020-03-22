using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Models;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.DataStorage
{
    public interface IRepository
    {
        void AddUser(User u);
        void UpdateUser(User who, User to);
        void DeleteUser(User u);
    }
}