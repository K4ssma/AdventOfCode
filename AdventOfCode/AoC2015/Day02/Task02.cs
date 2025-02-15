namespace AdventOfCode.AoC2015.Day02;

internal static class Task02
{
    public static int RunTask(int[,] equations)
    {
        int ribbonLength = 0;

        for (int i = 0; i < equations.GetLength(0); i++)
        {
            int smallSideOne = Math.Min(equations[i, 0], equations[i, 1]);
            int smallSideTwo = Math.Min(Math.Max(equations[i, 0], equations[i, 1]), equations[i, 2]);

            ribbonLength += (2 * smallSideOne) + (2 * smallSideTwo);

            // bow length
            ribbonLength += equations[i, 0] * equations[i, 1] * equations[i, 2];
        }

        return ribbonLength;
    }
}
