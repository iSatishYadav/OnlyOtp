using System;
using System.Linq;

namespace OnlyOtp
{
    internal class SimpleRandomProvider : IRandomProvider
    {
        private static Random _random = new Random();
        public string GetRandom(int length, char[] charset)
        {
            var chars = new string(charset);
            return new string(Enumerable.Repeat(charset, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
