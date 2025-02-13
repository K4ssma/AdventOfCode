namespace AdventOfCodeTests.AoC2015.Door03;

using AdventOfCode.AoC2015.Door03;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(">")
                .Returns(2)
                .SetName("Test01");

            yield return new TestCaseData("^>v<")
                .Returns(4)
                .SetName("Test02");

            yield return new TestCaseData("^v^v^v^v^v")
                .Returns(2)
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShoulReturnCorrectInt(string inputString)
    {
        return Task01.RunTask(inputString);
    }
}
