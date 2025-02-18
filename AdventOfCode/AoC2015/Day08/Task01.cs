namespace AdventOfCode.AoC2015.Day08;

using System.Text.RegularExpressions;

internal static class Task01
{
    private static readonly char[] EscapeableChars = ['\\', '"'];

    private static readonly (Regex Regex, int Length)[] EscapeablePatterns =
    {
        (new Regex(@"x[a-fA-F0-9]{2}", RegexOptions.Compiled), 3),
    };

    public static int RunTask(string inputString)
    {
        return inputString
            .Split("\n")
            .Where((string str) => str != string.Empty)
            .Select((string str) =>
            {
                if (str.Length < 2
                    || str[0] != '"'
                    || str[^1] != '"')
                {
                    throw new FormatException($"character sequence '{str}' doesn't start or end with '\"'");
                }

                ReadOnlySpan<char> cutStr = str.AsSpan(1, str.Length - 2);

                int memorySize = str.Length - 2;

                bool isEscaping = false;
                int needsToJumpAmount = 0;

                for (int i = 0; i < cutStr.Length; i++)
                {
                    if (needsToJumpAmount > 0)
                    {
                        needsToJumpAmount--;
                        continue;
                    }

                    if (!isEscaping)
                    {
                        if (cutStr[i] == '\\')
                        {
                            isEscaping = true;
                        }
                        else if (EscapeableChars.Contains(cutStr[i]))
                        {
                            throw new FormatException(
                                $"char '{cutStr[i]}' in '{str}' can't be used without being escaped first");
                        }

                        continue;
                    }

                    if (EscapeableChars.Contains(cutStr[i]))
                    {
                        memorySize--;
                        isEscaping = false;
                        continue;
                    }

                    bool foundPattern = false;

                    foreach ((Regex regex, int length) in EscapeablePatterns)
                    {
                        if (i + length - 1 >= cutStr.Length
                            || !regex.IsMatch(new ReadOnlySpan<char>(cutStr.ToArray(), i, length)))
                        {
                            continue;
                        }

                        memorySize -= length;
                        isEscaping = false;
                        foundPattern = true;
                        needsToJumpAmount += length - 1;
                        break;
                    }

                    if (!foundPattern)
                    {
                        throw new InvalidOperationException(
                            $"there was no valid char or pattern found to be escaped in '{str}'");
                    }
                }

                return str.Length - memorySize;
            })
            .Aggregate((int curr, int next) => curr + next);
    }
}
