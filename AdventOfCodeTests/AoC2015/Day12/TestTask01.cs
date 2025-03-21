namespace AdventOfCodeTests.AoC2015.Day12;

using AdventOfCode.AoC2015.Day12;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("[1,2,3]").Returns(6).SetName("Test01");

            yield return new TestCaseData("{\"a\":2,\"b\":4}").Returns(6).SetName("Test02");

            yield return new TestCaseData("[[[3]]]").Returns(3).SetName("Test03");

            yield return new TestCaseData("{\"a\":{\"b\":4},\"c\":-1}").Returns(3).SetName("Test04");

            yield return new TestCaseData("{\"a\":[-1,1]}").Returns(0).SetName("Test05");

            yield return new TestCaseData("[-1,{\"a\":1}]").Returns(0).SetName("Test06");

            yield return new TestCaseData("[]").Returns(0).SetName("Test07");

            yield return new TestCaseData("{}").Returns(0).SetName("Test08");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectSum(string inputString)
    {
        return Task01.RunTask(inputString);
    }
}
