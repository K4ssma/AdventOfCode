namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using System.Diagnostics;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solving the Advent of Code day 3 challenge.
/// </summary>
public sealed class Day03 : IAocDay
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

        var banks = input.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);

        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "Solving",
            StatusPercent = 0,
        });

        var sum = 0;

        for (var bankIndex = 0; bankIndex < banks.Length; bankIndex++)
        {
            var bank = banks[bankIndex];

            var firstDigitIndex = GetFirstHighestDigitIndex(
                bank, 0, bank.Length - 1, out var firstDigit);

            GetFirstHighestDigitIndex(
                bank, firstDigitIndex + 1, bank.Length, out var secondDigit);

            sum += (firstDigit * 10) + secondDigit;

            progress.Report(new()
            {
                IsHeadStatus = false,
                StatusMessage = $"Solved bank {bankIndex + 1}",
                StatusPercent = (byte)((bankIndex + 1) * (100 / banks.Length)),
            });
        }

        return sum.ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        throw new NotImplementedException();
    }

    private static int GetFirstHighestDigitIndex(string numberString, int startIndex, int endIndex, out int highestDigit)
    {
        var highestDigitIndex = startIndex;
        highestDigit = int.Parse(numberString[startIndex].ToString());

        for (var i = startIndex + 1; i < endIndex; i++)
        {
            var parsedDigit = int.Parse(numberString[i].ToString());

            if (parsedDigit <= highestDigit)
            {
                continue;
            }

            highestDigit = parsedDigit;
            highestDigitIndex = i;

            if (highestDigit == 9)
            {
                break;
            }
        }

        return highestDigitIndex;
    }
}
