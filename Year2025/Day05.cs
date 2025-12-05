namespace Kassma.AdventOfCode.Years.Year2025;

using System;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Class for solutions of the Advent of Code day 5 challenge.
/// </summary>
public sealed class Day05 : IAocDay
{
    /// <inheritdoc/>
    public string SolvePart01(IProgress<ProgressStatus> progress, string input)
    {
        var parts = input.Split(["\r\n\r\n", "\n\n"], StringSplitOptions.RemoveEmptyEntries);

        var ranges = parts[0]
            .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select((rangeString) =>
            {
                var rangeParts = rangeString.Split('-');
                return new Range(ulong.Parse(rangeParts[0]), ulong.Parse(rangeParts[1]));
            })
            .ToArray();

        var ids = parts[1]
            .Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select((idString) => ulong.Parse(idString));

        return ids
            .Count((id) => ranges.Any((range) => id >= range.Min && id <= range.Max))
            .ToString();
    }

    /// <inheritdoc/>
    public string SolvePart02(IProgress<ProgressStatus> progress, string input)
    {
        var ranges = input
            .Split(["\r\n\r\n", "\n\n"], StringSplitOptions.RemoveEmptyEntries)[0]
            .Split(["\r\n", "\n\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select((rangeString) =>
            {
                var rangeParts = rangeString.Split('-');
                return new Range(ulong.Parse(rangeParts[0]), ulong.Parse(rangeParts[1]));
            });

        var orderedRanges = new LinkedList<Range>();

        foreach (var range in ranges)
        {
            var currNode = orderedRanges.First;

            if (currNode is null)
            {
                orderedRanges.AddFirst(range);
                continue;
            }

            while (true)
            {
                if (range.Max < currNode.Value.Min - 1)
                {
                    orderedRanges.AddBefore(currNode, range);
                    break;
                }

                if (range.Min > currNode.Value.Max + 1)
                {
                    if (currNode.Next is null)
                    {
                        orderedRanges.AddLast(range);
                        break;
                    }

                    currNode = currNode.Next;
                    continue;
                }

                var newMax = Math.Max(range.Max, currNode.Value.Max);
                var nextNode = currNode.Next;
                var combinedNodes = new List<LinkedListNode<Range>>() { currNode };

                while (nextNode is not null)
                {
                    if (newMax < nextNode.Value.Min - 1)
                    {
                        break;
                    }

                    combinedNodes.Add(nextNode);

                    newMax = Math.Max(newMax, nextNode.Value.Max);
                    nextNode = nextNode.Next;
                }

                orderedRanges.AddBefore(currNode, new Range(Math.Min(range.Min, currNode.Value.Min), newMax));

                foreach (var node in combinedNodes)
                {
                    orderedRanges.Remove(node);
                }

                break;
            }
        }

        return orderedRanges
            .Select((range) => range.Max - range.Min + 1)
            .Aggregate((curr, next) => curr + next)
            .ToString();
    }

    private struct Range(ulong min, ulong max)
    {
        public ulong Min = min;
        public ulong Max = max;
    }
}
