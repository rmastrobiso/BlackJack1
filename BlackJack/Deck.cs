using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Deck
    {
        public List<Card> cards { set; get; }

        public Deck()
        {
            cards = new List<Card>();
            loadDeck();
        }

        public void loadDeck()
        {
            cards.Clear();
            int cardNum = 1;
            for (int i = 1; i < 5; i++) // 4 suits
            {
                for (int j = 1; j < 14; j++) // 13 cards each (total 52 cards)
                {
                    Card currentCard = new Card(); //create a new card

                    //assign suit
                    currentCard.cardNumber = cardNum;
                    if (i == 1)
                        currentCard.suit = "spades";
                    if (i == 2)
                        currentCard.suit = "clubs";
                    if (i == 3)
                        currentCard.suit = "hearts";
                    if (i == 4)
                        currentCard.suit = "diamonds";
                    // assign value
                    currentCard.value = j;
                    // put in deck 
                    cards.Add(currentCard); // adding card to deck
                                            //next card
                    cardNum++;
                }
            }
        }

        public Card FindCard(int cardNum)
        {
            foreach (Card a_card in cards)
            {
                if (a_card.cardNumber == cardNum)
                {
                    return a_card;
                }
            }
            return null;
        }
    }
}
