using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        string recordFile = "Data/Records.txt";
        string[] questionFiles = Directory.GetFiles("Questions", "*.txt");
        bool playAgain = true;

        while (playAgain)
        {
            bool gameover = false;
            Console.Clear();
            Logo.StartLogo();

            string playerName = Utils.GetValidUsername();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Вітаю, {playerName}! Почнемо гру.");
            PrintCategory.Categories();
            int choose = Utils.GetValidCategoryChoice(questionFiles.Length);
            var categorychoosed = new Dictionary<int, string>();
            for (int i = 0; i < questionFiles.Length; i++)
            {
                string filePath = questionFiles[i];
                categorychoosed[i + 1] = filePath;
            }
            string selectedFile = categorychoosed[choose];
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintCategory.Category(selectedFile);
            Console.ResetColor();

            int score = 0;

            for (int i = 0; i < questionFiles.Length && !gameover; i++)
            {
                List<Question> questions = QuestionLoader.LoadQuestions(selectedFile).Skip(1).ToList();
                List<string> hints = new List<string> { "50/50", "Допомога друга", "Допомога залу" };
                

                foreach (var question in questions)
                {
                    if (!PlayManager.PlayQuestion(question, hints, ref score))
                    {
                        RecordManager.SaveRecord(playerName, score, recordFile);
                        gameover = true;
                        break;
                    }
                }

                if (gameover)
                {
                    if (Utils.AskForRestart(recordFile))
                        playAgain = true;
                    else
                        playAgain = false;
                }
            }
            if (!gameover)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🎉 Вітаємо, ви успішно пройшли всі рівні та виграли гру!");
                Console.WriteLine($"Ваш фінальний рахунок: {score} балів.");
                Console.ResetColor();

                RecordManager.SaveRecord(playerName, score, recordFile);

                if (Utils.AskForRestart(recordFile))
                    playAgain = true;
                else
                    playAgain = false;
            }
        }

        Logo.FinishLogo();
    }
}