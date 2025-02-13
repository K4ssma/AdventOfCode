namespace AdventOfCode.AoC2015.Door03;

internal class DoorHandler : IDoorHandler
{
    public int? OpenDoor(string inputString)
    {
        int? taskNum = UserInputUtility.ReadIntChoice(
            [1], "Please enter the number of the task you would like to run.");

        if (taskNum == null)
        {
            return null;
        }

        Func<string, int> taskFunc;

        switch (taskNum)
        {
            case 1:
            {
                taskFunc = Task01.RunTask;
                break;
            }

            default:
            {
                throw new NotImplementedException($"task number '{taskNum}' is not yet supported");
            }
        }

        return taskFunc(inputString);
    }
}
