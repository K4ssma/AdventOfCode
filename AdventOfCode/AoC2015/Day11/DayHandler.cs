namespace AdventOfCode.AoC2015.Day11;

using System;
using System.Collections.Generic;

internal class DayHandler : IDayHandler
{
    public Dictionary<int, Func<string, int>> AvailableTasks => new()
    {
        {
            1,
            (string inputString) =>
            {
                Console.WriteLine(Task01.RunTask(inputString));
                return 0;
            }
        },
        {
            2,
            (string inputString) =>
            {
                Console.WriteLine(Task01.RunTask(Task01.RunTask(inputString)));
                return 0;
            }
        },
    };
}
