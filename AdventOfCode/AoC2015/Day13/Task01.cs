namespace AdventOfCode.AoC2015.Day13;

using System;

internal static class Task01
{
    public static int RunTask(int[,] happinessMatrix)
    {
        if (happinessMatrix.GetLength(0) != happinessMatrix.GetLength(1))
        {
            throw new ArgumentException("the provided matrix needs to have a squared size (f.e. 2x2, 3x3,...");
        }

        int? maxHappiness = null;

        int maxBitMask = (int)Math.Pow(2, happinessMatrix.GetLength(0)) - 1;
        int[] indexSeats = new int[happinessMatrix.GetLength(0)];

        int usedIndecesBitMask = 0;
        int[] seatUsedIndecesBitMask = new int[happinessMatrix.GetLength(0)];

        int currSeat = 0;

        while (currSeat >= 0)
        {
            if ((usedIndecesBitMask | seatUsedIndecesBitMask[currSeat]) == maxBitMask)
            {
                seatUsedIndecesBitMask[currSeat] = 0;
                indexSeats[currSeat] = 0;
                currSeat--;

                if (currSeat >= 0)
                {
                    usedIndecesBitMask -= 1 << indexSeats[currSeat];
                }

                continue;
            }

            for (int i = 0; i < happinessMatrix.GetLength(0); i++)
            {
                if (((usedIndecesBitMask >> i) & 1) != 0
                    || ((seatUsedIndecesBitMask[currSeat] >> i) & 1) != 0)
                {
                    continue;
                }

                indexSeats[currSeat] = i;
                usedIndecesBitMask += 1 << i;
                seatUsedIndecesBitMask[currSeat] += 1 << i;
                break;
            }

            if (currSeat < happinessMatrix.GetLength(0) - 1)
            {
                currSeat++;
                continue;
            }

            usedIndecesBitMask -= 1 << indexSeats[currSeat];
            int currHappiness = 0;

            for (int i = 0; i < indexSeats.Length; i++)
            {
                int indexOne = indexSeats[i];
                int indexTwo = indexSeats[(i + 1) % indexSeats.Length];

                currHappiness += happinessMatrix[indexOne, indexTwo];
                currHappiness += happinessMatrix[indexTwo, indexOne];
            }

            if (maxHappiness == null
                || currHappiness > maxHappiness)
            {
                maxHappiness = currHappiness;
            }
        }

        return maxHappiness!.Value;
    }
}
