namespace AdventOfCode.AoC2015.Day11;

using System.Text;

internal static class Task01
{
    private const string LetterLookup = "abcdefghijklmnopqrstuvwxyz";

    private static IEnumerable<Func<string, bool>> DefaultRules
    {
        get
        {
            yield return static (string password) => password.Length == 8;

            yield return static (string password) =>
            {
                if (password.Length < 3)
                {
                    return false;
                }

                for (int i = 2; i < password.Length; i++)
                {
                    int charValOne = LetterLookup.IndexOf(password[i - 2]);
                    int charValTwo = LetterLookup.IndexOf(password[i - 1]);
                    int charValThree = LetterLookup.IndexOf(password[i]);

                    if (charValTwo - charValOne == 1
                        && charValThree - charValTwo == 1)
                    {
                        return true;
                    }
                }

                return false;
            };

            yield return static (string password) =>
            {
                return !password.Contains('i')
                    && !password.Contains('o')
                    && !password.Contains('l');
            };

            yield return static (string password) =>
            {
                if (password.Length < 4)
                {
                    return false;
                }

                char? firstPairChar = null;

                for (int i = 1; i < password.Length; i++)
                {
                    if (password[i - 1] != password[i])
                    {
                        continue;
                    }

                    if (firstPairChar == null)
                    {
                        firstPairChar = password[i];
                        continue;
                    }

                    if (firstPairChar != password[i])
                    {
                        return true;
                    }
                }

                return false;
            };
        }
    }

    public static string RunTask(
        string previousPassword,
        IEnumerable<Func<string, bool>> ruleSet,
        string charSet = LetterLookup)
    {
        if (charSet.Length < 2)
        {
            throw new ArgumentException("the provided char set needs to have at least to characters");
        }

        previousPassword = previousPassword.Trim().ToLower();

        foreach (char c in previousPassword)
        {
            if (!charSet.Contains(c))
            {
                throw new ArgumentException(
                    $"the letter '{c}' in the provided password doesn't appear in the used char set");
            }
        }

        string newPassword = previousPassword;

        do
        {
            char[] chars = newPassword.ToCharArray();

            int currPos = chars.Length - 1;

            while (charSet.IndexOf(chars[currPos]) == charSet.Length - 1
                && currPos >= 0)
            {
                chars[currPos] = charSet[0];
                currPos--;
            }

            if (currPos < 0)
            {
                chars[^1] = charSet[1];
            }
            else
            {
                chars[currPos] = charSet[charSet.IndexOf(chars[currPos]) + 1];
            }

            StringBuilder sb = new();
            newPassword = sb.Append(chars).ToString();

            if (newPassword == previousPassword)
            {
                throw new OperationCanceledException($"there is no valid next password for '{previousPassword}'");
            }
        }
        while (ruleSet.Any((Func<string, bool> rule) => !rule(newPassword)));

        return newPassword;
    }

    public static string RunTask(
        string previousPassword,
        string charSet = LetterLookup)
    {
        return RunTask(previousPassword, DefaultRules, charSet);
    }
}
