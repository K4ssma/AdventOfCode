namespace AdventOfCode.AoC2015.Day09;

internal static class Task01
{
    public static int RunTask(int[,] distanceMatrix)
    {
        if (distanceMatrix.GetLength(0) != distanceMatrix.GetLength(1))
        {
            throw new FormatException("distance matrix need to have a square size (like 2x2, 3x3,...)");
        }

        if (distanceMatrix.GetLength(0) == 1)
        {
            return 0;
        }

        int shortestDistance = int.MaxValue;

        int[] currPath = new int[distanceMatrix.GetLength(0)];

        int maxBitMask = (int)Math.Pow(2, distanceMatrix.GetLength(0)) - 1;

        // bitmasks ('1' represents index 0 being used)
        int usedIndecesForPath = 0;
        int[] posUsedIndeces = new int[distanceMatrix.GetLength(0)];

        int currPathPos = 0;

        while (currPathPos >= 0)
        {
            if ((usedIndecesForPath | posUsedIndeces[currPathPos]) == maxBitMask
                || posUsedIndeces[currPathPos] == maxBitMask)
            {
                posUsedIndeces[currPathPos] = 0;
                currPath[currPathPos] = 0;
                currPathPos--;

                if (currPathPos < 0)
                {
                    break;
                }

                usedIndecesForPath -= 1 << currPath[currPathPos];
                continue;
            }

            int? cityIndex = null;

            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                if ((usedIndecesForPath & (1 << i)) > 0
                    || (posUsedIndeces[currPathPos] & (1 << i)) > 0)
                {
                    continue;
                }

                cityIndex = i;
                break;
            }

            if (cityIndex == null)
            {
                throw new ArgumentException("couldn't find valid index for next city in path");
            }

            currPath[currPathPos] = cityIndex.Value;
            posUsedIndeces[currPathPos] += 1 << cityIndex.Value;
            usedIndecesForPath += 1 << cityIndex.Value;

            if (currPathPos != distanceMatrix.GetLength(0) - 1)
            {
                currPathPos++;
                continue;
            }

            usedIndecesForPath -= 1 << currPath[currPathPos];

            int pathLength = 0;

            for (int i = 1; i < currPath.Length; i++)
            {
                pathLength += distanceMatrix[currPath[i - 1], currPath[i]];
            }

            if (pathLength < shortestDistance)
            {
                shortestDistance = pathLength;
            }
        }

        return shortestDistance;
    }
}
