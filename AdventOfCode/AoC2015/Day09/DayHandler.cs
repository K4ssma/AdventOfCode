namespace AdventOfCode.AoC2015.Day09;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks { get; } = new()
    {
        { 1, (string inputString) => Task01.RunTask(InputConverter.Convert(inputString)) },
        { 2, (string inputString) => Task02.RunTask(InputConverter.Convert(inputString)) },
    };
}
