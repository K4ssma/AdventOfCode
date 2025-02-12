namespace AdventOfCode.AoC2015.Door02;

using System.Text.RegularExpressions;

internal static class InputConverter
{
    public static int[,] Convert(string inputString)
    {
        string[] equationStrings = inputString.Split("\r\n");

        int[,] equations = new int[equationStrings.Length, 3];

        Regex regex = new(@"(\d+)x(\d+)x(\d+)", RegexOptions.Compiled);

        for (int i = 0; i < equationStrings.Length; i++)
        {
            MatchCollection matches = regex.Matches(equationStrings[i]);

            if (!matches[0].Success)
            {
                throw new FormatException($"string on line index {i} is not in the correct format");
            }

            equations[i, 0] = int.Parse(matches[0].Groups[1].Value);
            equations[i, 1] = int.Parse(matches[0].Groups[2].Value);
            equations[i, 2] = int.Parse(matches[0].Groups[3].Value);
        }

        return equations;
    }
}
