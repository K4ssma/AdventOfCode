namespace AdventOfCodeTests.AoC2015.Day09;

using AdventOfCode.AoC2015.Day09;

[TestFixture]
public static class TestInputConverter
{
    [Test]
    public static void Convert_ValidCase_ShouldRunSuccessfully()
    {
        // arrange
        string inputString =
            "London to Dublin = 464\n" +
            "London to Belfast = 518\n" +
            "Dublin to Belfast = 141";

        // act
        int[,] result = InputConverter.Convert(inputString);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetLength(0), Is.EqualTo(3));
            Assert.That(result.GetLength(1), Is.EqualTo(3));
        });

        Assert.Multiple(() =>
        {
            Assert.That(result[0, 0], Is.EqualTo(0));
            Assert.That(result[1, 1], Is.EqualTo(0));
            Assert.That(result[2, 2], Is.EqualTo(0));

            Assert.That(result[0, 1], Is.EqualTo(464));
            Assert.That(result[1, 0], Is.EqualTo(464));

            Assert.That(result[0, 2], Is.EqualTo(518));
            Assert.That(result[2, 0], Is.EqualTo(518));

            Assert.That(result[1, 2], Is.EqualTo(141));
            Assert.That(result[2, 1], Is.EqualTo(141));
        });
    }
}
