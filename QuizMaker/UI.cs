using System;

namespace QuizApp
{
    public static class UI
    {
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