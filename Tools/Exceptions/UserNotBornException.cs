using System;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions
{
    public class UserNotBornException : InvalidAge
    {
        public UserNotBornException() { }
        
        public UserNotBornException(string message) : base(message) { }
        
        public UserNotBornException(string message, Exception inner) : base(message, inner) { }
    }
}