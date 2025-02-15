namespace AdventOfCode;

using System;
using AdventOfCode.AoC2015;
using Microsoft.Extensions.Configuration;

public static class Program
{
    private static readonly Dictionary<int, IYearHandler> AvailableYears = new()
    {
        { 2015, new YearHandler() },
    };

    public static async Task Main()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettinfs.json")
            .AddUserSecrets<Dummy>()
            .Build();

        string exitCode = config["AppSettings:ExitCode"]
            ?? throw new ArgumentException("'ExitCode' entry in the congig is empty");

        while (true)
        {
            int? yearNum = ReadIntChoice(
                [.. AvailableYears.Keys], "Please enter the year of Advent of Code you would like to run", exitCode);

            if (yearNum == null)
            {
                return;
            }

            IYearHandler yearHandler = AvailableYears[yearNum.Value];

            int? dayNum = ReadIntChoice(
                [.. yearHandler.AvailableDays.Keys],
                "Please enter the number of the day you would like to run",
                exitCode);

            if (dayNum == null)
            {
                return;
            }

            IDayHandler dayHandler = yearHandler.AvailableDays[dayNum.Value];

            int? taskNum = ReadIntChoice(
                [.. dayHandler.AvailableTasks.Keys],
                "Please enter the number of the task you would like to run",
                exitCode);

            if (taskNum == null)
            {
                return;
            }

            string sessionCookie = config["SessionCookie"]
            ?? throw new ArgumentException("'SessionCookie' entry in the config is empty");

            string url = config["AppSettings:AdventOfCodeUrl"]
                ?? throw new ArgumentException("'AdventOfCodeUrl' entry in the config is empty");

            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");

            string inputString = await client.GetStringAsync(url + $"/{yearNum}/day/{dayNum}/input");

            int result = dayHandler.AvailableTasks[taskNum.Value](inputString);

            Console.WriteLine($"\r\nThe result is:");
            Console.WriteLine($"{result}\r\n");
        }
    }

    /// <summary>
    /// prints the input prompt and the available options to the console and lets him choose one of them.
    /// continues to ask for an answer when no valid option got chosen
    /// </summary>
    /// <param name="options">
    /// the available valid options to choose from
    /// </param>
    /// <param name="inputPrompt">
    /// the prompt that gets printed to the console as information for the user
    /// </param>
    /// <returns>
    /// <para><c>null</c> user entered in the config defined exit code</para>
    /// <para><c>int</c> theoption from the pool the user chose</para>
    /// </returns>
    /// <exception cref="ArgumentException">
    /// 'ExitCode' entry in the config is empty
    /// </exception>
    private static int? ReadIntChoice(int[] options, string inputPrompt, string exitCode)
    {
        while (true)
        {
            Console.WriteLine(inputPrompt);
            Console.WriteLine("You can choose one of the following numbers.");

            Console.Write('[');

            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(options[i]);

                if (i < options.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine(']');

            string inputString = Console.ReadLine()!;

            if (inputString.Equals(exitCode))
            {
                return null;
            }

            if (!int.TryParse(inputString, out int choice))
            {
                Console.WriteLine("Invalid input! Please try again.\r\n");
                continue;
            }

            if (!options.Contains(choice))
            {
                Console.WriteLine("Your choice is not part of the valid options! Please try again.\r\n");
                continue;
            }

            return choice;
        }
    }

    private sealed class Dummy
    {
    }
}