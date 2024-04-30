using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    //inherits from the game class
    internal class SevensOut : Game
    {
        //encapsulates the scores
        private int _player1Score;
        private int _player2Score;
        private int _CPUScore;
        private int _player1Wins = 2;
        private int _player2Wins = 2;
        private int _CPUwins = 2;


        public int player1score
        {
            get { return _player1Score; }
            set { _player1Score = value; }
        }

        public int player2score
        {
            get { return _player2Score; }
            set { _player2Score = value; }
        }

        public int CPUscore
        {
            get { return _CPUScore; }
            set { _CPUScore = value; }
        }

        public int player1Wins
        {
            get { return _player1Wins; }
            set { _player1Wins = value;}
        }

        public int player2Wins
        {
            get { return _player2Wins; }
            set { _player2Wins = value; }
        }

        public int CPUwins
        {
            get { return _CPUwins; }
            set { _CPUwins = value; }
        }

        //overrides the dicerolls array and changes the length to 2
        public SevensOut()
        {
            diceRolls = new int[2];
        }

        //overrides (polymorphism) the roll all dice method 
        public override int[] RollAllDice()
        {
            //rolls 2 dice and adds it to the array
            for (int i = 0; i < diceRolls.Length; i++)
            {
                diceRolls[i] = dice1.Roll();
            }
            //returns the dice rolls array
            return diceRolls;
        }

        /// <summary>
        /// adds up the dice rolls and returns the results
        /// </summary>
        /// <param name="diceRolls"></param>
        /// <returns></returns>
        public int sumUp(int[] diceRolls)
        {
            //sets results to 0
            int result = 0;
            for (int i = 0;i< diceRolls.Length; i++)
            {
                //adds the dicerolls and results together
                result += diceRolls[i];
            }
            //returns the total of the dice rolls
            return result;
        }

        /// <summary>
        /// checks if the player has rolled a total of 7
        /// </summary>
        /// <param name="rollResults"></param>
        /// <returns></returns>
        public bool CheckIfSeven(int rollResults)
        {
            //checks if its equal to 7
            if (rollResults == 7)
            {
                //returns true if it is
                return true;
            }
            else
            {
                //returns false otherwise
                return false;
            }
        }

        /// <summary>
        /// doubles the players points if both dicerolls are equal to eachother
        /// </summary>
        /// <param name="diceRolls"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public int DoublePoints(int[] diceRolls, int results)
        {
            //uses 2 for loops to check if they are equal
            for (int i = 0; i < diceRolls.Length; i++)
            {
                for (int j = + i + 1; j < diceRolls.Length; j++)
                {
                    //if they are qual to eachother it will double the players reults
                    if (diceRolls[i] == diceRolls[j])
                    {
                        Console.WriteLine("Double Points!");
                        results = results * 2;
                        
                    }
                }
                
            }
            //returns the results of this
            return results;
        }

        public void CPUSevensOutPlayer()
        {
            // sets players scores to 0
            player1score = 0;
            CPUscore = 0;
            bool endGame = false;
            //uses do loop to loop the game
            do
            {

                int playersDiceScore = 0;
                int CPUDiceScore = 0;
                Console.WriteLine("Players Turn");
                Console.WriteLine("please press any key to roll the dice");
                Console.ReadKey();
                //rolls the dice
                RollAllDice();
                //outputs the dice theyve rolled
                PrintDiceRolls(diceRolls);
                //adds the dice up
                playersDiceScore = sumUp(diceRolls);
                //tells the palyer the total they got
                Console.WriteLine($"rolled a total of {playersDiceScore}");
                //checks if theres a seven 
                if (CheckIfSeven(playersDiceScore))
                {
                    // if true it will end game 
                    endGame = true;
                    break;
                }
                else
                {
                    //it will check the dice rolls and if they had 2 dice that were equal to eachother 
                    playersDiceScore = DoublePoints(diceRolls, playersDiceScore);
                    //adds it to players score
                    player1score += playersDiceScore;
                    Console.WriteLine("players score: {0}", player1score);
                    Console.WriteLine("Computers score: {0}", CPUscore);
                }
                Console.WriteLine();
                Console.WriteLine("Computers turn");
                //rolls the computers dice and outputs the dice and total 
                RollAllDice();
                PrintDiceRolls(diceRolls);
                CPUDiceScore = sumUp(diceRolls);
                Console.WriteLine($"rolled a total of {CPUDiceScore}");
                //checks if the computers dice is equal to 7 
                if (CheckIfSeven(CPUDiceScore))
                {
                    // if so it will end the game 
                    endGame= true;
                    break;
                }
                else
                {
                    //it will check the dice rolls and if they had 2 dice that were equal to eachother 
                    CPUDiceScore = DoublePoints(diceRolls, CPUDiceScore);
                    //adds it to computers score
                    CPUscore += CPUDiceScore;
                    Console.WriteLine("players score: {0}", player1score);
                    Console.WriteLine("Computers score: {0}", CPUscore);
                    Console.WriteLine();
                }
                

            }
            while (endGame == false);
            //this will check who has a higher score, if its the Computer it will output the computer wins if its the player it will output the player wins
            if (CPUscore > player1score)
            {
                Console.WriteLine("--------------------------------------");
                //outputs the final score
                Console.WriteLine("players final score: {0}", player1score);
                Console.WriteLine("Computers final score: {0}", CPUscore);
                Console.WriteLine("CPU wins!");
                //adds it to the total wins the computer has
                CPUwins += 1;
                Console.ReadLine();
            }
            else if (CPUscore < player1score)
            {
                Console.WriteLine("--------------------------------------");
                //outputs the final score
                Console.WriteLine("players final score: {0}", player1score);
                Console.WriteLine("Computers final score: {0}", CPUscore);
                Console.WriteLine("Player wins!");
                //adds it to the total wins player 1 has
                player1Wins += 1;
                Console.ReadLine();
            }
           
            

        }

        public void SevensOut2Player()
        {
            bool endGame = false;
            // uses do loop as a game loop
            do
            {
                Console.WriteLine("Player 1s Turn");
                Console.WriteLine("please press any key to roll the dice");
                Console.ReadKey();
                //rolls player 1s dice 
                RollAllDice();
                //outputs the dice rolls they got 
                PrintDiceRolls(diceRolls);
                //adds up the dice rolls
                int player1DiceScore = sumUp(diceRolls);
                //outputs the total they got 
                Console.WriteLine($"rolled a total of {player1DiceScore}");
                //checks if its equal to seven 
                if (CheckIfSeven(player1DiceScore))
                {
                    //ends the game if true 
                    endGame = true;
                    break;
                }
                else
                {
                    //checks if they are equal and gives them double points if true 
                    player1DiceScore = DoublePoints(diceRolls, player1DiceScore);
                    //adds the dice score to player 1 score
                    player1score += player1DiceScore;
                    //outputs the score 
                    Console.WriteLine("player 1s score: {0}", player1score);
                    Console.WriteLine("Player 2s score: {0}", player2score);
                }
                Console.WriteLine();
                Console.WriteLine("player 2s turn");
                Console.WriteLine("please press any key to roll the dice");
                Console.ReadKey();
                //rolls player 2s dice
                RollAllDice();
                //outputs the dice player 2 rolled
                PrintDiceRolls(diceRolls);
                //adds up the dice rolls palyer 2 got 
                int player2DiceScore = sumUp(diceRolls);
                //outputs the total they got 

                Console.WriteLine($"rolled a total of {player2DiceScore}");
                //checks if its equal to seven 
                if (CheckIfSeven(player2DiceScore))
                {
                    //ends the game if true 
                    endGame = true;
                    break;
                }
                else
                {
                    //checks if they are equal and gives them double points if true 
                    player2DiceScore = DoublePoints(diceRolls, player2DiceScore);
                    //adds the dice score to player 2 score
                    player2score += player2DiceScore;
                    //outputs the score 
                    Console.WriteLine("player 1s score: {0}", player1score);
                    Console.WriteLine("player 2s score: {0}", player2score);
                    Console.WriteLine();
                }


            }
            while (endGame == false);
            //checks which scores bigger and outputs the final score and whoever won the game 
            if (player2score > player1score)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("player 1s final score: {0}", player1score);
                Console.WriteLine("player 2s final score: {0}", player2score);
                Console.WriteLine("Player 2 wins!");
                //adds it to the total wins player 2 has
                player2Wins += 1;
                Console.ReadLine();
            }
            else if (player2score < player1score)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("player 1s final score: {0}", player1score);
                Console.WriteLine("player 2s final score: {0}", player2score);
                Console.WriteLine("Player 1 wins!");
                //adds it to the total wins player 1 has
                player1Wins += 1;
                Console.ReadLine();
            }
        }
        public void PlayerChoiceAgainst()
        {
            //do loop used to muliple inputs
            bool End = false;
            do
            {
                //asks the user who they want to play against or leave
                Console.WriteLine("Would you like to play against a computer, 2 player or exit");
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    // if they chose computer they will play against the computer
                    case "computer":
                        CPUSevensOutPlayer();
                        End = false;
                        break;
                    // if they chose 2 player they will play against a coop member
                    case "2 player":
                        SevensOut2Player();
                        End = false;
                        break;
                    //exit will leave the game 
                    case "exit":
                        End = true;
                        break;
                    //default will ask the user to enter again
                    default:
                        Console.WriteLine("error occured");
                        break;
                }
            }while(End == false);
            
        }
    }
}
