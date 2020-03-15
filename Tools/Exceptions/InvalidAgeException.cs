using System;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions
{
    public class InvalidAge : Exception
    {
        internal InvalidAge() { }
                
        internal InvalidAge(string message) : base(message) { }
        
        internal InvalidAge(string message, Exception inner) : base(message, inner) { }
    }
}