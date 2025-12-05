namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solutions of the Advent of Code day 5 challenge.
/// </summary>
public sealed class Day05 : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        var parts = input.Split(["\r\n\r\n", "\n\n"], StringSplitOptions.RemoveEmptyEntries);

        var ranges = parts[0]
            .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select((rangeString) =>
            {
                var rangeParts = rangeString.Split('-');
                return (Min: ulong.Parse(rangeParts[0]), Max: ulong.Parse(rangeParts[1]));
            });

        var ids = parts[1]
            .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select((idString) => ulong.Parse(idString));

        return ids
            .Count((id) => ranges.Any((range) => id >= range.Min && id <= range.Max))
            .ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        throw new NotImplementedException();
    }
}
