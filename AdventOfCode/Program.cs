namespace AdventOfCode;

using System;

public static class Program
{
    public static async Task Main()
    {
        while (true)
        {
            int? yearNum = UserInputUtility.ReadIntChoice(
                [], "Please enter the year of Advent of Code you would like to run");

            if (yearNum == null)
            {
                return;
            }

            IYearHandler yearHandler;

            switch (yearNum)
            {
                default:
                {
                    throw new NotImplementedException($"year '{yearNum}' is not yet supported");
                }
            }

            if (!(await yearHandler.RunYear()))
            {
                return;
            }
        }
    }
}