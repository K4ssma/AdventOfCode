namespace AdventOfCode.AoC2015.Day17;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    private const ushort EggnogAmount = 150;

    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, (string inputString) => (int)Task01.RunTask(EggnogAmount, InputConverter.Convert(inputString)) },
    };
}
