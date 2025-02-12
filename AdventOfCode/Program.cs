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

            int? result = await yearHandler.RunYear();

            if (!result.HasValue)
            {
                return;
            }

            Console.WriteLine($"\r\nThe result is:");
            Console.WriteLine(result.Value);
        }
    }
}