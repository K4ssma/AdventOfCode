namespace AdventOfCodeTests.AoC2015.Day12;

using AdventOfCode.AoC2015.Day12;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("[1,2,3]").Returns(6).SetName("Test01");
            yield return new TestCaseData("[1,{\"c\":\"red\",\"b\":2},3]").Returns(4).SetName("Test02");
            yield return new TestCaseData("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}").Returns(0).SetName("Test03");
            yield return new TestCaseData("[1,\"red\",5]").Returns(6).SetName("Test04");
            yield return new TestCaseData("{1,-1,2}").Returns(2).SetName("Test05");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectSum(string inputString)
    {
        return Task02.RunTask(inputString);
    }
}
