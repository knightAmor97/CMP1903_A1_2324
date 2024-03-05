using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             *
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             * 
             */
            //creates a game object
            Game game = new Game();
            //creates a testing object
            Testing test = new Testing();
            //outputs a starting screen before entering the game
            Console.WriteLine("Welcome to the Dice game");
            Console.WriteLine("Press any key to start: ");
            Console.ReadKey();
            //tests the die and game first before starting
            test.testDie(game.D1);
            test.testGame(game);
            //outputs the total of the die 
            int totalOfDie = game.Sumup();
            Console.WriteLine($"The sum of the amount of die is {totalOfDie}");
            bool EnteredCorrectly = false;
            
            // do loop used so the used so the user has lots of attempts to write a correct input
            do
            {
                //asks user if they want to reroll
                Console.WriteLine("would you like to reroll(y/n)");
                string answer = Console.ReadLine();
                // if they answered yes it will go thrugh the amountOfRolls, reroll and then it will display all the statistics
                if (answer == "y")
                {
                    game.AmountOfRolls();
                    game.reroll();
                    game.displayInformation();
                    //this will exit the loop
                    EnteredCorrectly = true;
                }
                // if they dont want to reroll it exit the loop
                else if (answer == "n")
                {
                    EnteredCorrectly = true;
                }
                // if the user didnt enter a correct answer it will ask them to input again
                else
                {
                    Console.WriteLine("didnt enter a right input please try again");
                }
            }
            //breaks out of loop when the user has inputted a correct input
            while (EnteredCorrectly == false);
            Console.ReadKey();
            
            




        }
    }
}
