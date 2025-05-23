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
            bool gameover = false;
            Console.Clear();
            Logo.StartLogo();

            string playerName = Utils.GetValidUsername();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Вітаю, {playerName}! Почнемо гру.");
            Console.ResetColor();

            int score = 0;

            for (int i = 0; i < questionFiles.Length && !gameover; i++)
            {
                List<Question> questions = QuestionLoader.LoadQuestions(questionFiles[i]);
                List<string> hints = new List<string> { "50/50", "Допомога друга", "Допомога залу" };

                Utils.GetDifficultyLevel(i);

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
        }

        Logo.FinishLogo();
    }
}