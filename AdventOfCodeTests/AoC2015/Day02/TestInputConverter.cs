namespace AdventOfCodeTests.AoC2015.Day02;

using AdventOfCode.AoC2015.Day02;

[TestFixture]
internal static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("2x3x4")
                .Returns(new int[,]
                {
                    { 2, 3, 4 },
                })
                .SetName("Test01");

            yield return new TestCaseData("1x1x10")
                .Returns(new int[,]
                {
                    { 1, 1, 10 },
                })
                .SetName("Test02");

            yield return new TestCaseData(
                "1x2x3\r\n" +
                "4x5x6")
                .Returns(new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                })
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int[,] Convert_ValidCases_ShouldReturnCorrectArrays(string inputString)
    {
        return InputConverter.Convert(inputString);
    }
}
