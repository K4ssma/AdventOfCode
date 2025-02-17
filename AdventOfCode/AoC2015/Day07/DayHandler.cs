namespace AdventOfCode.AoC2015.Day07;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks { get; } = new()
    {
        { 1, (string inputString) => Task01.RunTask(InputConverter.Convert(inputString), "a") },
        { 2, Task02.RunTask },
    };
}
