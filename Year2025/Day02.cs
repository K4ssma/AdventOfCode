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

                return (int.Parse(rangeParts[0]), int.Parse(rangeParts[1]));
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

                for (var splitGroups = 2; splitGroups <= digits; splitGroups++)
                {
                    if (digits % splitGroups != 0)
                    {
                        continue;
                    }

                    var digitsPerGroup = digits / splitGroups;
                    var compareNumber = id / (int)Math.Pow(10, digitsPerGroup * (splitGroups - 1));
                    var isPattern = true;

                    for (var group = 0; group < splitGroups - 1; group++)
                    {
                        var leftSideMask = id / (int)Math.Pow(10, digitsPerGroup * (group + 1));
                        var rightSideMask = group == 0
                            ? 0
                            : id / (int)Math.Pow(10, digitsPerGroup * (group - 1));

                        if (id - leftSideMask - rightSideMask != compareNumber)
                        {
                            isPattern = false;
                            break;
                        }
                    }

                    if (isPattern)
                    {
                        sum += (ulong)id;
                        break;
                    }
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
