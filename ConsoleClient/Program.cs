using Logic;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static BusinessLogic Logic = new BusinessLogic();
        static string[] Commands = new string[] { "Quit", "Clear", "AddCar", "GetAvailableCars" };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[COMMANDS]");
                foreach(string s in Commands)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                string input = Console.ReadLine();
                if (!Commands.Any(c => c.ToLower() == input.ToLower()))
                {
                    Console.WriteLine($"\"{input}\" is not supported, use an alternative from the command list");
                }
                else
                {
                    input = input.ToLower();
                    switch (input)
                    {
                        case "quit":
                            return;
                        case "clear":
                            Console.Clear();
                            break;
                        case "addcar":
                            Logic.AddCar(GetStringParameter("registration number"), GetStringParameter("brand"),
                                GetStringParameter("model"), GetIntParameter("year"));
                            Console.WriteLine("Added car");
                            break;
                        case "getavailablecars":
                            List<Car> cars = Logic.GetAvailableCars(GetDateTimeParameter("from date"), GetDateTimeParameter("to date"));
                            if (cars.Count == 0)
                            {
                                Console.WriteLine("No available cars");
                            }
                            else
                            {
                                Console.WriteLine("[AVAILABLE CARS]");
                                foreach (Car c in cars)
                                {
                                    Console.WriteLine(c.ToString());
                                }
                            }
                            break;
                        default:
                            Console.WriteLine($"There's no current support for command \"{input}\"");
                            break;
                    }
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

        public static DateTime GetDateTimeParameter(string parameterName)
        {
            while (true)
            {
                Console.WriteLine($"Assign a \"{parameterName}\" parameter (Type: DateTime - assign value in format year-month-day)");
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    if (DateTime.TryParse(input, out DateTime date))
                    {
                        return date;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, a valid date is required (format: year-month-day)");
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
