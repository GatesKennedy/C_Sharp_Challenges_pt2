using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    [Serializable]
    public class Deck
    {
        public int TotalCards { get; set; }
        public int TotalSuitMembers { get; set; }
        public Dictionary<int,string> DefinitionRank { get; set; }
        public List<string> DefinitionSuit { get; set; }

        public Deck()
        {
            this.TotalCards = 52;
            this.TotalSuitMembers = 13;
            this.DefinitionRank = new Dictionary<int, string>()
            {
                {2,"2" },
                {3,"3" },
                {4,"4" },
                {5,"5" },
                {6,"6" },
                {7,"7" },
                {8,"8" },
                {9,"9" },
                {10,"10" },
                {11,"Jack" },
                {12,"Queen" },
                {13,"King" },
                {14,"Ace" }
            };
            this.DefinitionSuit = new List<string>()
            {
                {"Hearts" },
                {"Diamonds" },
                {"Clubs" },
                {"Spades" }
            };
        }

        public List<Card> BuildFrenchDeck(Deck deck, Card cards, out List<Card> DeckFresh)
        {
            DeckFresh = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card tempCard = new Card() { rank = deck.DefinitionRank.ElementAt(j).Value, suit = deck.DefinitionSuit.ElementAt(i) };
                    DeckFresh.Add(tempCard);
                }
            }
            return DeckFresh;
        }
    }
}