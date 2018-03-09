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
        protected void PlayButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            Game game = new Game();
            int i = 1;
            while (game.ScorePlayerOne < 300 && game.ScorePlayerTwo < 300)
            {
                game.Round();
                resultLabel.Text += string.Format(".:Round {0}:.<br />Player 1: {1}<br />Player 2: {2}<br /><br />",
                    i, game.ScorePlayerOne, game.ScorePlayerTwo);
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
        public void Round()
        {
            Random rando = new Random();
            Dart dart = new Dart(rando);
            for (int i = 0; i < 3; i++)
            {
                ScorePlayerOne += Score.Throw(dart.Throw());
                ScorePlayerTwo += Score.Throw(dart.Throw());
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