namespace AdventOfCode.AoC2015.Door02;

internal static class Task02
{
    public static int RunTask(int[,] dimensions)
    {
        int ribbonLength = 0;

        for (int i = 0; i < dimensions.GetLength(0); i++)
        {
            int smallSideOne = Math.Min(dimensions[i, 0], dimensions[i, 1]);
            int smallSideTwo = Math.Min(Math.Max(dimensions[i, 0], dimensions[i, 1]), dimensions[i, 2]);

            ribbonLength += (2 * smallSideOne) + (2 * smallSideTwo);

            // bow length
            ribbonLength += dimensions[i, 0] * dimensions[i, 1] * dimensions[i, 2];
        }

        return ribbonLength;
    }
}
