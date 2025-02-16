namespace AdventOfCode.AoC2015.Day07.Logics.Values;

public class ConstantValue(ushort value) : IValue
{
    public ushort Value { get; init; } = value;
}
