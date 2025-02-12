namespace AdventOfCode.AoC2015.Door02;

internal class DoorHandler : IDoorHandler
{
    public int? OpenDoor(string inputString)
    {
        int? taskNum = UserInputUtility.ReadIntChoice(
            [], "Please enter the number of the task you want to run.");

        if (taskNum == null)
        {
            return null;
        }

        Func<int[,], int> taskFunc;

        switch (taskNum.Value)
        {
            default:
            {
                throw new NotImplementedException($"task number '{taskNum}' is not yet supported");
            }
        }

        int[,] equations = InputConverter.Convert(inputString);

        return taskFunc(equations);
    }
}
