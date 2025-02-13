namespace AdventOfCode.AoC2015.Door04;

using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

internal static class Task01
{
    private const int MaxIteration = 2_000_000_000;

    public static int RunTask(string inputString)
    {
        int num = 1;

        ConcurrentBag<int> fittingNumbers = new();
        int batchSize = Environment.ProcessorCount * 2;

        while (num <= MaxIteration)
        {
            Parallel.For(0, batchSize, (i, state) =>
            {
                int id = num + i;
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputString + id);
                byte[] hashBytes = MD5.HashData(inputBytes);

                if (BitConverter.ToString(hashBytes).Replace("-", string.Empty).StartsWith("00000"))
                {
                    fittingNumbers.Add(id);
                    state.Stop();
                }
            });

            if (!fittingNumbers.IsEmpty)
            {
                return fittingNumbers.Min();
            }

            num += batchSize;
        }

        throw new ArgumentException($"could not find fitting hash in first {MaxIteration} iterations");
    }
}
