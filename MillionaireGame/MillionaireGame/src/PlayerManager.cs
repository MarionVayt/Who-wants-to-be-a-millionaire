using System;
using System.Collections.Generic;

static class PlayManager
{
    public static bool PlayQuestion(Question question, List<string> hints, ref int score)
    {
        while (true)
        {
            Console.WriteLine($"\n{question.Text}");
            for (int i = 0; i < 4; i++)
                Console.WriteLine($"{i + 1}. {question.Answers[i]}");

            Console.Write("\nВведіть 'hint' або номер відповіді (1-4): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "hint")
            {
                HintSystem.ShowHintMenu(question, hints);
            }
            else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            {
                if (question.CorrectAnswer == choice)
                {
                    Console.WriteLine("Правильно!");
                    score += 10;
                    return true;
                }
                else
                {
                    Console.WriteLine("Неправильно! Гра закінчена.");
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