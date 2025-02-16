namespace AdventOfCode.AoC2015.Day07;

using AdventOfCode.AoC2015.Day07.Logics.Gates;
using AdventOfCode.AoC2015.Day07.Logics.Values;

internal static class InputConverter
{
    public static Dictionary<string, IGate> Convert(string inputString)
    {
        return inputString
            .Split("\r\n")
            .Where((string str) => str != string.Empty)
            .Select<string, IGate>((string str) =>
            {
                string[] gateParts = str.Split("->");
                string outputWireId = gateParts[1].Trim();

                if (gateParts[0].Contains("AND"))
                {
                    string[] inputParts = gateParts[0].Split("AND");

                    return new AndGate(
                        GetValue(inputParts[0]),
                        GetValue(inputParts[1]),
                        outputWireId);
                }

                if (gateParts[0].Contains("OR"))
                {
                    string[] inputParts = gateParts[0].Split("OR");

                    return new OrGate(
                        GetValue(inputParts[0]),
                        GetValue(inputParts[1]),
                        outputWireId);
                }

                if (gateParts[0].Contains("LSHIFT"))
                {
                    string[] inputParts = gateParts[0].Split("LSHIFT");

                    return new LShiftGate(
                        GetValue(inputParts[0]),
                        GetValue(inputParts[1]),
                        outputWireId);
                }

                if (gateParts[0].Contains("RSHIFT"))
                {
                    string[] inputParts = gateParts[0].Split("RSHIFT");

                    return new RShiftGate(
                        GetValue(inputParts[0]),
                        GetValue(inputParts[1]),
                        outputWireId);
                }

                if (gateParts[0].Contains("NOT"))
                {
                    return new NotGate(
                        GetValue(gateParts[0].Split("NOT")[1]),
                        outputWireId);
                }

                return new ConstantGate(
                    GetValue(gateParts[0]),
                    outputWireId);
            })
            .ToDictionary((IGate gate) => gate.OutputWireId);
    }

    private static IValue GetValue(string str)
    {
        return ushort.TryParse(str, out ushort value)
            ? new ConstantValue(value)
            : new WireValue(str.Trim());
    }
}
