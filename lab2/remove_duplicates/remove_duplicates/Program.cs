using System;
using System.Linq;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(args[0].Distinct().ToArray());
            }
            else
            {
                Console.WriteLine("Incorrect number of arguments!\nUsage remove_duplicates.exe <input string>");
            }
        }
    }
}
