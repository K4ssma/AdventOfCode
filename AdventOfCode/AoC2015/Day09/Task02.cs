namespace AdventOfCode.AoC2015.Day09;

internal static class Task02
{
    public static int RunTask(int[,] distanceMatrix)
    {
        if (distanceMatrix.GetLength(0) != distanceMatrix.GetLength(1))
        {
            throw new FormatException("distance matrix needs to have a squared format (like 2x2, 3x3,...)");
        }

        if (distanceMatrix.GetLength(0) == 0)
        {
            throw new ArgumentException("can't find a path length without distances");
        }

        if (distanceMatrix.GetLength(0) == 1)
        {
            return 0;
        }

        int longestPath = 0;
        int maxBitMask = (int)Math.Pow(2, distanceMatrix.GetLength(0)) - 1;

        int usedLocationsMask = 0;
        int[] pathPositions = new int[distanceMatrix.GetLength(0)];
        int[] usedPosLocationMask = new int[distanceMatrix.GetLength(0)];

        int currPos = 0;

        while (usedPosLocationMask[currPos] != maxBitMask)
        {
            if ((usedLocationsMask | usedPosLocationMask[currPos]) == maxBitMask)
            {
                usedLocationsMask -= 1 << pathPositions[currPos - 1];
                pathPositions[currPos] = 0;
                usedPosLocationMask[currPos] = 0;
                currPos--;
                continue;
            }

            int? cityIndex = null;

            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                if ((usedLocationsMask & (1 << i)) > 0
                    || (usedPosLocationMask[currPos] & (1 << i)) > 0)
                {
                    continue;
                }

                cityIndex = i;
                break;
            }

            usedLocationsMask += 1 << cityIndex!.Value;
            usedPosLocationMask[currPos] += 1 << cityIndex!.Value;
            pathPositions[currPos] = cityIndex!.Value;

            if (currPos != pathPositions.Length - 1)
            {
                currPos++;
                continue;
            }

            usedLocationsMask -= 1 << pathPositions[currPos];

            int pathLength = 0;

            for (int i = 1; i < pathPositions.Length; i++)
            {
                pathLength += distanceMatrix[pathPositions[i - 1], pathPositions[i]];
            }

            if (pathLength > longestPath)
            {
                longestPath = pathLength;
            }
        }

        return longestPath;
    }
}
