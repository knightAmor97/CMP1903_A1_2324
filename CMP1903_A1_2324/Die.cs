using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {


        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */


        //Property
        //creates a private value and random variables inside the class
        private Random rand;
        private int _Value;

        //creates a random object in the constructor class
        public Die()
        {
            rand = new Random();
        }

        //Method

        /*
         This method should generate a random value from 1-6 then return the value
         */
        public int roll()
        {
            Console.WriteLine("Rolling...");
            //Generates a value from 1 to 6 (its 1-7 as it will do 1 less then the orginal)
            _Value = rand.Next(1, 7);
            //outputs the rolled value
            Console.WriteLine($"rolled a {_Value}");
            //returns value
            return _Value;
        }
        //gets the value from the private variable 
        public int value
        {
            get { return _Value; }
        }
    }
}
