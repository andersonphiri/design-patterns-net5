using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.PokerApplication
{
    class HighCardCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            return HandRanking.HighCard;
        }
    }

    class PairCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasNofKind(2, hand))
            {
                return HandRanking.Pair;
            }

            return Next.Catagorize(hand);
        }
    }

    class TwoPairCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            Dictionary<Value, int> seen = new Dictionary<Value, int>();

            foreach (Card c in hand.Cards)
            {
                if (seen.ContainsKey(c.Value))
                {
                    seen[c.Value]++;
                }
                else
                {
                    seen[c.Value] = 1;
                }
            }

            if (seen.Count == 3)
            {
                int twoSeen = 0;
                int oneSeen = 0;
                foreach (int val in seen.Values)
                {
                    switch (val)
                    {
                        case 1:
                            oneSeen++;
                            break;
                        case 2:
                            twoSeen++;
                            break;
                        default:
                            break;
                    }
                }

                if (oneSeen == 1 && twoSeen == 2)
                {
                    return HandRanking.TwoPair;
                }
            }

            return Next.Catagorize(hand);
        }
    }

    class ThreeOfAKindCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasNofKind(3, hand))
            {
                return HandRanking.ThreeOfAKind;
            }

            return Next.Catagorize(hand);
        }
    }

    class StraightCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasStraight(hand))
            {
                return HandRanking.Straight;
            }

            return Next.Catagorize(hand);
        }
    }

    class FlushCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasFlush(hand))
            {
                return HandRanking.Flush;
            }

            return Next.Catagorize(hand);
        }
    }

    class FullHouseCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            Dictionary<Value, int> seen = new Dictionary<Value, int>();

            foreach (Card c in hand.Cards)
            {
                if (seen.ContainsKey(c.Value))
                {
                    seen[c.Value]++;
                }
                else
                {
                    seen[c.Value] = 1;
                }
            }

            if (seen.Count == 2)
            {
                if (seen.ContainsValue(3) && seen.ContainsValue(2))
                {
                    return HandRanking.FullHouse;
                }
            }

            return Next.Catagorize(hand);
        }
    }

    class FourOfAKindCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasNofKind(4, hand))
            {
                return HandRanking.FourOfAKind;
            }

            return Next.Catagorize(hand);
        }
    }

    class StraightFlushCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasFlush(hand) && HasStraight(hand))
            {
                return HandRanking.StraightFlush;
            }

            return Next.Catagorize(hand);
        }
    }

    class RoyalFlushCatagorizer : HandCategorizer
    {
        public override HandRanking Catagorize(Hand hand)
        {
            if (HasFlush(hand) && HasStraight(hand) && hand.HighCard.Value == Value.Ace)
            {
                return HandRanking.RoyalFlush;
            }

            return Next.Catagorize(hand);
        }
    }
}
