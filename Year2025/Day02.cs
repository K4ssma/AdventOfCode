namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solving both parts of the Advent of Code 2025 day 2 challenge.
/// </summary>
public sealed class Day02 : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "Parsing input",
            StatusPercent = 0,
        });

        var ranges = input
            .Split(',')
            .Select((rangeString) =>
            {
                var rangeParts = rangeString.Split('-');

                return (ulong.Parse(rangeParts[0]), ulong.Parse(rangeParts[1]));
            })
            .ToArray();

        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = $"Solving process (checking {ranges.Length} ranges)",
            StatusPercent = 0,
        });

        var sum = 0ul;

        for (var i = 0; i < ranges.Length; i++)
        {
            (var min, var max) = ranges[i];

            progress.Report(new()
            {
                IsHeadStatus = false,
                StatusMessage = $"Checking range {min}-{max}",
                StatusPercent = (byte)(i * (100 / ranges.Length)),
            });

            for (var id = min; id <= max; id++)
            {
                var digits = (int)Math.Log10(id) + 1;

                if (digits % 2 != 0)
                    {
                        continue;
                    }

                var firstGroup = id / (ulong)Math.Pow(10, digits / 2);
                var leftSideMask = firstGroup * (ulong)Math.Pow(10, digits / 2);

                var secondGroup = id - leftSideMask;

                if (firstGroup == secondGroup)
                    {
                        sum += id;
                }
            }
        }

        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "Done",
            StatusPercent = 100,
        });

        return sum.ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        throw new NotImplementedException();
    }
}
