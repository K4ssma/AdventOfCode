namespace AdventOfCode.AoC2015.Day12;

internal static class Task02
{
    public static int RunTask(string inputString)
    {
        inputString = inputString.Trim();

        if (inputString == string.Empty)
        {
            return 0;
        }

        if (inputString[0] != '{'
            && inputString[0] != '[')
        {
            throw new FormatException(
                "The provided string is not a valid json object. It needs to start with '{' or '['");
        }

        Stack<(List<int> Nums, bool IsObject)> hirachyStack = [];
        int? currNumber = null;
        bool numIsNegative = false;

        bool lvlIsAbondend = false;
        int abondendLvls = 0;

        for (int i = 0; i < inputString.Length; i++)
        {
            if (lvlIsAbondend)
            {
                if (inputString[i] == '{'
                    || inputString[i] == '[')
                {
                    abondendLvls++;
                    continue;
                }

                if (inputString[i] != '}'
                    && inputString[i] != ']')
                {
                    continue;
                }

                if (abondendLvls > 0)
                {
                    abondendLvls--;
                    continue;
                }

                hirachyStack.Pop();
                lvlIsAbondend = false;
                continue;
            }

            if (int.TryParse(inputString[i].ToString(), out int currDigit))
            {
                currNumber = currNumber == null
                    ? currDigit
                    : (currNumber * 10) + currDigit;
                continue;
            }

            if (currNumber != null)
            {
                if (numIsNegative)
                {
                    currNumber *= -1;
                    numIsNegative = false;
                }

                hirachyStack.Peek().Nums.Add(currNumber.Value);
                currNumber = null;
            }

            if (inputString[i] == '{')
            {
                hirachyStack.Push(([], true));
                continue;
            }

            if (inputString[i] == '[')
            {
                hirachyStack.Push(([], false));
                continue;
            }

            if (inputString[i] == '}'
                || inputString[i] == ']')
            {
                int lvlSum = hirachyStack.Pop().Nums.Sum();

                if (hirachyStack.Count == 0)
                {
                    return lvlSum;
                }

                hirachyStack.Peek().Nums.Add(lvlSum);
                continue;
            }

            if (inputString[i] == '-')
            {
                numIsNegative = true;
                continue;
            }

            if (hirachyStack.Peek().IsObject
                && i < inputString.Length - 2
                && char.ToLower(inputString[i]) == 'r'
                && char.ToLower(inputString[i + 1]) == 'e'
                && char.ToLower(inputString[i + 2]) == 'd')
            {
                lvlIsAbondend = true;
                continue;
            }
        }

        // only happens if first lvl is abondend
        return 0;
    }
}
