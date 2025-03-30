namespace AdventOfCode.AoC2015.Day15;

internal static class Task01
{
    public static uint RunTask((int Capacity, int Durability, int Flavor, int Texture, int Calories)[] ingredients)
    {
        if (ingredients.Length == 0)
        {
            throw new ArgumentException("the number of ingredients has to be greater than 0.");
        }

        uint maxCookieScore = 100_000_000u
            * (uint)Math.Max(0, ingredients[0].Capacity)
            * (uint)Math.Max(0, ingredients[0].Durability)
            * (uint)Math.Max(0, ingredients[0].Flavor)
            * (uint)Math.Max(0, ingredients[0].Texture);

        if (ingredients.Length == 1)
        {
            return maxCookieScore;
        }

        byte[] distribution = new byte[ingredients.Length];
        byte freePoints = 100;

        while (distribution[^1] < 100)
        {
            if (freePoints > 0)
            {
                distribution[1]++;
                freePoints--;
            }
            else
            {
                for (uint i = 1; i < distribution.Length; i++)
                {
                    if (distribution[i] == 0)
                    {
                        continue;
                    }

                    freePoints = (byte)(distribution[i] - 1);
                    distribution[i] = 0;
                    distribution[i + 1]++;
                    break;
                }
            }

            distribution[0] = freePoints;

            (int capacity, int curability, int flavor, int texture) = ingredients
                .Select((ingredient, index) =>
                {
                    return (
                        distribution[index] * ingredient.Capacity,
                        distribution[index] * ingredient.Durability,
                        distribution[index] * ingredient.Flavor,
                        distribution[index] * ingredient.Texture);
                })
                .Aggregate((curr, next) =>
                {
                    return (
                        curr.Item1 + next.Item1,
                        curr.Item2 + next.Item2,
                        curr.Item3 + next.Item3,
                        curr.Item4 + next.Item4);
                });

            uint currCookieScore =
                (uint)Math.Max(0, capacity)
                * (uint)Math.Max(0, curability)
                * (uint)Math.Max(0, flavor)
                * (uint)Math.Max(0, texture);

            if (currCookieScore > maxCookieScore)
            {
                maxCookieScore = currCookieScore;
            }
        }

        return maxCookieScore;
    }
}