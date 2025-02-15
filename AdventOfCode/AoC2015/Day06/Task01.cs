namespace AdventOfCode.AoC2015.Day06;

internal static class Task01
{
    public static int RunTask((InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[] instructions)
    {
        bool[,] grid = new bool[1000, 1000];

        int activeLightCount = 0;

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
                            if (!grid[x, y])
                            {
                                activeLightCount++;
                            }

                            grid[x, y] = true;
                            break;
                        }

                        case InstructionType.Off:
                        {
                            if (grid[x, y])
                            {
                                activeLightCount--;
                            }

                            grid[x, y] = false;
                            break;
                        }

                        case InstructionType.Toogle:
                        {
                            if (grid[x, y])
                            {
                                activeLightCount--;
                            }
                            else
                            {
                                activeLightCount++;
                            }

                            grid[x, y] = !grid[x, y];
                            break;
                        }

                        default:
                        {
                            throw new NotImplementedException(
                                $"instruction type '{type}' is not supported for this task");
                        }
                    }
                }
            }
        }

        return activeLightCount;
    }
}
