class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        string recordFile = "Data/Records.txt";

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

            CategoryManager categoryManager = new CategoryManager();
            int score = 0;
            bool gameover = false;
            bool gameContinue = true;

            while (categoryManager.HasCategories && !gameover)
            {
                categoryManager.ShowCategories();
                int choose = Utils.GetValidCategoryChoice(categoryManager.CategoryCount());

                string selectedFile = categoryManager.ChooseCategory(choose);
                categoryManager.ShowCategory(selectedFile);

                List<Question> questions = Question.LoadQuestions(selectedFile);
                List<string> hints = new List<string> { "50/50", "Допомога друга", "Допомога залу" };

                foreach (var question in questions)
                {
                    if (!PlayManager.PlayQuestion(question, hints, ref score))
                    {
                        RecordManager.SaveRecord(playerName, score, recordFile);
                        gameover = true;
                        break;
                    }
                    else
                    {
                        if (!Utils.AskForContinueCategory(ref score))
                        {
                            gameContinue = false;
                            break;
                        }
                    }
                }
                if (!gameContinue)
                {
                    gameover = true;
                    break;
                }

                if (!gameover && gameContinue)
                {
                    categoryManager.RemoveCategory(selectedFile);

                    if (categoryManager.HasCategories)
                    {
                        if (!Utils.AskForContinueNextCategory(ref score))
                        {
                            gameover = true;
                            break;
                        }
                    }
                }
            }
        
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            if (!gameover)
                Console.WriteLine("\n🎉 Ви пройшли всі доступні категорії!");
            Console.WriteLine($"Ваш фінальний баланс: {score}$.");
            Console.ResetColor();

            RecordManager.SaveRecord(playerName, score, recordFile);

            playAgain = Utils.AskForRestart(recordFile);

        }

        Logo.FinishLogo();
    }
}