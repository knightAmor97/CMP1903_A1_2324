using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    //abstract class is used
    internal abstract class Game
    {

       /*
        * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
        *
        * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
        * rolls could be continous, and the totals and other statistics could be summarised for example.
        */

        //Methods

        /*
         * sumup methods will roll all 3 dice 
         * it will then add the dice together and return the result
         */


        //creates a private variables for the game 
        private Die _dice1;
        private Die _dice2;
        private Die _dice3;
        private int _dice1Roll;
        private int _dice2Roll;
        private int _dice3Roll;
        private int _noOfRolls;
        private int[] _diceRolls;
        //list is created in order to store the results 


        //Encapsulation is used in order to change the values but they cannot be edited outside the program
        public Die dice1
        {
            get { return _dice1; }
            set { _dice1 = value; }
        }
        public Die dice2
        {
            get { return _dice2; }
            set { _dice2 = value; }
        }
        public Die dice3
        {
            get { return _dice3; }
            set { _dice3 = value; }
        }

        public int dice1Roll
        {
            get { return _dice1Roll; }
            set { _dice1Roll = value; }
        }
        public int dice2Roll
        {
            get { return _dice2Roll; }
            set { _dice2Roll = value; }
        }
        public int dice3Roll
        {
            get { return _dice3Roll; }
            set { _dice3Roll = value; }
        }

        public int noOfRolls
        {
            get { return _noOfRolls; }
            set { _noOfRolls = value; }
        }

        public int[] diceRolls
        {
            get { return _diceRolls; }
            set { _diceRolls = value;}
        }


        //constructor for the class
        public Game()
        {
            //creates the die classes and assigns them to the variables
            dice1 = new Die();
            dice2 = new Die();
            dice3 = new Die();
            diceRolls = new int[3];
            //creates the list

        }

        //set as virtual to override this function
        /// <summary>
        /// rolls three dice then returns the array
        /// </summary>
        /// <returns>returns the array</returns>
        public virtual int[] RollAllDice()
        {
            //rolls 3 dice    
            diceRolls[0] = dice1.Roll();
            diceRolls[1] = dice2.Roll();
            diceRolls[2] = dice3.Roll();
            //returns the array of the three dice that were rolled 
            return diceRolls;
        }

        /// <summary>
        /// Will output the dice rolled
        /// </summary>
        /// <param name="array"></param>
        public void PrintDiceRolls(int[] array)
        {
            Console.Write("you rolled a ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]},");
            }
            Console.WriteLine();
        }

    }
}