namespace AdventOfCode.AoC2015.Day10;

using System.Text;
using System.Text.RegularExpressions;

internal static class Task01
{
    public static int RunTask(string inputString, int iterations)
    {
        inputString = inputString.Trim();

        if (inputString == string.Empty)
        {
            return 0;
        }

        Regex regex = new(@"^\d+$");

        if (!regex.IsMatch(inputString))
        {
            throw new ArgumentException($"the provided string '{inputString}' must contain only numbers");
        }

        if (iterations == 0)
        {
            return inputString.Length;
        }

        for (int i = 0; i < iterations; i++)
        {
            StringBuilder builder = new();

            char currChar = inputString[0];
            int count = 1;

            for (int j = 1; j < inputString.Length; j++)
            {
                if (inputString[j] == currChar)
                {
                    count++;
                    continue;
                }

                builder.Append(count);
                builder.Append(currChar);
                currChar = inputString[j];
                count = 1;
            }

            builder.Append(count);
            builder.Append(currChar);

            inputString = builder.ToString();
        }

        return inputString.Length;
    }
}
