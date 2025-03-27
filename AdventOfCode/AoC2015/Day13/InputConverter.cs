namespace AdventOfCode.AoC2015.Day13;

using System.Text.RegularExpressions;

internal static class InputConverter
{
    public static int[,] Convert(string inputString)
    {
        Dictionary<string, Dictionary<string, int>> happinessConnections = [];
        Dictionary<string, int> indexLookup = [];

        Regex regex = new(
            @"^(?<source>\w+)\swould\s(?<operator>gain|lose)\s(?<amount>\d+)\shappiness\sunits\sby\ssitting\snext\sto\s(?<target>\w+)\.$",
            RegexOptions.Compiled);

        foreach (string line in inputString.Trim().Split("\r\n"))
        {
            Match match = regex.Match(line);

            if (!match.Success)
            {
                throw new FormatException($"the line '{line}' is not in the right format");
            }

            if (!happinessConnections.TryGetValue(match.Groups["source"].Value, out Dictionary<string, int>? connection))
            {
                connection = [];
                happinessConnections.Add(match.Groups["source"].Value, connection);

                indexLookup.Add(match.Groups["source"].Value, indexLookup.Count);
            }

            int amount = int.Parse(match.Groups["amount"].Value);

            if (match.Groups["operator"].Value == "lose")
            {
                amount *= -1;
            }

            connection.Add(match.Groups["target"].Value, amount);
        }

        int[,] happinessMatrix = new int[happinessConnections.Count, happinessConnections.Count];

        foreach (KeyValuePair<string, Dictionary<string, int>> connections in happinessConnections)
        {
            foreach (KeyValuePair<string, int> connection in connections.Value)
            {
                happinessMatrix[indexLookup[connections.Key], indexLookup[connection.Key]] = connection.Value;
            }
        }

        return happinessMatrix;
    }
}
