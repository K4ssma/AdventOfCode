namespace Kassma.AdventOfCode.ConsoleApp;

using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Mockup implementation of the <see cref="IAocDay"/>-interface for providing dummy data.
/// </summary>
internal sealed class AocDayMock : IAocDay
{
    /// <summary>
    ///     Simulates the computation of an advent of code result by letting the thread sleep for 5 seconds.
    /// </summary>
    /// <param name="input">
    ///     "<paramref name="input"/>" is not used in this method. Provide any string you want.
    /// </param>
    /// <returns>
    ///     The string "Dummy result for part 01".
    /// </returns>
    public static string SolvePart01(string input)
    {
        Thread.Sleep(5000);

        return "Dummy result for part 01";
    }

    /// <summary>
    ///     Simulates the computation of an advent of code result by letting the thread sleep for 5 seconds.
    /// </summary>
    /// <param name="input">
    ///     "<paramref name="input"/>" is not used in this method. Provide any string you want.
    /// </param>
    /// <returns>
    ///     The string "Dummy result for part 02".
    /// </returns>
    public static string SolvePart02(string input)
    {
        Thread.Sleep(5000);

        return "Dummy result for part 02";
    }
}
