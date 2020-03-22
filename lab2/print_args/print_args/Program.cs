using System;

namespace print_args
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Number of arguments: " + args.Length);
                Console.Write("Arguments: ");
                foreach (string argument in args)
                {
                    Console.Write(argument + " ");
                }
            }
            else
            {
                Console.WriteLine("No parameters were specified!");
            }
        }
    }
}
