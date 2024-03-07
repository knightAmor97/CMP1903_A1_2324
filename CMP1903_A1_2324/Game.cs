﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
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


        //creates a private objects for the game 
        private Die _dice1;
        private Die _dice2;
        private Die _dice3;
        private int _dice1Roll;
        private int _dice2Roll;
        private int _dice3Roll;
        private int _noOfRolls;
        //list is created in order to store the results 
        private List<int> _results;


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
        public List<int> results
        {
            get { return _results; }
            set { _results = value; }
        }



        //constructor for the class
        public Game()
        {
            //creates the die classes and assigns them to the variables
            dice1 = new Die();
            dice2 = new Die();
            dice3 = new Die();
            //creates the list
            results = new List<int>();
            
        }



        public int SumUp()
        {
            //rolls 3 dice
            dice1Roll = dice1.Roll();
            dice2Roll = dice2.Roll();
            dice3Roll = dice3.Roll();

            //adds the 3 dice rolls rogether
            int result = dice1Roll + dice2Roll + dice3Roll;
            //adds the results to the list
            results.Add(result);
            //returns the results from the method
            return result;
        }

        public void AmountOfRolls()
        {
            //uses a do while loop so that the user can have as alot of attempts to input a correct input
            bool inputtedCorrectly = false;
            do
            {
                //uses a try and except method so ther are no errornous inputs when inputting the amopount of times to roll
                try
                {
                    //asks how much the user wants to roll then takes the users input
                    Console.WriteLine("How many times would you like to reroll");
                    int numberOfRolls = int.Parse(Console.ReadLine());
                    //this checks if the user has inputted a number less than 0
                    if (numberOfRolls <= 0) 
                    {
                        //if true it will output a message and retry
                        Console.WriteLine("the number is too small please try again");
                    
                    }
                    else
                    {
                        // will set the built in variable to what the user has inputted
                        noOfRolls = numberOfRolls;
                        //exits the loop
                        inputtedCorrectly = true;
                    }
                    

                }
                //catches any errounous inputs
                catch (Exception e)
                {
                    //prints a message if the user has not inputted a number
                    Console.WriteLine(e.Message + " please try again");
                }
            }
            //breaks out of loop when the user has inputted a correct input
            while(inputtedCorrectly == false);
        }

        
        public void ReRoll()
        {
            //sets the sumUp variable
            int sumUp = 0;
            //loopd through the amount the users inputted 
            for (int i = 0; i < noOfRolls; i++)
            {
                // adds up and stores the scores the rolls given and stores it in the list
                sumUp = SumUp();
                Console.WriteLine($"The sum of the die is {sumUp}");
                Console.WriteLine();

            }
        }

        public int AddUpAll()
        {
            //sets the sumOfAlll variable
            int sumOfAll = 0; 
            //loops through the list 
            for(int i = 0; i < results.Count; i++)
            {
                //adds all the results it gathered together
                sumOfAll += results[i];
            }
            //returns the results together
            return sumOfAll;
        }
        public double AverageDie()
        {
            //sets up a variable and assigns it to the addUpall method
            int sumOfAll = AddUpAll();
            //gets the total amount of die and dividing it by the amount of die there is (gotten by taking the noOfRolls x3) to get the average
            double average = (double)sumOfAll / (noOfRolls * 3 + 3);
            //returns a rounded result (rounded by 2 dp)
            return Math.Round(average, 2);
        }

        public int MinResult()
        {
            //finds the minimum result that the user got
            int minResult = results.Min();
            //returns the minimum result
            return minResult;
        }

        public int MaxResult()
        {
            //finds the maximum result that the user got
            int maxResult = results.Max();
            //returns the result
            return maxResult;
        }

        public void DisplayInformation()
        {
            //outputs the average, min, max scores and the sum up all the scores the user got
            Console.WriteLine($"sum of all the die: {AddUpAll()}");
            Console.WriteLine($"average die the you got: {AverageDie()}");
            Console.WriteLine($"minimum score you got: {MinResult()}");
            Console.WriteLine($"maximum score the you got: {MaxResult()}");
        }

    }
}