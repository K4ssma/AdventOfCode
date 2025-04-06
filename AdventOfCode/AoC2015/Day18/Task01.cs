namespace AdventOfCode.AoC2015.Day18;

internal static class Task01
{
    public static uint RunTask(bool[,] grid, uint steps)
    {
        for (var i = 0u; i < steps; i++)
        {
            var nextGrid = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (var y = 0; y < grid.GetLength(0); y++)
            {
                for (var x = 0; x < grid.GetLength(1); x++)
                {
                    var glowingNeighbourCount = 0;

                    if (y != 0)
                    {
                        glowingNeighbourCount += grid[y - 1, x] ? 1 : 0;

                        if (x != 0)
                        {
                            glowingNeighbourCount += grid[y - 1, x - 1] ? 1 : 0;
                        }

                        if (x < grid.GetLength(1) - 1)
                        {
                            glowingNeighbourCount += grid[y - 1, x + 1] ? 1 : 0;
                        }
                    }

                    if (y < grid.GetLength(0) - 1)
                    {
                        glowingNeighbourCount += grid[y + 1, x] ? 1 : 0;

                        if (x != 0)
                        {
                            glowingNeighbourCount += grid[y + 1, x - 1] ? 1 : 0;
                        }

                        if (x < grid.GetLength(1) - 1)
                        {
                            glowingNeighbourCount += grid[y + 1, x + 1] ? 1 : 0;
                        }
                    }

                    if (x != 0)
                    {
                        glowingNeighbourCount += grid[y, x - 1] ? 1 : 0;
                    }

                    if (x < grid.GetLength(1) - 1)
                    {
                        glowingNeighbourCount += grid[y, x + 1] ? 1 : 0;
                    }

                    if ((grid[y, x]
                            && (glowingNeighbourCount == 2
                                || glowingNeighbourCount == 3))
                        || (!grid[y, x]
                            && glowingNeighbourCount == 3))
                    {
                        nextGrid[y, x] = true;
                    }
                }
            }

            grid = nextGrid;
        }

        var lightCount = 0u;

        foreach (var light in grid)
        {
            if (light)
            {
                lightCount++;
            }
        }

        return lightCount;
    }
}
