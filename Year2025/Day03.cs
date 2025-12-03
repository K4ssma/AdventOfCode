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

    private static int GetFirstHighestDigitIndex(string numberString, int startIndex, int endIndex, out int highestDigit)
    {
        highestDigit = 0;
        var highestDigitIndex = default(int?);
        var currIndex = startIndex;

        do
        {
            var parsedDigit = int.Parse(numberString[currIndex].ToString());

            if (highestDigitIndex is null
                || parsedDigit > highestDigit)
            {
                highestDigit = parsedDigit;
                highestDigitIndex = currIndex;
            }

            currIndex++;
        }
        while (currIndex < endIndex
            && highestDigit != 9);

        return highestDigitIndex.Value;
    }
}
