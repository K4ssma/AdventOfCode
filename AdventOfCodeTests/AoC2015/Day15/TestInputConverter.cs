namespace AdventOfCodeTests.AoC2015.Day15;

using AdventOfCode.AoC2015.Day15;

[TestFixture]
public static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                "Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8\r\n" +
                "Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3")
                .Returns(new (int, int, int, int, int)[]
                {
                    (-1, -2, 6, 3, 8),
                    (2, 3, -2, -1, 3),
                })
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static (int Capacity, int Durability, int Flavor, int Texture, int Calories)[]
        Convert_ValidCases_ShouldReturnCorrectConversion(string inputString)
    {
        return InputConverter.Convert(inputString).ToArray();
    }
}
