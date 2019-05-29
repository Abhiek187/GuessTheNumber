using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class Program
    {
        static readonly Random rand = new Random(); // Initialize random seed for entire program

        static void PlayGame()
        {
            Console.Write("Enter an upper bound > 1: "); // Ask for the highest number to guess
            string input = Console.ReadLine();
            int upperBound;

            // Error check upper bound
            while (!int.TryParse(input, out upperBound) || upperBound <= 1 || upperBound == int.MaxValue)
            {
                if (!int.TryParse(input, out _))
                    Console.WriteLine("That's not an integer, try again.");
                else if (upperBound <= 1)
                    Console.WriteLine("That bound is <= 1, try again.");
                else
                    Console.WriteLine("That bound is too big, try again."); // Check for overflow

                Console.Write("Enter an upper bound > 1: ");
                input = Console.ReadLine();
            }

            int randNum = rand.Next(1, upperBound + 1); // Generates a random number between 1 and user's input
            double tries = Math.Ceiling(Math.Log(upperBound, 2)); // Gives user a fair shot at guessing the number
            Console.WriteLine($"I'm thinking of a number between 1 and {upperBound}. You have {tries} " +
                (tries == 1 ? "try" : "tries") + ". Can you guess what it is?"); // Account for grammar

            // Game loop
            for (double attempt = 1; attempt <= tries; attempt++)
            {
                Console.Write($"Guess #{attempt}: ");
                input = Console.ReadLine();
                int guess;

                // Error check guess
                while (!int.TryParse(input, out guess) || guess < 1 || guess > upperBound)
                {
                    if (!int.TryParse(input, out _))
                        Console.WriteLine("That's not a number, try again.");
                    else if (guess < 1)
                        Console.WriteLine("That guess is < 1, try again.");
                    else
                        Console.WriteLine($"That guess is > {upperBound}, try again.");

                    Console.Write($"Guess #{attempt}: ");
                    input = Console.ReadLine();
                }

                if (guess < randNum)
                {
                    // Guess should be higher
                    Console.WriteLine("Higher!");
                }
                else if (guess > randNum)
                {
                    // Guess should be lower
                    Console.WriteLine("Lower!");
                }
                else
                {
                    // User guesses the right number
                    Console.WriteLine("Correct! You win!");
                    break;
                }

                if (attempt == tries)
                {
                    // User failed, reveal answer
                    Console.WriteLine($"Sorry, you lose. The answer is {randNum}.");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guess the Number!");
            char playAgain;

            do
            {
                PlayGame(); // Keep playing until user wants to quit
                Console.Write("Do you want to play again? (y/n): ");
                string input = Console.ReadLine();
                
                // Error check try again prompt
                while (!char.TryParse(input, out playAgain) ||
                    (Char.ToLower(playAgain) != 'y' && Char.ToLower(playAgain) != 'n'))
                {
                    Console.Write("Please enter y or n: ");
                    input = Console.ReadLine();
                }
            } while (Char.ToLower(playAgain) == 'y');

            Console.WriteLine("Thank you for playing!");
        }
    }
}
