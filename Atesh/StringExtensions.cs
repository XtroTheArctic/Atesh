namespace Atesh;

public static class StringExtensions
{
    extension(string This)
    {
        public bool HasValue => !string.IsNullOrWhiteSpace(This);
        public bool HasValue_WhiteSpaceAllowed => !string.IsNullOrEmpty(This);

        public string Replace(char[] OldChars, string NewValue) => string.Join(NewValue, This.Split(OldChars, StringSplitOptions.RemoveEmptyEntries));
    }
}