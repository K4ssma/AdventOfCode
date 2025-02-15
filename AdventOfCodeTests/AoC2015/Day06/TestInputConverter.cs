namespace AdventOfCodeTests.AoC2015.Day06;

using AdventOfCode.AoC2015.Day06;

[TestFixture]
public static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("turn on 0,0 through 999,999")
                .Returns((object)(new (InstructionType, Vector2Int, Vector2Int)[]
                {
                    (InstructionType.On, new(0, 0), new(999, 999)),
                }))
                .SetName("Test01");

            yield return new TestCaseData("toggle 0,0 through 999,0")
                .Returns((object)(new (InstructionType, Vector2Int, Vector2Int)[]
                {
                    (InstructionType.Toogle, new(0, 0), new(999, 0)),
                }))
                .SetName("Test02");

            yield return new TestCaseData("turn off 499,499 through 500,500")
                .Returns((object)(new (InstructionType, Vector2Int, Vector2Int)[]
                {
                    (InstructionType.Off, new(499, 499), new(500, 500)),
                }))
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static (InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[]
        Convert_ValidCases_ShouldReturnCorrectInstructions(string inputString)
    {
        return InputConverter.Convert(inputString);
    }
}
