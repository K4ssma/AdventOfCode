namespace AdventOfCode.AoC2015.Door02;

internal static class Task01
{
    public static int RunTask(int[,] equations)
    {
        int paperAmount = 0;

        for (int i = 0; i < equations.GetLength(0); i++)
        {
            int[] sideAreas =
            {
                equations[i, 0] * equations[i, 1],
                equations[i, 1] * equations[i, 2],
                equations[i, 2] * equations[i, 0],
            };

            foreach (int area in sideAreas)
            {
                paperAmount += 2 * area;
            }

            paperAmount += Math.Min(Math.Min(sideAreas[0], sideAreas[1]), sideAreas[2]);
        }

        return paperAmount;
    }
}
