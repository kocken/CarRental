using Logic;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using TestClient;

namespace ConsoleClient
{
    class Program
    {
        static BusinessLogic Logic = new BusinessLogic();
        static string[] Commands = new string[] { "Quit", "Clear",
            "AddCar", "RemoveCar","AddCustomer","ChangeCustomer","RemoveCustomer", "GetAvailableCars", "CreateBooking", "RemoveBooking", "ReturnCar" };

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
                    Console.WriteLine($"\"{input}\" is not a valid command, choose an option from the command list");
                }
                else
                {
                    input = input.ToLower();
                    ExecuteCommand(input);
                }
                if (input != "clear")
                {
                    Console.WriteLine(); // adds some spacing between command input
                }
            }
        }

        static void ExecuteCommand(string command)
        {
            try
            {
                switch (command)
                {
                    case "quit":
                        return;

                    case "clear":
                        Console.Clear();
                        break;

                    case "addcar":
                        Logic.AddCar(
                            GetStringParameterInput("registration number"),
                            GetStringParameterInput("brand"),
                            GetStringParameterInput("model"),
                            GetIntParameterInput("year"));
                        Console.WriteLine("Added car");
                        break;

                    case "removecar":
                        Logic.RemoveCar(GetObjectFromListInput(Logic.GetCars(), "car"));
                        Console.WriteLine("Removed car");
                        break;

                    case "addcustomer":
                        Logic.AddCustomer(
                            GetStringParameterInput("first name"),
                            GetStringParameterInput("last name"),
                            GetStringParameterInput("telephonenumber"),
                            GetStringParameterInput("email"));
                        Console.WriteLine("Added customer");
                        break;

                    

                    case "removecustomer":
                        Logic.RemoveCustomer(GetObjectFromListInput(Logic.GetCustomers(), "customer"));
                        Console.WriteLine("Removed customer");
                        break;

                    case "getavailablecars":
                        List<Car> cars = Logic.GetAvailableCars(
                            GetDateTimeParameterInput("from date"),
                            GetDateTimeParameterInput("to date"));
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

                    case "createbooking":
                        Logic.CreateBooking(
                            GetObjectFromListInput(Logic.GetCars(), "car"),
                            GetObjectFromListInput(Logic.GetCustomers(), "customer"), 
                            GetDateTimeParameterInput("booking start time"),
                            GetDateTimeParameterInput("booking end time"));
                        Console.WriteLine("Created booking");
                        break;

                    case "removebooking":
                        Logic.RemoveBooking(GetObjectFromListInput(Logic.GetBookings(), "booking"));
                        Console.WriteLine("Removed booking");
                        break;

                    case "returncar":
                        Logic.ReturnCar(GetObjectFromListInput(Logic.GetBookings(), "booking"));
                        Console.WriteLine("Returned car");
                        break;

                    default:
                        Console.WriteLine($"There's no current support for command \"{command}\"");
                        break;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid method parameters.");
            }
            catch (EmptyListException e)
            {
                Console.WriteLine("Failed to execute command. " + e.Message);
            }
        }

        public static string GetStringParameterInput(string parameterName)
        {
            while(true)
            {
                Console.WriteLine($"Assign the \"{parameterName}\" parameter (Type: string)");
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

        public static int GetIntParameterInput(string parameterName)
        {
            while (true)
            {
                Console.WriteLine($"Assign the \"{parameterName}\" parameter (Type: int)");
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

        public static DateTime GetDateTimeParameterInput(string parameterName)
        {
            while (true)
            {
                Console.WriteLine($"Assign the \"{parameterName}\" parameter (Type: DateTime - assign value in format year-month-day)");
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

        public static T GetObjectFromListInput<T>(List<T> list, string parameterName)
        {
            if (list.Count == 0)
            {
                throw new EmptyListException($"There's no available \"{parameterName}\" choices.");
            }
            while (true)
            {
                Console.WriteLine($"Assign the \"{parameterName}\" parameter by selecting a number from the list");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine((i+1) + ": " + list[i].ToString());
                }
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    if (Int32.TryParse(input, out int number))
                    {
                        if (number >= 1 && number <= (list.Count))
                        {
                            return list[number - 1];
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, enter a number from 1 to " + (list.Count));
                        }
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
