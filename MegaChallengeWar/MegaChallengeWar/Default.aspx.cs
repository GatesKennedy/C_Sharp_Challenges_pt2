using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Random rando = new Random();
        Deck deckAccess = new Deck();
        List<Card> player1Deck = new List<Card>();
        List<Card> player2Deck = new List<Card>();
        List<Card> BountyDeck = new List<Card>();

        protected void PlayButton_Click(object sender, EventArgs e)
        {
            FreshStart();
            ShuffleDeck(rando);
            List<Card> deckShuffled = (List<Card>)ViewState["Deck"];
            PlayGame(deckShuffled);
        }

        protected void RecordButton_Click(object sender, EventArgs e)
        {
            ResultLabel.Visible = true;
        }

        private void ShuffleDeck(Random rando)
        {
            List<Card> deck = (List<Card>)ViewState["Deck"];
            List<Card> deckShuffled = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                while (deck.Count > 0)
                {
                    int tempRando = rando.Next(0, deck.Count);
                    deckShuffled.Add(deck.ElementAt(tempRando));
                    deck.RemoveAt(tempRando);
                }
            }
            ViewState["Deck"] = deckShuffled;
        }

        private void PlayGame(List<Card> _deckShuffled)
        {
            int roundCount = 1;
            DealPlayers(_deckShuffled);
            if (player1Deck.Count > 0 && player2Deck.Count > 0)
            {
                while (player1Deck.Count<40 && player2Deck.Count<40)
                {
                    DrawTurn(player1Deck.ElementAt(0),player2Deck.ElementAt(0), out bool warLogic);
                    if (warLogic) War();
                    roundCount++;
                }
            }
            MilkShake.Visible = true;
            if (player1Deck.Count > player2Deck.Count) ResultOfGame.Text = String.Format("{0} rounds later...<br /><h2>Player 1 Drank Your Milkshake</h2>",roundCount);
            else ResultOfGame.Text = String.Format("{0} rounds later...<br /><h2>Player 2 Drank Your Milkshake</h2>", roundCount);
        }

        private void DealPlayers (List<Card> _deckShuffled)
        {
            List<Card> p1Deck = new List<Card>();
            List<Card> p2Deck = new List<Card>();
            bool dealLogic = false;
            foreach (Card card in _deckShuffled)
            {
                if (dealLogic) p1Deck.Add(card);
                else p2Deck.Add(card);
                dealLogic = !dealLogic;
            }
            player1Deck = p1Deck;
            player2Deck = p2Deck;
        }

        private bool DrawTurn(Card card1, Card card2, out bool warLogic)
        {
            card1.GetCardValue(deckAccess, out int card1Value);
            card2.GetCardValue(deckAccess, out int card2Value);
            ResultLabel.Text += "Battle Cards:<br />" + card1.BuildCardTitle() + " VS " + card2.BuildCardTitle() + "<br />";
            EvaluateTurn(card1Value, card2Value, out warLogic);
            return warLogic;
        }

        private bool EvaluateTurn(int _card1Value, int _card2Value, out bool warLogic)
        {
            warLogic = false;
            if (_card1Value > _card2Value) P1Spoils();
            else if (_card1Value < _card2Value) P2Spoils();
            else if (_card1Value == _card2Value) warLogic = true;
            return warLogic;
        }

        private void P1Spoils()
        {
            ResultLabel.Text += "Player1 wins the round.<br /><br />";
            BattleSpoils(player1Deck, player2Deck);
            WarSpoils(player1Deck);
            BountyDeck.Clear();
        }

        private void P2Spoils()
        {
            ResultLabel.Text += "Player2 wins the round.<br /><br />";
            BattleSpoils(player2Deck, player1Deck);
            WarSpoils(player2Deck);
            BountyDeck.Clear();
        }

        private void BattleSpoils(List<Card> _winnersDeck, List<Card> _losersDeck)
        {
            _winnersDeck.Add(_winnersDeck.ElementAt(0));
            _winnersDeck.Add(_losersDeck.ElementAt(0));
            _winnersDeck.RemoveAt(0);
            _losersDeck.RemoveAt(0);
        }

        private void WarSpoils(List<Card> _winnersDeck)
        {
            foreach (Card card in BountyDeck) _winnersDeck.Add(card);
        }

        private void War()
        {
            ResultLabel.Text += String.Format("<br /><h3>WAR!</h3><br />Player1: {0} cards || Player2: {1} cards<br />", player1Deck.Count, player2Deck.Count);
            if (player1Deck.Count>2 && player2Deck.Count>2)
            for (int i = 0; i < 3; i++)
            {
                BountyDeck.Add(player1Deck.ElementAt(i));
                BountyDeck.Add(player2Deck.ElementAt(i));
            }
            for (int i = 0; i < 3; i++)
            {
                player1Deck.RemoveAt(i);
                player2Deck.RemoveAt(i);
            }
            ResultLabel.Text += "Bounty Cards:<br />"+BountyString(BountyDeck)+"<br />";
        }

        private string BountyString(List<Card> _bountyDeck)
        {
            string BountyString = "";
            foreach (Card card in _bountyDeck)
            {
                BountyString += card.BuildCardTitle()+"<br />";
            }
            return BountyString;
        }

        private void FreshStart()
        {
            ResultLabel.Visible = false;
            ResultLabel.Text = "";
            ResultOfGame.Text = "";
            MilkShake.Visible = false;

            Card cards = new Card();
            Deck deck = new Deck();
            List<Card> DeckFresh = new List<Card>();
            deck.BuildFrenchDeck(deck, cards, out DeckFresh);
            ViewState.Add("Deck", DeckFresh);
        }

    }
}
