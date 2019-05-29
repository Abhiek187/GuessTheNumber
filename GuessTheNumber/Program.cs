using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.Write("Enter an upper bound: "); // Ask for the highest number to guess
            int upperBound = int.Parse(Console.ReadLine());
            int randNum = rand.Next(1, upperBound + 1); // Generates a random number between 1 and user's input
            double tries = Math.Ceiling(Math.Log(upperBound, 2)); // Gives user a fair shot at guessing the number
            Console.WriteLine($"I'm thinking of a number between 1 and {upperBound}. You have {tries} tries. Can you guess what it is?");

            for (double attempt = 1; attempt <= tries; attempt++)
            {
                Console.Write($"Guess #{attempt}: ");
                int guess = int.Parse(Console.ReadLine());

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
    }
}
