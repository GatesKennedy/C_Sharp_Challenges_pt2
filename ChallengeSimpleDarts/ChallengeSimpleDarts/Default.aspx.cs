using System;
using Darts;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rando1 = new Random();
            Random rando2 = new Random();
            Game game = new Game();

            while (game.ScorePlayerOne < 300 && game.ScorePlayerTwo < 300)
            {
                int i = 1;
                game.Round(rando1, rando2);
                resultLabel.Text += string.Format(".:Round {0}:.<br />Player 1: {1}<br />Player 2: {2}<br /><br />",
                    i,game.ScorePlayerOne,game.ScorePlayerTwo);
                i++;
            }
            if (game.ScorePlayerOne > game.ScorePlayerTwo) resultLabel.Text += "Player 1 Wins";
            else resultLabel.Text += "Player 2 Wins";
        }
    }

    public class Game
    {
        public int ScorePlayerOne { get; set; }
        public int ScorePlayerTwo { get; set; }

        public Game()
        {
            this.ScorePlayerOne = 0;
            this.ScorePlayerTwo = 0;
        }

        public void Round(Random rando1, Random rando2)
        {
            for (int i = 0; i < 3; i++)
            {
                ScorePlayerOne += Score.Throw(Dart.Throw(rando1.Next(20), rando2.Next(20)));
                ScorePlayerTwo += Score.Throw(Dart.Throw(rando1.Next(20), rando2.Next(20)));
            }
        }
    }

    public static class Score
    {
        public static int Throw(int[] regionAndRing)
        {
            int points = 0;
            if (regionAndRing[0] == 0) points = 25 * regionAndRing[1];
            else points = regionAndRing[0] * regionAndRing[1];
            return points;
        }
    }
}