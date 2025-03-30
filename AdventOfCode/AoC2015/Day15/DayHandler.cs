namespace AdventOfCode.AoC2015.Day15;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, (string inputString) => (int)Task01.RunTask(InputConverter.Convert(inputString).ToArray()) },
    };
}
