using System;
using System.Collections.Generic;
namespace MyConsoleApps
{
    public class Program
    {
        static Dictionary<string, string> accounts = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to My Console Apps ===");

            // Login or Register
            while (true)
            {
                Console.WriteLine("\nDo you have an account? (yes/no)");
                string response = Console.ReadLine().Trim().ToLower();

                if (response == "yes")
                {
                    if (Login()) break;
                }
                else if (response == "no")
                {
                    Register();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please type yes or no.");
                }
            }

            // Main Menu
            ShowMenu();
        }

        static void Register()
        {
            Console.Write("Choose a username: ");
            string username = Console.ReadLine();

            Console.Write("Choose a password: ");
            string password = Console.ReadLine();

            if (accounts.ContainsKey(username))
            {
                Console.WriteLine("Username already exists! Try another one.");
            }
            else
            {
                accounts[username] = password;
                Console.WriteLine("Account created successfully!");
            }
        }

        static bool Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (accounts.ContainsKey(username) && accounts[username] == password)
            {
                Console.WriteLine($"\nWelcome back, {username}!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }
        }

        static void ShowMenu()
        {
            while (true)
{
    Console.WriteLine("\n=== Console App Hub ===");
    Console.WriteLine("1. Calculator");
    Console.WriteLine("2. Who Wants to Be a Millionaire");
    Console.WriteLine("3. Number Guessing Game");
    Console.WriteLine("4. To-Do List");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1": CalculatorApp.Run(); break;
        case "2": MillionaireGameApp.Run(); break;
        case "3": NumberGuessingApp.Run(); break;
        case "4": ToDoListApp.Run(); break;
        case "5": return;
        default: Console.WriteLine("Invalid choice, try again."); break;
    }
}

        }
    }
}
