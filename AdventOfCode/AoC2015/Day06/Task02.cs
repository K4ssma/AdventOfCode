namespace AdventOfCode.AoC2015.Day06;

internal static class Task02
{
    public static int RunTask((InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[] instructions)
    {
        int totalBrightness = 0;

        int[,] grid = new int[1000, 1000];

        foreach ((InstructionType type, Vector2Int posOne, Vector2Int posTwo) in instructions)
        {
            for (int x = Math.Min(posOne.X, posTwo.X); x <= Math.Max(posOne.X, posTwo.X); x++)
            {
                for (int y = Math.Min(posOne.Y, posTwo.Y); y <= Math.Max(posOne.Y, posTwo.Y); y++)
                {
                    switch (type)
                    {
                        case InstructionType.On:
                        {
                            totalBrightness++;
                            grid[x, y]++;
                            break;
                        }

                        case InstructionType.Off:
                        {
                            grid[x, y]--;

                            if (grid[x, y] < 0)
                            {
                                grid[x, y] = 0;
                            }
                            else
                            {
                                totalBrightness--;
                            }

                            break;
                        }

                        case InstructionType.Toggle:
                        {
                            totalBrightness += 2;
                            grid[x, y] += 2;
                            break;
                        }

                        default:
                        {
                            throw new NotImplementedException($"instruction type '{type}' is not supported");
                        }
                    }
                }
            }
        }

        return totalBrightness;
    }
}
