using System;

namespace MyConsoleApps
{
    public static class CalculatorApp
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Calculator ===");

            while (true)
            {
                Console.WriteLine("\nChoose operation: add, subtract, multiply, divide, quit");
                string op = Console.ReadLine().Trim().ToLower();

                if (op == "quit") break;

                Console.Write("Enter first number: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                double b = double.Parse(Console.ReadLine());

                switch (op)
                {
                    case "add":
                        Console.WriteLine($"Result: {a + b}");
                        break;
                    case "subtract":
                        Console.WriteLine($"Result: {a - b}");
                        break;
                    case "multiply":
                        Console.WriteLine($"Result: {a * b}");
                        break;
                    case "divide":
                        if (b == 0)
                            Console.WriteLine("Cannot divide by zero!");
                        else
                            Console.WriteLine($"Result: {a / b}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }
            }
        }
    }
}
