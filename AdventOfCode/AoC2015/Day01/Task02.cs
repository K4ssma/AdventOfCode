namespace AdventOfCode.AoC2015.Day01;

internal static class Task02
{
    public static int RunTask(string inputString)
    {
        int floorNum = 0;

        for (int i = 0; i < inputString.Length; i++)
        {
            switch (inputString[i])
            {
                case '(':
                {
                    floorNum++;
                    break;
                }

                case ')':
                {
                    floorNum--;
                    break;
                }

                default:
                {
                    throw new FormatException($"invalid char '{inputString[i]}' occured at position {i}");
                }
            }

            if (floorNum < 0)
            {
                return i + 1;
            }
        }

        throw new ArgumentException($"there is no solution for the input {inputString}");
    }
}
