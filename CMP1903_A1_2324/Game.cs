using System;
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
        private Die _D1;
        private Die _D2;
        private Die _D3;
        private int _result;
        private int _noOfRolls;
        //list is created in order to store the results 
        private List<int> _results;

        //polymorphism is used in order to change the values but they cannot be edited outside the program
        public Die D1
        {
            get { return _D1; }
            set { _D1 = value; }
        }
        public Die D2
        {
            get { return _D2; }
            set { _D2 = value; }
        }
        public Die D3
        {
            get { return _D3; }
            set { _D3 = value; }
        }

        public int result
        {
            get { return _result; }
            set { _result = value; }
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
            D1 = new Die();
            D2 = new Die();
            D3 = new Die();
            result = 0;
            results = new List<int>();
            
        }
        /*
         * these are the methods for this class
         * SumUp should addup all 3 die and then store the results inside the the list it will then return it
         * amountOfRolls allows the user to reroll as many times as the user wants
         * reRoll rerolls the die from the amount the user has given
         * addUpAll should add up all the dies roll together
         * averageDie will take all the die added up together then divide it by the amount the user has asked to reroll
         * minResults will find the minimum score of what the user got
         * maxResults will find the max score the user got
         * displayInformation will display all the data gathered
         */
        public int Sumup()
        {
            //rolls 3 dice
            int D1Roll = D1.roll();
            int D2Roll = D2.roll();
            int D3Roll = D3.roll();

            //adds the 3 dice rolls rogether
            result = D1Roll + D2Roll + D3Roll;
            //adds the results to the list
            results.Add(result);
            //returns the results from the method
            return result;
        }

        public void AmountOfRolls()
        {
            //asks how much the user wants to roll then takes the users input
            Console.WriteLine("How many times would you like to reroll");
            int numberOfRolls = int.Parse(Console.ReadLine());
            // will set the built in variable to what the user has inputted
            noOfRolls = numberOfRolls;


        }

        
        public void reroll()
        {
            //sets the sumUp variable
            int sumUp = 0;
            //loopd through the amount the users inputted 
            for (int i = 0; i < noOfRolls; i++)
            {
                // adds up and stores the scores the rolls given and stores it in the list
                sumUp = Sumup();

            }
        }

        public int AddUpAll()
        {
            //sets the sumOfAlll variable
            int SumOfAll = 0;
            //loops through the list 
            for(int i = 0; i < results.Count; i++)
            {
                //adds all the results it gathered together
                SumOfAll += results[i];
            }
            //returns the results together
            return SumOfAll;
        }
        public double averageDie()
        {
            //sets up a variable and assigns it to the addUpall method
            int sumOfAll = AddUpAll();
            //gets the total amount of die and dividing it by the amount of die there is (gotten by taking the noOfRolls x3) to get the average
            double average = (double)sumOfAll / (noOfRolls *3);
            //returns a rounded result (rounded by 2 dp)
            return Math.Round(average, 2);
        }

        public int minResult()
        {
            //finds the minimum result that the user got
            int minResult = results.Min();
            //returns the minimum result
            return minResult;
        }

        public int maxResult()
        {
            //finds the maximum result that the user got
            int maxResult = results.Max();
            //returns the result
            return maxResult;
        }

        public void displayInformation()
        {
            //outputs the average, min, max scores and the sum up all the scores the user got
            Console.WriteLine($" sum of all the die: {AddUpAll()}");
            Console.WriteLine($"average score the user got: {averageDie()}");
            Console.WriteLine($"minimum score you got: {minResult()}");
            Console.WriteLine($"maximum score the user got: {maxResult()}");
        }

    }
}