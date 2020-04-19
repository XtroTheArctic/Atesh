using System;

namespace Atesh
{
    public static class StringExtensions
    {
        public static string Replace(this string This, char[] OldChars, string NewValue) => string.Join(NewValue, This.Split(OldChars, StringSplitOptions.RemoveEmptyEntries));
    }
}
