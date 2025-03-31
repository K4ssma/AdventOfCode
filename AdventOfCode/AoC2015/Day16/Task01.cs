namespace AdventOfCode.AoC2015.Day16;

internal static class Task01
{
    public static uint? RunTask(Dictionary<string, byte> targetAuntProperties, Dictionary<string, byte>[] auntAnalysis)
    {
        for (uint i = 0; i < auntAnalysis.Length; i++)
        {
            bool isSameAsTargetAunt = auntAnalysis[i]
                .All((KeyValuePair<string, byte> properties) =>
                {
                    return !targetAuntProperties.TryGetValue(properties.Key, out byte value)
                        || value == properties.Value;
                });

            if (isSameAsTargetAunt)
            {
                return i + 1;
            }
        }

        return null;
    }
}
