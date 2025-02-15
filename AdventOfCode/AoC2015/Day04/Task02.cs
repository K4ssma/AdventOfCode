namespace AdventOfCode.AoC2015.Day04;

using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

internal static class Task02
{
    private const int MaxIteration = 2_000_000_000;

    public static int RunTask(string inputString)
    {
        int num = 1;
        int batchSize = Environment.ProcessorCount * 2;
        ConcurrentBag<int> fittingNums = new();

        while (num <= MaxIteration)
        {
            Parallel.For(0, batchSize, (i, state) =>
            {
                int id = num + i;

                byte[] inputBytes = Encoding.UTF8.GetBytes(inputString + id);
                byte[] hashBytes = MD5.HashData(inputBytes);

                if (BitConverter.ToString(hashBytes).Replace("-", string.Empty).StartsWith("000000"))
                {
                    fittingNums.Add(id);
                    state.Stop();
                }
            });

            if (!fittingNums.IsEmpty)
            {
                return fittingNums.Min();
            }

            num += batchSize;
        }

        throw new ArgumentException($"could not find valid id in {MaxIteration} iterations");
    }
}
