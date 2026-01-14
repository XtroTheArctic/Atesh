namespace Atesh;

public static class FloatExtensions
{
    extension(float This)
    {
        public string ToTimeString(TimeUnit? FixedUnit = null, string Format = "d:hh:mm:ss", bool TrimLeadingNonNumerics = true) => TimeSpan.FromSeconds(This).ToStringExtended(Format, FixedUnit, TrimLeadingNonNumerics);
        public string ToShortTimeString(TimeUnit? FixedUnit = null) => TimeSpan.FromSeconds(This).ToStringExtended("mm:ss", FixedUnit);
    }
}