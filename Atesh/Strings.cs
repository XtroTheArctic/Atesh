namespace Atesh
{
    public static class Strings
    {
        public const string ArgumentCantBeNullOrEmpty = "Argument cannot be null or empty.";
        public const string ValueIsInvalid = "Value is invalid.";

        public static string AlreadyActive(string Name) => $"{Name} is already active.";
        public static string NotActive(string Name) => $"{Name} is not active.";
        public static string AlreadyInitialized(string Name) => $"{Name} is already initialized.";
        public static string NotInitialized(string Name) => $"{Name} is not initialized.";
    }
}