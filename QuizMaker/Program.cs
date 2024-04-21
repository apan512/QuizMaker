using System;
using System.Collections.Generic;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Quiz Maker App!");

            // Adding questions
            UI.ShowMessage("Let's add some questions to the repository.");

            bool addingQuestions = true;
            while (addingQuestions)
            {
                string questionText = UI.GetUserInput("Enter the question (or type 'done' to finish):");
                if (questionText.ToLower() == "done")
                {
                    addingQuestions = false;
                    break;
                }

                List<string> answers = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    answers.Add(UI.GetUserInput($"Enter answer {i + 1}:"));
                }
                int correctAnswerIndex = int.Parse(UI.GetUserInput("Enter the index of the correct answer (0-based):"));

                QuizLogic.AddQuestion(questionText, answers, correctAnswerIndex);
            }

            // Clearing screen
            Console.Clear();
            UI.ShowMessage("Quiz is starting!");

            // Quiz
            int score = 0;
            for (int i = 0; i < 3; i++) 
            {
                var question = QuizLogic.GetRandomQuestion();
                UI.ShowMessage($"\nQuestion {i + 1}: {question.QuestionText}");
                for (int j = 0; j < question.Answers.Count; j++)
                {
                    UI.ShowMessage($"{j + 1}. {question.Answers[j]}");
                }
                int selectedAnswerIndex = int.Parse(UI.GetUserInput("Enter your answer (1-based):")) - 1;
                if (QuizLogic.IsAnswerCorrect(question, selectedAnswerIndex))
                {
                    UI.ShowMessage("Correct!");
                    score++;
                }
                else
                {
                    UI.ShowMessage("Incorrect!");
                }
            }

            UI.ShowMessage($"\nQuiz complete! Your score is {score}/{3}");

            // Clear repository after quiz
           // QuizLogic.ClearRepository();
        }
    }
}