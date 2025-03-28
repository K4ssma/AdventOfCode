namespace AdventOfCode.AoC2015.Day15;

using System.Text.RegularExpressions;

internal static class InputConverter
{
    public static IEnumerable<(int Capacity, int Durability, int Flavor, int Texture, int Calories)>
        Convert(string inputString)
    {
        Regex regex = new(
            @"^\w+:\scapacity\s(?<capacity>(-)?\d+),\sdurability\s(?<durability>(-)?\d+),\sflavor\s(?<flavor>(-)?\d+),\stexture\s(?<texture>(-)?\d+),\scalories\s(?<calories>(-)?\d+)$",
            RegexOptions.Compiled);

        return inputString
            .Trim()
            .Split('\n')
            .Select((string line) =>
            {
                Match match = regex.Match(line.Trim());

                if (!match.Success)
                {
                    throw new FormatException($"the line '{line}' does not have the right format for conversion");
                }

                return (int.Parse(match.Groups["capacity"].Value),
                    int.Parse(match.Groups["durability"].Value),
                    int.Parse(match.Groups["flavor"].Value),
                    int.Parse(match.Groups["texture"].Value),
                    int.Parse(match.Groups["calories"].Value));
            });
    }
}
