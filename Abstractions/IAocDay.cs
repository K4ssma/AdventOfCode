namespace Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Interface which represents a single day in the Advent of Code calender.
/// </summary>
public interface IAocDay
{
    /// <summary>
    ///     Method for solving the first part of the day this instance represents.
    /// </summary>
    /// <param name="progress">
    ///     An instance of <see cref="IProgress{ProgressStatus}"/>
    ///     where the current progress of the challenge solver gets reported.
    /// </param>
    /// <param name="input">
    ///     The string provided by Advent of Code as input to solve this challenge.
    /// </param>
    /// <returns>
    ///     A string representing the solution of this challenge part.
    /// </returns>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input);

    /// <summary>
    ///     Method for solving the second part of the day this instance represents.
    /// </summary>
    /// <param name="progress">
    ///     An instance of <see cref="IProgress{ProgressStatus}"/>
    ///     where the current progress of the challenge solver gets reported.
    /// </param>
    /// <param name="input">
    ///     The string provided by Advent of Code as input to solve this challenge.
    /// </param>
    /// <returns>
    ///     A string representing the solution of this challenge part.
    /// </returns>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input);
}
