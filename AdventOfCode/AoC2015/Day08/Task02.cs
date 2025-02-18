namespace AdventOfCode.AoC2015.Day08;

internal static class Task02
{
    public static int RunTask(string inputString)
    {
        return inputString
            .Split("\n")
            .Where((string str) => str != string.Empty)
            .Select((string str) =>
            {
                int codeSize = str.Length + 2;

                foreach (char c in str)
                {
                    if (c == '\\'
                        || c == '"')
                    {
                        codeSize++;
                    }
                }

                return codeSize - str.Length;
            })
            .Aggregate((int curr, int next) => curr + next);
    }
}
