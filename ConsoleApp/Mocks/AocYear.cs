namespace Kassma.AdventOfCode.ConsoleApp.Mocks;

using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Mock class implementing the <see cref="IAocYear"/>-interface for providing dummy data.
/// </summary>
internal sealed class AocYear : IAocYear
{
    /// <summary>
    ///     Gets 0.
    /// </summary>
    public uint Year => 0;

    /// <summary>
    ///     Gets an array only containing the <see cref="AocDay"/> at index 0.
    /// </summary>
    public IAocDay?[] Days => [new AocDay()];
}
