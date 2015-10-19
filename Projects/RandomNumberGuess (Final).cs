using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberrndNbrFinal
{
    class Program
    {
        //Allows the user to input the guess, difficulty and limits the attempts.
        static string userInputFunction = "";
        static int rndNbr = 0;
        static int guessLimit = 0;
        
        
        static void Main(string[] args)
        {
            //Prompts user on how to begin the game.
            Console.WriteLine("Hello, to begin the game state your difficulty as easy, medium, or hard.");

            //Methods used in the codes (statics).
            randomNumber(); //Variable being declared (the actual number being produced/guessed).
            
            checkrndNbr();  //Allows user to either win or lose by checking whether or not the random number is guessed. 
        }

        //This method gives the option of number ranges and number of guesses.
        static void randomNumber()
        {
            string userInputFunction = "";
            userInputFunction = Console.ReadLine();
            
            //These are the levels allowing the number ranges to be different as well as guess limits.

            Random rnd = new Random();

            if (userInputFunction == "easy")
            {
                rndNbr = rnd.Next(1, 5); //Range
                guessLimit = 4;
            }
            else if (userInputFunction == "medium")
            {
               rndNbr = rnd.Next(1, 15); //Range
               guessLimit = 3;
            }
            else if (userInputFunction == "hard")
            {
                rndNbr = rnd.Next(1, 25); //Range
                guessLimit = 2;
            }
            Console.Clear();
            Console.WriteLine("You picked " + userInputFunction + ".\nYou have " + Convert.ToString(guessLimit) + " guesses.\nChoose your number.");

        }

        //This method is for checking the numbers and giving the win/loss functionality.

        static void checkrndNbr()
        {
            //Converting the guess limit to prompt the user to try guessing again and saying the number of guesses left.
            string userInputFunction = "";
            userInputFunction = Console.ReadLine();
            int guessedNumber = Convert.ToInt32(userInputFunction);
            
            if (rndNbr != guessedNumber)
            {
                if (guessLimit <= 1) //Set to 1 so an extra guess isn't given. No cheating!
                {
                    Console.WriteLine("Game over, all out of guesses.");
                }
                else
                {
                    guessLimit--; //Subtracting a guess each round.
                    Console.WriteLine("Opps, try again, you have " + Convert.ToString(guessLimit) + " guesses left.");
                    
                    checkrndNbr(); //This statement ensures the win/lose function. 
                }
                
            }
            else
            {
                Console.WriteLine("You won! Congrats!");
            }

            Console.ReadLine();
        }
    }
}
