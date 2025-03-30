namespace AdventOfCodeTests.AoC2015.Day16;

using AdventOfCode.AoC2015.Day16;

[TestFixture]
public static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                "Sue: " +
                "children: 3, " +
                "cats: 7, " +
                "samoyeds: 2, " +
                "pomeranians: 3, " +
                "akitas: 0, " +
                "vizslas: 0, " +
                "goldfish: 5, " +
                "trees: 3, " +
                "cars: 2, " +
                "perfumes: 1")
                .Returns(new (string, byte)[][]
                {
                    [
                        ("children", 3),
                        ("cats", 7),
                        ("samoyeds", 2),
                        ("pomeranians", 3),
                        ("akitas", 0),
                        ("vizslas", 0),
                        ("goldfish", 5),
                        ("trees", 3),
                        ("cars", 2),
                        ("perfumes", 1),
                    ],
                })
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static (string, byte)[][] Convert_ValidCases_ShouldReturnCorrectConversion(string inputString)
    {
        Dictionary<string, byte>[] auntsProperties = InputConverter.Convert(inputString);

        return auntsProperties
            .Select((Dictionary<string, byte> auntProperties) =>
            {
                return auntProperties
                    .Select((KeyValuePair<string, byte> property) => (property.Key, property.Value))
                    .ToArray();
            })
            .ToArray();
    }
}
