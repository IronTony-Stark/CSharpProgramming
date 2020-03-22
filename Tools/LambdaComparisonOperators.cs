using System;
using System.Reflection;
using KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Exceptions;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools
{
    internal static class LambdaComparisonOperators
    {
        public static Func<T, T, bool> Greater<T>()
            where T : IComparable<T>
        {
            return (lhs, rhs) => lhs.CompareTo(rhs) > 0;
        }

        public static Func<T, T, bool> Less<T>()
            where T : IComparable<T>
        {
            return (lhs, rhs) => lhs.CompareTo(rhs) < 0;
        }
        
        public static Func<T, T, bool> GreaterEquals<T>()
            where T : IComparable<T>
        {
            return (lhs, rhs) => lhs.CompareTo(rhs) >= 0;
        }

        public static Func<T, T, bool> LessEquals<T>()
            where T : IComparable<T>
        {
            return (lhs, rhs) => lhs.CompareTo(rhs) <= 0;
        }
        
        // Standard Equals :( ...
        public static Func<T, T, bool> Equalss<T>()
            where T : IComparable<T>
        {
            return (lhs, rhs) => lhs.Equals(rhs);
        }

        public static Func<T, T, bool> GetFunctionByName<T>(string name)
            where T : IComparable<T>
        {
            try
            {
                if (name == "Equals")
                    return Equalss<T>();
            
                MethodInfo method = typeof(LambdaComparisonOperators).GetMethod(name);
                MethodInfo generic = method.MakeGenericMethod(typeof(T));
                return (Func<T, T, bool>) generic.Invoke(null, null);
            }
            catch (Exception e)
            {
                throw new ClassMethodNotFound($"Method {name} is not found in class {typeof(LambdaComparisonOperators)}", e);
            }
        }
    }
}