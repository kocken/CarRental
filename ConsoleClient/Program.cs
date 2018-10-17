using System;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = new string[] { "quit" };
            while(true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Commands:");
                foreach(string s in commands)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                string input = Console.ReadLine();
                if (commands.Any(c => c == input))
                {
                    switch(input) {
                        case "quit":
                            return;
                        default:
                            Console.WriteLine($"There's no current support for command \"{input}\"");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"\"{input}\" is not supported, use an alternative from the command list");
                }
                Console.WriteLine();
            }
        }
    }
}
