namespace AdventOfCode.AoC2015.Day15;

internal static class Task02
{
    public static uint? RunTask(
        (int Capacity, int Durability, int Flavor, int Texture, int Calories)[] ingredients,
        uint calorieTarget)
    {
        if (ingredients.Length == 0)
        {
            throw new ArgumentException("There has to be at least one ingredient.");
        }

        uint? maxCookieScore = 100 * ingredients[0].Calories != calorieTarget
            ? null
            : 100_000_000u
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
                freePoints--;
                distribution[1]++;
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

            (int combinedCapacity, int combinedDurability, int combinedFlavor, int combinedTexture, int combinedCalories) = ingredients
                .Select((ingredient, index) =>
                {
                    return (
                        distribution[index] * ingredient.Capacity,
                        distribution[index] * ingredient.Durability,
                        distribution[index] * ingredient.Flavor,
                        distribution[index] * ingredient.Texture,
                        distribution[index] * ingredient.Calories);
                })
                .Aggregate((curr, next) =>
                {
                    return (
                        curr.Item1 + next.Item1,
                        curr.Item2 + next.Item2,
                        curr.Item3 + next.Item3,
                        curr.Item4 + next.Item4,
                        curr.Item5 + next.Item5);
                });

            if (combinedCalories != calorieTarget)
            {
                continue;
            }

            uint cookieScore =
                (uint)Math.Max(0, combinedCapacity)
                * (uint)Math.Max(0, combinedDurability)
                * (uint)Math.Max(0, combinedFlavor)
                * (uint)Math.Max(0, combinedTexture);

            if (maxCookieScore == null
                || cookieScore > maxCookieScore)
            {
                maxCookieScore = cookieScore;
            }
        }

        return maxCookieScore;
    }
}
