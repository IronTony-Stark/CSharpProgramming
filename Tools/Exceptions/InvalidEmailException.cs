using System;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() { }
        
        public InvalidEmailException(string message) : base(message) { }
        
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
    }
}