using System;

namespace ChipSecuritySystem.Help
{
    public class ConsoleHelper
    {
        /// <summary>
        /// Let's print friendly errors
        /// </summary>
        /// <param name="message">The red text</param>
        public static void PrintError(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Let's print friendly success
        /// </summary>
        /// <param name="message">The friendly message in GREEN</param>
        public static void PrintSuccess(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Print a prompt response as indicate by standard
        /// </summary>
        public static void PrintPrompt()
        {
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey();
        }

    }
}
