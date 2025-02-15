namespace AdventOfCode.AoC2015.Day06;

using System.Text.RegularExpressions;

internal static class InputConverter
{
    public static (InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[] Convert(string inputString)
    {
        Regex numberRegex = new(@"\s(\d+),(\d+)\s.*\s(\d+),(\d+)", RegexOptions.Compiled);

        return inputString
            .Split("\n")
            .Select((string instructionString) =>
            {
                InstructionType type;

                if (instructionString.StartsWith("turn on"))
                {
                    type = InstructionType.On;
                }
                else if (instructionString.StartsWith("turn off"))
                {
                    type = InstructionType.Off;
                }
                else if (instructionString.StartsWith("toggle"))
                {
                    type = InstructionType.Toogle;
                }
                else
                {
                    throw new FormatException($"invalid instruction type: '{instructionString}'");
                }

                Match match = numberRegex.Match(instructionString);

                if (!match.Success)
                {
                    throw new FormatException($"unable to find numbers in instruction string: '{instructionString}'");
                }

                Vector2Int posOne = new()
                {
                    X = int.Parse(match.Groups[1].Value),
                    Y = int.Parse(match.Groups[2].Value),
                };

                Vector2Int posTwo = new()
                {
                    X = int.Parse(match.Groups[3].Value),
                    Y = int.Parse(match.Groups[4].Value),
                };

                return (type, posOne, posTwo);
            })
            .ToArray();
    }
}
