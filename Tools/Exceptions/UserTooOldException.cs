using System;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions
{
    public class UserTooOldException : InvalidAge
    {
        public UserTooOldException() { }
        
        public UserTooOldException(string message) : base(message) { }
        
        public UserTooOldException(string message, Exception inner) : base(message, inner) { }
    }
}