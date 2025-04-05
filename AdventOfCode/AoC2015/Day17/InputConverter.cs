namespace AdventOfCode.AoC2015.Day17;

internal static class InputConverter
{
    public static ushort[] Convert(string inputString)
    {
        return inputString
            .Trim()
            .Split('\n')
            .Select((string line) =>
            {
                return ushort.TryParse(line.Trim(), out ushort value)
                    ? value
                    : throw new FormatException($"unable to convert line '{line}' to an ushort");
            })
            .ToArray();
    }
}
