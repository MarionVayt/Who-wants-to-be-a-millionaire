using System;
using System.Collections.Generic;

static class HintSystem
{
    public static void ShowHintMenu(Question question, List<string> hints)
    {
        if (hints.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Всі підказки використано.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nДоступні підказки:");
        for (int i = 0; i < hints.Count; i++)
            Console.WriteLine($"{i + 1}. {hints[i]}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("Виберіть підказку: ");
        Console.ResetColor();
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= hints.Count)
        {
            UseHint(hints[choice - 1], question);
            hints.RemoveAt(choice - 1);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некоректний вибір.");
            Console.ResetColor();
        }
    }

    static void UseHint(string hint, Question question)
    {
        switch (hint)
        {
            case "50/50":
                Console.WriteLine($"1. {question.Answers[question.CorrectAnswer - 1]}   2. {Utils.GetRandomWrongAnswer(question)}");
                break;
            case "Допомога друга":
            case "Допомога залу":
                Console.WriteLine($"Порада: {question.Answers[question.CorrectAnswer - 1]}");
                break;
        }
    }
}