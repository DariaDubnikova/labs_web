using System;

namespace CheckIdentifier
{
    public static class Program
    {
        public static bool IsLetter(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }

        public static bool CheckIdentifier(string input)
        {
            if (input == "")
            {
                System.Console.WriteLine("No\nEmpty identifier");
                return false;
            }
            if (!IsLetter(input[0]))
            {
                System.Console.WriteLine("No\nIdentifier must not begin with a digit");
                return false;
            }
            foreach (char ch in input)
            {
                if (!IsLetter(ch) && !char.IsDigit(ch))
                {
                    System.Console.WriteLine("No\nIdentifier must include only letters or digits");
                    return false;
                }
            }
            
            System.Console.WriteLine("Yes");
            return true;
        }

        public static bool CheckArgs(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("No\nIncorrect number of arguments!\nUsage CheckIdentifier.exe <input string>");
                return false;
            }
            return true;
        }


        public static int Main(string[] args)
        {
            if (!CheckArgs(args))
            {
                return 1;
            }

            string identifier = args[0];
            CheckIdentifier(identifier);

            return 0;
        }
    }
}