using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.PokerApplication
{
    public class Deck
    {
        private Queue<Card> Cards { get; set; }
        public Deck()
        {
            Cards = new Queue<Card>();
            CreateDeck();
            
        }
        private void CreateDeck()
        {
            const int _lowValue = (int)Value.Two;
            const int _highValue = (int)Value.Ace;

            const int _lowSuit = (int)Suit.Diamond;
            const int _highSuit = (int)Suit.Spade;

            for (int i = _lowValue; i <= _highValue; i++)
            {
                for (int j = _lowSuit; j <= _highSuit; j++)
                    Cards.Enqueue(new((Suit)j, (Value)i));
            }
        }
        public void Shuffle(int times = 7)
        {
            for (int i = 0; i < times; i++)
            {
                Cards = new Queue<Card>(Cards.OrderBy(a => Guid.NewGuid()));
            }
            
        }
        public Card Deal() => Cards.Dequeue();
    }
}
