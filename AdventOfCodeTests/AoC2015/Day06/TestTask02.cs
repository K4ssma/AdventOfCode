namespace AdventOfCodeTests.AoC2015.Day06;

using AdventOfCode.AoC2015.Day06;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData((object)(new (InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[]
            {
                (InstructionType.On, new(0, 0), new(0, 0)),
            }))
                .Returns(1)
                .SetName("Test01");

            yield return new TestCaseData((object)(new (InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[]
            {
                (InstructionType.Toggle, new(0, 0), new(999, 999)),
            }))
                .Returns(2_000_000)
                .SetName("Test02");

            yield return new TestCaseData((object)(new (InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[]
            {
                (InstructionType.Off, new(0, 0), new(999, 0)),
            }))
                .Returns(0)
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(
        (InstructionType Type, Vector2Int PosOne, Vector2Int PosTwo)[] instructions)
    {
        return Task02.RunTask(instructions);
    }
}
