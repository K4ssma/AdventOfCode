namespace AdventOfCodeTests.AoC2015.Day15;

using AdventOfCode.AoC2015.Day15;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new (int, int, int, int, int)[]
            {
                (-1, -2, 6, 3, 8),
                (2, 3, -2, -1, 3),
            })
                .Returns(62842880u)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static uint RunTask_ValidCases_ShouldReturnCorrectCookieScore(
        (int Capacity, int Durability, int Flavor, int Texture, int Calories)[] ingredients)
    {
        return Task01.RunTask(ingredients);
    }
}
