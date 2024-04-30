using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        //encapsulates all vaiables
        private SevensOut _sevensOut;
        private ThreeOrMore _threeOrMore;

        public SevensOut sevensOut
        {
            get { return _sevensOut; }
            set { _sevensOut = value; }
        }

        public ThreeOrMore threeOrMore
        {
            get { return _threeOrMore; }
            set { _threeOrMore = value; }
        }

        //gets the current classes used in the game 
        public Statistics(SevensOut sevensOutGame, ThreeOrMore threeOrMoreGame)
        {
            threeOrMore = threeOrMoreGame;
            sevensOut = sevensOutGame;
        }

        /// <summary>
        /// gets the win loss ratio for player 1 in the sevens out game 
        /// </summary>
        /// <returns></returns>
        public double Player1WinLossRatioSevensOut()
        {
            //sets all wins as double 
            double player1Wins = sevensOut.player1Wins;
            double player2Wins = sevensOut.player2Wins;
            double CPUWins = sevensOut.CPUwins;
            double gamesPlayed = player2Wins + player1Wins + CPUWins;
            // checks if games played is 0 so it doesnt return as null
            if (gamesPlayed == 0)
            {
                return 0;

            }
            //returns the win loss ratio equation and rounds it to 2 d.p
            double winLossRatio = Math.Round(player1Wins / gamesPlayed, 2);
            return winLossRatio;

        }
        /// <summary>
        /// gets the win loss ratio for player 2 in the sevens out game 
        /// </summary>
        /// <returns></returns>
        public double Player2WinLossRatioSevensOut()
        {

            double player1Wins = sevensOut.player1Wins;
            double player2Wins = sevensOut.player2Wins;
            double CPUWins = sevensOut.CPUwins;
            double gamesPlayed = player2Wins + player1Wins + CPUWins;
            // checks if games played is 0 so it doesnt return as null
            if (gamesPlayed == 0)
            {
                return 0;

            }
            //returns the win loss ratio equation and rounds it to 2 d.p
            double winLossRatio = Math.Round(player2Wins / gamesPlayed, 2);
            return winLossRatio;
        }

        /// <summary>
        /// gets the win loss ratio for the computer in the sevens out game 
        /// </summary>
        /// <returns></returns>
        public double CPUWinLossRatioSevensOut()
        {

            double player1Wins = sevensOut.player1Wins;
            double player2Wins = sevensOut.player2Wins;
            double CPUWins = sevensOut.CPUwins;
            double gamesPlayed = player2Wins + player1Wins + CPUWins;
            // checks if games played is 0 so it doesnt return as null
            if (gamesPlayed == 0)
            {
                return 0;

            }
            //win loss ratio and rounds it to 2 d.p
            double winLossRatio = Math.Round(CPUWins / gamesPlayed, 2);
            return winLossRatio;
        }
        /// <summary>
        /// gets the win loss ratio for player 1 in the three or more game 
        /// </summary>
        /// <returns></returns>
        public double Player1WinLossRatioThreeOrMore()
        {

            double player1Wins = threeOrMore.player1Wins;
            double player2Wins = threeOrMore.player2Wins;
            double CPUWins = threeOrMore.CPUWins;
            double gamesPlayed = player2Wins + player1Wins + CPUWins;
            // checks if games played is 0 so it doesnt return as null
            if (gamesPlayed == 0)
            {
                return 0;

            }
            //returns the win loss ratio equation and rounds it to 2 d.p
            double winLossRatio = Math.Round(player1Wins / gamesPlayed, 2);
            return winLossRatio;
        }

        /// <summary>
        /// gets the win loss ratio for player 2 in the three or more game 
        /// </summary>
        /// <returns></returns>
        public double Player2WinLossRatioThreeOrMore()
        {

            double player1Wins = threeOrMore.player1Wins;
            double player2Wins = threeOrMore.player2Wins;
            double CPUWins = threeOrMore.CPUWins;
            double gamesPlayed = player2Wins + player1Wins + CPUWins;
            // checks if games played is 0 so it doesnt return as null
            if (gamesPlayed == 0)
            {
                return 0;

            }
            //returns the win loss ratio equation and rounds it to 2 d.p
            double winLossRatio = Math.Round(player1Wins / gamesPlayed, 2);
            return winLossRatio;
        }
    

        /// <summary>
        /// gets the win loss ratio for the computer in the three or more game 
        /// </summary>
        /// <returns></returns>
        public double CPUWinLossRatioThreeorMore()
        {

            double player1Wins = threeOrMore.player1Wins;
            double player2Wins = threeOrMore.player2Wins;
            double CPUWins = threeOrMore.CPUWins;
            double gamesPlayed = player2Wins + player1Wins + CPUWins;
            // checks if games played is 0 so it doesnt return as null
            if (gamesPlayed == 0) 
            {
                return 0;
            
            }
            //returns the win loss ratio equation and rounds it to 2 d.p
            double winLossRatio = Math.Round(CPUWins / gamesPlayed, 2);
            return winLossRatio;
        }

        /// <summary>
        /// returns player 1s highest score in the sevens out game 
        /// </summary>
        /// <returns></returns>
        public int Player1HighestScoreSevensOut()
        {
            //creates a list of the scores
            List<int> scores = new List<int>();
            //adds the scores to the list 
            scores.Add(sevensOut.player1score);
            //returns the high score
            return scores.Max();

        }

        /// <summary>
        /// returns player 2s highest score in the sevens out game 
        /// </summary>
        /// <returns></returns>
        public int Player2HighestScoreSevensOut()
        {
            //creates a list of the scores
            List<int> scores = new List<int>();
            //adds the scores to the list 
            scores.Add(sevensOut.player2score);
            //returns the high score
            return scores.Max();

        }

        /// <summary>
        /// returns computers highest score in the sevens out game 
        /// </summary>
        /// <returns></returns>
        public int CPUHighestScoreSevensOut()
        {
            //creates a list of the scores
            List<int> scores = new List<int>();
            //adds the scores to the list 
            scores.Add(sevensOut.CPUscore);
            //returns the high score
            return scores.Max();

        }


        /// <summary>
        /// displays the each stat for the game
        /// </summary>
        public void DisplayStats()
        {
            /*
             * this will display the stats for the highest score for all players in sevens out game, and the win loss ratio for all games
             */
            Console.WriteLine("Sevens Out Stats");
            Console.WriteLine($"Player 1s Highest score: {Player1HighestScoreSevensOut()}");
            Console.WriteLine($"Player 2s Highest score: {Player2HighestScoreSevensOut()}");
            Console.WriteLine($"CPUs Highest score: {CPUHighestScoreSevensOut()}");
            Console.WriteLine($"Player 1 W/L ratio: {Player1WinLossRatioSevensOut()}");
            Console.WriteLine($"Player 2 W/L ratio: {Player2WinLossRatioSevensOut()}");
            Console.WriteLine($"CPUs W/L ratio: {CPUWinLossRatioSevensOut()}");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Three Or More Stats");
            Console.WriteLine($"Player 1 W/L ratio: {Player1WinLossRatioThreeOrMore()}");
            Console.WriteLine($"Player 2 W/L ratio: {Player2WinLossRatioThreeOrMore()}");
            Console.WriteLine($"Computers W/L ratio: {CPUWinLossRatioThreeorMore()}");
        }
    }
}
