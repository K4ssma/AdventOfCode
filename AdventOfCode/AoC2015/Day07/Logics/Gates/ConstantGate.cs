namespace AdventOfCode.AoC2015.Day07.Logics.Gates;

using AdventOfCode.AoC2015.Day07.Logics.Values;

public class ConstantGate(IValue value, string wireId) : IGate
{
    public IValue Value { get; init; } = value;

    public string OutputWireId { get; init; } = wireId;
}
