namespace AdventOfCode.AoC2015.Day07.Logics.Values;

public class WireValue(string wireId) : IValue
{
    public ValueType Type { get => ValueType.Wire; }

    public string WireId { get; init; } = wireId;
}
