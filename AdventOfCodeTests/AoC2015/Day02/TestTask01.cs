namespace AdventOfCodeTests.AoC2015.Day02;

using AdventOfCode.AoC2015.Day02;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[,] { { 2, 3, 4 } })
                .Returns(58)
                .SetName("Test01");

            yield return new TestCaseData(new int[,] { { 1, 1, 10 } })
                .Returns(43)
                .SetName("Test02");

            yield return new TestCaseData(new int[,]
            {
                { 2, 3, 4 },
                { 1, 1, 10 },
            })
                .Returns(101)
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(int[,] equations)
    {
        return Task01.RunTask(equations);
    }
}
