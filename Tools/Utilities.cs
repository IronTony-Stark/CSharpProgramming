using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools
{
    public class Utilities
    {
        internal static readonly Random Random = new Random();
        
        internal static DateTime RandomDateTime(DateTime start, DateTime end)
        {
            int range = (end - start).Days;           
            return start.AddDays(Random.Next(range));
        }
        
        internal static T RandomItem<T>(IList<T> collection)
        {
            int size = collection.Count;

            return collection[Random.Next(size)];
        }

        internal static string RandomString(int length)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            
            StringBuilder sb = new StringBuilder();
            while (sb.Length < length) { 
                int index = Random.Next(letters.Length);
                sb.Append(letters[index]);
            }
            
            return sb.ToString();
        }
    }
}