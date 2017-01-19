using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> cards { set; get; }
        public int cardsInHand { set; get; }
        public int score { set; get; }
        public string result { set; get; }

        public Hand(int numCards) //constructor creates list and places empty cards in it
        {
            cardsInHand = numCards; //number of cards in a hand

            cards = new List<Card>(); // list to hold cards
            Card emptyCard = new Card(); // blank card

            for (int i = 0; i < numCards; i++)
            {
                cards.Add(emptyCard); // adding blank cards to list
            }
        }

        public void AddCard(Deck currentDeck, int number_cards_in_a_hand) // picks random card from deck and puts it in one of the blank card spots created 
        {
            bool added = false;
            int pickedCard = 0;

            if (currentDeck.cards.Count <= 2)
            {
                currentDeck.loadDeck();
            }
            pickedCard = RandomNumber.NumberBetween(2, currentDeck.cards.Count - 1);
            Card currentCard = currentDeck.cards.ElementAt(pickedCard);
            Card toBeReplaced = new Card();

            while (!added)
            {
                foreach (Card temp in cards)
                {
                    if (temp.suit == "") //place to put new card in
                        toBeReplaced = temp;
                }
                if (toBeReplaced != null)
                {
                    cards.Remove(toBeReplaced);
                    cards.Add(currentCard);
                    added = true;
                    currentDeck.cards.Remove(currentCard);
                }
            }
        }

        public void DealCards(Deck currentDeck, int numCards)
        {
            numCards = cards.Count;
            for (int i = 0; i < numCards; i++)
            {
                AddCard(currentDeck, numCards);
            }
        }
         
        public void EvaluateHand()
        {
            score = 0;

            foreach (Card temp in cards)
            {
                if (temp.value < 10)
                    score = score + temp.value;
                else
                    score = score + 10; // assigning face cards a value of 10
            }

            // adjust for aces
            foreach (Card temp in cards)
            {
                if (temp.value == 1 && score + 10 <= 21)
                    score = score + 10; // We haven't gone bust yet so Ace is scored at 11
            }
            if (score > 21)
            {
                result = "Sorry you bust";
            }
            else
            {
                result = "You have " + score;
            }
        }
    }
}
