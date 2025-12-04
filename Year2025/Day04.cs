namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solving the Advent of Code day 4 challenge.
/// </summary>
public sealed class Day04 : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        var lines = input.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);

        var count = 0;

        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] != '@')
                {
                    continue;
                }

                var neighbourCount = 0;

                if (x != 0)
                {
                    if (lines[y][x - 1] == '@')
                    {
                        neighbourCount++;
                    }

                    if (y != 0
                        && lines[y - 1][x - 1] == '@')
                    {
                        neighbourCount++;
                    }

                    if (y != lines.Length - 1
                        && lines[y + 1][x - 1] == '@')
                    {
                        neighbourCount++;
                    }
                }

                if (x != lines[y].Length - 1)
                {
                    if (lines[y][x + 1] == '@')
                    {
                        neighbourCount++;
                    }

                    if (y != 0
                        && lines[y - 1][x + 1] == '@')
                    {
                        neighbourCount++;
                    }

                    if (y != lines.Length - 1
                        && lines[y + 1][x + 1] == '@')
                    {
                        neighbourCount++;
                    }
                }

                if (y != 0
                    && lines[y - 1][x] == '@')
                {
                    neighbourCount++;
                }

                if (y != lines.Length - 1
                    && lines[y + 1][x] == '@')
                {
                    neighbourCount++;
                }

                if (neighbourCount < 4)
                {
                    count++;
                }
            }
        }

        return count.ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        throw new NotImplementedException();
    }
}
