namespace AdventOfCode;

using System;
using Microsoft.Extensions.Configuration;

public class Program
{
    private readonly IConfigurationRoot config;

    protected Program()
    {
        this.config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();
    }

    public async void Main()
    {
        string exitCode = this.config["AppSettings:ExitCode"]
            ?? throw new ArgumentException("there is not exit code defined in the app settings");

        Console.WriteLine($"In order to end this program you can always enter '{exitCode}'\r\n");

        string? sessionCookieSecret = config["SessionCookie"];

        string sessionCookie;

        if (sessionCookieSecret != null)
        {
            sessionCookie = sessionCookieSecret;
        }
        else
        {
            Console.WriteLine("Please enter a valid Session Id, so that this program is able to fetch the inputs");
            sessionCookie = Console.ReadLine()!;
        }

        while (true)
        {
            int? yearNum = UserInputUtility.ReadIntChoice(
                [], "Please enter the year of Advent of Code you would like to run", exitCode);

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

            if (!(await yearHandler.OpenDoor(sessionCookie)))
            {
                return;
            }
        }
    }
}