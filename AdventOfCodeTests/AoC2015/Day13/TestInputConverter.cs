namespace AdventOfCodeTests.AoC2015.Day13;

using AdventOfCode.AoC2015.Day13;

[TestFixture]
public static class TestInputConverter
{
    [Test]
    public static void Convert_ValidCase_ShouldConvertToCorrectMatrix()
    {
        // arrange
        string inputString =
            "Alice would gain 54 happiness units by sitting next to Bob.\r\n" +
            "Alice would lose 79 happiness units by sitting next to Carol.\r\n" +
            "Alice would lose 2 happiness units by sitting next to David.\r\n" +
            "Bob would gain 83 happiness units by sitting next to Alice.\r\n" +
            "Bob would lose 7 happiness units by sitting next to Carol.\r\n" +
            "Bob would lose 63 happiness units by sitting next to David.\r\n" +
            "Carol would lose 62 happiness units by sitting next to Alice.\r\n" +
            "Carol would gain 60 happiness units by sitting next to Bob.\r\n" +
            "Carol would gain 55 happiness units by sitting next to David.\r\n" +
            "David would gain 46 happiness units by sitting next to Alice.\r\n" +
            "David would lose 7 happiness units by sitting next to Bob.\r\n" +
            "David would gain 41 happiness units by sitting next to Carol.";

        // act
        int[,] result = InputConverter.Convert(inputString);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetLength(0), Is.EqualTo(4));
            Assert.That(result.GetLength(1), Is.EqualTo(4));
        });

        Assert.Multiple(() =>
        {
            Assert.That(result[0, 0], Is.EqualTo(0));
            Assert.That(result[0, 1], Is.EqualTo(54));
            Assert.That(result[0, 2], Is.EqualTo(-79));
            Assert.That(result[0, 3], Is.EqualTo(-2));

            Assert.That(result[1, 0], Is.EqualTo(83));
            Assert.That(result[1, 1], Is.EqualTo(0));
            Assert.That(result[1, 2], Is.EqualTo(-7));
            Assert.That(result[1, 3], Is.EqualTo(-63));

            Assert.That(result[2, 0], Is.EqualTo(-62));
            Assert.That(result[2, 1], Is.EqualTo(60));
            Assert.That(result[2, 2], Is.EqualTo(0));
            Assert.That(result[2, 3], Is.EqualTo(55));

            Assert.That(result[3, 0], Is.EqualTo(46));
            Assert.That(result[3, 1], Is.EqualTo(-7));
            Assert.That(result[3, 2], Is.EqualTo(41));
            Assert.That(result[3, 3], Is.EqualTo(0));
        });
    }
}
