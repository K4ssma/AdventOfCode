namespace AdventOfCodeTests.AoC2015.Day15;

using AdventOfCode.AoC2015.Day15;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                new (int, int, int, int, int)[]
                {
                    (-1, -2, 6, 3, 8),
                    (2, 3, -2, -1, 3),
                },
                500u)
                .Returns(57600000u)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static uint? RunTask_ValidCases_ShouldReturnCorrectScore(
        (int Capacity, int Durability, int Flavor, int Texture, int Calories)[] ingredientes,
        uint calorieTarget)
    {
        return Task02.RunTask(ingredientes, calorieTarget);
    }
}
