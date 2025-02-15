namespace AdventOfCode.AoC2015.Day05;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks { get; } = new()
    {
        { 1, (string inputString) => Task01.RunTask(inputString.Split("\n")) },
        { 2, (string inputString) => Task02.RunTask(inputString.Split("\n")) },
    };
}
