namespace AdventOfCode;

internal static class UserInputUtility
{
    public static int? ReadIntChoice(int[] options, string inputPrompt)
    {
        string exitCode = Config.Instance["ExitCode"]
            ?? throw new ArgumentException("'ExitCode' entry in the config is empty");

        while (true)
        {
            Console.WriteLine(inputPrompt);
            Console.WriteLine("You can choose one of the following numbers.");

            Console.Write('[');

            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(options[i]);

                if (i < options.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine(']');

            string inputString = Console.ReadLine()!;

            if (inputString.Equals(exitCode))
            {
                return null;
            }

            if (!int.TryParse(inputString, out int choice))
            {
                Console.WriteLine("Invalid input! Please try again.\r\n");
                continue;
            }

            if (!options.Contains(choice))
            {
                Console.WriteLine("Your choice is not part of the valid options! Please try again.\r\n");
                continue;
            }

            return choice;
        }
    }
}
