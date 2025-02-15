namespace AdventOfCode.AoC2015.Day03;

internal static class Task02
{
    public static int RunTask(string inputString)
    {
        Vector2Int posOne = new()
        {
            X = 0,
            Y = 0,
        };

        Vector2Int posTwo = new()
        {
            X = 0,
            Y = 0,
        };

        HashSet<Vector2Int> visitedHouses = [new() { X = 0, Y = 0 }];

        for (int i = 0; i < inputString.Length; i++)
        {
            Vector2Int movingVersion = i % 2 == 0
                ? posOne
                : posTwo;

            switch (inputString[i])
            {
                case '^':
                {
                    movingVersion.Y++;
                    break;
                }

                case '>':
                {
                    movingVersion.X++;
                    break;
                }

                case 'v':
                {
                    movingVersion.Y--;
                    break;
                }

                case '<':
                {
                    movingVersion.X--;
                    break;
                }

                default:
                {
                    throw new FormatException($"invalid char '{inputString[i]}' found at position {i}");
                }
            }

            visitedHouses.Add(new()
            {
                X = movingVersion.X,
                Y = movingVersion.Y,
            });
        }

        return visitedHouses.Count;
    }

    private sealed record Vector2Int
    {
        public required int X { get; set; }

        public required int Y { get; set; }
    }
}
