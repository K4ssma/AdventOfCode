﻿namespace AdventOfCode.AoC2015.Day08;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks { get; } = new()
    {
        { 1, Task01.RunTask },
    };
}
