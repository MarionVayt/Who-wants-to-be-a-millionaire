using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        string recordFile = "Records.txt";
        string[] questionFiles = { "Easy.txt", "Medium.txt", "Hard.txt" };
        bool playAgain = true;

        while (playAgain)
        {
            Console.Clear();
            Logo.StartLogo();

            string playerName = Utils.GetValidUsername();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Вітаю, {playerName}! Почнемо гру.");
            Console.ResetColor();

            int score = 0;

            for (int i = 0; i < questionFiles.Length && playAgain; i++)
            {
                List<Question> questions = QuestionLoader.LoadQuestions(questionFiles[i]);
                List<string> hints = new List<string> { "50/50", "Допомога друга", "Допомога залу" };

                Utils.GetDifficultyLevel(i);

                foreach (var question in questions)
                {
                    if (!PlayManager.PlayQuestion(question, hints, ref score))
                    {
                        RecordManager.SaveRecord(playerName, score, recordFile);
                        playAgain = Utils.AskForRestart(recordFile);
                        break;
                    }
                }
            }

            if (playAgain)
            {
                Console.WriteLine($"\n--- Вітаємо, {playerName}! Ви перемогли! Ваш рахунок: {score} ---");
                RecordManager.SaveRecord(playerName, score, recordFile);
                playAgain = Utils.AskForRestart(recordFile);
            }
        }

        Logo.FinishLogo();
    }
}