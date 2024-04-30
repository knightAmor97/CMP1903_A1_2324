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
        //creates a private value variable inside the class and rand
        //use a static here in order to get a different number from each class
        private static Random _random;
        private int _value;
        //encapsulation used in order to change the values without it being changed outside the class
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }
        public Random random
        {
            get { return _random; }
            set { _random = value; }
        }

        public Die()
        {
            random = new Random();
        }

        //Method

        /*
         * This method should generate a random value from 1-6 then return the value
        */
        public int Roll()
        {
            //Generates a value from 1 to 6 (its 1-7 as it will do 1 less then the orginal)
            value = random.Next(1, 7);
            //returns value
            return value;
        }
        //gets the value from the private variable 

    }
}
