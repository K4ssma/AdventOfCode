namespace AdventOfCodeTests.AoC2015.Day13;

using AdventOfCode.AoC2015.Day13;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[,]
            {
                { 0, 54, -79, -2 },
                { 83, 0, -7, -63 },
                { -62, 60, 0, 55 },
                { 46, -7, 41, 0 },
            })
                .Returns(330)
                .SetName("Test01");

            yield return new TestCaseData(new int[,]
            {
                { 0, 1, 1, 1 },
                { 1, 0, 1, 1 },
                { 1, 1, 0, 1 },
                { -999, 1, 1, 0 },
            })
                .Returns(8)
                .SetName("Test02");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectValue(int[,] happinessMatrix)
    {
        return Task01.RunTask(happinessMatrix);
    }
}
