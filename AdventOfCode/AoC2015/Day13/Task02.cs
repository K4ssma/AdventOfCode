namespace AdventOfCode.AoC2015.Day13;

internal static class Task02
{
    public static int RunTask(int[,] happinessMatrix)
    {
        int[,] extendetMatrix = new int[happinessMatrix.GetLength(0) + 1, happinessMatrix.GetLength(1) + 1];

        for (int i = 0; i < happinessMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < happinessMatrix.GetLength(1); j++)
            {
                extendetMatrix[i, j] = happinessMatrix[i, j];
            }
        }

        return Task01.RunTask(extendetMatrix);
    }
}
