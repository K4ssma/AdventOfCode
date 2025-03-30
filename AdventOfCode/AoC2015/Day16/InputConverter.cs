namespace AdventOfCode.AoC2015.Day16;

using System.Text.RegularExpressions;

internal static class InputConverter
{
    public static Dictionary<string, byte>[] Convert(string inputString)
    {
        Dictionary<string, Regex> regexes = new Dictionary<string, Regex>
        {
            { "children", new(@"children:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "cats", new(@"cats:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "samoyeds", new(@"samoyeds:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "pomeranians", new(@"pomeranians:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "akitas", new(@"akitas:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "vizslas", new(@"vizslas:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "goldfish", new(@"goldfish:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "trees", new(@"trees:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "cars", new(@"cars:\s(?<count>\d+)", RegexOptions.Compiled) },
            { "perfumes", new(@"perfumes:\s(?<count>\d+)", RegexOptions.Compiled) },
        };

        return inputString
            .Trim()
            .Split('\n')
            .Select((string line) =>
            {
                Dictionary<string, byte> properties = new();

                foreach ((string propertyName, Regex regex) in regexes)
                {
                    Match match = regex.Match(line);

                    if (!match.Success)
                    {
                        continue;
                    }

                    properties.Add(propertyName, byte.Parse(match.Groups["count"].Value));
                }

                return properties;
            })
            .ToArray();
    }
}
