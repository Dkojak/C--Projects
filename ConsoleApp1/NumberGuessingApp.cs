using System;

namespace MyConsoleApps
{
    public static class NumberGuessingApp
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Number Guessing Game ===");
            Random rand = new Random();
            int target = rand.Next(1, 101); // pick number 1–100
            int attempts = 0;

            while (true && attempts <= 3)
            {
                Console.Write("Guess a number between 1 and 100: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int guess))
                {
                    attempts++;
                    if (guess < target)
                        Console.WriteLine("Too low! Try again.");
                    else if (guess > target)
                        Console.WriteLine("Too high! Try again.");
                    else
                    {
                        Console.WriteLine($"🎉 Correct! You guessed it in {attempts} attempts.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
            }
        }
    }
}
