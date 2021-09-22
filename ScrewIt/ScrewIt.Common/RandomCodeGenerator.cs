using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrewIt.Common
{
    public static class RandomCodeGenerator
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
