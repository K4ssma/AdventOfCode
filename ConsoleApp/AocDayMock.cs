namespace Kassma.AdventOfCode.ConsoleApp;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Mock for the <see cref="IAocDay"/>-interface in order to test the app with a dummy solver.
/// </summary>
internal sealed class AocDayMock : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = "Initialization",
            StatusPercent = 0,
        });

        Thread.Sleep(200);

        progress.Report(new()
        {
            IsHeadStatus = false,
            StatusMessage = "First sub status",
            StatusPercent = 50,
        });

        Thread.Sleep(300);

        var random = new Random();
        var maxSubTask = random.Next(5, 13);

        progress.Report(new()
        {
            IsHeadStatus = true,
            StatusMessage = $"Main part with {maxSubTask} sub tasks",
            StatusPercent = 0,
        });

        for (var i = 0; i < maxSubTask; i++)
        {
            Thread.Sleep(random.Next(1500));

            progress.Report(new()
            {
                IsHeadStatus = false,
                StatusMessage = $"Stage {i}",
                StatusPercent = (byte)(i * 100 / maxSubTask),
            });
        }

        return "Mock solution";
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        throw new NotImplementedException();
    }
}
