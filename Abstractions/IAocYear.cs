namespace Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Represents an Advent of Code calender year containing solutions foreach day.
/// </summary>
public interface IAocYear
{
    /// <summary>
    ///     Gets an uint indicating which year of Advent of Code this implementation represents.
    /// </summary>
    public static abstract uint Year { get; }

    /// <summary>
    ///     Gets an array of each Advent of Code day.
    ///     The index represents the corresponding day starting at day 1 = index 0.
    /// </summary>
    public static abstract IAocDay?[] Days { get; }
}
