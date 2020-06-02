using System;
using System.Linq;

namespace PasswordStrength
{
    public class Program
    {

        public static int PasswordStrengthByNumberOfCharacters(string password)
        {
            return 4 * password.Length;
        }

        public static int PasswordStrengthByNumberOfDigits(string password)
        {
            int numberOfDigits = password.Count(char.IsDigit);
            return numberOfDigits *= 4;
        }

        public static int PasswordStrengthByNumberOfUpperCaseLetters(string password)
        {
            int numberOfUpperCaseLetters = password.Count(char.IsUpper);
            if (numberOfUpperCaseLetters != 0)
            {
                return (password.Length - numberOfUpperCaseLetters) * 2;
            }
            return 0;
        }

        public static int PasswordStrengthByNumberOfLowerCaseLetters(string password)
        {
            int numberOfLowerCaseLetters = password.Count(char.IsLower);
            if (numberOfLowerCaseLetters != 0)
            {
                return (password.Length - numberOfLowerCaseLetters) * 2;
            }
            return 0;
        }

        public static int PasswordStrengthByOnlyLetters(string password)
        {
            int numberOfLetters = password.Count(char.IsLetter);
            if (numberOfLetters == password.Length)
            {
                return numberOfLetters;
            }
            return 0;
        }

        public static int PasswordStrengthByOnlyDigits(string password)
        {
            int numberOfDigits = password.Count(char.IsDigit);
            if (numberOfDigits == password.Length)
            {
                return numberOfDigits;
            }
            return 0;
        }

        public static int PasswordStrengthByNumberOfReapetedSymbols(string password)
        {
            int numberOfReapetedSymbols = 0;
            int count = 0;
            foreach (var letter in password.Distinct().ToArray())
            {
                count = password.Count(chr => chr == letter);
                if (count != 1)
                {
                    numberOfReapetedSymbols += count;
                }
            }
            return numberOfReapetedSymbols;
        }

        public static int PasswordStrength(string password)
        {
            int passwordStrenght = 0;
            passwordStrenght += PasswordStrengthByNumberOfCharacters(password);
            passwordStrenght += PasswordStrengthByNumberOfDigits(password);
            passwordStrenght += PasswordStrengthByNumberOfUpperCaseLetters(password);
            passwordStrenght += PasswordStrengthByNumberOfLowerCaseLetters(password);
            passwordStrenght -= PasswordStrengthByOnlyLetters(password);
            passwordStrenght -= PasswordStrengthByOnlyDigits(password);
            passwordStrenght += PasswordStrengthByNumberOfReapetedSymbols(password);
            return passwordStrenght;
        }

        public static bool IsCorrectPassword(string password)
        {
            foreach (char character in password)
            {
                if (!char.IsUpper(character) && !char.IsLower(character) && !char.IsDigit(character))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckArgs(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Incorrect number of arguments!\nUsage PasswordStrength.exe <input file name> <output file name>");
                return false;
            }
            return true;
        }

        static int Main(string[] args)
        {
            if (!CheckArgs(args))
            {
                return 1;
            }

            string password = args[0];
            if (!IsCorrectPassword(password))
            {
                return 1;
            }

            int passwordStrenght = PasswordStrength(password);
            Console.WriteLine(passwordStrenght);
            return 0;
        }
    }
}
