// See https://aka.ms/new-console-template for more information
using System;
using Spectre.Console;
using TaskList.Services;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            Console.Clear();
            TaskService TS = new TaskService();
            var welcomeFiglet = new FigletText("Welcome To Task CLI")
                {
                    Justification = Justify.Center
                }
                .Color(Color.Blue);
            AnsiConsole.Write(welcomeFiglet);
            while (running)
            {
                var features = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose your [green]Option[/]")
                        .AddChoices("Read Task", "Add Task", "Update", "Delete", "Exit"));
                switch (features)
                {
                    case "Read Task":
                        AnsiConsole.MarkupLine($"You Selected: [green]{features}[/]");
                        TS.ReadTask();
                        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                        Console.ReadKey(true);
                        break;
                    case "Add Task":
                        AnsiConsole.MarkupLine($"You Selected: [green]{features}[/]");
                        TS.AddTask();
                        break;
                    case "Update":
                        AnsiConsole.MarkupLine($"You Selected: [green]{features}[/]");
                        break;
                    case "Delete":
                        AnsiConsole.MarkupLine($"You Selected: [green]{features}[/]");
                        break;
                    case "Exit":
                        running = false;
                        break;
                    default:
                        AnsiConsole.MarkupLine("Not Found");
                        break;
                }
            }
        }
    }
}

