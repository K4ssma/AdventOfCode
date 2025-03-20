namespace AdventOfCodeTests.AoC2015.Day09;

using AdventOfCode.AoC2015.Day09;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[,]
            {
                { 0, 464, 518 },
                { 464, 0, 141 },
                { 518, 141, 0 },
            })
                .Returns(605)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectValue(int[,] distanceMatrix)
    {
        return Task01.RunTask(distanceMatrix);
    }
}
