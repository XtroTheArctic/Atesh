namespace Atesh;

public static class StringExtensions
{
    public static bool HasValue(this string This) => !string.IsNullOrWhiteSpace(This);
    public static bool HasValue_WhiteSpaceAllowed(this string This) => !string.IsNullOrEmpty(This);

    public static string Replace(this string This, char[] OldChars, string NewValue) => string.Join(NewValue, This.Split(OldChars, StringSplitOptions.RemoveEmptyEntries));
}