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
        var lines = input.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);

        var positionsToCheck = new HashSet<Vector2Int>();

        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == '@')
                {
                    positionsToCheck.Add(new(x, y));
                }
            }
        }

        var removedRolls = 0;

        while (positionsToCheck.Count > 0)
        {
            var position = positionsToCheck.First();
            positionsToCheck.Remove(position);

            var neighbourRolls = new List<Vector2Int>(8);

            if (position.X != 0)
            {
                if (lines[position.Y][position.X - 1] == '@')
                {
                    neighbourRolls.Add(new(position.X - 1, position.Y));
                }

                if (position.Y != 0
                    && lines[position.Y - 1][position.X - 1] == '@')
                {
                    neighbourRolls.Add(new(position.X - 1, position.Y - 1));
                }

                if (position.Y < lines.Length - 1
                    && lines[position.Y + 1][position.X - 1] == '@')
                {
                    neighbourRolls.Add(new(position.X - 1, position.Y + 1));
                }
            }

            if (position.X < lines[position.Y].Length - 1)
            {
                if (lines[position.Y][position.X + 1] == '@')
                {
                    neighbourRolls.Add(new(position.X + 1, position.Y));
                }

                if (position.Y != 0
                    && lines[position.Y - 1][position.X + 1] == '@')
                {
                    neighbourRolls.Add(new(position.X + 1, position.Y - 1));
                }

                if (position.Y < lines.Length - 1
                    && lines[position.Y + 1][position.X + 1] == '@')
                {
                    neighbourRolls.Add(new(position.X + 1, position.Y + 1));
                }
            }

            if (position.Y != 0
                    && lines[position.Y - 1][position.X] == '@')
            {
                neighbourRolls.Add(new(position.X, position.Y - 1));
            }

            if (position.Y < lines.Length - 1
                && lines[position.Y + 1][position.X] == '@')
            {
                neighbourRolls.Add(new(position.X, position.Y + 1));
            }

            if (neighbourRolls.Count >= 4)
            {
                continue;
            }

            removedRolls++;

            lines[position.Y] = string.Create(
                lines[position.Y].Length,
                (Source: lines[position.Y], Index: position.X, Replacement: '.'),
                (span, state) =>
            {
                state.Source.AsSpan().CopyTo(span);
                span[state.Index] = state.Replacement;
            });

            positionsToCheck.UnionWith(neighbourRolls);
        }

        return removedRolls.ToString();
    }

    private struct Vector2Int(int x, int y)
    {
        public int X = x;
        public int Y = y;
    }
}
