/// \file PlayManager.cs
/// \brief Manages the gameplay loop for individual questions.

/// <summary>
/// Static class that handles the display and interaction logic for a quiz question,
/// including processing user input, checking correctness, and updating the score.
/// </summary>
static class PlayManager
{
    /// <summary>
    /// Displays a question, processes the user's answer, handles hints, and updates the score.
    /// </summary>
    /// <param name="question">The question to present to the user.</param>
    /// <param name="hints">List of remaining available hints.</param>
    /// <param name="score">Reference to the player's current score (modified if correct).</param>
    /// <returns>True if the user answered correctly; false if incorrect (game over).</returns>
    public static bool PlayQuestion(Question question, List<string> hints, ref int score)
    {
        while (true)
        {
            Print.QuestionAndAnswers(question);

            Print.Answer();

            string input = Console.ReadLine()?.Trim().ToLower();
            
            if (input == "hint")
            {
                HintSystem.ShowHintMenu(question, hints);
            }
            else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            {
                if (question.CorrectAnswer == choice)
                {
                    Print.True(question);
                    score += question.Point;
                    return true;
                }
                else
                {
                    Print.False(); 
                    return false;
                }
            }
            else
            {
                Print.Error();
            }
        }
    }
}
