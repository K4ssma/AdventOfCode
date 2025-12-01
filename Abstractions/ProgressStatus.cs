namespace Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Dto for passing progress information.
/// </summary>
public sealed record ProgressStatus
{
    /// <summary>
    ///     Gets a value indicating whether this instance is part of a bigger status categorie or not.
    /// </summary>
    public required bool IsSubstatus { get; init; }

    /// <summary>
    ///     Gets the message which describes the current status.
    /// </summary>
    public required string StatusMessage { get; init; }

    /// <summary>
    ///     Gets the currents status categories completion status.
    /// </summary>
    public required byte StatusPercent { get; init; }
}
