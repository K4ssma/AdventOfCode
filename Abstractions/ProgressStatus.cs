namespace Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Dto for passing progress information.
/// </summary>
public sealed record ProgressStatus
{
    /// <summary>
    ///     Gets a value indicating whether this instance is a major status step with potential substatuses or not.
    /// </summary>
    public required bool IsHeadStatus { get; init; }

    /// <summary>
    ///     Gets the message which describes the current status.
    /// </summary>
    public required string StatusMessage { get; init; }

    /// <summary>
    ///     Gets the currents status categories completion status.
    /// </summary>
    public required byte StatusPercent { get; init; }
}
