namespace AdventOfCode.AoC2015.Door01;

internal class DoorHandler : IDoorHandler
{
    public int? OpenDoor(string inputString)
    {
        int? taskNum = UserInputUtility.ReadIntChoice(
            [1, 2], "Please enter which task you want to run.");

        if (taskNum == null)
        {
            return null;
        }

        Func<string, int> taskFunc;

        switch (taskNum.Value)
        {
            case 1:
            {
                taskFunc = Task01.RunTask;
                break;
            }

            case 2:
            {
                taskFunc = Task02.RunTask;
                break;
            }

            default:
            {
                throw new NotImplementedException($"task '{taskNum}' is not yet supported");
            }
        }

        return taskFunc(inputString);
    }
}
