namespace AdventOfCode.AoC2015.Day03;

internal static class Task01
{
    public static int RunTask(string instructionString)
    {
        int x = 0;
        int y = 0;

        HashSet<(int X, int Y)> visitedHouses = [(0, 0)];

        foreach (char c in instructionString)
        {
            switch (c)
            {
                case '^':
                {
                    y++;
                    break;
                }

                case '>':
                {
                    x++;
                    break;
                }

                case 'v':
                {
                    y--;
                    break;
                }

                case '<':
                {
                    x--;
                    break;
                }

                default:
                {
                    throw new FormatException($"invalid character '{c}' occured");
                }
            }

            visitedHouses.Add((x, y));
        }

        return visitedHouses.Count;
    }
}
