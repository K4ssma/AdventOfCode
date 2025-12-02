namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solving both parts of the Advent of Code 2025 day 1 challenge.
/// </summary>
public sealed class Day01 : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "Reading input",
            StatusPercent = 0,
        });

        var moveOperations = input
            .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select((inputLine, index) =>
            {
                var isMovingRight = inputLine[0] switch
                {
                    'L' => false,
                    'R' => true,
                    _ => throw new FormatException($"Input contains invalid character '{inputLine[0]}' at line {index}"),
                };

                var moveAmount = int.Parse(inputLine[1..]);

                return (isMovingRight, moveAmount);
            });

        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "SolvingTask",
            StatusPercent = 50,
        });

        var currentPos = 50;
        var zeroCount = 0;

        foreach ((var isMovingRight, var moveAmount) in moveOperations)
        {
            currentPos = isMovingRight
                ? currentPos + moveAmount
                : currentPos - moveAmount;

            currentPos %= 100;

            if (currentPos == 0)
            {
                zeroCount++;
            }
        }

        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "Challenge solved",
            StatusPercent = 100,
        });

        return $"Stopped {zeroCount} times at zero";
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        throw new NotImplementedException();
    }
}
