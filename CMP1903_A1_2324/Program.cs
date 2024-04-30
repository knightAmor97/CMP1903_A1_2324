using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMP1903_A1_2324
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            //creates the games, testing and statistics classes
            SevensOut sevensOut = new SevensOut();
            ThreeOrMore threeOrMore = new ThreeOrMore();
            Testing test = new Testing();
            Statistics statistics = new Statistics(sevensOut, threeOrMore);

            //uses do loop for the user
            bool endChoice = false;
            do
            {
                //asks user to input an option
                Console.WriteLine("please select an opion below");
                Console.WriteLine("sevens out");
                Console.WriteLine("three or more");
                Console.WriteLine("Statistics ");
                Console.WriteLine("testing");
                Console.WriteLine("exit");
                //set to lower to reduce errornous input
                string choice = Console.ReadLine().ToLower();
                //switch case used for choice 
                switch(choice)
                {
                    //if the chose sevens out they will go straight to choosing if they want to go 2 player or CPU
                    case "sevens out":
                        sevensOut.PlayerChoiceAgainst();
                        break;
                    //if they chose three or more they will go straight to choosing if they want to go 2 player or CPU
                    case "three or more":
                        threeOrMore.PlayerChoiceAgainst();
                        break;
                    // if they chose statistics it will display the stats they got from the games
                    case "statistics":
                        statistics.DisplayStats();
                        break;
                    //testing will test the entire game 
                    case "testing":
                        test.TestSevensOut();
                        test.TestThreeOrMore();
                        test.TestDie();
                        break;
                    //exit will end the loop and quit the program
                    case "exit":
                        endChoice = true;
                        break;
                    //default will be used for any errornous inputs
                    default:
                        Console.WriteLine("error, please try again");
                        break;

                }

            } while (endChoice == false);
            
        }
    }
}
