namespace AdventOfCode.AoC2015.Day07;

using AdventOfCode.AoC2015.Day07.Logics.Gates;
using AdventOfCode.AoC2015.Day07.Logics.Values;

internal static class Task02
{
    public static int RunTask(string inputString)
    {
        Dictionary<string, IGate> gates = InputConverter.Convert(inputString);

        ushort value = (ushort)Task01.RunTask(gates, "a");

        Dictionary<string, IGate> rewiredGates = InputConverter.Convert(inputString);
        rewiredGates["b"] = new ConstantGate(new ConstantValue(value), "b");

        return Task01.RunTask(rewiredGates, "a");
    }
}
