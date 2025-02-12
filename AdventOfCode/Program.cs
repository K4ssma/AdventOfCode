namespace AdventOfCode;

using System;
using AdventOfCode.AoC2015;

public static class Program
{
    public static async Task Main()
    {
        while (true)
        {
            int? yearNum = UserInputUtility.ReadIntChoice(
                [2015], "Please enter the year of Advent of Code you would like to run");

            if (yearNum == null)
            {
                return;
            }

            IYearHandler yearHandler;

            switch (yearNum)
            {
                case 2015:
                {
                    yearHandler = new Year2015Handler();
                    break;
                }

                default:
                {
                    throw new NotImplementedException($"year '{yearNum}' is not yet supported");
                }
            }

            int? result = await yearHandler.RunYear();

            if (!result.HasValue)
            {
                return;
            }

            Console.WriteLine($"\r\nThe result is:");
            Console.WriteLine($"{result.Value}\r\n");
        }
    }
}