namespace AdventOfCode.AoC2015.Day05;

internal static class Task02
{
    public static int RunTask(string[] inputStrings)
    {
        int niceStringCount = 0;

        foreach (string str in inputStrings)
        {
            bool hasSameNotOverlapPairs = false;
            bool hasCharBetweenSameChars = false;

            Dictionary<string, List<int>> charPairs = [];

            for (int i = 1; i < str.Length; i++)
            {
                if (i >= 2
                    && str[i] != str[i - 1]
                    && str[i] == str[i - 2])
                {
                    hasCharBetweenSameChars = true;
                }

                string currPair = new([str[i - 1], str[i]]);

                if (charPairs.TryAdd(currPair, [i]))
                {
                    continue;
                }

                charPairs[currPair].Add(i);

                foreach (int pairEndIndex in charPairs[currPair])
                {
                    if (pairEndIndex < i - 1)
                    {
                        hasSameNotOverlapPairs = true;
                        break;
                    }
                }
            }

            if (hasSameNotOverlapPairs
                && hasCharBetweenSameChars)
            {
                niceStringCount++;
            }
        }

        return niceStringCount;
    }
}
