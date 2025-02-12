namespace AdventOfCode;

internal static class UserInputUtility
{
    /// <summary>
    /// prints the input prompt and the available options to the console and lets him choose one of them.
    /// continues to ask for an answer when no valid option got chosen
    /// </summary>
    /// <param name="options">
    /// the available valid options to choose from
    /// </param>
    /// <param name="inputPrompt">
    /// the prompt that gets printed to the console as information for the user
    /// </param>
    /// <returns>
    /// <para><c>null</c> user entered in the config defined exit code</para>
    /// <para><c>int</c> theoption from the pool the user chose</para>
    /// </returns>
    /// <exception cref="ArgumentException">
    /// 'ExitCode' entry in the config is empty
    /// </exception>
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
