namespace AdventOfCode.AoC2015.Day16;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    private static Dictionary<string, byte> TargetAunt => new()
    {
        { "children", 3 },
        { "cats", 7 },
        { "samoyeds", 2 },
        { "pomeranians", 3 },
        { "akitas", 0 },
        { "vizslas", 0 },
        { "goldfish", 5 },
        { "trees", 3 },
        { "cars", 2 },
        { "perfumes", 1 },
    };

    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, (string inputString) => (int)Task01.RunTask(TargetAunt, InputConverter.Convert(inputString))! },
    };
}
