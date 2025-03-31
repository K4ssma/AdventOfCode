namespace AdventOfCode.AoC2015.Day16;

internal static class Task02
{
    public static uint? RunTask(
        Dictionary<string, byte> targetAuntProperties,
        Dictionary<string, byte>[] auntAnalysis,
        (Func<byte, byte, bool> CompareFunc, HashSet<string> TargetedProperties)[] ruleSet)
    {
        for (uint i = 0; i < auntAnalysis.Length; i++)
        {
            bool isTargetAunt = auntAnalysis[i]
                .All((KeyValuePair<string, byte> property) =>
                {
                    if (!targetAuntProperties.TryGetValue(property.Key, out byte targetValue))
                    {
                        return true;
                    }

                    foreach ((Func<byte, byte, bool> compareFunc, HashSet<string> targetProperties) in ruleSet)
                    {
                        if (!targetProperties.Contains(property.Key))
                        {
                            continue;
                        }

                        return compareFunc(targetValue, property.Value);
                    }

                    return targetValue == property.Value;
                });

            if (isTargetAunt)
            {
                return i + 1;
            }
        }

        return null;
    }
}
