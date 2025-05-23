using System;
using System.Collections.Generic;

static class PlayManager
{
    public static bool PlayQuestion(Question question, List<string> hints, ref int score)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{question.Text}");
            Console.ResetColor();
            for (int i = 0; i < 4; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{i + 1}. {question.Answers[i]}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\nВведіть 'hint' або номер відповіді (1-4): ");
            Console.ResetColor();
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "hint")
            {
                HintSystem.ShowHintMenu(question, hints);
            }
            else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            {
                if (question.CorrectAnswer == choice)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Правильно!");
                    Console.ResetColor();
                    score += 10;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неправильно! Гра закінчена.");
                    Console.ResetColor();   
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Некоректний ввід.");
            }
        }
    }
}