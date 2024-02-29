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
            test.testDie(game.d1);
            test.testGame(game);
            //outputs the total of the die 
            int totalOfDie = game.Sumup();
            Console.WriteLine($"The sum of the amount of die is {totalOfDie}");
            Console.ReadKey();
            
            
            




        }
    }
}
