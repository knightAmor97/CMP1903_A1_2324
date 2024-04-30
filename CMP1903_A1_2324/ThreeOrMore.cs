using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMP1903_A1_2324
{

    //inherits from game class
    internal class ThreeOrMore : Game
    {
        //encapsulates all vaiables
        private int _CPUScore;
        private int _playerScore;
        private int _player2Score;
        private int _player1Wins = 0;
        private int _player2Wins = 0;
        private int _CPUwins = 0;
        private int _totalGamesPlayed = 0;


        //sets the dicerolls variable from game to 5
        public ThreeOrMore()
        {
            diceRolls = new int[5];
        }

        public int CPUScore
        {
            get { return _CPUScore; }
            set { _CPUScore = value; }
        }

        public int playerScore
        {
            get { return _playerScore; }
            set { _playerScore = value; }
        }

        public int player2Score
        {
            get { return _player2Score; }
            set { _player2Score = value; }
        }

        public int player1Wins
        {
            get { return _player1Wins; }
            set { _player1Wins = value; }
        }

        public int player2Wins
        {
            get { return _player2Wins; }
            set { _player2Wins = value; }
        }

        public int CPUWins
        {
            get { return _CPUwins; }
            set { _CPUwins = value; }
        }




        //overrides RollAllDice from game class
        /// <summary>
        /// rolls 5 dice and returns the array
        /// </summary>
        /// <returns></returns>
        public override int[] RollAllDice()
        {

            base.RollAllDice();
            for (int i = 0; i < diceRolls.Length; i++)
            {
                diceRolls[i] = dice1.Roll();
            }
            return diceRolls;
        }

        /// <summary>
        /// rolls the the dice that arent equal to eachother
        /// </summary>
        /// <returns></returns>
        public int[] ReRoll()
        {
            //creates a bool array to know which dice to reroll
            bool[] shouldReRoll = new bool[diceRolls.Length];
            //uses 2 for loops to check 
            for (int i = 0; i < diceRolls.Length; i++)
            {
                for (int j = i + 1; j < diceRolls.Length; j++)
                {
                    //checks if they are set to eachother
                    if (diceRolls[i] == diceRolls[j])
                    {
                        //checks sets them to true if they need to be rerolled
                        shouldReRoll[i] = true;
                        shouldReRoll[j] = true;
                    }

                }
            }


            for (int i = 0; i < shouldReRoll.Length; i++)
            {
                //checks the array for any that was flagged as false(not the same)
                if (!shouldReRoll[i])
                {
                    //rolls the dice that were false
                    diceRolls[i] = dice1.Roll();
                }
            }
            //returns the dice rolls
            return diceRolls;
        }

        /// <summary>
        /// counts the amount of dice rolls that are the same and returns the counter to the main
        /// </summary>
        /// <param name="diceRolls"></param>
        /// <returns></returns>
        public int Count(int[] diceRolls)
        {
            //creates a counter variable and a dicationary for the amount of pairs 
            int counter = 0;
            Dictionary<int, int> diceCounts = new Dictionary<int, int>();

            //counts the amount of pairs in the array and adds it to the pairs dictionary
            foreach (int i in diceRolls)
            {
                if (diceCounts.ContainsKey(i))
                {
                    diceCounts[i]++;
                }
                else
                {
                    diceCounts[i] = 1;
                }
                
            }
            //checks if the pairs are bigger then 2 and sets it to counter
            foreach (var pair in diceCounts)
            {
                if(pair.Value >= 2)
                {
                    counter = pair.Value;
                }
            }
            return counter;
        }

        /// <summary>
        /// adds up the score depending on what the counter returned
        /// </summary>
        /// <param name="score"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        public int ThreeOrMoreOfAKind(int score, int counter)
        {
            //if counter is equal to three then it will add 3 to the score and return the score
            if (counter == 3)
            {
                Console.WriteLine("Three Of A Kind!");
                score += 3;
                return score;
            }
            // if the counter is equal to 4 it will add 4 to the score
            else if (counter == 4)
            {
                Console.WriteLine("Four Of A Kind!");
                score += 6;
                return score;
            }
            // if counter is equal to 5 it add 12 and return the score
            else if (counter == 5)
            {
                Console.WriteLine("Five Of A Kind");
                score += 12;
                return score;
            }
            // if its 1 or 2 it will just return the score
            else
            {
                return score;
            }
        }

        /// <summary>
        /// checks if the player score is bigger or equal to 20 to end the game 
        /// </summary>
        /// <param name="playerScore"></param>
        /// <param name="player2Score"></param>
        /// <returns></returns>
        public bool Reached20orMore(int playerScore, int player2Score)
        {
            // if player 1s or players 2s score is bigger or equal to 20 it will return true to end the game 
            if (playerScore >= 20 || player2Score >= 20)
            {
                return true;


            }
            //otherwise it will return false
            else
            {
                return false;
            }
        }

        /// <summary>
        /// this method is for the CPU
        /// </summary>
        public void ThreeOrMoreCPU()
        {
            // sets score to 0
            playerScore = 0;
            CPUScore = 0;
            //set to false initally 
            bool endGame = false;
            //uses a while loop for the game loop
            while (endGame == false)
            {
                //checks if its reached 20 or more 
                if (Reached20orMore(playerScore, CPUScore))
                {
                    //ends game if the fucntion returns true 
                    endGame = true;
                    break;
                }

                Console.WriteLine("Players turn");
                Console.WriteLine("Press any key to start");
                Console.ReadKey();
                //rolls players dice
                RollAllDice();
                //outputs what the player rolled
                PrintDiceRolls(diceRolls);
                //counts the same dice the player got 
                int playerdiceRollsCount = Count(diceRolls);
                //checks if its equal to 2 
                if (playerdiceRollsCount == 2)
                {
                    bool endTwoOfAKindChoice = false;
                    //do loop used for players input
                    do
                    {
                        //user can either reroll or reroll the dice that arent the same 
                        Console.WriteLine("Would you like to reroll or reroll the remaining dice");
                        string TwoOfAkindChoice = Console.ReadLine();
                        //switch case used for users input
                        switch (TwoOfAkindChoice)
                        {
                            //if they chose to reroll it would roll all dice and exit the do loop
                            case "reroll":
                                RollAllDice();
                                endTwoOfAKindChoice = true;
                                break;
                            // if they chose to reroll rhe remaining dice it woulf use the reroll function and exit the do loop
                            case "reroll the remaining dice":
                                ReRoll();
                                endTwoOfAKindChoice = true;
                                break;
                            //default is used for exception handling if there are any errornous inputs
                            default:
                                Console.WriteLine("Error, please try again");
                                break;

                        }

                    } while (!endTwoOfAKindChoice);
                    //outputs the new rolls from what ever the user selected
                    PrintDiceRolls(diceRolls);
                    //counts the same dice the player got
                    playerdiceRollsCount = Count(diceRolls);
                    //checks if its a higher score
                    playerScore = ThreeOrMoreOfAKind(playerScore, playerdiceRollsCount);
                }
                else
                {
                    //checks if the player has scored three or or more of a kind 
                    playerScore = ThreeOrMoreOfAKind(playerScore, playerdiceRollsCount);
                }

                //outputs the players and computers current scores
                Console.WriteLine($"players Score: {playerScore}");
                Console.WriteLine($"Computers Score: {CPUScore}");
                Console.ReadLine();
                Console.WriteLine("Computers turn");
                //rolls the computers dice and outputs the dice they got 
                RollAllDice();
                PrintDiceRolls(diceRolls);
                //counts the same dice the player got
                int CPUdiceRollsCount = Count(diceRolls);
                //checks if its 2 
                if (CPUdiceRollsCount == 2)
                {
                    /*
                     * the computer will choose randomly to either reroll the dice or the rest of the dice 
                     */
                    //random class is created
                    Random random = new Random();
                    //creates a string array for rerolling 
                    string[] CPUChoicesFor2OfAKind = { "reroll", "reroll all the rest of the dice" };
                    //randomly chooses from the array
                    int CPUChoice = random.Next(CPUChoicesFor2OfAKind.Length);
                    //switch case is used for whatever it randomly chose
                    switch (CPUChoice)
                    {
                        //case 0 means it chose to reroll and it rerolled all the dice
                        case 0:
                            Console.WriteLine("Computer chose to reroll all the dice");
                            RollAllDice();
                            break;
                        // case 1 means it chose to reroll the rest of the dice  
                        case 1:
                            Console.WriteLine("Computer chose to reroll the rest of the dice");
                            ReRoll();
                            break;
                    }
                    //outputs the new dice rolls
                    PrintDiceRolls(diceRolls);
                    //counts the same dice the computer got
                    CPUdiceRollsCount = Count(diceRolls);
                    //checks if theres 3 or more of a kind 
                    CPUScore = ThreeOrMoreOfAKind(CPUScore, CPUdiceRollsCount);

                }
                else
                {
                    //if its not equal to 2 it will check if its three or more of a kind 
                    CPUScore = ThreeOrMoreOfAKind(CPUScore, CPUdiceRollsCount);
                }
                //outputs the players and computers score
                Console.WriteLine($"players Score: {playerScore}");
                Console.WriteLine($"Computers Score: {CPUScore}");
                Console.ReadLine();

            }
            //outputs who wins depending if the player got 20 or the computer got 20
            Console.WriteLine("------------------------------------");
            if (playerScore >= 20)
            {
                Console.WriteLine("Player wins! ");
            }
            else if (CPUScore >= 20)
            {
                Console.WriteLine("Computer Wins! ");
            }

        }

        /// <summary>
        /// This method is for 2 player three or moe 
        /// </summary>
        public void TwoPlayerThreeOrMore()
        {
            //sets the scores to 0
            playerScore = 0;
            player2Score = 0;

            bool endGame = false;
            //game loop
            while (endGame != true)
            {
                
                //checks if its 20 or more
                if (Reached20orMore(playerScore, player2Score))
                {
                    //ends the game if true 
                    endGame = true;
                    break;
                }
                Console.WriteLine("Player 1s turn");
                Console.WriteLine("Press any key to start");
                Console.ReadKey();
                //rolls player 1s dice 
                RollAllDice();
                //outputs the dice rolled
                PrintDiceRolls(diceRolls);
                //counts the same dice the player got
                int playerdiceRollsCount = Count(diceRolls);
                //checks if the counter is 2 
                if (playerdiceRollsCount == 2)
                {
                    bool endTwoOfAKindChoice = false;
                    do
                    {
                        /*
                         * does the same thing in the CPU method as it does here and for player 2
                         */
                        Console.WriteLine("Would you like to reroll or reroll the remaining dice");
                        string TwoOfAkindChoice = Console.ReadLine();
                        //switch case used for player choice 
                        switch (TwoOfAkindChoice)
                        {
                            //rerolls the dice if the player chose it
                            case "reroll":
                                RollAllDice();
                                endTwoOfAKindChoice = true;
                                break;
                            //rerolls the remaining dice if the player chose it 
                            case "reroll the remaining dice":
                                ReRoll();
                                endTwoOfAKindChoice = true;
                                break;
                            //default is used for any errornous input
                            default:
                                Console.WriteLine("Error, please try again");
                                break;

                        }

                    } while (!endTwoOfAKindChoice);
                    //outputs the new dice rolls
                    PrintDiceRolls(diceRolls);
                    //counts the same dice the player got
                    playerdiceRollsCount = Count(diceRolls);
                    //checks if theres 3 or more of a kind 
                    playerScore = ThreeOrMoreOfAKind(playerScore, playerdiceRollsCount);
                }
                else
                {
                    //checks if theres 3 or more of a kind 
                    playerScore = ThreeOrMoreOfAKind(playerScore, playerdiceRollsCount);
                }
                Console.WriteLine($"player 1s Score: {playerScore}");
                Console.WriteLine($"player 2s Score: {player2Score}");
                Console.WriteLine("player 2s turn");
                Console.WriteLine("Press any key to start");
                Console.ReadKey();
                RollAllDice();
                PrintDiceRolls(diceRolls);
                int player2diceRollsCount = Count(diceRolls);
                //checks if the counter is 2 
                if (player2diceRollsCount == 2)
                {
                    bool endTwoOfAKindChoice = false;
                    do
                    {
                        /*
                         * does the same thing in the CPU method as it does here and for player 2
                         */
                        Console.WriteLine("Would you like to reroll or reroll the remaining dice");
                        string TwoOfAkindChoice = Console.ReadLine();
                        //switch case used for player choice 
                        switch (TwoOfAkindChoice)
                        {
                            //rerolls the dice if the player chose it
                            case "reroll":
                                RollAllDice();
                                endTwoOfAKindChoice = true;
                                break;
                            //rerolls the remaining dice if the player chose it 
                            case "reroll the remaining dice":
                                ReRoll();
                                endTwoOfAKindChoice = true;
                                break;
                            //default is used for any errornous input
                            default:
                                Console.WriteLine("Error, please try again");
                                break;

                        }

                    } while (!endTwoOfAKindChoice);
                    //outputs the new dice rolls
                    PrintDiceRolls(diceRolls);
                    //counts the same dice the player got
                    player2diceRollsCount = Count(diceRolls);
                    //checks if theres 3 or more of a kind 
                    player2Score = ThreeOrMoreOfAKind(player2Score, player2diceRollsCount);
                }
                else
                {
                    //checks if theres 3 or more of a kind 
                    player2Score = ThreeOrMoreOfAKind(player2Score, playerdiceRollsCount);
                }
                //outputs the players score
                Console.WriteLine($"player 1s Score: {playerScore}");
                Console.WriteLine($"player 2s Score: {player2Score}");
                Console.ReadKey();

            }
            //outputs who wins depending if the player got 20 or player 2 got 20
            Console.WriteLine("------------------------------------");
            if (playerScore >= 20)
            {
                Console.WriteLine("Player 1 wins! ");
            }
            else if (player2Score >= 20)
            {
                Console.WriteLine("player 2 Wins! ");
            }
        }

        public void PlayerChoiceAgainst()
        {
            bool End = false;
            //do loop used to muliple inputs
            do
            {
                //asks the user who they want to play against or leave
                Console.WriteLine("Would you like to play against a computer, 2 player or exit");
                string playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    // if they chose computer they will play against the computer
                    case "computer":
                        ThreeOrMoreCPU();
                        break;
                    // if they chose 2 player they will play against a coop member
                    case "2 player":
                        TwoPlayerThreeOrMore();
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
            } while (End == false);
        }
    }
}
