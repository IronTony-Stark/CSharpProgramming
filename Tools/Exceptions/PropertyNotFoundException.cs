using System;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        internal PropertyNotFoundException() { }
                
        internal PropertyNotFoundException(string message) : base(message) { }
        
        internal PropertyNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}