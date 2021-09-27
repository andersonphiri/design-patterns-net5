using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.PokerApplication
{
    public class Hand
    {
        private readonly List<Card> _cards = new List<Card>();
        private HandRanking _rank = HandRanking.Unknown;

        public void Add(Card c)
        {
            if (_cards.Count == 5)
            {
                throw new InvalidOperationException("Cannot add more than 5 cards to a hand.");
            }

            _cards.Add(c);

            if (_cards.Count == 5)
            {
                //_rank = HandCatagorizerChain.GetRank(this);
            }
        }

        public Card HighCard
        {
            get
            {
                if (_cards.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                return _cards[_cards.Count - 1];
            }
        }

        public IEnumerable<Card> Cards
        {
            get { return _cards; }
        }

        public HandRanking Rank
        {
            get { return _rank; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Card c in _cards)
            {
                sb.AppendFormat("{0} ", c);
            }

            return sb.ToString();
        }

    }
    public enum HandRanking
    {
        Unknown,
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush,
    }

}
