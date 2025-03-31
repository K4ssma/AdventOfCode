﻿namespace AdventOfCode.AoC2015;

using System.Collections.Generic;

using DayHandler01 = AdventOfCode.AoC2015.Day01.DayHandler;
using DayHandler02 = AdventOfCode.AoC2015.Day02.DayHandler;
using DayHandler03 = AdventOfCode.AoC2015.Day03.DayHandler;
using DayHandler04 = AdventOfCode.AoC2015.Day04.DayHandler;
using DayHandler05 = AdventOfCode.AoC2015.Day05.DayHandler;
using DayHandler06 = AdventOfCode.AoC2015.Day06.DayHandler;
using DayHandler07 = AdventOfCode.AoC2015.Day07.DayHandler;
using DayHandler08 = AdventOfCode.AoC2015.Day08.DayHandler;
using DayHandler09 = AdventOfCode.AoC2015.Day09.DayHandler;
using DayHandler10 = AdventOfCode.AoC2015.Day10.DayHandler;
using DayHandler11 = AdventOfCode.AoC2015.Day11.DayHandler;
using Dayhandler12 = AdventOfCode.AoC2015.Day12.DayHandler;
using DayHandler13 = AdventOfCode.AoC2015.Day13.DayHandler;
using DayHandler14 = AdventOfCode.AoC2015.Day14.DayHandler;
using DayHandler15 = AdventOfCode.AoC2015.Day15.DayHandler;
using DayHandler16 = AdventOfCode.AoC2015.Day16.DayHandler;
using DayHandler17 = AdventOfCode.AoC2015.Day17.DayHandler;

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
        { 8, new DayHandler08() },
        { 9, new DayHandler09() },
        { 10, new DayHandler10() },
        { 11, new DayHandler11() },
        { 12, new Dayhandler12() },
        { 13, new DayHandler13() },
        { 14, new DayHandler14() },
        { 15, new DayHandler15() },
        { 16, new DayHandler16() },
        { 17, new DayHandler17() },
    };
}
