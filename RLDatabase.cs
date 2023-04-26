using System;

namespace RhythmsGonnaGetYou
{
    public class RLDatabase
    {
        public static void WelcomeMessage()
        {

        }

        public static void Menu()
        {

        }

        // Helper Functions
        public static int PromptForInt(string prompt)
        {
            var inputWasInteger = false;
            int inputAsInteger = 0;

            while (!inputWasInteger)
            {
                var userInput = PromptForString(prompt);
                var isThisGoodInput = int.TryParse(userInput, out inputAsInteger);

                if (isThisGoodInput == true)
                {
                    inputWasInteger = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid number. Please try again");
                    // DIALOGUE REFRESHER
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true).Key.ToString();
                    Console.Clear();
                }
            }
            return inputAsInteger;
        }

        public static string PromptForChar(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadKey(true).Key.ToString().ToUpper();
            Console.Clear();
            return userInput;
        }

        public static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }

        public void DialogueRefresher()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true).Key.ToString();
            Console.Clear();
        }

        static void Debug(int num, bool flag = false)
        {
            Console.WriteLine($"Debug {num}");
            if (flag == true)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true).Key.ToString();
            }
        }

    }
}