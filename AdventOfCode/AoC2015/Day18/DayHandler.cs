namespace AdventOfCode.AoC2015.Day18;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    private const uint Steps = 100u;

    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, (inputString) => (int)Task01.RunTask(InputConverter.Convert(inputString), Steps) },
        { 2, (inputString) => (int)Task02.RunTask(InputConverter.Convert(inputString), Steps) },
    };
}
