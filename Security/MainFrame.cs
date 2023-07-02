using ChipSecuritySystem.CustomExceptions;
using ChipSecuritySystem.Factory;
using ChipSecuritySystem.Help;
using System;
using System.Collections.Generic;

namespace ChipSecuritySystem.Security
{

    /// <summary>
    /// Sealeed class due to Chip Security Measures
    /// </summary>
    internal sealed class Mainframe
    {
        private List<ColorChip> Chips { get; set; }
        /// <summary>
        /// Initiaizler, taken from C/C++ to deconstruct the original default constructor method
        /// </summary>
        private void Initialize()
        {
            Chips = new List<ColorChip>(); //Generic instatiation
        }

        /// <summary>
        /// Construcor
        /// </summary>
        public Mainframe()
        {
            Initialize(); //Call the deconsctucted original initialize method that's private
        }

        /// <summary>
        /// Begin the sequence such that the preliminary checks are... checked and reset to original status
        /// </summary>
        public void Begin()
        {
            Initialize();

            try
            {
                PrintWelcome();
                InputChips();
                PerformCheck();
            }
            catch (ChipListNullOrEmpty chipListNullorEmpty)
            {
                Console.WriteLine("No chips are present. Press any key to restart...");
                Console.ReadKey();
                Begin();
            }
            catch
            {
                Console.WriteLine("An unknown error has occured. Please report this to your system administrator.\nPress any key to restart...");
                Console.ReadKey();
                Begin();
            }
        }

        /// <summary>
        /// Welcome, world!
        /// </summary>
        protected void PrintWelcome()
        {

            Console.Title = "Welcome to thee Chip Security System";

            Console.Clear();

            Console.WriteLine("Please enter the contents of your bag, and when finished simply enter a BLANK value for the starting chip.");
            Console.WriteLine("Accepted values are as follows:");

            foreach (var chip in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine("\t" + chip.ToString());
            }


        }

        /// <summary>
        /// Process the input
        /// </summary>
        protected void InputChips()
        {
            Color startingChip, endingChip;
            var inputString = string.Empty;
            do
            {
                Console.Write("Starting Chip: ");

                try
                {
                    inputString = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputString))
                        break;

                    startingChip = ((Color)Enum.Parse(typeof(Color), inputString.Replace(" ", ""), true));
                    Console.Write("Ending Chip: ");
                    inputString = Console.ReadLine();
                    endingChip = ((Color)Enum.Parse(typeof(Color), inputString.Replace(" ", ""), true));

                    Chips.Add(new ColorChip(startingChip, endingChip));
                }
                catch
                {
                    Console.WriteLine("We're sorry, but " + inputString + " is not a valid chip color.");
                }
            } while (true);
        }

        /// <summary>
        /// Core algorithm
        /// </summary>
        /// <exception cref="ChipListNullOrEmpty"></exception>
        protected void PerformCheck()
        {
            if (Chips.Count == 0)
                throw new ChipListNullOrEmpty();
            Console.WriteLine("\n\n\tThese are the contents of your bag:");
            foreach (var chip in Chips)
            {
                Console.WriteLine("\t\t\t\t\t   " + chip.ToString());
            }
            Console.WriteLine("\n\nBeginning Security Check...");

            var canUnlock = ValidationEngine.CanUnlock(Chips);

            if (!canUnlock)
            {
                ConsoleHelper.PrintError(Constants.ErrorMessage);
                ConsoleHelper.PrintPrompt();
                Begin();
            }
            else
            {
                ConsoleHelper.PrintSuccess("Succsfully logged into security console!");
                ConsoleHelper.PrintPrompt();
                Begin();
            }
        }


    }
}
