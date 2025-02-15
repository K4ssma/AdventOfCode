namespace AdventOfCode.AoC2015.Day01;

internal static class Task01
{
    public static int RunTask(string inputString)
    {
        int floorNum = 0;

        foreach (char c in inputString)
        {
            switch (c)
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
                    throw new FormatException($"invalid char '{c}' occured");
                }
            }
        }

        return floorNum;
    }
}
