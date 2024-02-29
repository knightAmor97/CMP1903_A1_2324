using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        //creates a private objects for the game 
        private Die _D1;
        private Die _D2;
        private Die _D3;

        //initaites these in the constructor
        public Game()
        {
            _D1 = new Die();
            _D2 = new Die();
            _D3 = new Die();
        }


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
        public int Sumup()
        {
            //rolls 3 dice
            int D1Roll = _D1.roll();
            int D2Roll = _D2.roll();
            int D3Roll = _D3.roll();
            //adds the 3 dice rolls rogether
            int result = D1Roll + D2Roll + D3Roll;
            //returns the results from the method
            return result;
        }

        //These methods will get and return all 3 of the dice objectsbut cannot be edited as it is a private object
        public Die d1
        {
            get { return _D1; }
        }
        public Die d2
        {
            get { return _D2; }
        }
        public Die d3
        {
            get { return _D3; }
        }




    }
}
