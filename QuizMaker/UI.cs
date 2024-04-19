using System;

namespace QuizMaker
{
    public static class UI
    {
        public static void RunQuiz()
        {
            Console.WriteLine("Hi! Let's take a QUIZ!");

            // Creating an object of Repository
            Repository repository = new Repository();

            // Adding the question in Repository
            repository.AddQuestion(new Question("What is the color of the sky?", new List<string> { "Red", "Blue", "Purple" }, 1));
            repository.AddQuestion(new Question("How many wheels does a car have?", new List<string> { "4", "5", "6" }, 0));

            // Getting a random question from the Repository
            Question randomQuestion = Logic.GetRandomQuestion(repository);

            // Display the question and choosing options
            Console.WriteLine(randomQuestion.QuestionText);
            for (int i = 0; i < randomQuestion.Answers.Count; i++)
            {
                Console.WriteLine($"{Constants.ChoiceLetters[i]}. {randomQuestion.Answers[i]}");
            }

            // Reading the user input
            string userChoice;
            do
            {
                Console.WriteLine("Please choose A, B, or C:");
                userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    case "A":
                    case "B":
                    case "C":
                        break; // Getting out from the do-while loop if the choice is valid
                    default:
                        Console.WriteLine("Invalid choice! Please choose A, B, or C.");
                        break; // Do-while loop continue if the choice is invalid
                }
            } while (userChoice != "A" && userChoice != "B" && userChoice != "C");

            // Checking the user answer
            Logic.EvaluateAnswer(randomQuestion, userChoice);

            // Serialize the Repository in a xml file
            Logic.SerializeRepository(repository);
        }
    }
}
