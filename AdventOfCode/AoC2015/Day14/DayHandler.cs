namespace AdventOfCode.AoC2015.Day14;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, (string inputString) => Task01.RunTask(InputConverter.Convert(inputString), 2503) },
        { 2, (string inputString) => Task02.RunTask(InputConverter.Convert(inputString).ToArray(), 2503) },
    };
}
