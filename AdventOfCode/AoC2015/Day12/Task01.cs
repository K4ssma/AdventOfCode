namespace AdventOfCode.AoC2015.Day12;

using System.Text.RegularExpressions;

internal static class Task01
{
    public static int RunTask(string inputString)
    {
        Regex regex = new(@"-?\d+");
        MatchCollection matches = regex.Matches(inputString);

        return matches.Count == 0
            ? 0
            : matches
                .Select((Match match) => int.Parse(match.Value))
                .Aggregate((int curr, int next) => curr + next);
    }
}
