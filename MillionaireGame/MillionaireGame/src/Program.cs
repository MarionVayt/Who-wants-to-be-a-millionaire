/// \file Program.cs
/// \brief Entry point for the quiz game.
/// 
/// This file contains the main game loop logic, including player interaction,
/// category and question selection, scoring, and record saving.

/// <summary>
/// Main class containing the game entry point.
/// </summary>
class Program
{
    /// <summary>
    /// The main method that starts and manages the entire quiz game session.
    /// </summary>
    static void Main()
    {
        // Enable UTF-8 encoding for proper character display
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // File path to store user records
        string recordFile = "Data/Records.txt";

        bool playAgain = true;

        // Main game restart loop
        while (playAgain)
        {
            Console.Clear();
            Logo.StartLogo(); // Display game logo

            // Get a valid player name
            string playerName = Utils.GetValidUsername();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Вітаю, {playerName}! Почнемо гру.");
            Console.ResetColor();

            // Initialize category manager and game state
            CategoryManager categoryManager = new CategoryManager();
            int score = 0;
            bool gameover = false;
            bool gameContinue = true;

            // Loop through categories
            while (categoryManager.HasCategories && !gameover)
            {
                categoryManager.ShowCategories();
                int choose = Utils.GetValidCategoryChoice(categoryManager.CategoryCount());

                string selectedFile = categoryManager.ChooseCategory(choose);
                categoryManager.ShowCategory(selectedFile);

                List<Question> questions = Question.LoadQuestions(selectedFile);
                List<string> hints = new List<string> { "50/50", "Допомога друга", "Допомога залу" };

                // Ask each question in the selected category
                foreach (var question in questions)
                {
                    if (!PlayManager.PlayQuestion(question, hints, ref score))
                    {
                        // Player answered incorrectly
                        RecordManager.SaveRecord(playerName, score, recordFile);
                        gameover = true;
                        break;
                    }
                    else
                    {
                        // Player answered correctly and chooses to continue or not
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

                // Prepare next category if available
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

            // Final message after game ends
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            if (!gameover)
                Console.WriteLine("\n🎉 Ви пройшли всі доступні категорії!");
            Console.WriteLine($"Ваш фінальний баланс: {score}$.");
            Console.ResetColor();

            RecordManager.SaveRecord(playerName, score, recordFile);

            // Ask if the player wants to play again
            playAgain = Utils.AskForRestart(recordFile);
        }

        // Display closing logo
        Logo.FinishLogo();
    }
}
