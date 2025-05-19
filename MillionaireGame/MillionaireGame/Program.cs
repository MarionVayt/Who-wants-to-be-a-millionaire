using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string recordFile = "Records.txt";
        string[] questionFiles = { "Easy.txt", "Medium.txt", "Hard.txt" };
        bool playAgain = true;

        while (playAgain)
        {
            Console.Clear();
            Console.WriteLine("Ласкаво просимо до гри 'Хто хоче стати мільйонером'!");

            string playerName = Utils.GetValidUsername();
            Console.WriteLine($"Вітаю, {playerName}! Почнемо гру.");

            int score = 0;

            for (int i = 0; i < questionFiles.Length && playAgain; i++)
            {
                List<Question> questions = QuestionLoader.LoadQuestions(questionFiles[i]);
                List<string> hints = new List<string> { "50/50", "Допомога друга", "Допомога залу" };

                Console.WriteLine($"\n--- {Utils.GetDifficultyLevel(i)} рівень ---");

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

        Console.WriteLine("\n--- Дякуємо за гру! До побачення! ---");
    }
}