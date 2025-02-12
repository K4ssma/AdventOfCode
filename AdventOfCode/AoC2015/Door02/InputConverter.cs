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

            equations[i, 0] = int.Parse(matches[0].Groups[0].Value);
            equations[i, 1] = int.Parse(matches[0].Groups[1].Value);
            equations[i, 2] = int.Parse(matches[0].Groups[2].Value);
        }

        return equations;
    }
}
