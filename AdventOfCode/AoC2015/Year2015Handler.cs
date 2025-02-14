﻿namespace AdventOfCode.AoC2015;

using System.Threading.Tasks;

using DoorHandler01 = AdventOfCode.AoC2015.Door01.DoorHandler;
using DoorHandler02 = AdventOfCode.AoC2015.Door02.DoorHandler;
using DoorHandler03 = AdventOfCode.AoC2015.Door03.DoorHandler;
using DoorHandler04 = AdventOfCode.AoC2015.Door04.DoorHandler;
using DoorHandler05 = AdventOfCode.AoC2015.Door05.DoorHandler;

public class Year2015Handler : IYearHandler
{
    public async Task<int?> RunYear()
    {
        int? doorNum = UserInputUtility.ReadIntChoice(
            [1, 2, 3, 4, 5], "Please enter the number of the day of the task you want to run");

        if (doorNum == null)
        {
            return null;
        }

        IDoorHandler doorHandler;

        switch (doorNum.Value)
        {
            case 1:
            {
                doorHandler = new DoorHandler01();
                break;
            }

            case 2:
            {
                doorHandler = new DoorHandler02();
                break;
            }

            case 3:
            {
                doorHandler = new DoorHandler03();
                break;
            }

            case 4:
            {
                doorHandler = new DoorHandler04();
                break;
            }

            case 5:
            {
                doorHandler = new DoorHandler05();
                break;
            }

            default:
            {
                throw new NotImplementedException($"day number '{doorNum}' is not yet supported");
            }
        }

        string inputString = await InputFetcher.FetchInput(2015, doorNum.Value);

        return doorHandler.OpenDoor(inputString);
    }
}
