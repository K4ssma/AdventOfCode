namespace AdventOfCode.AoC2015.Day18;

internal static class InputConverter
{
    public static bool[,] Convert(string inputString)
    {
        var lines = inputString
            .Trim()
            .Split('\n')
            .Select((line) => line.Trim())
            .ToArray();

        if (lines.Length == 0
            || lines[0].Length == 0)
        {
            throw new FormatException("unable to convert input string to grid");
        }

        var grid = new bool[lines[0].Length, lines.Length];

        for (var y = 0; y < lines.Length; y++)
        {
            if (lines[y].Length != lines[0].Length)
            {
                throw new FormatException($"line {y} ({lines}) has a different length");
            }

            for (var x = 0; x < lines[0].Length; x++)
            {
                if (lines[y][x] == '#')
                {
                    grid[y, x] = true;
                }
                else if (lines[y][x] != '.')
                {
                    throw new ArgumentException($"invalid char '{lines[y][x]}' in line '{y}'");
                }
            }
        }

        return grid;
    }
}
