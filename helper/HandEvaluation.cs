using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fivecard.model;

namespace fivecard.helper
{
    public static class HandEvaluation
    {
        public enum HandStrength
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        public static HandStrength EvaluateHand(List<Card> hand)
        {

            hand.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank));

            if (IsRoyalFlush(hand))
                return HandStrength.RoyalFlush;

            if (IsStraightFlush(hand))
                return HandStrength.StraightFlush;

            if (IsFourOfAKind(hand))
                return HandStrength.FourOfAKind;

            if (IsFullHouse(hand))
                return HandStrength.FullHouse;

            if (IsFlush(hand))
                return HandStrength.Flush;

            if (IsStraight(hand))
                return HandStrength.Straight;

            if (IsThreeOfAKind(hand))
                return HandStrength.ThreeOfAKind;
            if (IsTwoPair(hand))
                return HandStrength.TwoPair;

            if (IsOnePair(hand))
                return HandStrength.OnePair;

            return HandStrength.HighCard;
        }

        public static bool IsRoyalFlush(List<Card> hand)
        {
            return IsStraightFlush(hand) && GetValue(hand.Last().Rank) == 14;
        }

        public static bool IsStraightFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        public static bool IsFourOfAKind(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Any(group => group.Count() == 4);
        }

        public static bool IsFullHouse(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Any(group => group.Count() == 3) &&
                   hand.GroupBy(card => card.Rank).Any(group => group.Count() == 2);
        }

        public static bool IsFlush(List<Card> hand)
        {
            return hand.Select(card => card.Suit).Distinct().Count() == 1;
        }

        public static bool IsStraight(List<Card> hand)
        {
            for (int i = 0; i < hand.Count - 1; i++)
            {
                if (GetValue(hand[i + 1].Rank) - GetValue(hand[i].Rank) != 1)
                    return false;
            }
            return true;
        }

        public static bool IsThreeOfAKind(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Any(group => group.Count() == 3);
        }

        public static bool IsTwoPair(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Count(group => group.Count() == 2) == 2;
        }

        public static bool IsOnePair(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Any(group => group.Count() == 2);
        }
        static int GetValue(string rank)
        {
            switch (rank)
            {
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "10": return 10;
                case "Jack": return 11;
                case "Queen": return 12;
                case "King": return 13;
                case "Ace": return 14;
                default: return 0;
            }
        }
    }


}
