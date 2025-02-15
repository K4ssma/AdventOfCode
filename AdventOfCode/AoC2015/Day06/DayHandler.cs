namespace AdventOfCode.AoC2015.Day06;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks { get; } = new()
    {
        { 1, (string inputString) => Task01.RunTask(InputConverter.Convert(inputString)) },
    };
}
