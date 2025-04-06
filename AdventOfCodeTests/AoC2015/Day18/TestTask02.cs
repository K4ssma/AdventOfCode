namespace AdventOfCodeTests.AoC2015.Day18;

using AdventOfCode.AoC2015.Day18;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                new bool[,]
                {
                    { true, true, false, true, false, true },
                    { false, false, false, true, true, false },
                    { true, false, false, false, false, true },
                    { false, false, true, false, false, false },
                    { true, false, true, false, false, true },
                    { true, true, true, true, false, true },
                },
                5u)
                .Returns(17u)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static uint RunTask_ValidCases_ShouldReturnCorrectLightAmount(bool[,] grid, uint stepCount)
    {
        return Task02.RunTask(grid, stepCount);
    }
}
