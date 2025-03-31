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

    private static (Func<byte, byte, bool> CompareFunc, HashSet<string> TargetedProps)[] RuleSet =>
    [
        ((byte targetValue, byte analysisValue) => targetValue < analysisValue, ["cats", "trees"]),
        ((byte targetValue, byte analysisValue) => targetValue > analysisValue, ["pomeranians", "goldfish"]),
    ];

    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        { 1, (string inputString) => (int)Task01.RunTask(TargetAunt, InputConverter.Convert(inputString))! },
        { 2, (string inputString) => (int)Task02.RunTask(TargetAunt, InputConverter.Convert(inputString), RuleSet)! },
    };
}
