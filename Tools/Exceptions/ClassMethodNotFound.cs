using System;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions
{
    public class ClassMethodNotFound : Exception
    {
        internal ClassMethodNotFound() { }
                
        internal ClassMethodNotFound(string message) : base(message) { }
        
        internal ClassMethodNotFound(string message, Exception inner) : base(message, inner) { }
    }
}