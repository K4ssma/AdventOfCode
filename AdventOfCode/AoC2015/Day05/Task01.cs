namespace AdventOfCode.AoC2015.Day05;

internal static class Task01
{
    private static readonly char[] Vowels = ['a', 'e', 'i', 'o', 'u'];
    private static readonly string[] NaughtyStringParts = ["ab", "cd", "pq", "xy"];

    public static int RunTask(string[] inputStrings)
    {
        int niceStringCount = 0;

        foreach (string str in inputStrings)
        {
            int vowelCount = 0;
            bool hasDoubleLetter = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (Vowels.Contains(str[i]))
                {
                    vowelCount++;
                }

                if (i <= 0)
                {
                    continue;
                }

                if (NaughtyStringParts.Contains(new string([str[i - 1], str[i]])))
                {
                    hasDoubleLetter = false;
                    break;
                }

                if (str[i - 1] == str[i])
                {
                    hasDoubleLetter = true;
                }
            }

            if (vowelCount >= 3 && hasDoubleLetter)
            {
                niceStringCount++;
            }
        }

        return niceStringCount;
    }
}
