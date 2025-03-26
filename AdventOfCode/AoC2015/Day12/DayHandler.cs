namespace AdventOfCode.AoC2015.Day12;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, Task01.RunTask },
        { 2, Task02.RunTask },
    };
}
