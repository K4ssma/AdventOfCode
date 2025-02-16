namespace AdventOfCode.AoC2015.Day07.Logics.Gates;

public interface IGate
{
    public GateType Type { get; }

    public string OutputWireId { get; init; }
}
