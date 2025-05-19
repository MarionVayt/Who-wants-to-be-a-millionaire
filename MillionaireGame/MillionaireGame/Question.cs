using System.Collections.Generic;
using System.IO;

class Question
{
    public string Text { get; }
    public string[] Answers { get; }
    public int CorrectAnswer { get; }

    public Question(string text, string[] answers, int correctAnswer)
    {
        Text = text;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }
}

static class QuestionLoader
{
    public static List<Question> LoadQuestions(string filePath)
    {
        var questions = new List<Question>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('|');
            if (parts.Length == 6)
                questions.Add(new Question(parts[0], new[] { parts[1], parts[2], parts[3], parts[4] }, int.Parse(parts[5])));
        }
        return questions;
    }
}