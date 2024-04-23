using System;
using System.Collections.Generic;

namespace QuizApp
{
    public static class UI
    {
        public static void RunQuizApp()
        {
            Console.WriteLine("Welcome to the Quiz Maker App!");

            Console.WriteLine("1. Add Questions");
            Console.WriteLine("2. Start Quiz");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddQuestions();
                    break;
                case "2":
                    QuizLogic.RunQuiz();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    RunQuizApp();
                    break;
            }
        }

        public static void AddQuestions()
        {
            Console.WriteLine("\nAdding questions to the repository.");

            bool addingQuestions = true;
            while (addingQuestions)
            {
                string questionText = GetUserInput("Enter the question (or type 'done' to finish):");
                if (questionText.ToLower() == "done")
                {
                    addingQuestions = false;
                    break;
                }

                List<string> answers = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    answers.Add(GetUserInput($"Enter answer {i + 1}:"));
                }

                int correctAnswerIndex;
                while (true)
                {
                    string input = GetUserInput("Enter the index of the correct answer (0-based):");
                    if (int.TryParse(input, out correctAnswerIndex) && correctAnswerIndex >= 0 && correctAnswerIndex < answers.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid index.");
                    }
                }

                QuizLogic.AddQuestion(questionText, answers, correctAnswerIndex);
            }

            Console.WriteLine("\nQuestions added successfully.");
            RunQuizApp(); 
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine();
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}