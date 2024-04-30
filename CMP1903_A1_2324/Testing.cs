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

        public void TestThreeOrMore()
        {
            
            ThreeOrMore threeOrMoreTest = new ThreeOrMore();
            //rolls all the dice
            threeOrMoreTest.RollAllDice();
            int[] diceRolls = threeOrMoreTest.diceRolls;

            for (int i = 0; i < diceRolls.Length; i++)
            {
                //checks if the dice are rolling correctly
                Trace.Assert(1 <= diceRolls[i] && diceRolls[i] <= 6, "Three Or More Dice Aren't rolling in range");
            }

            //checks if were getting the expected results for scoring in three or more
            int ThreeOfAKind  = threeOrMoreTest.ThreeOrMoreOfAKind(0, 3);
            int FourOfAKind = threeOrMoreTest.ThreeOrMoreOfAKind(0, 4);
            int FiveOfAKind = threeOrMoreTest.ThreeOrMoreOfAKind(0, 5);
            Debug.Assert(ThreeOfAKind == 3 || FourOfAKind == 6 || FiveOfAKind == 12, "Scores arent adding up properly");
            bool player1checkFor20OrMore = threeOrMoreTest.Reached20orMore(20, 15);
            bool player2checkFor20OrMore = threeOrMoreTest.Reached20orMore(8, 20);
            Debug.Assert(player1checkFor20OrMore == true || player2checkFor20OrMore == true, "did not identify if there was 20 or more, game wont end otherwise");
            Console.WriteLine("ThreeOrMore is Working");

        }

        public void TestSevensOut()
        {
            SevensOut sevensOutTest = new SevensOut();
            //checks if the dice are adding up within the range
            sevensOutTest.RollAllDice();
            int[] DiceRolls = sevensOutTest.diceRolls;
            int sumUp = sevensOutTest.sumUp(DiceRolls);
            Debug.Assert(sumUp < 12 && sumUp > 3, "results are not within range");
            //checks if its scoring double points 
            int[] testRolls = { 3, 3 };
            int results = sevensOutTest.DoublePoints(testRolls, 0);
            Debug.Assert(results != (3 + 3 * 2), "double points arent scoring");
            //checks if it returns true if someone rolls a total of seven
            bool checkIfSeven = sevensOutTest.CheckIfSeven(7);
            Debug.Assert(checkIfSeven == true, "Seven wasnt identfied, game wont end due to this ");
            Console.WriteLine("Sevens out game is working");
        }
        public void TestDie()
        {
            Die testDie = new Die();
            for (int i = 0; i < 100; i++) 
            {
                //stores roll results
                int rollResult = testDie.Roll();
                /*
                 * Debug.Assert used to check to see if its rolling in a range between 1 and 6
                 * if not it will display an error window of die is out of range 
                 */

                Debug.Assert(1 <= rollResult && rollResult <= 6, "die roll out of range");
            }
            Console.WriteLine("Dice is working properly");
        
        }
    }
}
