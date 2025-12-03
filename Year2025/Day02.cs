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
        var ranges = input
            .Split(',')
            .Select((rangeString) =>
            {
                var rangeParts = rangeString.Split('-');

                return (ulong.Parse(rangeParts[0]), ulong.Parse(rangeParts[1]));
            });

        var sum = 0ul;

        foreach ((var min, var max) in ranges)
        {
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

        return sum.ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        var ranges = input
            .Split(',')
            .Select((rangeString) =>
            {
                var rangeParts = rangeString.Split('-');

                return (ulong.Parse(rangeParts[0]), ulong.Parse(rangeParts[1]));
            });

        var sum = 0ul;

        foreach ((var min, var max) in ranges)
        {
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
                    var compareNumber = id / (ulong)Math.Pow(10, digitsPerGroup * (splitGroups - 1));
                    var isPattern = true;

                    for (var group = 0; group < splitGroups - 1; group++)
                    {
                        var leftSideMask = id / (ulong)Math.Pow(10, digitsPerGroup * (group + 1));
                        leftSideMask *= (ulong)Math.Pow(10, digitsPerGroup * (group + 1));

                        var number = (id - leftSideMask) / (ulong)Math.Pow(10, digitsPerGroup * group);

                        if (number != compareNumber)
                        {
                            isPattern = false;
                            break;
                        }
                    }

                    if (isPattern)
                    {
                        sum += id;
                        break;
                    }
                }
            }
        }

        return sum.ToString();
    }
}
