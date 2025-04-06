namespace AdventOfCode.AoC2015.Day17;

internal static class Task02
{
    public static uint RunTask(ushort eggnogAmount, ushort[] bucketSizes)
    {
        uint[] validPathsPerUsedBuckets = new uint[bucketSizes.Length];

        Stack<uint> currUsedBucketIndices = new();
        uint currPos = 0;

        while (true)
        {
            if (currPos != bucketSizes.Length - 1)
            {
                if (eggnogAmount > bucketSizes[currPos])
                {
                    eggnogAmount -= bucketSizes[currPos];
                    currUsedBucketIndices.Push(currPos);
                }
                else if (eggnogAmount == bucketSizes[currPos])
                {
                    validPathsPerUsedBuckets[currUsedBucketIndices.Count + 1]++;
                }

                currPos++;
                continue;
            }

            if (eggnogAmount == bucketSizes[currPos])
            {
                validPathsPerUsedBuckets[currUsedBucketIndices.Count + 1]++;
            }

            if (currUsedBucketIndices.Count == 0)
            {
                break;
            }

            uint lastbucketIndex = currUsedBucketIndices.Pop();
            eggnogAmount += bucketSizes[lastbucketIndex];
            currPos = lastbucketIndex + 1;
        }

        for (uint i = 0; i < validPathsPerUsedBuckets.Length; i++)
        {
            if (validPathsPerUsedBuckets[i] != 0)
            {
                return validPathsPerUsedBuckets[i];
            }
        }

        return 0;
    }
}
