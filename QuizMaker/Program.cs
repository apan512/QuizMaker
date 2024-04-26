using QuizMaker;
using System;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Console.WriteLine("Welcome to our Quiz Maker!");

            logic.CreatingQuestions();
            

        }
    }
}