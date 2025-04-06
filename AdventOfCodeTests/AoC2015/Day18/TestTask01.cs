namespace AdventOfCodeTests.AoC2015.Day18;

using AdventOfCode.AoC2015.Day18;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                new bool[,]
                {
                    { false, true, false, true, false, true },
                    { false, false, false, true, true, false },
                    { true, false, false, false, false, true },
                    { false, false, true, false, false, false },
                    { true, false, true, false, false, true },
                    { true, true, true, true, false, false },
                },
                4u)
                .Returns(4u)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static uint RunTask_ValidCases_ShouldReturnCorrectLightAmount(bool[,] grid, uint steps)
    {
        return Task01.RunTask(grid, steps);
    }
}
