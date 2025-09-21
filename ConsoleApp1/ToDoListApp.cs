using System;
using System.Collections.Generic;

namespace MyConsoleApps
{
    public static class ToDoListApp
    {
        private static List<string> tasks = new List<string>();

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== To-Do List App ===");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        private static void ViewTasks()
        {
            Console.WriteLine("\nYour Tasks:");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet!");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }

        private static void AddTask()
        {
            Console.Write("\nEnter a new task: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task.Trim());
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }
        }

        private static void RemoveTask()
        {
            ViewTasks();
            if (tasks.Count == 0) return;

            Console.Write("\nEnter the task number to remove: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index >= 1 && index <= tasks.Count)
            {
                Console.WriteLine($"Removed: {tasks[index - 1]}");
                tasks.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }
}
