namespace AdventOfCodeTests.AoC2015.Door01;

using AdventOfCode.AoC2015.Door01;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCasesTask01
    {
        get
        {
            yield return new TestCaseData("(())").Returns(0).SetName("Test01");
            yield return new TestCaseData("()()").Returns(0).SetName("Test02");

            yield return new TestCaseData("(((").Returns(3).SetName("Test03");
            yield return new TestCaseData("(()(()(").Returns(3).SetName("Test04");
            yield return new TestCaseData("))(((((").Returns(3).SetName("Test05");

            yield return new TestCaseData("())").Returns(-1).SetName("Test06");
            yield return new TestCaseData("))(").Returns(-1).SetName("Test07");

            yield return new TestCaseData(")))").Returns(-3).SetName("Test08");
            yield return new TestCaseData(")())())").Returns(-3).SetName("Test09");
        }
    }

    [TestCaseSource(nameof(TestCasesTask01))]
    public static int Task01_ValidCases_ShouldReturnCorrectNum(string inputString)
    {
        return Task01.RunTask(inputString);
    }
}
