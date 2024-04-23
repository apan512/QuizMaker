using QuizMaker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizApp
{
    public static class QuizLogic
    {
        public static Repository LoadRepository()
        {
            if (File.Exists(Constants.RepositoryFilePath))
            {
                XmlSerializer reader = new XmlSerializer(typeof(Repository));
                using (FileStream file = File.OpenRead(Constants.RepositoryFilePath))
                {
                    return (Repository)reader.Deserialize(file);
                }
            }
            else
            {
                return new Repository();
            }
        }

        public static void SerializeRepository(Repository repository)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Repository));
            using (FileStream file = File.Create(Constants.RepositoryFilePath))
            {
                writer.Serialize(file, repository);
            }
        }

        public static void AddQuestion(string questionText, List<string> answers, int correctAnswerIndex)
        {
            var repository = LoadRepository();
            var question = new Question
            {
                QuestionText = questionText,
                Answers = answers,
                CorrectAnswerIndex = correctAnswerIndex
            };
            repository.Questions.Add(question);
            SerializeRepository(repository);
        }

        public static Question GetRandomQuestion()
        {
            var repository = LoadRepository();
            Random random = new Random();
            int index = random.Next(repository.Questions.Count);
            return repository.Questions[index];
        }

        public static bool IsAnswerCorrect(Question question, int selectedAnswerIndex)
        {
            return selectedAnswerIndex == question.CorrectAnswerIndex;
        }

        public static void RunQuiz()
        {
            var repository = LoadRepository();

            if (repository.Questions.Count == 0)
            {
                UI.ShowMessage("No questions available. Please add questions to the repository first.");
                return;
            }

            UI.ShowMessage("Quiz is starting!");

            int score = 0;
            foreach (var question in repository.Questions)
            {
                UI.ShowMessage($"\nQuestion: {question.QuestionText}");
                for (int j = 0; j < question.Answers.Count; j++)
                {
                    UI.ShowMessage($"{j + 1}. {question.Answers[j]}");
                }

               
                int selectedAnswerIndex;
                while (true)
                {
                    string input = UI.GetUserInput("Enter your answer (1-based):");
                    if (int.TryParse(input, out selectedAnswerIndex) && selectedAnswerIndex >= 1 && selectedAnswerIndex <= question.Answers.Count)
                    {
                        selectedAnswerIndex--; 
                        break;
                    }
                    else
                    {
                        UI.ShowMessage("Invalid input. Please enter a valid answer index.");
                    }
                }

                if (IsAnswerCorrect(question, selectedAnswerIndex))
                {
                    UI.ShowMessage("Correct!");
                    score++;
                }
                else
                {
                    UI.ShowMessage("Incorrect!");
                }
            }

            UI.ShowMessage($"\nQuiz complete! Your score is {score}/{repository.Questions.Count}");
        }


        public static void ClearRepository()
        {
            File.Delete(Constants.RepositoryFilePath);
        }
    }
}