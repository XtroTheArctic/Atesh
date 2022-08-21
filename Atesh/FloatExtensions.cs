using System;

namespace Atesh;

public static class FloatExtensions
{
    public static string ToTimeString(this float This, TimeUnit? FixedUnit = null, string Format = "d:hh:mm:ss", bool TrimLeadingNonNumerics = true) => TimeSpan.FromSeconds(This).ToStringExtended(Format, FixedUnit, TrimLeadingNonNumerics);
    public static string ToShortTimeString(this float This, TimeUnit? FixedUnit = null) => TimeSpan.FromSeconds(This).ToStringExtended("mm:ss", FixedUnit);
}