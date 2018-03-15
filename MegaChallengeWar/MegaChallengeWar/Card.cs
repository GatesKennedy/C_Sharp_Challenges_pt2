using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    [Serializable]
    public class Card
    {
        public string rank { get; set; }
        public string suit { get; set; }


        public int GetCardValue(Deck _deck, out int cardValue)
        {
            cardValue = 0;
            foreach (var rankDefinition in _deck.DefinitionRank)
            {
                if (this.rank == rankDefinition.Value) cardValue = rankDefinition.Key;
            }
            return cardValue;
        }

        public string BuildCardTitle()
        {
            string cardTitle = this.rank + " of " + this.suit;
            return cardTitle;
        }

    }


}