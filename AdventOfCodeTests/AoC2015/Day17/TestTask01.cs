namespace AdventOfCodeTests.AoC2015.Day17;

using AdventOfCode.AoC2015.Day17;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData((ushort)25, new ushort[] { 20, 15, 10, 5, 5 })
                .Returns(4u)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static uint RunTask_ValidCases_ShouldReturnCorrectAmount(ushort eggnogAmount, ushort[] bucketSizes)
    {
        return Task01.RunTask(eggnogAmount, bucketSizes);
    }
}
