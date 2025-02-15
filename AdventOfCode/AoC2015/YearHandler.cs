﻿namespace AdventOfCode.AoC2015;

using System.Collections.Generic;

using DayHandler01 = AdventOfCode.AoC2015.Day01.DayHandler;
using DayHandler02 = AdventOfCode.AoC2015.Day02.DayHandler;
using DayHandler03 = AdventOfCode.AoC2015.Day03.DayHandler;
using DayHandler04 = AdventOfCode.AoC2015.Day04.DayHandler;
using DayHandler05 = AdventOfCode.AoC2015.Day05.DayHandler;
using DayHandler06 = AdventOfCode.AoC2015.Day06.DayHandler;
using DayHandler07 = AdventOfCode.AoC2015.Day07.DayHandler;

public class YearHandler : IYearHandler
{
    public Dictionary<int, IDayHandler> AvailableDays { get; } = new()
    {
        { 1, new DayHandler01() },
        { 2, new DayHandler02() },
        { 3, new DayHandler03() },
        { 4, new DayHandler04() },
        { 5, new DayHandler05() },
        { 6, new DayHandler06() },
        { 7, new DayHandler07() },
    };
}
