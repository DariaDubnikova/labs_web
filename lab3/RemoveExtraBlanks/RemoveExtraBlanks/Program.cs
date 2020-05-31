using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static string RemoveExtraBlanks(string stringOfFile)
        {
            stringOfFile = stringOfFile.Trim();
            return Regex.Replace(stringOfFile, "\\s+|\\t+", " ");
        }

        public static bool RewriteFileWithoutExtraBlanks(string inputFileName, string outputFileName)
        {
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Input file doesn't exist");
                return false;
            }

            StreamReader inputFile = new StreamReader(inputFileName);
            StreamWriter outputFile = new StreamWriter(outputFileName);
            string stringOfFile;

            while ((stringOfFile = inputFile.ReadLine()) != null)
            {
                outputFile.WriteLine(RemoveExtraBlanks(stringOfFile));
            }

            inputFile.Close();
            outputFile.Close();

            return true;
        }

        public static bool CheckArgs(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("Incorrect number of arguments!\nUsage RemoveExtraBlanks.exe <input file name> <output file name>");
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

            string inputFileName = args[0];
            string outputFileName = args[1];

            if (!RewriteFileWithoutExtraBlanks(inputFileName, outputFileName))
            {
                return 1;
            }

            return 0;
        }
    }
}

