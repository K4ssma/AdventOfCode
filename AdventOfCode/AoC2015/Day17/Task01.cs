namespace AdventOfCode.AoC2015.Day17;

internal static class Task01
{
    public static uint RunTask(ushort eggnogAmount, ushort[] bucketSizes)
    {
        return CheckBucketPath(eggnogAmount, bucketSizes.AsSpan());
    }

    private static uint CheckBucketPath(ushort remainingEggnog, Span<ushort> remainingBuckets)
    {
        if (remainingBuckets.Length == 0)
        {
            return 0;
        }

        ushort currBucketSize = remainingBuckets[0];
        remainingBuckets = remainingBuckets[1..];

        uint validPaths = CheckBucketPath(remainingEggnog, remainingBuckets);

        if (remainingEggnog == currBucketSize)
        {
            validPaths++;
        }

        if (remainingEggnog > currBucketSize)
        {
            validPaths += CheckBucketPath((ushort)(remainingEggnog - currBucketSize), remainingBuckets);
        }

        return validPaths;
    }
}
