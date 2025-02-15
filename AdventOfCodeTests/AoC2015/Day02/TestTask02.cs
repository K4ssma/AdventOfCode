namespace AdventOfCodeTests.AoC2015.Day02;

using AdventOfCode.AoC2015.Day02;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[,]
            {
                { 2, 3, 4 },
            })
                .Returns(34)
                .SetName("Test01");

            yield return new TestCaseData(new int[,]
            {
                { 1, 1, 10 },
            })
                .Returns(14)
                .SetName("Test02");

            yield return new TestCaseData(new int[,]
            {
                { 2, 3, 4 },
                { 1, 1, 10 },
            })
                .Returns(48)
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTest_ValidCases_ShouldReturnCorrectInt(int[,] dimensions)
    {
        return Task02.RunTask(dimensions);
    }
}
