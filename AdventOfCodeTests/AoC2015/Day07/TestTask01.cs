namespace AdventOfCodeTests.AoC2015.Day07;

using AdventOfCode.AoC2015.Day07;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("123 -> x", "x")
                .Returns(123)
                .SetName("Test01");

            yield return new TestCaseData(
                "123 -> x\n" +
                "456 -> y\n" +
                "x AND y -> d",
                "d")
                .Returns(72)
                .SetName("Test02");

            yield return new TestCaseData(
                "123 -> x\n" +
                "456 -> y\n" +
                "x OR y -> e",
                "e")
                .Returns(507)
                .SetName("Test03");

            yield return new TestCaseData(
                "123 -> x\n" +
                "x LSHIFT 2 -> f",
                "f")
                .Returns(492)
                .SetName("Test04");

            yield return new TestCaseData(
                "456 -> y\n" +
                "y RSHIFT 2 -> g",
                "g")
                .Returns(114)
                .SetName("Test05");

            yield return new TestCaseData(
                "123 -> x\n" +
                "NOT x -> h",
                "h")
                .Returns(65412)
                .SetName("Test06");

            yield return new TestCaseData(
                "456 -> y\n" +
                "NOT y -> i",
                "i")
                .Returns(65079)
                .SetName("Test07");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectValue(string inputString, string wireId)
    {
        return Task01.RunTask(InputConverter.Convert(inputString), wireId);
    }
}
