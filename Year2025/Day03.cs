namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solving the Advent of Code day 3 challenge.
/// </summary>
public sealed class Day03 : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        return GetMaxJoltage(progress, input, 2).ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        return GetMaxJoltage(progress, input, 12).ToString();
    }

    private static ulong GetMaxJoltage(IProgress<ProgressStatus> progress, string input, int batteriesPerBank)
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

        var sum = 0ul;

        for (var bankIndex = 0; bankIndex < banks.Length; bankIndex++)
        {
            var bank = banks[bankIndex];

            if (bank.Length < batteriesPerBank)
            {
                throw new ArgumentException(
                    $"Bank \"{bank}\" does not have enough batteries to activate {batteriesPerBank} batteries");
            }

            var previousBatteryIndex = 0;

            for (var battery = 0; battery < batteriesPerBank; battery++)
            {
                var highestDigit = default(int?);
                var highestDigitIndex = default(int?);
                var currIndex = battery == 0
                    ? 0
                    : previousBatteryIndex + 1;

                do
                {
                    var parsedDigit = int.Parse(bank[currIndex].ToString());

                    if (highestDigit is null
                        || parsedDigit > highestDigit)
                    {
                        highestDigit = parsedDigit;
                        highestDigitIndex = currIndex;
                    }

                    currIndex++;
                }
                while (highestDigit != 9
                    && currIndex <= bank.Length - (batteriesPerBank - battery));

                sum += (ulong)(highestDigit * Math.Pow(10, batteriesPerBank - battery - 1));

                previousBatteryIndex = highestDigitIndex!.Value;
            }

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

        return sum;
    }
}
