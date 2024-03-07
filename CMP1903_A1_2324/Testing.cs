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
        /*
         * this method tests the game 
         * It will get the current game sumup used in the program and test it after the start screen
         * it will sum up results and compare them
         */
        public void testGame(Game currentGame)
        {
            
            //stores the games sum up in results
            int sumUpResult = currentGame.SumUp();
            
            //get the value of each die from the same game and adds them up
            int expectedResults = currentGame.dice1Roll + currentGame.dice2Roll + currentGame.dice3Roll;
            
            /* Debug Assert used to check the sumup results are the same as the expected results
             * if false will error it will output an error window saying unexpected result
             */

            Debug.Assert(expectedResults == sumUpResult, "unexpected result");
            //checks to see if the results are within range, if not true it will it will output that the results arent within range
            Debug.Assert(sumUpResult < 18 && sumUpResult > 3, "results are not within range");
        }
        public void testDie(Die currentDie)
        {
            
            
            
            for (int i = 0; i < 100; i++) 
            {
                //stores roll results
                int rollResult = currentDie.Roll();
                /*
                 * Debug.Assert used to check to see if its rolling in a range between 1 and 6
                 * if not it will display an error window of die is out of range 
                 */

                Debug.Assert(1 <= rollResult && rollResult <= 6, "die roll out of range");
            }
        
        }
    }
}
