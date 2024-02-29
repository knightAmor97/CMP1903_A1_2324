using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {

        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method
        public void testGame()
        {
            Game game = new Game();

            int sumUpResult = game.Sumup();
            Console.Clear();
            

            int expectedResults = game.d1.value + game.d2.value + game.d3.value;
            

            Debug.Assert(expectedResults == sumUpResult, "the games sumup numbers dont match with expected result");
        }
        public void testDie()
        {
            Die die = new Die();

            int rollResult = die.roll();

            Debug.Assert(1 <= rollResult && rollResult <= 6, "die is rolling wrong");

        }
    }
}
