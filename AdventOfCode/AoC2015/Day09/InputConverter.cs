namespace AdventOfCode.AoC2015.Day09;

using System.Text.RegularExpressions;

internal static partial class InputConverter
{
    public static int[,] Convert(string inputString)
    {
        string[] inputLines = inputString
            .Split("\n")
            .Where((string line) => line != string.Empty)
            .ToArray();

        /*
         * num of lines = all 2-combinations of the cities
         *
         * lines = (cityNum - 1) + (cityNum - 2) + ... + 1
         * or other way around:
         * lines =            1  +            2  + ... + (cityNum - 1)
         *
         * combine both:
         * 2 * lines = cityNum   + cityNum       + ... + cityNum
         *
         * cityNums are added cityNum - 1 times:
         * 2 * lines = cityNum * (cityNum - 1)
         * 2 * lines = cityNum^2 - cityNum      | -(2 * lines)
         * 0 = cityNum^2 - cityNum - (2 * lines)
         *
         * use pq-formula:
         * -(p/2) +- sqrt((p/2)^2 - q)
         * 1/2 +- sqrt((-1/2)^2 + (2 * lines))
        */

        int answerOne = (int)(0.5f + Math.Sqrt(0.25f + (inputLines.Length * 2)));
        int answerTwo = (int)(0.5f - Math.Sqrt(0.25f + (inputLines.Length * 2)));

        int cityCount = answerOne > 0
            ? answerOne
            : answerTwo;

        int[,] distanceMatrix = new int[cityCount, cityCount];

        Dictionary<string, int> indexLookup = [];

        Regex regex = new(@"^(\w+)\sto\s(\w+)\s=\s(\d+)$");

        foreach (string line in inputLines)
        {
            Match match = regex.Match(line);

            if (!match.Success)
            {
                throw new FormatException(
                    $"line '{line}' does not in the correct format '[cityName01] to [cityName02] = [distance]'");
            }

            if (!indexLookup.TryGetValue(match.Groups[1].Value, out int indexOne))
            {
                indexOne = indexLookup.Count;
                indexLookup.Add(match.Groups[1].Value, indexOne);
            }

            if (!indexLookup.TryGetValue(match.Groups[2].Value, out int indexTwo))
            {
                indexTwo = indexLookup.Count;
                indexLookup.Add(match.Groups[2].Value, indexTwo);
            }

            int distance = int.Parse(match.Groups[3].Value);

            distanceMatrix[indexOne, indexTwo] = distance;
            distanceMatrix[indexTwo, indexOne] = distance;
        }

        return distanceMatrix;
    }
}
