namespace AdventOfCode.AoC2015.Day14;

using System.Text.RegularExpressions;

internal static class InputConverter
{
    public static IEnumerable<(uint Speed, uint FlightTime, uint RestingTime)> Convert(string inputString)
    {
        Regex regex = new(
            @"^\w+\scan\sfly\s(?<speed>\d+)\skm/s\sfor\s(?<flightTime>\d+)\sseconds,\sbut\sthen\smust\srest\sfor\s(?<restTime>\d+)\sseconds\.$",
            RegexOptions.Compiled);

        foreach (string line in inputString.Trim().Split('\n'))
        {
            Match match = regex.Match(line.Trim());

            yield return match.Success
                ? ((uint Speed, uint FlightTime, uint RestingTime))(
                uint.Parse(match.Groups["speed"].Value),
                uint.Parse(match.Groups["flightTime"].Value),
                uint.Parse(match.Groups["restTime"].Value))
                : throw new FormatException($"the line '${line}' is not in the right format for conversion");
        }
    }
}
