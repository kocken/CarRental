using Logic;
using System;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic logic = new BusinessLogic();
            string[] commands = new string[] { "Clear", "Quit", "TestCount", "AddCar" };

            while(true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[COMMANDS]");
                foreach(string s in commands)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                string input = Console.ReadLine();
                if (commands.Any(c => c.ToLower() == input.ToLower()))
                {
                    input = input.ToLower();
                    switch(input) {
                        case "clear":
                            Console.Clear();
                            break;
                        case "quit":
                            return;
                        case "testcount":
                            Console.WriteLine(logic.TestCount());
                            break;
                        case "addcar":
                            logic.AddCar(GetStringParameter("registration number"), GetStringParameter("brand"), 
                                GetStringParameter("model"), GetIntParameter("year"));
                            Console.WriteLine("Added car");
                            break;
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

        public static string GetStringParameter(string parameterName)
        {
            while(true)
            {
                Console.WriteLine($"Assign a \"{parameterName}\" parameter (Type: string)");
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("A valid input is required");
                }
            }
        }

        public static int GetIntParameter(string parameterName)
        {
            while (true)
            {
                Console.WriteLine($"Assign a \"{parameterName}\" parameter (Type: int)");
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    if (Int32.TryParse(input, out int number))
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, a valid number is required");
                    }
                }
                else
                {
                    Console.WriteLine("A valid input is required");
                }
            }
        }
    }
}
